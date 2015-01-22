using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    public abstract class FlowBase<TFlow> where TFlow : FlowBase<TFlow>
    {
        protected readonly INavigator navigator;

        protected FlowBase(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public TFlow Wait(int t)
        {
            //Thread.Sleep(t);
            DateTime oldTime = DateTime.Now;
            DateTime newTime = DateTime.Now;
            var timeSpan = new TimeSpan(0, 0, 0, 0, t);
            while ((newTime - oldTime) < timeSpan)
            {
                newTime = DateTime.Now;
                try
                {
                    string title = SeleniumContext.WebDriver.Title;
                }
                catch (WebDriverException)
                {
                }
                catch (InvalidOperationException)
                {
                }
            }
            return (TFlow) this;
        }

        public TFlow RefreshPage()
        {
            SeleniumContext.WebDriver.Navigate().Refresh();
            return (TFlow) this;
        }

        public TFlow ClearCookies()
        {
            SeleniumContext.WebDriver.Manage().Cookies.DeleteAllCookies();
            return (TFlow) this;
        }


        public TFlow AssertEmailReceived(string userEmail, string subject, string bodyText, string from = null)
        {
            bodyText = bodyText.Replace("\\r", "\r");
            bodyText = bodyText.Replace("\\n", "\n");
            if (from == null)
            {
                from = UiConst.Email.MyBtec;
            }

            MailHelper.CheckEmailReceived(userEmail, from, subject, bodyText);

            return (TFlow) this;
        }

        public TFlow RemoveInboxMessages(string userEmail)
        {
            MailHelper.EmptyInbox(userEmail);
            return (TFlow) this;
        }
    }
}