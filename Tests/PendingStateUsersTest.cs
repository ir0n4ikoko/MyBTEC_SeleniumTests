using System;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
    using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
    {
    internal class PendingStateUsersTest : TestBase
    {
        [Test,Ignore]
        [Category("WithCourse")]
        public void PendingStateUserHasPriveleges()
        {
            #region Variables

            string subjectLiv = UiConst.Subject.Application_of_Science;
            string subjectCl = UiConst.Subject.AppliedScience;
            string subjectIv = UiConst.Subject.Art_and_Design;
            string subjectAssessor = UiConst.Subject.Business;
            string subjectTeacher = UiConst.Subject.Engineering;
            string courseNameQN = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));

            var courseContext = new CreateCourseContext();
            var assignmentContext = new CreateAssignmentContext();

            #endregion

            #region ClaimRoles

            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles7, UiConst.Password.UserNoRoles7)
                .ConfirmEulaRedirectClaimRoles()
                .SelectRoleForSubject(0, subjectLiv, UiConst.Role.Liv)
                .SelectRoleForSubject(1, subjectCl, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(2, subjectIv, UiConst.Role.Iv)
                .SelectRoleForSubject(3, subjectAssessor, UiConst.Role.Assessor)
                .SelectRoleForSubject(4, subjectTeacher, UiConst.Role.Teacher)
                .ClaimRoles()
                #endregion

                #region CourseCreationAndCheck

                .CreateCourseTillStep3(courseContext)
                .AssertRedWarningNoteExists()
                .AssertRedWarningNoteTextCorrect(UI.NotePendingUserCourseStep3)
                .AssertConfirmCourseHidden()
                .SaveAsDraft()
                .DraftPopupClickYes()
                .CheckCourseActionsByName(courseContext.Title, UiConst.CourseActions.PendingCourseCreator)
                #endregion

                #region AssignmentCreationAndCheck

                .CreateAssignmentTillStep4(assignmentContext)
                .AssertRedWarningNoteExists()
                .AssertRedWarningNoteTextCorrect(UI.NotePendingUserAssignmentStep4)
                .AssertSendToAcsButtonExists(false)
                .AssertSendToIvButtonExists(false)
                .ClickFinish()
                .CheckActionList(assignmentContext.Title, UiConst.AssignmentActions.PendingAssignmentCreator)

                #endregion

                #region CourseTeamCheck

                .ClickLogout()
                .LoginWithQN()
                .GoToCourses()
                .CreateCourseAndConfirmIt(new CreateCourseContext(courseNameQN))
                .ClickOnThisCourse(courseNameQN)
                .ViewCourseTeam()
                .CheckTeamMembers(UiConst.FirstName.UserNoRoles7 + " " + UiConst.LastName.UserNoRoles7);

            #endregion
        }

        [Test, Ignore]
        [Category("WithCourse")]
        public void PendingUserHidingSomeAssignmentsFunctionalityTest()
        {
            string userName = UiConst.FirstName.UserNoRoles5 + " " + UiConst.LastName.UserNoRoles5;

            string subject = UiConst.Subject.AppliedScience;
            
            string teacher = UiConst.Role.Teacher;
            string assessor = UiConst.Role.Assessor;
            string IV = UiConst.Role.Iv;
            string CL = UiConst.Role.CourseLeader;
            string LIV = UiConst.Role.Liv;

            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles5, UiConst.Password.UserNoRoles5)
                .ConfirmEulaRedirectClaimRoles()
                .SelectRoleForSubject(0, subject, teacher)
                .ClaimRoles()
                .GoToAssignments()
                .CheckCreateAssignmentButton(false)
                .ClickLogout()
                .LoginWithQN()
                .GoToUserRoleApproval()
                .Approve(userName, subject, teacher)
                .Confirm()
                .GoToCourses()
                .CreateConfirmedCourse()
                .Next((courseFlow, courseId) => courseFlow
                    .ViewCourse(courseId)
                    .ViewCourseTeam()
                    .SelectTeamMember(userName)
                    .AddToTeam()
                    .SaveTeam()
                    .ClickLogout()
                    .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles5,
                                                UiConst.Password.UserNoRoles5)
                #region CheckForAssessor

                    .GoToClaimRoles()
                    .SelectRoleForSubject(0, subject, assessor)
                    .ClaimRoles()
                    .CreateAssignmentTillStep4()
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))

                    .CreateAssignmentWithCourseIdTillStep4(courseId)//Check can create assignment with course
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))
                    .GoToCourses()
                    .ViewCourse(courseId)
                    .CheckCourseAssignmentsTabHidden()
                #endregion
                #region DeclineTeacher

                    .ClickLogout()
                    .LoginWithQN()
                    .GoToUserRoleApproval()
                    .Decline(userName, subject, teacher)
                    .Confirm()
                    .ClickLogout()
                    .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles5, UiConst.Password.UserNoRoles5)
                #endregion
                #region CheckForIV

                    .GoToClaimRoles()
                    .SelectRoleForSubject(0, subject, IV)
                    .ClaimRoles()
                    .CreateAssignmentTillStep4()
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))

                    //.CreateAssignment()//Check can not create assignment with course
                    //.SelectCourseById(courseId,false) // bug Teacher is declined, but can create assignment with course
                    .GoToCourses()
                    .ViewCourse(courseId)
                    .CheckCourseAssignmentsTabHidden()
                #endregion
                #region AddCLtoCourse

                    .GoToClaimRoles()
                    .SelectRoleForSubject(0, subject, CL)
                    .ClaimRoles()
                    .ClickLogout()
                    .LoginWithQN()
                    .GoToUserRoleApproval()
                    .Approve(userName, subject, CL)
                    .Confirm()
                    .GoToCourses()
                    .ViewCourse(courseId)
                    .ViewCourseTeam()
                    .AddCourseLeader(userName)
                    .SaveTeam()
                    .GoToUserRoleApproval()
                    .Decline(userName, subject, CL)
                    .Confirm()
                    .ClickLogout()
                #endregion
                #region CheckForPendingCL

                    .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles5, UiConst.Password.UserNoRoles5)
                    .GoToClaimRoles()
                    .SelectRoleForSubject(0, subject, CL)
                    .ClaimRoles()
                    .CreateAssignmentTillStep4()
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))
                    .CreateAssignmentWithCourseIdTillStep4(courseId) //Check can create assignment with course
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))
                    .GoToCourses()
                    .ViewCourse(courseId)
                    .CheckCourseAssignmentsTabHidden()
                #endregion
                #region CheckForLIV

                    .GoToClaimRoles()
                    .SelectRoleForSubject(0, subject, LIV)
                    .ClaimRoles()
                    .CreateAssignmentTillStep4()
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))
                    .CreateAssignmentWithCourseIdTillStep4(courseId) //Check can create assignment with course
                    .AssertSendToAcsButtonExists(false)
                    .AssertSendToIvButtonExists(false)
                    .ClickFinishResult().Next((assignmentFlow, assignmentId) => assignmentFlow
                        .AssertActions(UiConst.AssignmentActions.PendingAssignmentCreator, assignmentId))
                    .GoToCourses()
                    .ViewCourse(courseId)
                    .CheckCourseAssignmentsTabHidden()
                #endregion

                    .ClickLogout());
        }
    }
}
