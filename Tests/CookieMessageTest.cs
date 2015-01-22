using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CookieMessageTest : TestBase
    {
        private const int sessionTimeout = 9*60*1000;

        [Test]
        public void CookieMessageBoxTest()
        {
            Start
                .GoToLoginPage()
                .ClearCookies()
                .EnterCredentials(UiConst.Login.PearsonManager, UiConst.Password.PearsonManager)
                .Login()
                .AssertCookieMsgBoxTextCorrect(UI.CookieTitle, UI.CookieText)
                .AssertCookieMsgBoxLearnMoreLinkIsOpened(UI.CookieLearnMoreUrl)
                .CloseCookieMsgBox()
                .AssertCookieMsgBoxClosed()
                .GoToReports()
                .AssertCookieMsgBoxClosed();
        }

        [Test]
        public void SessionExpiringAutoLogoutTest()
        {
            Start
                .LoginWithQN()
                .GoToCourses()
                .Wait(sessionTimeout)
                .AssertSessionExpiredPopupAppearedDoNothing()
                .LoginWithPearsonManager()
                .GoToTermsOfUse();
        }

        [Test]
        public void SessionExpiringContinueSessionTest()
        {
            Start
                .LoginWithPearsonManager()
                .GoToBroadcast()
                .Wait(sessionTimeout)
                .AssertSessionExpiredPopupAppeared()
                .ContinueSession()
                .GoToTermsOfUse();
        }

        [Test]
        public void SessionExpiringOnAssignmentStep3AutoSaveOnAutoLogoutTest()
        {
            var assignmentContext = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignmentTillStep3(assignmentContext)
                .FillAllRequiredDataOnStep3(assignmentContext).Next((flow, id) =>
                    flow
                        .Wait(sessionTimeout)
                        .AssertSessionExpiredPopupAppearedDoNothing()
                        .LoginWithAssessor()
                        .GoToAssignments()
                        .Edit(id)
                        .SaveAndContinue()
                        .SaveAndContinue()
                        .CheckAllEnteredDataOnStep3(assignmentContext));
        }

        [Test]
        public void SessionExpiringOnAssignmentStep3BreakSessionTest()
        {
            var assignmentContext = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignmentTillStep3(assignmentContext)
                .FillAllRequiredDataOnStep3(assignmentContext).Next((flow, id) =>
                    flow
                        .Wait(sessionTimeout)
                        .AssertSessionExpiredPopupAppeared()
                        .BreakSession()
                        .LoginWithAssessor()
                        .GoToAssignments()
                        .Edit(id)
                        .SaveAndContinue()
                        .SaveAndContinue()
                        .CheckAllEnteredDataOnStep3(assignmentContext));
        }
    }
}