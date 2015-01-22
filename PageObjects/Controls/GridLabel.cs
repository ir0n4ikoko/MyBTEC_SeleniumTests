namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    using OpenQA.Selenium;

    public class GridLabel : ControlBase
    {

        public GridLabel(string id)
            : base(id)
        {
            by = By.XPath;
        }

        public string GetText()
        {
            return Element.Text;
        }
    }
}
