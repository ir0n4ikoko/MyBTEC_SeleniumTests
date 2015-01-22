using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class LoginPageTest : TestBase
    {
        [Test]
        public void LoginLogoutRelogin()
        {
            Start
                .LoginWithAssessor()
                .GoToAssignments()
                .ClickLogout()
                .LoginWithCL()
                .GoToCourses()
                .ClickLogout();
        }

        [Test]
        public void LoginNotAuthorised()
        {
            Start
                .GoToLoginPage()
                .EnterCredentials(UiConst.Login.UserNoRoles9, UiConst.Password.UserNoRoles9)
                .LoginWithError()
                .AssertUnauthorised(UI.UnauthorisedTitle, UI.UnauthorisedText);
        }
    }
}