using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ViewQualificationStep2Page : BtecMasterPage
    {
        public ViewQualificationStep2Page()
            : base(UI.ViewQualificationStep2)
        {
        }

        public ClickableControl Exit
        {
            get { return new ClickableControl("Exit", By.ClassName); }
        }

        public PopupButton ConfirmExit(bool yes = true)
        {
            return new PopupButton(yes ? UI.Yes : UI.No, "confirm");
        }

        public ClickableControl Previous
        {
            get { return new ClickableControl(".//div[contains(@class, 'prev')]", By.XPath); }
        }

        public Label HeadTitle
        {
            get { return new Label("b_title", By.ClassName); }
        }

        public Link GeneralSpecificationInformation
        {
            get { return new Link("General specification information", By.PartialLinkText); }
        }
    }
}