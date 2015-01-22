using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class FeedbackTest : TestBase
    {
        [Test,Ignore]
        public void CheckFeedbackPageTest()
        {
            Start
                .LoginWithQN()
                .GoToFeedback()
                .CheckText(UI.FeedbackText)
                .CheckContactUsLink(UI.FeedbackUrl);
        }
    }
}