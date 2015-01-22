using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class FeedbackPage : BtecMasterPage
    {
        public FeedbackPage()
            : base(UI.FeedbackPage)
        {
        }

        public Label FeedbackText
        {
            get { return new Label(".//div[@id='page']/h3", By.XPath); }
        }

        public Link FeedbackLink
        {
            get { return new Link(".//div[@id='page']/h3/a[@id='feedbackLink']", By.XPath); }
        }
    }
}