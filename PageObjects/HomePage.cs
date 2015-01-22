using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class HomePage : BtecMasterPage
    {
        public HomePage()
            : base("")
        {
        }

        public Dropdown Centers
        {
            get { return new Dropdown("Centers"); }
        }

        public PopupButton Continue
        {
            get { return new PopupButton(UI.Continue, "centreGroupSelectionPopup"); }
        }

        public Label ArticleHeadline
        {
            get { return new Label(".//div[@class='notif_title']", By.XPath); }
        }

        public Label ArticleText
        {
            get { return new Label("optionalContent"); }
        }

        public PopupButton ReadLaterButton
        {
            get { return new PopupButton(UI.ReadLaterNews, "newNotificationPopup"); }
        }

        public Label LatestNews
        {
            get { return new Label("ticker-content"); }
        }

        public Label EULA
        {
            get { return new Label("ui-dialog-title-eulaPopup"); }
        }

        public Checkbox EULAOptOut
        {
            get { return new Checkbox("OptOut"); }
        }

        public Label EULAOptOutText
        {
            get { return new Label("termsOptOutBox"); }
        }

        public PopupButton EULAIAgree
        {
            get { return new PopupButton(UI.EULAIAgree, "eulaPopup"); }
        }

        public PopupButton CancelEula
        {
            get { return new PopupButton(UI.Cancel, "eulaPopup"); }
        }

        public Label ThisText(string textToFind)
        {
            return new Label("//h2[contains(text(),'{0}')]".F(textToFind), By.XPath);
        }
    }
}