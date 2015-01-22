using System;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class ControlBase : ValidableControl
    {
        protected readonly string id;

        protected Func<string, By> by;

        protected IWebElement element;

        public ControlBase(string id) : base(id)
        {
            this.id = id;
            by = By.Id;
        }

        public ControlBase(string id, Func<string, By> by)
            : this(id)
        {
            this.by = by;
        }

        public string Id
        {
            get { return id; }
        }

        public virtual string Text
        {
            get { return Element.Text.Trim(); }
            set
            {
                Element.Clear();
                Element.SendKeys(value);
            }
        }

        protected virtual IWebElement Element
        {
            get
            {
                try
                {
                    if (by == null)
                    {
                        by = By.Id;
                    }

                    var wait = new WebDriverWait(WebDriver, Configuration.Timeout);

                    wait.Until(drv => drv.FindElement(by(id)).Displayed && drv.FindElement(by(id)).Enabled);

                    return element ?? (element = WebDriver.FindElement(by(id)));
                }
                catch (Exception exception)
                {
                    Assert.Fail("Element Id:{0};{1} ex:{2}{1}StackTrace:{3}{1}", id,
                        Environment.NewLine, exception.Message, exception.StackTrace);
                    throw;
                }
            }
        }

        public bool Exists
        {
            get { return !(WebDriver.FindElements(by(id)).IsNullOrEmpty()); }
        }

        public bool Displayed
        {
            get { return (Exists && WebDriver.FindElement(by(id)).Displayed); }
        }

        public bool Enabled
        {
            get { return (Displayed && WebDriver.FindElement(by(id)).Enabled); }
        }

        public override String ToString()
        {
            return Text;
        }

        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }
    }
}