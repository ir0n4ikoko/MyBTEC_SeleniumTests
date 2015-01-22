using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class HelpPage : BtecMasterPage
    {
        public HelpPage()
            : base(UI.HelpPage)
        {
        }

        public Link TestLink(string title)
        {
            return new Link(title, By.LinkText);
        }
    }
}