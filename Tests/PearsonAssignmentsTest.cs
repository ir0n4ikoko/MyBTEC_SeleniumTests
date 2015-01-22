using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class PearsonAssignmentsTest : TestBase
    {
        [Test]
        public void IdentifyPearsonAssignmentByNonPearsonUser()
        {
            var assignment = new CreateAssignmentContext {Status = UI.Authorised};

            Start
                .LoginWithDDM()
                .CreateAssignment(assignment).Flow
                .ClickLogout()
                .LoginWithLIV()
                .GoToAssignments()
                .AssertCreatorIs(UI.Pearson, assignment.ID)
                .GoToCentreAssignments()
                .AssertCreatorIs(UI.Pearson, assignment.ID);
        }

        [Test]
        [Category("WithCourse")]
        public void IdentifyPearsonAssignmentByNonPearsonUserWithCourse()
        {
            var course = new CreateCourseContext();
            var assignment = new CreateAssignmentContext {Status = UI.Authorised};

            Start
                .LoginWithDDM()
                .CreateAssignment(assignment).Flow
                .ClickLogout()
                .LoginWithCL()
                .CreateConfirmedCourse(course).Flow
                .GoToAssignments()
                .GoToCentreAssignments()
                .LinkAssignmentToCourse(assignment.ID, course.ID)
                .AssertCreatorIs(UI.Pearson, assignment.ID)
                .GoToMyAssignments()
                .AssertCreatorIs(UI.Pearson, assignment.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentCreatorIs(UI.Pearson, assignment.ID);
        }

        [Test]
        public void IdentifyPearsonAssignmentByPearsonUser()
        {
            var assignment = new CreateAssignmentContext {Status = UI.Authorised};

            Start
                .LoginWithDDM()
                .CreateAssignment(assignment).Flow
                .AssertCreatorIs(UiConst.FirstName.Ddm + " " + UiConst.LastName.Ddm, assignment.ID)
                .ClickLogout()
                .LoginWithEditor()
                .GoToAssignments()
                .AssertCreatorIs(UiConst.FirstName.Ddm + " " + UiConst.LastName.Ddm, assignment.ID);
        }

        [Test]
        public void PearsonAssignmentActions()
        {
            var editing = new CreateAssignmentContext {Status = UI.Editing};
            var ddmReview = new CreateAssignmentContext {Status = UI.DDMReview};
            var extTest = new CreateAssignmentContext {Status = UI.ExternalTest};
            var auth = new CreateAssignmentContext {Status = UI.Authorised};

            Start
                .LoginWithEditor()
                .CreateAssignment(editing).Flow
                .AssertActions(UiConst.AssignmentActions.PearsonEditor_Editing, editing.ID)
                .CreateAssignment(ddmReview).Flow
                .AssertActions(UiConst.AssignmentActions.PearsonEditor_DDMreview, ddmReview.ID)
                .ClickLogout()
                .LoginWithDDM()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.PearsonDDM_Editing, editing.ID)
                .AssertActions(UiConst.AssignmentActions.PearsonDDM_DDMreview, ddmReview.ID)
                .CreateAssignment(extTest).Flow
                .AssertActions(UiConst.AssignmentActions.PearsonDDM_ExternalTesting, extTest.ID)
                .CreateAssignment(auth).Flow
                .AssertActions(UiConst.AssignmentActions.PearsonDDM_Authorised, auth.ID)
                .ClickLogout()
                .LoginWithEditor()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.PearsonEditor_ExternalTesting, extTest.ID)
                .AssertActions(UiConst.AssignmentActions.PearsonEditor_Authorised, auth.ID)
                .ClickLogout()
                .LoginWithTester()
                .GoToAssignments()
                .AssertAssignmentDisplayed(editing.ID, false)
                .AssertAssignmentDisplayed(ddmReview.ID, false)
                .AssertAssignmentDisplayed(auth.ID, false)
                .AssertAssignmentDisplayed(extTest.ID)
                .AssertActions(UiConst.AssignmentActions.PearsonTester_ExternalTesting, extTest.ID);
        }

        [Test, Ignore]
        public void PearsonAssignmentCreationWithValidation()
        {
            var assignment = new CreateAssignmentContext {Status = UI.Editing};
            Start
                .LoginWithDDM()
                .PressCreateAssignment()
                .CheckValidation(true)
                .SetAssignmentTitle(assignment.Title)
                .SetAssignmentAuthor(assignment.Author, assignment.IsPearson)
                .CompleteAllDropDowns(assignment)
                .SaveAndContinueWithError()
                .CheckNoUnitsValidation()
                .SelectUnits(assignment)
                .SaveAndContinue()
                .SaveAndContinueWithError();
        }

        [Test]
        public void PearsonAssignmentStatuses()
        {
            var editing = new CreateAssignmentContext {Status = UI.Editing};
            var ddmReview = new CreateAssignmentContext {Status = UI.DDMReview};
            var extTest = new CreateAssignmentContext {Status = UI.ExternalTest};
            var auth = new CreateAssignmentContext {Status = UI.Authorised};

            Start
                .LoginWithDDM()
                .CreateAssignment(editing).Flow
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.DDM_Editing, editing.ID)
                .CreateAssignment(ddmReview).Flow
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.DDM_DDMReview, ddmReview.ID)
                .CreateAssignment(extTest).Flow
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.DDM_ExternalTest, extTest.ID)
                .CreateAssignment(auth).Flow
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.DDM_Authorised, auth.ID)
                .ClickLogout()
                .LoginWithEditor()
                .GoToAssignments()
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.Editor_Editing, editing.ID)
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.Editor_DDMReview, ddmReview.ID)
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.Editor_ExternalTest, extTest.ID)
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.Editor_Authorised, auth.ID)
                .ClickLogout()
                .LoginWithTester()
                .GoToAssignments()
                .AssertPearsonStatusesDropdown(UiConst.AssignmentStatus.Tester_ExternalTest, extTest.ID);
        }
    }
}