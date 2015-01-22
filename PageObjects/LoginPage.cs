using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class LoginPage : PageBase
    {
        public LoginPage()
            : base("")
        {
        }

        public TextField User
        {
            get
            {
                var user = new TextField("MainContent_LoginUser_UserName");
                if (!user.Exists) user = new TextField("ctl00_DefaultContentHolder_txtUsername");
                return user; 
            }
        }

        public TextField Password
        {
            get
            {
                var pwd = new TextField("MainContent_LoginUser_Password");
                if (!pwd.Exists) pwd = new TextField("ctl00_DefaultContentHolder_txtPassword");
                return pwd; 
            }
        }

        public Link LoginLink
        {
            get
            {
                var login =new Link("MainContent_LoginUser_LoginButton");
                if (!login.Exists) login = new Link("ctl00_DefaultContentHolder_btnLogin");
                return login; 
            }
        }

        public Label LoginUnauthorisedErrorTitle
        {
            get { return new Label(".//div[@id='content']/h1", By.XPath); }
        }

        public Label LoginUnauthorisedErrorMessage
        {
            get { return new Label(".//div[@id='content']/p", By.XPath); }
        }
    }
}