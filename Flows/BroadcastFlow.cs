using System;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class BroadcastFlow : BtecMasterFlow<BroadcastFlow>
    {
        protected string currentTime;
        public BroadcastPage page;

        public BroadcastFlow(INavigator navigator, BroadcastPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public BroadcastFlow NewArticleClick()
        {
            page.NewArticle.Click();
            navigator.WaitForJQuery();
            return this;
        }

        public BroadcastFlow OpenHomePageArticle()
        {
            NewsView100();
            page.HomePageArticle.Click();
            navigator.WaitForJQuery();
            return this;
        }

        public BroadcastFlow OpenHelpArticle()
        {
            NewsView100();
            page.HelpArticle.Click();

            return this;
        }

        public BroadcastFlow GiveHeadline(string subjHeader)
        {
            page.Subject.Text = subjHeader;
            return this;
        }

        public BroadcastFlow EnterArticleText(string articleText)
        {
            navigator.WaitForJQuery();
            page.ArticleText.Text = articleText;
            return this;
        }

        public BroadcastFlow ClearText()
        {
            page.ArticleText.Clear();

            return this;
        }

        public BroadcastFlow OkButtonCreatePopupClick()
        {
            navigator.WaitForJQuery();

            page = navigator.DoActionWaitForJQueryAndNavigate<BroadcastPage>(page.CreatePopupOk.Click);

            return new BroadcastFlow(navigator, page);
        }

        public BroadcastFlow OkButtonEditPopupClick()
        {
            navigator.WaitForJQuery();

            page = navigator.DoActionWaitForJQueryAndNavigate<BroadcastPage>(page.EditPopupButtonOk.Click);

            return new BroadcastFlow(navigator, page);
        }

        public BroadcastFlow CancelButtonClick()
        {
            navigator.WaitForJQuery();

            page = navigator.DoActionWaitForJQueryAndNavigate<BroadcastPage>(page.Cancel.Click);

            return new BroadcastFlow(navigator, page);
        }

        public BroadcastFlow ArchiveButtonClick()
        {
            navigator.WaitForJQuery();

            page = navigator.DoActionWaitForJQueryAndNavigate<BroadcastPage>(page.Archive.Click);

            return new BroadcastFlow(navigator, page);
        }

        public BroadcastFlow AssertArticleSaved()
        {
            navigator.WaitForJQuery();
            Assert.IsTrue(page.InfoMessage.Text.Contains(UI.MsgArticleSaved));
            return this;
        }

        public BroadcastFlow ClickThisArticle(string text)
        {
            navigator.WaitForJQuery();
            NewsView100();
            page.ThisArticle(text).Click();
            navigator.WaitForJQuery();
            return this;
        }

        public BroadcastFlow SetPublishDate(DateTime dateTime)
        {
            page.PublishDateCalendar.SelectDateTime(dateTime);
            return this;
        }

        public BroadcastFlow SetExpireDate(DateTime dateTime)
        {
            page.ExpireDateCalendar.SelectDateTime(dateTime);
            return this;
        }

        public BroadcastFlow CheckStatusArchived()
        {
            Assert.IsNotNull(page.Archived);
            return this;
        }

        public BroadcastFlow CheckStatusLive()
        {
            Assert.IsNotNull(page.Live);
            return this;
        }
        public BroadcastFlow NewsView100()
        {
            page.NewsGrid.ElementsPerPage.Value = "100";
            navigator.WaitForJQuery();
            return this;
        }
    }
}