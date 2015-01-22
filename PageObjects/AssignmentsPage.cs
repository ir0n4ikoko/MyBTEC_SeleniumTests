using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using Edi.Advance.Core.Common.Extentions;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class AssignmentsPage : BtecMasterPage
    {
        private ACSViewPage acsViewPopUp;

        private CloneAssignmentPage clonePopUp;
        private SendToIvPage sendToIvPopUp;

        public AssignmentsPage()
            : base(UI.AssignmentsPage)
        {
        }

        public Link CreateAssignment
        {
            get { return new Link("createAssignmentLink"); }
        }

        public Link CentreAssignmentsLink
        {
            get { return new Link("centerAssignmentLink"); }
        }

        public Link MyAssignmentsLink
        {
            get { return new Link("myAssignmentLink"); }
        }

        public PopupButton AddToCourse
        {
            get { return new PopupButton(UI.AddToCourse, "addToCoursePopUp"); }
        }

        public ACSViewPage ACSPopUp
        {
            get
            {
                if (acsViewPopUp.IsNull())
                {
                    acsViewPopUp = new ACSViewPage();
                }
                return acsViewPopUp;
            }
        }

        public SendToIvPage SendToIvPopUp
        {
            get
            {
                if (sendToIvPopUp.IsNull())
                {
                    sendToIvPopUp = new SendToIvPage();
                }
                return sendToIvPopUp;
            }
        }

        public CloneAssignmentPage CloneAssignmentPopUp
        {
            get
            {
                if (clonePopUp.IsNull())
                {
                    clonePopUp = new CloneAssignmentPage();
                }

                return clonePopUp;
            }
        }

        public Dropdown Actions(string grid, string id)
        {
            return new Dropdown(".//table[@id='table_{0}']//select[@id='assignmentAction{1}']".F(grid, id), By.XPath);
        }

        public Dropdown ActionsByName(string assignmentName)
        {
            return
                new Dropdown(
                    @"//tr[descendant::td[@title='{0}']]//select[contains(@id,'assignmentAction')]".F(assignmentName),
                    By.XPath);
        }

        public Dropdown Statuses(string id)
        {
            return new Dropdown("assignmentStatus{0}".F(id));
        }

        public Dropdown SendToIV()
        {
            return new Dropdown("IV");
        }

        public Checkbox GridEntity(string id)
        {
            return new Checkbox("cb_{0}".F(id));
        }

        public PopupButton ConfirmRemoving(bool ok = true)
        {
            return new PopupButton(ok ? UI.Yes : UI.No, "removePopup");
        }

        public PopupButton ConfirmRestore(bool ok = true)
        {
            return new PopupButton(ok ? UI.OK : UI.Cancel, "restorePopup");
        }

        public Label Status(string id)
        {
            return new Label("assignmentStatus{0}".F(id));
        }

        public ControlBase Qualification(string grid, string id)
        {
            return
                new ControlBase(
                    @".//select[@id='assignmentAction{0}']/../../td[@aria-describedby='table_{1}_QualificationName']".F(
                        id, grid), By.XPath);
        }

        public ControlBase Creator(string grid, string id)
        {
            return
                new ControlBase(
                    @".//select[@id='assignmentAction{0}']/../../td[@aria-describedby='table_{1}_Owner']".F(id,
                        grid), By.XPath);
        }

        public Dropdown SubjectDropdown()
        {
            return new Dropdown("Subjectdropdown");
        }

        public Dropdown QualificationDropdown()
        {
            return new Dropdown("Qualificationdropdown");
        }

        public Dropdown PathwayDropdown()
        {
            return new Dropdown("Pathwaydropdown");
        }

        public Dropdown SizeDropdown()
        {
            return new Dropdown("Sizedropdown");
        }

        public HiddenControl UnitsSelected()
        {
            return new HiddenControl("unitExclude");
        }

        public Label PopupWarningMessage
        {
            get { return new Label("errorDiv"); }
        }
    }
}