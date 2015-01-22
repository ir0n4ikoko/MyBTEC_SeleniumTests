using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ResourcesPage : QualificationFilterPage
    {
        public ResourcesPage()
            : base(UI.ResourcesPage)
        {
        }

        public Checkbox SelectAllResources
        {
            get { return new Checkbox("cbAllResources", By.Name); }
        }

        public Dropdown ActionForAllResources
        {
            get { return new Dropdown("ddlActionToAllResources"); }
        }

        public Dropdown Unit
        {
            get { return new Dropdown("Unitdropdown"); }
        }

        public ClickableControl AddUnit
        {
            get { return new ClickableControl("buttonAddUnit"); }
        }

        public ClickableControl Search
        {
            get { return new ClickableControl("btnSearch"); }
        }

        public ClickableControl Clear
        {
            get { return new ClickableControl("btnClear"); }
        }

        public ClickableControl PackView
        {
            get { return new ClickableControl("packView"); }
        }

        public ClickableControl ResourceView
        {
            get { return new ClickableControl("resourceView"); }
        }

        public ControlBase ActiveView
        {
            get
            {
                return new ControlBase(".//div[@id='resourcesITunes']//li[contains(@class,'ui-tabs-active')]", By.XPath);
            }
        }

        public Label ResourcePackNumber
        {
            get { return new Label("pager_resourcePackGrid_right"); }
        }

        public ControlBase ResourcePackGrid
        {
            get { return new ControlBase("gbox_table_resourcePackGrid"); }
        }

        public Label PackId(string grid, int index)
        {
            return new Label(".//table[@id='table_" + grid + "']//tr[" + index + "]", By.XPath);
        }

        public ClickableControl PackExpand(string grid, int index)
        {
            return new ClickableControl(".//table[@id='table_" + grid + "']//tr[" + index + "]//a", By.XPath);
        }

        public Dropdown PackAction(string grid, string id)
        {
            return new Dropdown(".//table[@id='table_" + grid + "']//select[@id='resPackAction" + id + "']", By.XPath);
        }

        public Checkbox PackCheckbox(string grid, string id)
        {
            return new Checkbox(".//table[@id='table_" + grid + "']//*[@id='" + id + "']/td[3]/input", By.XPath);
        }

        public Label PackTitle(string grid, int index)
        {
            return new Label(".//table[@id='table_" + grid + "']//tr[" + index + "]//td[4]/div", By.XPath);
        }

        public Label ResourceTitle(string grid, string packId, int index)
        {
            return new Label("//table[@id='table_" + grid + "_" + packId + "_t']//tr[" + index + "]//td[3]/div",
                By.XPath);
        }
    }
}