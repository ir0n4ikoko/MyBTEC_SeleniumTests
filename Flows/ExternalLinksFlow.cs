using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ExternalLinksFlow : BtecMasterFlow<ExternalLinksFlow>
    {
        public ExternalLinksPage page;

        public ExternalLinksFlow(INavigator navigator, ExternalLinksPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ExternalLinksFlow NewExternalLinkClick()
        {
            page.NewExternalLink.Click();

            return this;
        }

        public ExternalLinksFlow SetTitle(string title)
        {
            page.Title.Text = title;

            return this;
        }

        public ExternalLinksFlow SetUrl(string url)
        {
            page.Url.Text = url;

            return this;
        }

        public ExternalLinksFlow ClickOK()
        {
            page.OK.Click();

            return this;
        }

        public ExternalLinksFlow ClickCancel()
        {
            page.Cancel.Click();

            return this;
        }

        public ExternalLinksFlow ClickDelete()
        {
            page.Delete.Click();

            return this;
        }

        public ExternalLinksFlow ConfirmDelete()
        {
            page.ConfirmDelete.Click();

            return this;
        }

        public ExternalLinksFlow OpenLink(string title)
        {
            page.LinkInGrid(title).Click();

            return this;
        }

        public ExternalLinksFlow AssertLinkSaved(string title, string url, string action)
        {
            if (action.Equals("add"))
            {
                navigator.WaitForJQuery();
                Assert.AreEqual(page.InfoMessage.Text, UI.MsgExternalLinkSaved.F(title, "added", "see new added"),
                    "Incorrect info message");
                Assert.IsTrue(page.LinkInGrid(title).Displayed, "Link was not added in grid");
                Assert.IsTrue(page.UrlInGrid(title).Displayed && page.UrlInGrid(title).Text.Equals(url),
                    "Url was not added in grid");
            }
            if (action.Equals("edit"))
            {
                navigator.WaitForJQuery();
                Assert.AreEqual(page.InfoMessage.Text, UI.MsgExternalLinkSaved.F(title, "edited", "see new edited"),
                    "Incorrect info message");
                Assert.IsTrue(page.LinkInGrid(title).Displayed, "Link was not added in grid");
                Assert.IsTrue(page.UrlInGrid(title).Displayed && page.UrlInGrid(title).Text.Equals(url),
                    "Url was not added in grid");
            }
            if (action.Equals("delete"))
            {
                navigator.WaitForJQuery();
                Assert.AreEqual(page.InfoMessage.Text, UI.MsgExternalLinkSaved.F(title, "deleted", "switch off"),
                    "Incorrect info message");
                Assert.IsFalse(page.LinkInGrid(title).Displayed, "Link was not deleted from grid");
            }

            return this;
        }

        public ExternalLinksFlow CheckValidationEmptyFields()
        {
            NewExternalLinkClick()
                .ClickOK();

            Assert.IsFalse(page.Title.IsValid);
            Assert.AreEqual(page.Title.ValidationMessage, UI.ValidationFieldRequired.F(UI.Title));
            Assert.IsFalse(page.Url.IsValid);
            Assert.AreEqual(page.Url.ValidationMessage, UI.ValidationFieldRequired.F(UI.Url));

            ClickCancel();

            return this;
        }

        public ExternalLinksFlow CheckValidationOnLenthLimit()
        {
            string char50 = UI.Char50;

            NewExternalLinkClick()
                .SetTitle(char50 + "a")
                .SetUrl(char50 + char50 + "a")
                .ClickOK();

            Assert.IsFalse(page.Title.IsValid);
            Assert.AreEqual(page.Title.ValidationMessage, UI.ValidationLength.F(UI.Title, "50"));
            Assert.IsFalse(page.Url.IsValid);
            Assert.AreEqual(page.Url.ValidationMessage, UI.ValidationLength.F(UI.Url, "100"));

            ClickCancel();

            return this;
        }

        public ExternalLinksFlow AddNewLink(string title, string url)
        {
            return NewExternalLinkClick()
                .SetTitle(title)
                .SetUrl(url)
                .ClickOK();
        }

        public ExternalLinksFlow EditOldLink(string title, string newTitle, string newUrl)
        {
            return OpenLink(title)
                .SetTitle(newTitle)
                .SetUrl(newUrl)
                .ClickOK();
        }

        public ExternalLinksFlow DeleteLink(string title)
        {
            return OpenLink(title)
                .ClickDelete()
                .ConfirmDelete();
        }
    }
}