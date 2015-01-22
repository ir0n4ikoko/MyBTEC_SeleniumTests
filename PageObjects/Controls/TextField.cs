using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class TextField : ClickableControl
    {
        public TextField(string id)
            : base(id)
        {
        }

        public TextField(string id, Func<string, By> by)
            : base(id, by)
        {
        }


        public override string Text
        {
            get { return Element.GetAttribute("value").Trim(); }
            set
            {
                Element.Clear();
                Element.SendKeys(value);
            }
        }
    }
}