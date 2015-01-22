using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class AssignmentStep2Page : AssigmentWizardPage
    {
        private const string CommonXpath =
            "//div[@class='clear_both assignment_criterias']//div[@class='fieldspacer']/p/b[text()='{0} ']/ancestor::div[@class='clear_both assignment_criterias']";

        private const string CheckBoxAllXpath = CommonXpath + "//input[@class='selectAll' and @type='checkbox']";

        private const string CheckBoxGroupAllXpath =
            CommonXpath + "//div[input/@value='{1}']//input[@class='groupSelectAll' and @type='checkbox']";

        private const string CheckBoxGroupXpath = CommonXpath + "//input[@name='{1}' and @type='checkbox']";

        public AssignmentStep2Page()
            : base(UI.AssignmentStep2Page)
        {
        }

        public PopupButton ValidationOk
        {
            get { return new PopupButton(UI.OK, "errorDiv"); }
        }

        public Label ValidationErrorPopupTitle
        {
            get { return new Label(".//div[@aria-describedby='errorDiv']//span[@class='ui-dialog-title']", By.XPath); }
        }

        public Label ValidationErrorText
        {
            get { return new Label(".//*[@id='errorDiv']/p[1]", By.XPath); }
        }

        public Label ValidationErrorForUnits
        {
            get { return new Label(".//*[@id='errorDiv']/ul", By.XPath); }
        }

        public Checkbox Criterion(string id)
        {
            return new Checkbox(id);
        }

        public CheckboxList GetGroupFromUnit(string unitTitle, string group)
        {
            return new CheckboxList(CheckBoxGroupXpath.F(unitTitle, group), By.XPath);
        }

        public Checkbox GetUnitCheckAll(string unitTitle)
        {
            return new Checkbox(CheckBoxAllXpath.F(unitTitle), By.XPath);
        }

        public Checkbox GetUnitGroupCheckAll(string unitTitle, string group)
        {
            return new Checkbox(CheckBoxGroupAllXpath.F(unitTitle, group), By.XPath);
        }

        public Checkbox LearningObjective(string learningObjectiveValue)
        {
            string xpath = "//input[@type='checkbox' and @value='{0}']".F(learningObjectiveValue);

            return new Checkbox(xpath, By.XPath);
        }
    }
}