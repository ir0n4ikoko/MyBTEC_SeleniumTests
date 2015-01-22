using System;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    internal class BroadcastTest : TestBase
    {
        [Test, Ignore]
        public void HelpPageContentTest()
        {
            string title = UI.TestText.F(DateTime.Now.Ticks);
            string testText = UI.TestLink.F(title);
            Start
                .LoginWithPearsonManager()
                .GoToBroadcast()
                .OpenHelpArticle()
                .EnterArticleText(testText)
                .OkButtonEditPopupClick()
                .OpenHelpArticle()
                .OkButtonEditPopupClick()
                .GoToHelp()
                .CheckTestButton(title);
        }

        [Test]
        public void HomepageContentTest()
        {
            string testText = UI.TestText.F(DateTime.Now.Ticks);
            Start
                .LoginWithPearsonManager()
                .GoToBroadcast()
                .OpenHomePageArticle()
                .EnterArticleText(testText)
                .OkButtonEditPopupClick()
                .GoToHome()
                .FindThisText(testText);
        }
    }
}