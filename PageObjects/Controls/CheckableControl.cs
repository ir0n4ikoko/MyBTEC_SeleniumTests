using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class CheckableControl : ClickableControl
    {
        public CheckableControl(string id)
            : base(id)
        {
        }

        public CheckableControl(string id, Func<string, By> @by)
            : base(id, @by)
        {
        }

        public bool IsChecked
        {
            get { return Element.Selected; }
        }
    }
}