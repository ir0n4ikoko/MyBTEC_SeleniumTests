using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ACSViewFlow : BtecMasterFlow<ACSViewFlow>
    {
        private readonly ACSViewPage page;

        public ACSViewFlow(INavigator navigator, ACSViewPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ACSViewFlow Cancel()
        {
            page.Cancel.Click();

            return this;
        }

        public ACSViewFlow DownloadPdf()
        {
            page.DownloadPDF.Click();

            return this;
        }

        public ACSViewFlow GoToAssignmentCheckingService()
        {
            page.GotoAssignmentCheckingService.Click();

            return this;
        }

        public ACSViewFlow AssertACSPopupTextCorrect(string text)
        {
            Assert.AreEqual(text, page.PopupContent.Text, "ACS popup text is incorrect");

            return this;
        }

        public ACSViewFlow AssertNewACSTabOpenedWithUrl(string url)
        {
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.GotoAssignmentCheckingService.Click),
                "New ACS tab with link {0} is not opened".F(url));

            Assert.IsTrue(navigator.CheckUrlNewTabOpened(url), "New ACS tab is not redirected to {0}".F(url));

            return this;
        }
    }
}