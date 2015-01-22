using System;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ExternalLinksTest : TestBase
    {
        [Test, Ignore]
        public void LinksManagementTest()
        {
            string title = UI.TestText.F(Guid.NewGuid().ToString().Replace("-", ""));
            string url = UI.TestUrl.F(title);

            Start
                .LoginWithPearsonManager()
                .GoToExternalLinks()
                .CheckValidationEmptyFields()
                .CheckValidationOnLenthLimit()
                .AddNewLink(title, url)
                .AssertLinkSaved(title, url, "add")
                .RefreshPage()
                .CheckMenuLink(title, url)
                .GoToExternalLinks()
                .EditOldLink(title, title + "1", url + "1")
                .AssertLinkSaved(title + "1", url + "1", "edit")
                .DeleteLink(title + "1")
                .AssertLinkSaved(title + "1", url + "1", "delete");
        }
    }
}