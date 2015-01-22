using Edi.Advance.BTEC.UiTests.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public abstract class WebDriverControl
    {
        private readonly IWebDriver webDriver;

        protected WebDriverControl()
        {
            webDriver = SeleniumContext.WebDriver;
        }

        public IWebDriver WebDriver
        {
            get { return webDriver; }
        }
    }
}