using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class WithIdPage : BtecMasterPage
    {
        public WithIdPage(string url)
            : base(url)
        {
        }

        public string Id
        {
            get { return new HiddenControl("Id").Text; }
        }
    }
}