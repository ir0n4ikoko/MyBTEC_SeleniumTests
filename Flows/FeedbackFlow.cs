using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class FeedbackFlow : BtecMasterFlow<FeedbackFlow>
    {
        private readonly FeedbackPage page;

        public FeedbackFlow(INavigator navigator, FeedbackPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public FeedbackFlow CheckText(string feedbackText)
        {
            Assert.AreEqual(feedbackText, page.FeedbackText.Text, "Text on Feedback page is incorrect");

            return this;
        }

        public FeedbackFlow CheckContactUsLink(string url)
        {
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.FeedbackLink.Click),
                "New tab Contact Us is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(url), "New tab Contact Us is not redirected");

            return this;
        }
    }
}