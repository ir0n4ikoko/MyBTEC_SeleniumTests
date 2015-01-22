using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Link : ClickableControl
    {
        public Link(string id)
            : base(id)
        {
        }

        public Link(string id, Func<string, By> by)
            : base(id, by)
        {
        }
    }
}