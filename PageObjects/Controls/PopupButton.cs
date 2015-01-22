using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class PopupButton : ClickableControl
    {
        public PopupButton(string buttonText, string popupContentId)
            : base(
                "//div[@role='dialog' and descendant::div[@id='{1}']]//button[parent::div[@class='ui-dialog-buttonset']]//span[text()='{0}']"
                    .F(buttonText, popupContentId), By.XPath)
        {
        }
    }
}