using System;
using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class HomeFlow : BtecMasterFlow<HomeFlow>
    {
        private readonly HomePage homePage;

        public HomeFlow(INavigator navigator, HomePage homePage)
            : base(navigator, homePage)
        {
            this.homePage = homePage;
        }

        public ErrorFeedbackFlow GoToErrorFeedback()
        {
            navigator.GoToUrl(SeleniumContext.WebDriver.Url + "ErrorFeedback");
            var page = new ErrorFeedbackPage();
            return new ErrorFeedbackFlow(navigator, page);
        }

        public HomeFlow SelectRole(string roleName)
        {
            homePage.MyRole.Text = roleName;

            return this;
        }

        public HomeFlow CloseCookiePopupIfDisplayed()
        {
            if (homePage.CookieMsgBoxTitle.Enabled)
                try
                {
                    homePage.CookieMsgBoxCloseBtn.Click();
                }
                catch (InvalidOperationException)
                {
                }

            return this;
        }

        public HomeFlow SelectCenterContinue(string center)
        {
            homePage.Centers.Text = center;

            navigator.Navigate<HomePage>(homePage.Continue.Click);

            return new HomeFlow(navigator, homePage);
        }

        public HomeFlow CenterChoiceCheckOptionsAndAssert(IEnumerable<string> centersToCheck)
        {
            string[] difference = homePage.Centers.Options.Except(centersToCheck).ToArray();

            Assert.IsFalse(difference.Any(), "Centers differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public HomeFlow CheckArticleHeadline(string sampleText)
        {
            Assert.IsTrue(homePage.ArticleHeadline.Text.Contains(sampleText));
            return this;
        }

        public HomeFlow CheckNewsArticleText(string sampleText)
        {
            Assert.AreEqual(sampleText, homePage.ArticleText.Text);
            return this;
        }

        public HomeFlow ReadLaterButtonClick()
        {
            homePage.ReadLaterButton.Click();
            return this;
        }

        public HomeFlow CheckLatestNewsString(string sampleText)
        {
            Assert.IsTrue(homePage.LatestNews.Text.Contains(sampleText));
            return this;
        }

        public HomeFlow AssertEULA()
        {
            Assert.IsTrue(homePage.EULA.Text.Contains(UI.EULA));
            return this;
        }

        public HomeFlow FindThisText(string text)
        {
            Assert.IsTrue(homePage.ThisText(text).Text.Contains(text));
            return this;
        }

        public HomeFlow EULAOptOutPresence()
        {
            Assert.IsFalse(homePage.EULAOptOut.IsChecked);
            return this;
        }

        public HomeFlow ConfirmEula()
        {
            homePage.EULAIAgree.Click();

            return this;
        }

        public HomeFlow CheckEulaOptOutText(string optOutText)
        {
            Assert.AreEqual(optOutText, homePage.EULAOptOutText.Text, "Text for Opt Out is incorrect");

            return this;
        }

        public HomeFlow TickEULAOptOut()
        {
            homePage.EULAOptOut.Click();

            return this;
        }

        public StartFlow CancelEula()
        {
            navigator.WaitForJQuery();

            homePage.CancelEula.Click();

            return new StartFlow(navigator);
        }

        public ClaimRolesFlow ConfirmEulaRedirectClaimRoles()
        {
            if (homePage.EULAIAgree.Displayed)
                homePage.EULAIAgree.Click();

            navigator.WaitForJQuery();

            var page = navigator.DoActionWaitForJQueryAndNavigate<ClaimRolesPage>(homePage.ClaimRoles.Click);

            return new ClaimRolesFlow(navigator, page);
        }
    }
}