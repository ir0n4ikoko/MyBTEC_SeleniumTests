using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class FooterTest : TestBase
    {
        [Test]
        public void FooterLinksTest()
        {
            Start
                .LoginWithQN()
                .AssertFooterTextCorrect(UI.FooterText.Replace("\\r", "\r").Replace("\\n", "\n"))
                .AssertFooterLinksAreOpenedInNewTabs(UI.FooterLearnMoreUrl, UI.FooterCookiePolicyUrl,
                    UI.FooterPrivacyPolicyUrl, UI.TermsPage);
        }
    }
}