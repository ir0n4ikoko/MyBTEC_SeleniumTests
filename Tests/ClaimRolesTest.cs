using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ClaimRolesTest : TestBase
    {
        [Test, Ignore]
        public void ClaimRolesSubjectsOrderingTestCheckEmails()
        {
            string teacher = UI.Teacher;
            string assessor = UI.Assessor;
            string iv = UI.InternalVerifier;
            string courseLeader = UI.CourseLeader;
            string liv = UI.LeadInternalVerifier;
            string claimedRolesQN = UI.EmailRoleClaimed.F(UiConst.Subject.Application_of_Science, courseLeader) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.PerformingArts, assessor) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Principles_of_Applied_Science, iv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Sport, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.AppliedScience, teacher) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Information_and_Creative_Technology, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Engineering, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Art_and_Design, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Business, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    +
                                    UI.EmailRoleClaimed.F(UiConst.Subject.Childrens_Play_Learning_and_Development, liv) +
                                    UI.EmailRoleClaimedNewRow
                                    + UI.EmailRoleClaimed.F(UiConst.Subject.Health_and_Social_Care, liv);


            Start
                .RemoveInboxMessages(UiConst.Email.QualityNominee)
                .RemoveInboxMessages(UiConst.Email.Liv)
                .RemoveInboxMessages(UiConst.Email.UserNoRoles3)
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles3, UiConst.Password.UserNoRoles3)
                .ConfirmEulaRedirectClaimRoles()
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(1, UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .SelectRoleForSubject(2, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .SelectRoleForSubject(3, UiConst.Subject.Sport, UiConst.Role.Liv)
                .SelectRoleForSubject(4, UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .SelectRoleForSubject(5, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.Liv)
                .SelectRoleForSubject(6, UiConst.Subject.Engineering, UiConst.Role.Liv)
                .SelectRoleForSubject(7, UiConst.Subject.Art_and_Design, UiConst.Role.Liv)
                .SelectRoleForSubject(8, UiConst.Subject.Business, UiConst.Role.Liv)
                .SelectRoleForSubject(9, UiConst.Subject.Childrens_Play_Learning_and_Development, UiConst.Role.Liv)
                .SelectRoleForSubject(10, UiConst.Subject.Health_and_Social_Care, UiConst.Role.Liv)
                .ClaimRoles()
                .CheckSubject(0, UiConst.Subject.Application_of_Science)
                .CheckSubject(1, UiConst.Subject.AppliedScience)
                .CheckSubject(2, UiConst.Subject.Art_and_Design)
                .CheckSubject(3, UiConst.Subject.Business)
                .CheckSubject(4, UiConst.Subject.Childrens_Play_Learning_and_Development)
                .CheckSubject(5, UiConst.Subject.Engineering)
                .CheckSubject(6, UiConst.Subject.Health_and_Social_Care)
                .CheckSubject(7, UiConst.Subject.Information_and_Creative_Technology)
                .CheckSubject(8, UiConst.Subject.PerformingArts)
                .CheckSubject(9, UiConst.Subject.Principles_of_Applied_Science)
                .CheckSubject(10, UiConst.Subject.Sport)
                .ClickLogout()
                .LoginWithQN()
                .GoToUserRoleApproval()
                .AssertEmailReceived(UiConst.Email.Liv, UI.EmailSubjectRoleClaimed,
                    UI.EmailBodyRoleClaimed.F(UiConst.FirstName.UserNoRoles3, UiConst.LastName.UserNoRoles3,
                        UiConst.Email.UserNoRoles3, UI.EmailRoleClaimed.F(UiConst.Subject.AppliedScience, teacher),
                        UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.Liv, UI.EmailSubjectRoleClaimed,
                    UI.EmailBodyRoleClaimed.F(UiConst.FirstName.UserNoRoles3, UiConst.LastName.UserNoRoles3,
                        UiConst.Email.UserNoRoles3,
                        UI.EmailRoleClaimed.F(UiConst.Subject.Principles_of_Applied_Science, iv), UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.Liv, UI.EmailSubjectRoleClaimed,
                    UI.EmailBodyRoleClaimed.F(UiConst.FirstName.UserNoRoles3, UiConst.LastName.UserNoRoles3,
                        UiConst.Email.UserNoRoles3, UI.EmailRoleClaimed.F(UiConst.Subject.PerformingArts, assessor),
                        UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.Liv, UI.EmailSubjectRoleClaimed,
                    UI.EmailBodyRoleClaimed.F(UiConst.FirstName.UserNoRoles3, UiConst.LastName.UserNoRoles3,
                        UiConst.Email.UserNoRoles3,
                        UI.EmailRoleClaimed.F(UiConst.Subject.Application_of_Science, courseLeader),
                        UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.QualityNominee, UI.EmailSubjectRoleClaimed,
                    UI.EmailBodyRoleClaimed.F(UiConst.FirstName.UserNoRoles3, UiConst.LastName.UserNoRoles3,
                        UiConst.Email.UserNoRoles3, claimedRolesQN, UI.DoNotReplyMessage))
                .Approve(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3, UiConst.Subject.Sport,
                    UI.LIV)
                .Approve(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .Approve(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .Approve(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .Approve(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .Decline(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Information_and_Creative_Technology, UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Engineering, UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Art_and_Design, UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3, UiConst.Subject.Business,
                    UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles3 + " " + UiConst.LastName.UserNoRoles3,
                    UiConst.Subject.Childrens_Play_Learning_and_Development.Substring(11), "LIV")
                .Confirm()
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleDeclined.F(liv, UiConst.Subject.Childrens_Play_Learning_and_Development),
                    UI.EmailBodyRoleDeclined.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Childrens_Play_Learning_and_Development, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleDeclined.F(liv, UiConst.Subject.Business),
                    UI.EmailBodyRoleDeclined.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Business, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleDeclined.F(liv, UiConst.Subject.Art_and_Design),
                    UI.EmailBodyRoleDeclined.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Art_and_Design, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleDeclined.F(liv, UiConst.Subject.Engineering),
                    UI.EmailBodyRoleDeclined.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Engineering, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleDeclined.F(liv, UiConst.Subject.Information_and_Creative_Technology),
                    UI.EmailBodyRoleDeclined.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Information_and_Creative_Technology, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleApproved.F(teacher, UiConst.Subject.AppliedScience),
                    UI.EmailBodyRoleApproved.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee,
                        teacher, UiConst.Subject.AppliedScience, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleApproved.F(liv, UiConst.Subject.Sport),
                    UI.EmailBodyRoleApproved.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, liv,
                        UiConst.Subject.Sport, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleApproved.F(iv, UiConst.Subject.Principles_of_Applied_Science),
                    UI.EmailBodyRoleApproved.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee, iv,
                        UiConst.Subject.Principles_of_Applied_Science, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleApproved.F(assessor, UiConst.Subject.PerformingArts),
                    UI.EmailBodyRoleApproved.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee,
                        assessor, UiConst.Subject.PerformingArts, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.UserNoRoles3,
                    UI.EmailSubjectRoleApproved.F(courseLeader, UiConst.Subject.Application_of_Science),
                    UI.EmailBodyRoleApproved.F(UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee,
                        courseLeader, UiConst.Subject.Application_of_Science, UI.DoNotReplyMessage))
                ;
        }

        [Test,Ignore]
        public void ClaimRolesUpgradeDowngradeTest()
        {
            string userName = UiConst.FirstName.UserNoRoles8 + " " + UiConst.LastName.UserNoRoles8;
            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles8, UiConst.Password.UserNoRoles8)
                .ConfirmEulaRedirectClaimRoles()
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(1, UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .SelectRoleForSubject(2, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .SelectRoleForSubject(3, UiConst.Subject.Sport, UiConst.Role.Liv)
                .SelectRoleForSubject(4, UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .SelectRoleForSubject(5, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.Liv)
                .SelectRoleForSubject(6, UiConst.Subject.Engineering, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(7, UiConst.Subject.Art_and_Design, UiConst.Role.Iv)
                .SelectRoleForSubject(8, UiConst.Subject.Business, UiConst.Role.Assessor)
                .SelectRoleForSubject(9, UiConst.Subject.Childrens_Play_Learning_and_Development, UiConst.Role.Teacher)
                .SelectRoleForSubject(10, UiConst.Subject.Health_and_Social_Care, UiConst.Role.Teacher)
                .ClaimRoles()
                //Check that user can upgrade/downgrade claimed role while in pending state
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UiConst.Role.Iv)
                .SelectRoleForSubject(1, UiConst.Subject.AppliedScience, UiConst.Role.Liv)
                .SelectRoleForSubject(2, UiConst.Subject.Art_and_Design, UiConst.Role.Assessor)
                .SelectRoleForSubject(3, UiConst.Subject.Business, UiConst.Role.Teacher)
                .SelectRoleForSubject(4, UiConst.Subject.Childrens_Play_Learning_and_Development,
                    UiConst.Role.CourseLeader)
                .SelectRoleForSubject(5, UiConst.Subject.Engineering, UiConst.Role.Iv)
                .SelectRoleForSubject(6, UiConst.Subject.Health_and_Social_Care, UiConst.Role.Assessor)
                .SelectRoleForSubject(7, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(8, UiConst.Subject.PerformingArts, UiConst.Role.Teacher)
                .SelectRoleForSubject(9, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Assessor)
                .SelectRoleForSubject(10, UiConst.Subject.Sport, UiConst.Role.CourseLeader)
                .ClaimRoles()
                .ClickLogout()
                .LoginWithQN()
                .GoToUserRoleApproval()
                .Decline(userName, UiConst.Subject.Application_of_Science, UiConst.Role.Iv)
                .Decline(userName, UiConst.Subject.PerformingArts, UiConst.Role.Teacher)
                .Decline(userName, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Assessor)
                .Decline(userName, UiConst.Subject.Sport, UiConst.Role.CourseLeader)
                .Decline(userName, UiConst.Subject.AppliedScience, UI.LIV)
                .Decline(userName, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.CourseLeader)
                .Decline(userName, UiConst.Subject.Engineering, UiConst.Role.Iv)
                .Decline(userName, UiConst.Subject.Art_and_Design, UiConst.Role.Assessor)
                .Decline(userName, UiConst.Subject.Business, UiConst.Role.Teacher)
                .Decline(userName, UiConst.Subject.Childrens_Play_Learning_and_Development.Substring(11),
                    UiConst.Role.CourseLeader)
                .Decline(userName, UiConst.Subject.Health_and_Social_Care, UiConst.Role.Assessor)
                .Confirm()
                .ClickLogout()
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles8, UiConst.Password.UserNoRoles8)
                .GoToClaimRoles()
                //Check that user can upgrade/downgrade claimed role while declined
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(1, UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .SelectRoleForSubject(2, UiConst.Subject.Art_and_Design, UiConst.Role.Iv)
                .SelectRoleForSubject(3, UiConst.Subject.Business, UiConst.Role.Assessor)
                .SelectRoleForSubject(4, UiConst.Subject.Childrens_Play_Learning_and_Development, UiConst.Role.Liv)
                .SelectRoleForSubject(5, UiConst.Subject.Engineering, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(6, UiConst.Subject.Health_and_Social_Care, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(7, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.Liv)
                .SelectRoleForSubject(8, UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .SelectRoleForSubject(9, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .SelectRoleForSubject(10, UiConst.Subject.Sport, UiConst.Role.Liv)
                .ClaimRoles()
                .ClickLogout()
                .LoginWithQN()
                .GoToUserRoleApproval()
                .Approve(userName, UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .Approve(userName, UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .Approve(userName, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .Approve(userName, UiConst.Subject.Sport, UI.LIV)
                .Approve(userName, UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .Approve(userName, UiConst.Subject.Information_and_Creative_Technology, UI.LIV)
                .Approve(userName, UiConst.Subject.Engineering, UiConst.Role.CourseLeader)
                .Approve(userName, UiConst.Subject.Art_and_Design, UiConst.Role.Iv)
                .Approve(userName, UiConst.Subject.Business, UiConst.Role.Assessor)
                .Approve(userName, UiConst.Subject.Childrens_Play_Learning_and_Development.Substring(11), UI.LIV)
                .Approve(userName, UiConst.Subject.Health_and_Social_Care, UiConst.Role.CourseLeader)
                .Confirm()
                .ClickLogout()
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles8, UiConst.Password.UserNoRoles8)
                .GoToClaimRoles()
                //Check that user can ONLY upgrade claimed role if approved
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(1, UiConst.Subject.AppliedScience, UiConst.Role.Teacher)
                .SelectRoleForSubject(2, UiConst.Subject.Art_and_Design, UiConst.Role.Iv)
                .SelectRoleForSubject(3, UiConst.Subject.Business, UiConst.Role.Assessor)
                .SelectRoleForSubject(4, UiConst.Subject.Childrens_Play_Learning_and_Development, UiConst.Role.Liv)
                .SelectRoleForSubject(5, UiConst.Subject.Engineering, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(6, UiConst.Subject.Health_and_Social_Care, UiConst.Role.CourseLeader)
                .SelectRoleForSubject(7, UiConst.Subject.Information_and_Creative_Technology, UiConst.Role.Liv)
                .SelectRoleForSubject(8, UiConst.Subject.PerformingArts, UiConst.Role.Assessor)
                .SelectRoleForSubject(9, UiConst.Subject.Principles_of_Applied_Science, UiConst.Role.Iv)
                .SelectRoleForSubject(10, UiConst.Subject.Sport, UiConst.Role.Liv)
                .ClaimRoles();
        }

        [Ignore]
        [TestCase("Teacher", "test teacher", "test_teacher@learntodive.org.uk", "67546B6")]
        [TestCase("Assessor", "test assessor", "test_assessor@learntodive.org.uk", "5B56C3E")]
        [TestCase("InternalVerifier", "test iv", "test_internalverifier@learntodive.org.uk", "C9D4D43")]
        [TestCase("CourseLeader", "test cl", "test_courseleader@learntodive.org.uk", "2CD767B")]
        [TestCase("Teacher", "Auto Teacher", "mybtec.test.teacher@gmail.com", "Secret123")]
        [TestCase("Assessor", "Auto Assessor", "mybtec.test.assessor@gmail.com", "Secret123")]
        [TestCase("InternalVerifier", "Auto IV", "test.internalverifier@gmail.com", "Secret123")]
        [TestCase("CourseLeader", "Auto CL", "mybtec.test.courseleader@gmail.com", "Secret123")]
        [TestCase("LeadInternalVerifier", "Auto LIV", "test.leadinternalverifier@gmail.com", "Secret123")]
        public void ClaimRoleForAllSubjects(string role, string userName, string login, string password)
         {
             Start
                 .LoginWithAndGoToHomePage(login, password)
                 .ConfirmEulaRedirectClaimRoles()
                 .SelectRoleForAllSubjects(role)
                 .ClaimRoles()
                 .ClickLogout()
                 .LoginWithQN()
                 .GoToUserRoleApproval()
                 .ApproveAll(userName, role);
         }
    }
}