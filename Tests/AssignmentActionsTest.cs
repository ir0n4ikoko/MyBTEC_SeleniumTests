using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class AssignmentActionsTest : TestBase
    {
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_AssignmentCreatorActions(string login, string password, string name)
        {
            var draft = new CreateAssignmentContext();
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            var notApproved = new CreateAssignmentContext {Status = UI.NotApproved};
            var approved = new CreateAssignmentContext {Status = UI.Approved};
            if (name.Equals(UiConst.FirstName.Iv + " " + UiConst.LastName.Iv))
            {
                withIv.IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv;
                notApproved.IV = withIv.IV;
                notApproved.IvLogin = UiConst.Login.Liv;
                notApproved.IvPassword = UiConst.Password.Liv;
                approved.IV = withIv.IV;
                approved.IvLogin = notApproved.IvLogin;
                approved.IvPassword = notApproved.IvPassword;
            }

            Start
                .LoginWithAndGoToHomePage(login, password)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_WithIv, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, approved.ID)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, approved.ID);
        }

        [Category("WithCourse")]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_AssignmentCreatorActionsWithCourse(string login, string password, string name)
        {
            var course = new CreateCourseContext();
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext {Status = UI.WithIV, CourseTitle = course.Title};
            var notApproved = new CreateAssignmentContext {Status = UI.NotApproved, CourseTitle = course.Title};
            var approved = new CreateAssignmentContext {Status = UI.Approved, CourseTitle = course.Title};
            if (name.Equals(UiConst.FirstName.Iv + " " + UiConst.LastName.Iv))
            {
                withIv.IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv;
                notApproved.IV = withIv.IV;
                notApproved.IvLogin = UiConst.Login.Liv;
                notApproved.IvPassword = UiConst.Password.Liv;
                approved.IV = withIv.IV;
                approved.IvLogin = notApproved.IvLogin;
                approved.IvPassword = notApproved.IvPassword;
            }

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .ViewCourse(course.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_WithIv, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, approved.ID)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, approved.ID)
                .GoToCourses()
                .CheckCourseVisiblity(course.Title)
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertAssignmentCreatorIs(name, draft.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.AssignmentCreator_Draft), draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertAssignmentCreatorIs(name, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_WithIv, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertAssignmentCreatorIs(name, notApproved.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.AssignmentCreator_NotApproved),
                    notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertAssignmentCreatorIs(name, approved.ID)
                .AssertActions(
                    AddRemoveFromCourseAction(
                        AddCreateCoversheetAction(UiConst.AssignmentActions.AssignmentCreator_Approved)), approved.ID);
        }


        [Category("WithCourse")]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        //[TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        public void Assert_AssignmentOtherTeamMembersActions(string login, string password, string name)
        {
            var course = new CreateCourseContext();
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext
            {
                CourseTitle = course.Title,
                Status = UI.WithIV,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv
            };
            var notApproved = new CreateAssignmentContext
            {
                CourseTitle = course.Title,
                Status = UI.NotApproved,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                IvLogin = UiConst.Login.Liv,
                IvPassword = UiConst.Password.Liv
            };
            var approved = new CreateAssignmentContext
            {
                CourseTitle = course.Title,
                Status = UI.Approved,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                IvLogin = UiConst.Login.Liv,
                IvPassword = UiConst.Password.Liv
            };

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .ViewCourse(course.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .GoToAssignments()
                .GoToCentreAssignments()
                .LinkAssignmentToCourse(auth.ID, course.ID)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Authorised, auth.ID)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Authorised, auth.ID)
                .GoToCourses()
                .CheckCourseVisiblity(course.Title)
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(AddCreateCoversheetAction(UiConst.AssignmentActions.Assessor_IV_Approved), approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(AddCreateCoversheetAction(UiConst.AssignmentActions.Assessor_IV_Authorised), auth.ID)
                .ClickLogout();
        }

        protected IEnumerable<string> AddRemoveFromCourseAction(IEnumerable<string> actions)
        {
            var courseActions = new List<string> {UI.RemoveFromCourse};

            courseActions.AddRange(actions);

            return courseActions;
        }

        protected IEnumerable<string> AddCreateCoversheetAction(IEnumerable<string> actions)
        {
            var courseActions = new List<string> {UI.CreateCoversheet};

            courseActions.AddRange(actions);

            return courseActions;
        }

        [Test]
        [Category("WithCourse")]
        public void Assert_AssignmentCLActionsWithCourse()
        {
            var course = new CreateCourseContext();
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext {Status = UI.WithIV, CourseTitle = course.Title};
            var notApproved = new CreateAssignmentContext {Status = UI.NotApproved, CourseTitle = course.Title};
            var approved = new CreateAssignmentContext {Status = UI.Approved, CourseTitle = course.Title};

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .GoToAssignments()
                .GoToCentreAssignments()
                .LinkAssignmentToCourse(auth.ID, course.ID)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithCL()
                .GoToAssignments()
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Authorised, auth.ID)
                .GoToCourses()
                .GoToCentreCourses()
                .CheckCourseVisiblity(course.Title)
                .ViewCourse(course.ID)
                .CheckCoversheetsTabHidden()
                .CheckFoldersTabHidden()
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Draft), draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_NotApproved), notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(
                    AddCreateCoversheetAction(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Approved)),
                    approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(
                    AddCreateCoversheetAction(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Authorised)),
                    auth.ID)
                .CheckCreateCoversheetForbiddenNotInTeam(auth.ID)
                .CheckCreateCoversheetForbiddenNotInTeam(approved.ID)
                .CheckRemoveFromCourseForbiddenNotInTeam(draft.ID)
                .CheckRemoveFromCourseForbiddenNotInTeam(auth.ID)
                .CheckRemoveFromCourseForbiddenNotInTeam(approved.ID)
                .CheckRemoveFromCourseForbiddenNotInTeam(notApproved.ID)
                .ClickLogout();
        }

        [Test]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_AssignmentLIVsActions(string login, string password, string name)
        {
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext();
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            var notApproved = new CreateAssignmentContext {Status = UI.NotApproved};
            var approved = new CreateAssignmentContext {Status = UI.Approved};

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithCL()
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithCL()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Authorised, auth.ID)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Authorised, auth.ID);
        }

        [Test]
        [Category("WithCourse")]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_AssignmentLIVsActionsWithCourse(string login, string password, string name)
        {
            var course = new CreateCourseContext();
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext {Status = UI.WithIV, CourseTitle = course.Title};
            var notApproved = new CreateAssignmentContext {Status = UI.NotApproved, CourseTitle = course.Title};
            var approved = new CreateAssignmentContext {Status = UI.Approved, CourseTitle = course.Title};

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithCL()
                .CreateConfirmedCourse(course).Flow
                .GoToAssignments()
                .GoToCentreAssignments()
                .LinkAssignmentToCourse(auth.ID, course.ID)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithCL()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Authorised, auth.ID)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_Authorised, auth.ID)
                .GoToCourses()
                .CheckCourseVisiblity(course.Title)
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Draft), draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.CL_LIV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_NotApproved), notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(
                    AddCreateCoversheetAction(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Approved)),
                    approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(
                    AddCreateCoversheetAction(AddRemoveFromCourseAction(UiConst.AssignmentActions.CL_LIV_Authorised)),
                    auth.ID)
                .ClickLogout();
        }

        [Test]
        [Category("WithCourse")]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        public void Assert_AssignmentNotTeamMembersActions(string login, string password, string name)
        {
            var course = new CreateCourseContext();
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext
            {
                Status = UI.WithIV,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                CourseTitle = course.Title
            };
            var notApproved = new CreateAssignmentContext
            {
                Status = UI.NotApproved,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                IvLogin = UiConst.Login.Liv,
                IvPassword = UiConst.Password.Liv,
                CourseTitle = course.Title
            };
            var approved = new CreateAssignmentContext
            {
                Status = UI.Approved,
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                IvLogin = UiConst.Login.Liv,
                IvPassword = UiConst.Password.Liv,
                CourseTitle = course.Title
            };

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .GoToAssignments()
                .LinkAssignmentToCourse(auth.ID, course.ID)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID, false)
                .AssertAssignmentDisplayed(withIv.ID, false)
                .AssertAssignmentDisplayed(notApproved.ID, false)
                .AssertAssignmentDisplayed(approved.ID, false)
                .AssertAssignmentDisplayed(auth.ID, false)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(approved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Approved, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Authorised, auth.ID)
                .GoToCourses()
                .GoToCentreCourses()
                .ViewCourse(course.ID)
                .CheckCoversheetsTabHidden()
                .CheckFoldersTabHidden()
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_Draft, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_WithIV, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.Assessor_IV_NotApproved, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(AddCreateCoversheetAction(UiConst.AssignmentActions.Assessor_IV_Approved), approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(AddCreateCoversheetAction(UiConst.AssignmentActions.Assessor_IV_Authorised), auth.ID)
                .CheckCreateCoversheetForbiddenNotInTeam(auth.ID)
                .CheckCreateCoversheetForbiddenNotInTeam(approved.ID)
                .ClickLogout();
        }

        [Test]
        [Category("WithCourse")]
        public void Assert_AssignmentTeacherActions()
        {
            var course = new CreateCourseContext();
            var auth = new CreateAssignmentContext {Status = UI.Authorised};
            var draft = new CreateAssignmentContext {CourseTitle = course.Title};
            var withIv = new CreateAssignmentContext {CourseTitle = course.Title, Status = UI.WithIV};
            var notApproved = new CreateAssignmentContext {CourseTitle = course.Title, Status = UI.NotApproved};
            var approved = new CreateAssignmentContext {CourseTitle = course.Title, Status = UI.Approved};

            Start
                .LoginWithDDM()
                .CreateAssignment(auth).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .ViewCourse(course.ID)
                .ViewCourseTeam()
                .SelectTeamMember(UiConst.FirstName.Teacher + " " + UiConst.LastName.Teacher)
                .AddToTeam()
                .SaveTeam()
                .GoToAssignments()
                .GoToCentreAssignments()
                .LinkAssignmentToCourse(auth.ID, course.ID)
                .CreateAssignment(draft).Flow
                .CreateAssignment(withIv).Flow
                .CreateAssignment(notApproved).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateAssignment(approved).Flow
                .ClickLogout()
                .LoginWithTeacher()
                .GoToAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, auth.ID)
                .GoToCourses()
                .CheckCourseVisiblity(course.Title)
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(draft.ID)
                .AssertAssignmentStatusIs(UI.Draft, draft.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, draft.ID)
                .AssertAssignmentDisplayed(withIv.ID)
                .AssertAssignmentStatusIs(UI.WithIV, withIv.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, withIv.ID)
                .AssertAssignmentDisplayed(notApproved.ID)
                .AssertAssignmentStatusIs(UI.NotApproved, notApproved.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, notApproved.ID)
                .AssertAssignmentDisplayed(approved.ID)
                .AssertAssignmentStatusIs(UI.Approved, approved.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, approved.ID)
                .AssertAssignmentDisplayed(auth.ID)
                .AssertAssignmentStatusIs(UI.Authorised, auth.ID)
                .AssertActions(UiConst.AssignmentActions.TeacherActions, auth.ID)
                .ClickLogout();
        }

        [Test]
        public void Assert_AssignmentsSentToIvActions()
        {
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};

            Start
                .LoginWithCL()
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_WithIV, withIv.ID)
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend()
                .AssertActions(UiConst.AssignmentActions.Iv_NotApproved, withIv.ID)
                .ClickLogout()
                .LoginWithCL()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_NotApproved, withIv.ID)
                .SelectActionSendToIv(withIv.ID)
                .SelectSendToIv(withIv.IV)
                .ClickSendToIv().Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_WithIV, withIv.ID)
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .CheckAllAcceptanceCriterias()
                .SaveAndSend()
                .AssertActions(UiConst.AssignmentActions.Iv_Approved, withIv.ID)
                .GoToCentreAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_Approved, withIv.ID)
                .ClickLogout()
                .LoginWithCL()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, withIv.ID)
                .GoToCentreAssignments()
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Approved, withIv.ID);
        }

        [Test]
        [Category("WithCourse")]
        public void Assert_AssignmentsSentToIvActionsWithCourse()
        {
            var course = new CreateCourseContext();
            var withIv = new CreateAssignmentContext {Status = UI.WithIV, CourseTitle = course.Title};

            Start
                .LoginWithCL()
                .CreateConfirmedCourse(course).Flow
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToCourses()
                .GoToCentreCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_WithIV, withIv.ID)
                .GoToAssignments()
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend()
                .GoToCourses()
                .GoToCentreCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_NotApproved, withIv.ID)
                .ClickLogout()
                .LoginWithCL()
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(AddRemoveFromCourseAction(UiConst.AssignmentActions.AssignmentCreator_NotApproved),
                    withIv.ID)
                .GoToAssignments()
                .SelectActionSendToIv(withIv.ID)
                .SelectSendToIv(withIv.IV)
                .ClickSendToIv().Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToCourses()
                .GoToCentreCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(UiConst.AssignmentActions.Iv_WithIV, withIv.ID)
                .GoToAssignments()
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .CheckAllAcceptanceCriterias()
                .SaveAndSend()
                .GoToCourses()
                .GoToCentreCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(AddCreateCoversheetAction(UiConst.AssignmentActions.Iv_Approved), withIv.ID)
                .ClickLogout()
                .LoginWithCL()
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertActions(
                    AddRemoveFromCourseAction(
                        AddCreateCoversheetAction(UiConst.AssignmentActions.AssignmentCreator_Approved)), withIv.ID);
        }

        [Test,Ignore]
        [Category("WithCourse")]
        public void Assert_DeleteRestoreAssignmentActions()
        {
            var course = new CreateCourseContext();
            var assignment = new CreateAssignmentContext
            {
                CourseTitle = course.Title
            };
            Start
                //QN creates confirmed course and add Assessor in team 
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .ViewCourse(course.ID)
                .ViewCourseTeam()
                .SelectTeamMember(UiConst.FirstName.Assessor + " " + UiConst.LastName.Assessor)
                .AddToTeam()
                .SaveTeam()
                .ClickLogout()
                //Assessor creates assignmentId with course
                .LoginWithAssessor()
                .CreateAssignment(assignment).Flow
                    //Assessor deletes created assignmentId from Course view wizard - Assignments tab
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .SelectAssignmentAction(UI.Delete, assignment.ID)
                .ConfirmRemoving(false)
                .SelectAssignmentAction(UI.Delete, assignment.ID)
                .ConfirmRemoving()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Deleted, assignment.ID)
                .AssertAssignmentStatusIs(UI.Deleted, assignment.ID)
                .ClickLogout()
                    //Check assignmentId disappeared from Course view wizard for QN - course creator
                .LoginWithQN()
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .ClickLogout()
                    //Assessor restores assignmentId and send it to IV
                .LoginWithAssessor()
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .GoToAssignments()
                .SelectAction(UI.Restore, assignment.ID)
                .ConfirmRestore(false)
                .SelectAction(UI.Restore, assignment.ID)
                .ConfirmRestore()
                .AssertInfoMessage(UI.AssignmentRestoredMsg)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Draft, assignment.ID)
                .Edit(assignment.ID)
                .SaveAndContinue() //add data check
                .SaveAndContinue()
                .SaveAndContinue()
                .ClickSendToIv()
                .SelectSendToIv()
                .SaveAndSendToIVnow()
                .ClickLogout()
                //IV  - Not approved
                .LoginWithIV()
                .GoToAssignments()
                .Review(assignment.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend()
                .ClickLogout()
                      //LIV deletes assignmentId
                .LoginWithLIV()
                .GoToAssignments()
                .SelectAction(UI.Delete, assignment.ID)
                .ConfirmRemoving()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .ClickLogout()
                      //Assessor restores assignmentId, should be in Draft status and send it to IV
                .LoginWithAssessor()
                .GoToAssignments()
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Deleted, assignment.ID)
                .SelectAction(UI.Restore, assignment.ID)
                .ConfirmRestore()
                .AssertAssignmentStatusIs(UI.Draft, assignment.ID)
                .AssertActions(UiConst.AssignmentActions.AssignmentCreator_Draft, assignment.ID)
                .SelectActionSendToIv(assignment.ID)
                .SelectSendToIv()
                .ClickSendToIv().Flow
                .ClickLogout()
                      //IV approves assignmentId
                .LoginWithIV()
                .GoToAssignments()
                .Review(assignment.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .CheckAllAcceptanceCriterias()
                .SaveAndSend()
                .ClickLogout()
                      //Assessor deletes assignmentId, it is disappeared from Centre assignments
                .LoginWithAssessor()
                .GoToAssignments()
                .SelectAction(UI.Delete, assignment.ID)
                .ConfirmRemoving()
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .GoToCentreAssignments()
                .AssertAssignmentDisplayed(assignment.ID, false)
                .ClickLogout()
                        //Assessor restores assignmentId, it is appeared for QN
                .LoginWithAssessor()
                .GoToAssignments()
                .SelectAction(UI.Restore, assignment.ID)
                .ConfirmRestore()
                .ClickLogout()
                .LoginWithQN()
                .GoToAssignments()
                .AssertAssignmentDisplayed(assignment.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentDisplayed(assignment.ID);
        }

        [Test]
        public void CloneAssignmentRedNoteTest()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignment(assignment).Flow
                .Clone(assignment.ID)
                .AssertClonePopUpWithNote();
        }

        [Test]
        public void SendToAssignmentCheckingServiceAssignmentsTest()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithIV()
                .CreateAssignment(assignment).Flow
                .SendtoAssignmentCheckingService(assignment.ID)
                .AssertACSPopupTextCorrect(UI.ACSPopupContent.Replace("\\r\\n", "\r\n"))
                .AssertNewACSTabOpenedWithUrl(UI.ACSUrl);
        }

        [Test]
        public void SendToAssignmentCheckingServiceStep4Test()
        {
            Start
                .LoginWithIV()
                .CreateAssignmentTillStep4()
                .SendtoAssignmentCheckingService()
                .AssertACSPopupTextCorrect(UI.ACSPopupContent.Replace("\\r\\n", "\r\n"))
                .AssertNewACSTabOpenedWithUrl(UI.ACSUrl);
        }

        [Test]
        public void SendToIvActionTest()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignment(assignment).Flow
                .SelectActionSendToIv(assignment.ID)
                .ClickSendToIvError()
                .AssertIVRequiredErrorIsPresent()
                .SelectSendToIv()
                .ClickSendToIv().Flow
                .AssertAssignmentStatusIs(UI.WithIV, assignment.ID);
        }

        [Test]
        public void SendToIvStep4ActionTest()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignment(assignment).Flow
                .Edit(assignment.ID)
                .SaveAndContinue()
                .SaveAndContinue()
                .SaveAndContinue()
                .ClickSendToIv()
                .ClickSaveandsendtoIVnowWithError()
                .AssertIVRequiredErrorIsPresent()
                .SelectSendToIv()
                .ClickSaveandsendtoIVlater().Flow
                .AssertAssignmentStatusIs(UI.Draft, assignment.ID)
                .Edit(assignment.ID)
                .SaveAndContinue()
                .SaveAndContinue()
                .SaveAndContinue()
                .ClickSendToIv()
                .SaveAndSendToIVnow()
                .AssertAssignmentStatusIs(UI.WithIV, assignment.ID);
        }
    }
}