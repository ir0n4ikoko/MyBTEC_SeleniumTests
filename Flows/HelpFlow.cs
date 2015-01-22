using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class HelpFlow : BtecMasterFlow<HelpFlow>
    {
        private readonly HelpPage page;

        public HelpFlow(INavigator navigator, HelpPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public HelpFlow CheckTestButton(string title)
        {
            Assert.IsTrue(page.TestLink(title).Displayed, "Test link {0} was not added".F(title));

            return this;
        }
    }
}