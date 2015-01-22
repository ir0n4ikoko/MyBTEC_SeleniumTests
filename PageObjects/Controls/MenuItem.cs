using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class MenuItem : ClickableControl
    {
        public MenuItem(string id)
            : base("//div[@id='menu']/ul/li/a[text()='{0}']".F(id), By.XPath)
        {
        }
    }
}