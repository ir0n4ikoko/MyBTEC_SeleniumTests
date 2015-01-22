using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class StartFlow : FlowBase<StartFlow>
    {
        public StartFlow(INavigator navigator)
            : base(navigator)
        {
        }

        public LoginFlow GoToLoginPage()
        {
            var loginPage = navigator.Open<LoginPage>();

            return new LoginFlow(navigator, loginPage);
        }

        public HomeFlow LoginWithAndGoToHomePage(string userName, string password)
        {
            return GoToLoginPage()
                .EnterCredentials(userName, password)
                .Login()
                .CloseCookiePopupIfDisplayed();
        }

        public HomeFlow LoginWithTest6()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles6, UiConst.Password.UserNoRoles6);
        }

        public HomeFlow LoginWithIV()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Iv, UiConst.Password.Iv);
        }

        public HomeFlow LoginWithLIV()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Liv, UiConst.Password.Liv);
        }

        public HomeFlow LoginWithAssessor()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Assessor, UiConst.Password.Assessor);
        }

        public HomeFlow LoginWithCL()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.CourseLeader, UiConst.Password.CourseLeader);
        }

        public HomeFlow LoginWithQN()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.QualityNominee, UiConst.Password.QualityNominee);
        }

        public HomeFlow LoginWithDDM()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Ddm, UiConst.Password.Ddm);
        }

        public HomeFlow LoginWithEditor()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Editor, UiConst.Password.Editor);
        }

        public HomeFlow LoginWithTester()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Tester, UiConst.Password.Tester);
        }

        public HomeFlow LoginWithTeacher()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.Teacher, UiConst.Password.Teacher);
        }

        public HomeFlow LoginWithPearsonManager()
        {
            return LoginWithAndGoToHomePage(UiConst.Login.PearsonManager, UiConst.Password.PearsonManager);
        }
    }
}