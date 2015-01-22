using System;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class HiddenControl : ControlBase
    {
        private readonly IJavaScriptExecutor javaScriptExecutor;

        public HiddenControl(string id)
            : base(id)
        {
            javaScriptExecutor = (IJavaScriptExecutor) WebDriver;
        }

        public override string Text
        {
            get
            {
                return (string) javaScriptExecutor.ExecuteScript(" return document.getElementById('{0}').value".F(Id));
            }
            set { javaScriptExecutor.ExecuteScript("$('#{0}').val('{1}')".F(Id, value)); }
        }

        protected override IWebElement Element
        {
            get { throw new NotSupportedException(); }
        }
    }
}