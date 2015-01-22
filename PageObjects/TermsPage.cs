using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class TermsPage : BtecMasterPage
    {
        public TermsPage()
            : base(UI.TermsPage)
        {
        }

        public Label TermsOptOutBox
        {
            get { return new Label("termsOptOutBox"); }
        }

        public Checkbox OptOutCheckbox
        {
            get { return new Checkbox("OptOut"); }
        }
    }
}