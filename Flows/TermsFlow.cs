using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class TermsFlow : BtecMasterFlow<TermsFlow>
    {
        private readonly TermsPage page;

        public TermsFlow(INavigator navigator, TermsPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public TermsFlow CheckOptOutText(string optOutText)
        {
            Assert.AreEqual(optOutText, page.TermsOptOutBox.Text, "Text for Opt Out is incorrect");

            return this;
        }

        public TermsFlow TickOptOutCheckbox(bool untick = false)
        {
            Assert.AreEqual(untick, page.OptOutCheckbox.IsChecked,
                "Opt out checkbox was " + (untick ? "not" : "just") + " checked");

            page.OptOutCheckbox.Click();

            return this;
        }
    }
}