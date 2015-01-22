using System;
using System.Collections.Generic;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class HomePageTest : TestBase
    {
        private readonly IList<string> centres = new List<string>
        {
            "20104 20104T N/A - BORDESLEY GREEN CAMPUS",
            "20104 20104C 20104 - CONSTRUCTION CENTRE",
            "20104 20104D 20140 - DIGBETH CAMPUS",
            "20104 20104P N/A - HAGLEY ROAD",
            "20104 20104H N/A - HALL GREEN CAMPUS",
            "20104 20104S N/A - SPARKBROOK & SPARKHILL",
        };

        [Test]
        public void CheckCenterChoisePopup()
        {
            Start
                .LoginWithAndGoToHomePage("lisa.price@sbirmc.ac.uk", "j")
                .CenterChoiceCheckOptionsAndAssert(centres);
        }

        [Test,Ignore]
        public void CheckNewsAppearence()
        {
            string articleHeadline = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            string articleText = UI.TestText.F(DateTime.Now.Ticks);
            Start
                .LoginWithPearsonManager()
                .GoToBroadcast()
                .NewArticleClick()
                .GiveHeadline(articleHeadline)
                .EnterArticleText(articleText)
                .OkButtonCreatePopupClick()
                .GoToHome()
                .CheckArticleHeadline(articleHeadline)
                .CheckNewsArticleText(articleText)
                .ReadLaterButtonClick()
                .CheckLatestNewsString(articleHeadline)
                .GoToBroadcast()
                .ClickThisArticle(articleHeadline)
                .ArchiveButtonClick();
        }

        [Test]
        public void EULACheckAndOptOutCheckbox()
        {
            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles0, UiConst.Password.UserNoRoles0)
                .CheckEulaOptOutText(UI.OptOutText)
                .TickEULAOptOut()
                .CancelEula();
        }

        [Test]
        public void RedirectToClaimroles()
        {
            Start
                .GoToLoginPage()
                .EnterCredentials(UiConst.Login.UserNoRoles2, UiConst.Password.UserNoRoles2)
                //Login with user that accepted EULA and have no roles
                .LoginWithRedirectToClaimRoles();
        }
    }
}