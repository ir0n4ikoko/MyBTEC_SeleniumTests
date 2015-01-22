using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public abstract class ControlListBase<TControl> : ValidableControl
        where TControl : ControlBase
    {
        private readonly Func<string, TControl> constructorFunc;
        protected IList<IWebElement> elments;

        protected string name;

        protected ControlListBase(string name, Func<string, TControl> constructorFunc)
            : base(name)
        {
            this.name = name;
            this.constructorFunc = constructorFunc;
        }

        public IEnumerable<TControl> Items
        {
            get { return elments.Select(element => constructorFunc(element.GetAttribute("id"))); }
        }
    }
}