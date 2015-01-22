using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class AssignmentStep1Page : AssigmentWizardPage
    {
        public AssignmentStep1Page()
            : base(UI.AssignmentStep1Page)
        {
        }

        public AssignmentStep1Page(string page)
            : base(page)
        {
        }

        public TextField Title
        {
            get { return new TextField("Title"); }
        }

        public TextField Author
        {
            get { return new TextField("Author"); }
        }

        public Radiobutton ChooseFromAllSubjectsAndQualifications
        {
            get { return new Radiobutton(@"//input[@type='radio' and @value='Qualification']", By.XPath); }
        }

        public Radiobutton AssociateWithACourse
        {
            get { return new Radiobutton(@"//input[@type='radio' and @value='Course']", By.XPath); }
        }

        public Dropdown Course
        {
            get { return new Dropdown("Coursedropdown"); }
        }

        public Dropdown Unit
        {
            get { return new Dropdown("Unitdropdown"); }
        }

        public Link AddUnit
        {
            get { return new Link("buttonAddUnit"); }
        }

        public Label ErrorNoUnits
        {
            get { return new Label("errorDiv"); }
        }

        public PopupButton ErrorNoUnitsOk
        {
            get { return new PopupButton(UI.OK, "errorDiv"); }
        }

        public Label AddedUnit(string unitTitle)
        {
            return new Label(".//table[@id='selectedUnitTable']/tbody/tr/td[contains(text(),'{0}')]".F(unitTitle),
                By.XPath);
        }
    }
}