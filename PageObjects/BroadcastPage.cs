using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class BroadcastPage : BtecMasterPage
    {
        public BroadcastPage()
            : base(UI.BroadcastPage)
        {
        }

        public Link NewArticle
        {
            get { return new Link("createNewsItem"); }
        }

        public Link HomePageArticle
        {
            get { return new Link("//tr[descendant::td[text()='System User']]//a[text()='Home Page']", By.XPath); }
        }

        public Link HelpArticle
        {
            get { return new Link("//tr[descendant::td[text()='System User']]//a[text()='Help']", By.XPath); }
        }

        public TextField Subject
        {
            get { return new TextField("Subject"); }
        }

        public CKeditor ArticleText
        {
            get { return new CKeditor("NewsContent"); }
        }

        public PopupButton CreatePopupOk
        {
            get { return new PopupButton(UI.OK, "createNewsItemPopup"); }
        }

        public PopupButton EditPopupButtonOk
        {
            get { return new PopupButton(UI.OK, "editNewsItemPopup"); }
        }

        public PopupButton Archive
        {
            get { return new PopupButton(UI.Archive, "editNewsItemPopup"); }
        }

        public PopupButton Cancel
        {
            get { return new PopupButton(UI.Cancel, "editNewsItemPopup"); }
        }

        public Radiobutton PublishDateSheduled
        {
            get { return new Radiobutton("publishScheduled"); }
        }

        public Radiobutton ExpireDateSheduled
        {
            get { return new Radiobutton("expireScheduled"); }
        }

        public Calendar SetDate
        {
            get { return new Calendar("ui-datepicker-div"); }
        }

        public Calendar PublishDateCalendar
        {
            get { return new Calendar(".//input[contains(@id,'PublishDateCalendar')]", By.XPath); }
        }

        public Calendar ExpireDateCalendar
        {
            get { return new Calendar(".//input[contains(@id,'ExpireDateCalendar')]", By.XPath); }
        }

        public Label Time
        {
            get { return new Label(".//dd[@class = 'ui_tpicker_time']", By.XPath); }
        }

        public Label Archived
        {
            get { return new Label("//span[contains(text(),'" + UI.Archived + "')]", By.XPath); }
        }

        public Label Live
        {
            get { return new Label("//span[contains(text(),'" + UI.Live + "')]", By.XPath); }
        }

        public Link ThisArticle(string text)
        {
            return new Link("//a[contains(.,'{0}')]".F(text), By.XPath);
        }
        public GridControl NewsGrid
        {
            get { return new GridControl("gbox_table_newsItems", "newsItems"); }
        }
    }
}