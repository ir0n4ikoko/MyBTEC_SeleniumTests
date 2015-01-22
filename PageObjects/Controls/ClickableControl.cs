using System;
using Edi.Advance.BTEC.UiTests.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class ClickableControl : ControlBase
    {
        public ClickableControl(string id)
            : base(id)
        {
        }

        public ClickableControl(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public void Click()
        {
            /* this is work around for error and bug in chrome driver 
             * ERROR: System.InvalidOperationException : Element is not clickable at point (636, 16). Other element would receive the click: <div class="ui-widget-overlay" style="width: 1053px; height: 2098px; z-index: 1001;"></div>
             * SOURCE: https://code.google.com/p/selenium/issues/detail?id=2766#c27
             * LOOK AT COMMENT: 27
             * (WebDriver as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", Element.Location.Y));
             */
            try
            {
                Element.Click();
            }
            catch (WebDriverException)
            {
            }
        }

        public void MoveByOffset(int offX, int offY)
        {
            var action = new Actions(SeleniumContext.WebDriver);

            action.ClickAndHold(Element).MoveByOffset(offX, offY).Release().Perform();
        }
    }
}