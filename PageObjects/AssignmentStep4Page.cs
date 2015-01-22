using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common.Extentions;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class AssignmentStep4Page : AssigmentWizardPage
    {
        private ACSViewPage acsViewPopUp;

        private SendToIvPage sendToIvPage;

        public AssignmentStep4Page()
            : base(UI.AssignmentStep4Page)
        {
        }

        public string Title
        {
            get
            {
                return
                    new Label(
                        @"//div[contains(@class,'fieldspacer')]/div[contains(text(),'Title:')]/following-sibling::div//span",
                        By.XPath).Text;
            }
        }

        public Link Finish
        {
            get { return new Link("Finish", By.ClassName); }
        }

        public ACSViewPage ACSPopUp
        {
            get
            {
                if (acsViewPopUp.IsNull())
                {
                    acsViewPopUp = new ACSViewPage();
                }
                return acsViewPopUp;
            }
        }

        public SendToIvPage SendToIvPopUp
        {
            get
            {
                if (sendToIvPage.IsNull())
                {
                    sendToIvPage = new SendToIvPage();
                }
                return sendToIvPage;
            }
        }

        public Link SendtoAssignmentCheckingService
        {
            get { return new Link("ACSLink"); }
        }

        public Link SendtoIV
        {
            get { return new Link("selectivLink"); }
        }

        public Dropdown PearsonStatus
        {
            get { return new Dropdown("Statuses"); }
        }

        public Label RedWarningNote
        {
            get { return new Label("redWarning", By.ClassName); }
        }

        public Label PopupWarningMessage
        {
            get { return new Label("errorDiv"); }
        }
    }
}