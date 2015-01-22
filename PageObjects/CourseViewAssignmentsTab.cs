using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseViewAssignmentsTab : CourseViewPage
    {
        public Link SearchAssignment
        {
            get { return new Link("searchAssignmentLink"); }
        }

        public Dropdown Actions(string id)
        {
            return new Dropdown("assignmentAction{0}".F(id));
        }

        public PopupButton ConfirmRemoving(bool ok = true)
        {
            return new PopupButton(ok ? UI.Yes : UI.No, "removePopup");
        }

        public Label Status(string id)
        {
            return new Label("assignmentStatus{0}".F(id));
        }

        public ControlBase AssignmentCreator(string id)
        {
            return new ControlBase(@"//select[@assignmentid=""{0}""]/ancestor::tr/td[2]".F(id), By.XPath);
        }

        public ControlBase AssignmentQualification(string id)
        {
            return new ControlBase(@"//select[@assignmentid=""{0}""]/ancestor::tr/td[3]".F(id), By.XPath);
        }
    }
}