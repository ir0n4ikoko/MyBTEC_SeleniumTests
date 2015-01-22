using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class AssignmentStep3Page : AssigmentWizardPage
    {
        private const string CommonXpath =
            "//div[@class='unitblock clear_both']//b[text() [contains(., '{0}')]]/ancestor::div[@class='unitblock clear_both']";

        private const string CheckBoxUnitAllXpath = CommonXpath + "//input[@class='selectAll' and @type='checkbox']";

        private const string CheckBoxGroupAllXpath =
            CommonXpath + "//div[p[text() [contains(.,'{1}')]]]//input[@class='groupSelectAll' and @type='checkbox']";

        private const string CheckBoxGroupXpath = CommonXpath + "//div[@class='checkBoxList']//input[@type='checkbox']";

        public AssignmentStep3Page()
            : base(UI.AssignmentStep3Page)
        {
        }

        public CKeditor Scenario
        {
            get { return new CKeditor("Scenario"); }
        }

        public TextField Task1Tile
        {
            get { return new TextField("Tasks_0__Title"); }
        }

        public CKeditor Task1Description
        {
            get { return new CKeditor("Tasks_0__Description"); }
        }

        public TextField Evidence
        {
            get { return new TextField("Tasks_0__Evidences_0__Evidence"); }
        }

        public HiddenControl SourcesOfInformation
        {
            get { return new HiddenControl("Source"); }
        }

        public Link SelectCriteriaForTask
        {
            get { return new Link("assignmentTaskCriteriaLink"); }
        }

        public TextField AssignmentDuration
        {
            get { return new TextField("AssignmentDuration"); }
        }

        public PopupButton OK
        {
            get { return new PopupButton(UI.OK, "assignmentTaskCriteriaPopUp"); }
        }

        public Checkbox Criterion(string id)
        {
            return new Checkbox(id);
        }

        public Checkbox SelectAll(string unitTitle)
        {
            return new Checkbox(CheckBoxUnitAllXpath.F(unitTitle), By.XPath);
        }

        public Checkbox SelectAllLearningObjective(string unitTitle, string learningObjectiveTitle)
        {
            return new Checkbox(CheckBoxGroupAllXpath.F(unitTitle, learningObjectiveTitle), By.XPath);
        }

        public CheckboxList CriteriaForUnit(string unitTitle)
        {
            return new CheckboxList(CheckBoxGroupXpath.F(unitTitle), By.XPath);
        }
    }
}