using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Label : ControlBase
    {
        public Label(string id)
            : base(id)
        {
        }

        public Label(string id, Func<string, By> @by)
            : base(id, @by)
        {
        }


        public override String ToString()
        {
            return "Label with text '" + Text + "'";
        }
    }
}