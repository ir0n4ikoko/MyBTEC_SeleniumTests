using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Radiobutton : CheckableControl
    {
        public Radiobutton(string id)
            : base(id)
        {
        }

        public Radiobutton(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public string Value
        {
            get { return Element.GetAttribute("value"); }
        }
    }
}