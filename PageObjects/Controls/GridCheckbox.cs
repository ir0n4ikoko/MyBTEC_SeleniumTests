using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class GridCheckbox : GridControl
    {
        private int currentPage = 1;

        public GridCheckbox(string id, string gridName)
            : base(id, gridName)
        {
            by = By.XPath;
        }

        protected override IWebElement Element
        {
            get
            {
                if (currentPage > int.Parse(Pages.Text))
                {
                    return element;
                }
                try
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(2000));

                    wait.Until(drv => drv.FindElement(by(id)).Displayed && drv.FindElement(by(id)).Enabled);

                    return element ?? (element = WebDriver.FindElement(by(id)));
                }
                catch
                {
                    currentPage++;
                    NextPage.Click();
                    return Element;
                }
            }
        }

        public void CheckAll(string xpath)
        {
            var checkboxes = WebDriver.FindElements(By.XPath(xpath));

            foreach (var checkbox in checkboxes)
            {
                checkbox.Click();
            }

        }
    }
}