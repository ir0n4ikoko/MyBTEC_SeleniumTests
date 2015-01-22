using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ViewQualificationStep1Page : QualificationFilterPage
    {
        public ViewQualificationStep1Page()
            : base(UI.ViewQualificationStep1)
        {
        }

        public Link Continue
        {
            get { return new Link("Continue", By.ClassName); }
        }

        public ClickableControl Exit
        {
            get { return new ClickableControl("Exit", By.ClassName); }
        }

        public PopupButton ConfirmExit(bool yes = true)
        {
            return new PopupButton(yes ? UI.Yes : UI.No, "confirm");
        }
    }
}