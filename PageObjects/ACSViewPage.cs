using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ACSViewPage : BtecMasterPage
    {
        public ACSViewPage()
            : base(UI.ACSViewPage)
        {
        }

        public PopupButton DownloadPDF
        {
            get { return new PopupButton(UI.DownloadPDF, "ASCContent"); }
        }

        public PopupButton GotoAssignmentCheckingService
        {
            get { return new PopupButton(UI.GoToACS, "ASCContent"); }
        }

        public PopupButton Cancel
        {
            get { return new PopupButton(UI.Cancel, "ASCContent"); }
        }

        public Label PopupContent
        {
            get { return new Label(".//div[@id='ASCContent']", By.XPath); }
        }
    }
}