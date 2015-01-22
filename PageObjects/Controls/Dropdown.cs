using System;
using System.Collections.Generic;
using System.Linq;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Dropdown : ClickableControl
    {
        protected SelectElement selectElement;

        public Dropdown(string id)
            : base(id)
        {
        }

        public Dropdown(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public string Value
        {
            get { return SelectElement.SelectedOption.GetAttribute("value"); }
            set { SelectElement.SelectByValue(value); }
        }

        public override string Text
        {
            get { return SelectElement.SelectedOption.Text; }
            set
            {
                try
                {
                    SelectElement.SelectByText(value);
                }
                catch (NoSuchElementException)
                {
                    Assert.Fail("{0} not found in dropdown({1})\nAvailable options are: ".F(value, id,
                        string.Join(";", Options)));
                }
            }
        }

        public IEnumerable<string> Options
        {
            get { return SelectElement.Options.Select(o => o.Text); }
        }

        public IEnumerable<string> Values
        {
            get { return SelectElement.Options.Select(o => o.GetAttribute("value")); }
        }

        public IEnumerable<IWebElement> ElementOptions
        {
            get
            {
                selectElement = new SelectElement(Element); return selectElement.Options; }
        }

        public SelectElement SelectElement
        {
            get
            {
                try
                {
                    return selectElement
                           ?? (selectElement = new SelectElement(Element));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}