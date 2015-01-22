using System;
using Edi.Advance.BTEC.UiTests.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class CKeditor : ClickableControl
    {
        private string textarea_id;

        public CKeditor(string id)
            : base(id)
        {
        }

        public CKeditor(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public override string Text
        {
            get
            {
                if (by == null)
                {
                    by = By.Id;
                }
                textarea_id = SeleniumContext.WebDriver.FindElement(by(id)).GetAttribute("id");
                SeleniumContext.WebDriver.SwitchTo()
                    .Frame(SeleniumContext.WebDriver.FindElement(By.XPath(".//*[@id='cke_" + textarea_id + "']//iframe")));
                string text = SeleniumContext.WebDriver.FindElement(By.TagName("body")).Text;
                SeleniumContext.WebDriver.SwitchTo().DefaultContent();
                return text;
            }
            set
            {
                if (by == null)
                {
                    by = By.Id;
                }
                textarea_id = SeleniumContext.WebDriver.FindElement(by(id)).GetAttribute("id");
                SeleniumContext.WebDriver.SwitchTo()
                    .Frame(SeleniumContext.WebDriver.FindElement(By.XPath("//*[@id='cke_" + textarea_id + "']//iframe")));
                SeleniumContext.WebDriver.FindElement(By.TagName("body")).SendKeys(value);
                SeleniumContext.WebDriver.SwitchTo().DefaultContent();
            }
        }

        public void Clear()
        {
            if (by == null)
            {
                by = By.Id;
            }
            textarea_id = SeleniumContext.WebDriver.FindElement(by(id)).GetAttribute("id");
            SeleniumContext.WebDriver.SwitchTo()
                .Frame(SeleniumContext.WebDriver.FindElement(By.XPath(".//*[@id='cke_" + textarea_id + "']//iframe")));
            SeleniumContext.WebDriver.FindElement(By.TagName("body")).Clear();
            SeleniumContext.WebDriver.SwitchTo().DefaultContent();
        }
    }
}