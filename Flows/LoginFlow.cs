using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class LoginFlow : FlowBase<LoginFlow>
    {
        private readonly LoginPage loginPage;

        public LoginFlow(INavigator navigator, LoginPage loginPage)
            : base(navigator)
        {
            this.loginPage = loginPage;
        }

        public LoginFlow EnterCredentials(string userName, string password)
        {
            loginPage.User.Text = userName;

            loginPage.Password.Text = password;

            return this;
        }

        public HomeFlow Login()
        {
            var homePage = navigator.DoActionWaitForJQueryAndNavigate<HomePage>(loginPage.LoginLink.Click);

            return new HomeFlow(navigator, homePage);
        }

        public ClaimRolesFlow LoginWithRedirectToClaimRoles()
        {
            var claimRolesPage =
                navigator.DoActionWaitForJQueryAndNavigate<ClaimRolesPageAtFirstLogin>(loginPage.LoginLink.Click);

            return new ClaimRolesFlow(navigator, claimRolesPage);
        }

        public LoginFlow LoginWithError()
        {
            loginPage.LoginLink.Click();

            return this;
        }

        public LoginFlow AssertUnauthorised(string error, string message)
        {
            Assert.IsTrue(loginPage.LoginUnauthorisedErrorTitle.Text.Contains(error),
                "Login with user unathorised for myBTEC. Expected error title {0} but was {1}".F(error,
                    loginPage.LoginUnauthorisedErrorTitle.Text));

            Assert.IsTrue(loginPage.LoginUnauthorisedErrorMessage.Text.Contains(message),
                "Login with user unathorised for myBTEC. Expected error message {0} but was {1}".F(message,
                    loginPage.LoginUnauthorisedErrorMessage.Text));

            return this;
        }
    }
}