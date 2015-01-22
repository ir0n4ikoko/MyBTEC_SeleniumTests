using System.Linq;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class RadiobuttonList : ControlListBase<Radiobutton>
    {
        public RadiobuttonList(string name) :
            base(name, id => new Radiobutton(id))
        {
            this.name = name;
            elments = WebDriver.FindElements(By.Name(name));
        }

        public string Value
        {
            get { return SelectedItem.Value; }
            set
            {
                Radiobutton item = Items.First(x => x.Value == value);
                item.Click();
            }
        }

        public Radiobutton SelectedItem
        {
            get { return Items.First(i => i.IsChecked); }
            set
            {
                Radiobutton item = Items.First(x => x.Equals(value));

                if (!item.Equals(SelectedItem))
                {
                    item.Click();
                }
            }
        }
    }
}