using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    /// <summary>
    ///     Navigator represents entity, which monitors what page resides in browser. All redirects,
    ///     events which can causes redirects, postbacks, popups, Ajax calls should be performed using
    ///     Navigator.
    /// </summary>
    /// <remarks>
    ///     Responsibilities of Navigator includes:
    ///     Assert that redirect was performed to the right place. It means after click on “Home” link
    ///     in menu user must be redirected to HomePage, not to Login or somewhere else.
    ///     Assert that redirect or postback is not caused server error and if caused, then gather
    ///     information about error and include it in the error message of failed test.
    ///     Prevent appearing of confusing errors like “Control with ID ‘bla-bla-bla’ was not found”.
    ///     Often tests includes scenarios when it is needed to be redirected on some page and find control
    ///     on it. But if page throws exception, there will be no controls on it – just error message.
    ///     Encapsulate all “wait” activities. It should wait for browser to load whole page before
    ///     accessing it, wait for completing AJAX requests and of course manage timeouts.
    /// </remarks>
    public class Navigator : INavigator
    {
        private readonly TimeSpan timeout;

        private readonly IWebDriver webDriver;
        private string siteUrl;

        public Navigator()
        {
            timeout = Configuration.Timeout;
            webDriver = SeleniumContext.WebDriver;
        }

        private IJavaScriptExecutor JavaScriptExecutor
        {
            get { return (IJavaScriptExecutor) webDriver; }
        }

        public TPage Open<TPage>() where TPage : PageBase, new()
        {
            var page = new TPage();

            GoToUrl(Path.Combine(siteUrl, page.PageUrl).Replace(@"/", @"\"));

            WaitLoad(page);

            AssertErrorPage(page);

            AssertCorrectPageLoaded(page);

            return page;
        }

        public TPage Navigate<TPage>(Action action) where TPage : PageBase, new()
        {
            var page = new TPage();

            action();

            WaitLoad(page);

            AssertErrorPage(page);

            AssertCorrectPageLoaded(page);

            return page;
        }

        public TPage NavigateNewTab<TPage>(Action action) where TPage : PageBase, new()
        {
            var page = new TPage();

            action();

            webDriver.SwitchTo().Window(webDriver.WindowHandles[webDriver.WindowHandles.Count - 1]);

            WaitLoad(page);

            AssertErrorPage(page);

            AssertCorrectPageLoaded(page);

            return page;
        }

        public TPage WaitForJQueryAndNavigate<TPage>(Action action) where TPage : PageBase, new()
        {
            WaitForJQuery();
            return Navigate<TPage>(action);
        }

        public TPage DoActionWaitForJQueryAndNavigate<TPage>(Action action) where TPage : PageBase, new()
        {
            return Navigate<TPage>(() => ClickAndWaitForJQuery(action));
        }

        public TPage DoActionWaitUrlChangedAndNavigate<TPage>(Action action) where TPage : PageBase, new()
        {
            return Navigate<TPage>(() => ClickAndWaitUrlChanged(action));
        }

        public void GoToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public void ClickAndWaitForElement(Action action, Func<string> controlId)
        {
            action();

            WaitElementIsPresent(controlId);
        }

        public void ClickAndWaitForJQuery(Action action)
        {
            action();

            WaitForJQuery();
        }

        public void WaitForJQuery()
        {
            WebDriverWait wait = GetWaitWebDriverWait();

            try
            {
                wait.Until(d => (bool) JavaScriptExecutor.ExecuteScript("return jQuery.active == 0"));
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
            }
        }

        public void WaitElementIsPresent(Func<string> controlId)
        {
            WebDriverWait wait = GetWaitWebDriverWait();

            wait.Until(x => x.FindElement(By.Id(controlId())));
        }

        public bool DoActionCheckNewTabOpened(Action action)
        {
            int tabCount = webDriver.WindowHandles.Count;

            action();

            int tabCountAfter = webDriver.WindowHandles.Count;

            return (tabCount + 1 == tabCountAfter);
        }

        public bool CheckUrlNewTabOpened(string url)
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles[webDriver.WindowHandles.Count - 1]);

            bool isUrlCorrect = (url.Equals(webDriver.Url)) || (webDriver.Url.Contains(url));

            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);

            return isUrlCorrect;
        }


        public void WaitForFileDownloaded(string path)
        {
            WebDriverWait wait = GetWaitWebDriverWait();

            try
            {
                wait.Until(d => File.Exists(path));
            }
            catch (Exception)
            {
                Thread.Sleep(5000);
            }
        }

        private void WaitLoad<TPage>(TPage page) where TPage : PageBase, new()
        {
            WebDriverWait wait = GetWaitWebDriverWait();
            try
            {
                wait.Until(driver1 => JavaScriptExecutor.ExecuteScript("return document.readyState;").Equals("complete"));
            }
            catch (WebDriverException)
            {
                Thread.Sleep(2000);
            }
            catch (InvalidOperationException)
            {
                Thread.Sleep(2000);
            }
        }

        private WebDriverWait GetWaitWebDriverWait()
        {
            return new WebDriverWait(webDriver, timeout);
        }

        private void AssertCorrectPageLoaded<TPage>(TPage page) where TPage : PageBase, new()
        {
            string location = webDriver.Url;

            int paramsStart = location.IndexOf('?');

            if (paramsStart >= 0)
            {
                location = location.Substring(0, paramsStart);
            }

            if (!Regex.IsMatch(location, @"\A.+/{0}.*\z".F(page.PageUrl)))
            {
                Assert.Fail("Expected URL {0} but was {1}", page.PageUrl, location);
            }
        }

        private void AssertErrorPage<TPage>(TPage page) where TPage : PageBase, new()
        {
            CheckServerError();
            CheckEOLError();
            CheckApplicationException();
            //TODO Check Core services and EOL errors
        }

        private void CheckApplicationException()
        {
            try
            {
                Func<string, string> getErrorFunc =
                    errror =>
                        (string)
                            JavaScriptExecutor.ExecuteScript(" return document.getElementById('{0}').value".F(errror));

                string errorHidden = getErrorFunc("ExceptionMessage");

                string errorId = getErrorFunc("ExceptionId");

                string errorStackTrace = getErrorFunc("StackTrace");

                Assert.Fail(
                    "Application error while navigating.{0}Error Id: {1}{0}Error Message: {2}{0}Error StackTrace: {3}",
                    Environment.NewLine,
                    errorId, errorHidden, errorStackTrace);
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
        }

        private void CheckServerError()
        {
            try
            {
                if (webDriver.FindElement(By.TagName("body")).Text.Contains("Server Error in"))
                {
                    Assert.Fail("Server error while navigating.");
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
        }

        private void CheckEOLError()
        {
            try
            {
                if (
                    webDriver.FindElement(By.TagName("body"))
                        .Text.Contains("Edexcel Online is currently experiencing technical difficulties."))
                {
                    Assert.Fail("EOL error while navigating.");
                }

                IWebElement eolErr = webDriver.FindElement(By.Id("ctl00_DefaultContentHolder_vsumSummary"));
                Assert.IsFalse(eolErr.Displayed && eolErr.Text.Contains("Exception"), "EOL exception while navigating.");
            }
            catch (InvalidOperationException)
            {
            }
            catch (WebDriverException)
            {
            }
        }

        public void Start(string url)
        {
            siteUrl = url;
            GoToUrl(url);
        }

        public void ClickAndWaitUrlChanged(Action action)
        {
            string oldUrl = webDriver.Url;

            action();

            WaitForJQuery();

            try
            {
                GetWaitWebDriverWait().Until(d => !d.Url.Equals(oldUrl));
            }
            catch (WebDriverException)
            {
                WaitForJQuery();
            }
        }
    }
}