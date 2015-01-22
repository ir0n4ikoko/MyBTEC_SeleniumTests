using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ExternalLinksPage : BtecMasterPage
    {
        public ExternalLinksPage()
            : base(UI.Links)
        {
        }

        public Link NewExternalLink
        {
            get { return new Link("editLinkNew"); }
        }

        public PopupButton OK
        {
            get { return new PopupButton(UI.OK, "externalLinkPupUp"); }
        }

        public PopupButton Cancel
        {
            get { return new PopupButton(UI.Cancel, "externalLinkPupUp"); }
        }

        public PopupButton Delete
        {
            get { return new PopupButton(UI.Delete, "externalLinkPupUp"); }
        }

        public PopupButton ConfirmDelete
        {
            get { return new PopupButton(UI.Yes, "confirmDeleteLink"); }
        }

        public TextField Title
        {
            get { return new TextField("Header"); }
        }

        public TextField Url
        {
            get { return new TextField("Url"); }
        }

        public Link LinkInGrid(string title)
        {
            return new Link(title, By.LinkText);
        }

        public Link UrlInGrid(string title)
        {
            return new Link(".//a[text()='{0}']/../../td[@aria-describedby='table_externalLinksGrid_Url']".F(title),
                By.XPath);
        }
    }
}