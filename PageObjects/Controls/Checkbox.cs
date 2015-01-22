using System;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Checkbox : CheckableControl
    {
        public Checkbox(string id)
            : base(id)
        {
        }

        public Checkbox(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public override string Text
        {
            get { return new Label("//label[@for='{0}']".F(id), By.XPath).Text; }
            set { throw new NotSupportedException(); }
        }
    }
}