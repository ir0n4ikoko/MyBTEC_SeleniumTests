using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ViewQualificationStep2Flow : BtecMasterFlow<ViewQualificationStep2Flow>
    {
        private readonly ViewQualificationStep2Page page;

        public ViewQualificationStep2Flow(INavigator navigator, ViewQualificationStep2Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public HomeFlow Exit()
        {
            page.Exit.Click();

            var homePage = navigator.Navigate<HomePage>(page.ConfirmExit().Click);

            return new HomeFlow(navigator, homePage);
        }

        public ViewQualificationStep1Flow Previous()
        {
            var step1Page = navigator.DoActionWaitForJQueryAndNavigate<ViewQualificationStep1Page>(page.Previous.Click);

            return new ViewQualificationStep1Flow(navigator, step1Page);
        }

        public ViewQualificationStep2Flow AssertStep2HeadTextCorrect(string text)
        {
            Assert.AreEqual(text, page.HeadTitle.Text, "Incorrect text for head title");

            return this;
        }

        public ViewQualificationStep2Flow DownloadGeneralSpecificationInformation()
        {
            navigator.WaitForJQuery();

            page.GeneralSpecificationInformation.Click();

            return this;
        }

        public ViewQualificationStep2Flow CheckDownloadGeneralSpecificationInformationLinkIsActive(bool exists = true)
        {
            navigator.WaitForJQuery();

            Assert.AreEqual(exists, page.GeneralSpecificationInformation.Exists);

            return this;
        }
        
    }
}