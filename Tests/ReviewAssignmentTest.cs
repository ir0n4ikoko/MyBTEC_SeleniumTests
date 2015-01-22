using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ReviewAssignmentTest : TestBase
    {
        [Test]
        [Category("WithCourse")]
        public void AssignmentsSentToIvEmailChecking()
        {
            var course = new CreateCourseContext();
            var withIv = new CreateAssignmentContext {Status = UI.WithIV, CourseTitle = course.Title};

            string subjSentToIv = UI.EmailSubjectAssignmentSentToIv;
            string msgSentToIv = UI.EmailBodyAssignmentSentToIv.F(
                UiConst.FirstName.Iv,
                UiConst.LastName.Iv,
                withIv.Title,
                UiConst.FirstName.CourseLeader,
                UiConst.LastName.CourseLeader,
                withIv.Subject,
                withIv.CourseTitle,
                UI.DoNotReplyMessage);

            string subjRejected = UI.EmailSubjectAssignmentRejected.F(withIv.Title);
            string msgRejected = UI.EmailBodyAssignmentRejected.F(
                UiConst.FirstName.CourseLeader,
                UiConst.LastName.CourseLeader,
                withIv.Title,
                UiConst.FirstName.Iv,
                UiConst.LastName.Iv,
                UI.DoNotReplyMessage);

            string subjApprovedd = UI.EmailSubjectAssignmentApproved;
            string msgApproved = UI.EmailBodyAssignmentApproved.F(
                UiConst.FirstName.CourseLeader,
                UiConst.LastName.CourseLeader,
                withIv.Title,
                withIv.Subject,
                withIv.CourseTitle,
                UI.DoNotReplyMessage);

            Start
                .RemoveInboxMessages(UiConst.Email.Assessor)
                .RemoveInboxMessages(UiConst.Email.Iv)
                .LoginWithCL()
                .CreateConfirmedCourse(course).Flow
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .AssertEmailReceived(UiConst.Email.Iv, subjSentToIv, msgSentToIv)
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend()
                .ClickLogout()
                .LoginWithCL()
                .GoToAssignments()
                .AssertEmailReceived(UiConst.Email.CourseLeader, subjRejected, msgRejected)
                .SelectActionSendToIv(withIv.ID)
                .SelectSendToIv(withIv.IV)
                .ClickSendToIv().Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .AssertEmailReceived(UiConst.Email.Iv, subjSentToIv, msgSentToIv)
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .CheckAllAcceptanceCriterias()
                .SaveAndSend()
                .ClickLogout()
                .LoginWithCL()
                .GoToAssignments()
                .GoToCentreAssignments()
                .AssertEmailReceived(UiConst.Email.CourseLeader, subjApprovedd, msgApproved);
        }

        [Test]
        public void ReviewAssignment_Approve()
        {
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            Start
                .LoginWithAssessor()
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .SelectAreAssessmentCriteriaAddressedByEachTask()
                .SelectAreActivitiesAppropriate()
                .SelectIsAppropriateScenario()
                .SelectIsAppropriateLanguage()
                .SelectIsAssignmentFitForPurpose()
                .ChooseIsAssignmentApproved()
                .SaveAndSend();
        }

        [Test]
        public void ReviewAssignment_NotApprove()
        {
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            Start
                .LoginWithAssessor()
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend();
        }

        [Test]
        public void ReviewWhenAssignmentCoverageIsNotSelectedTheFormIsNotValid()
        {
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            Start
                .LoginWithCL()
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(withIv.ID)
                .ClickSaveAndSendError()
                .AssertAssignmentCoverageIsNotValid();
        }

        [Test]
        public void ReviewWhenAssignmentCoverageIsSelectedTheFormIsSubmited()
        {
            var withIv = new CreateAssignmentContext {Status = UI.WithIV};
            Start
                .LoginWithLIV()
                .CreateAssignment(withIv).Flow
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(withIv.ID)
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentNotApproved()
                .SetFeedback(UI.NotApprovedFeedback)
                .SaveAndSend()
                .AssertAssignmentStatusIs(UI.NotApproved, withIv.ID);
        }
    }
}