using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class GridControl : CheckableControl
    {
        protected readonly string gridName;

        public GridControl(string id, string gridName)
            : base(id)
        {
            by = By.XPath;
            this.gridName = gridName;
        }


        public Link NextPage
        {
            get { return new Link("next_pager_{0}".F(gridName)); }
        }

        public Label Pages
        {
            get { return new Label("sp_1_pager_{0}".F(gridName)); }
        }

        public Dropdown ElementsPerPage
        {
            get { return new Dropdown("ui-pg-selbox", By.ClassName); }
        }
    }
}