using System;
using System.Linq;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class CheckboxList : ControlListBase<Checkbox>
    {
        public CheckboxList(string name)
            : base(name, id => new Checkbox(id))
        {
            elments = elments = WebDriver.FindElements(By.Name(name));
        }

        public CheckboxList(string selector, Func<string, By> by)
            : this(selector)
        {
            elments = elments = WebDriver.FindElements(by(name));
        }

        public bool IsAllChecked
        {
            get { return Items.Any() && Items.All(item => item.IsChecked); }
        }

        public bool IsAllUnchecked
        {
            get { return Items.Any() && Items.All(item => !item.IsChecked); }
        }
    }
}