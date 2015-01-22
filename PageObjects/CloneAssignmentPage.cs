using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CloneAssignmentPage : PageBase
    {
        public CloneAssignmentPage()
            : base(UI.CloneAssignmentPage)
        {
        }

        public PopupButton WarningConfirm
        {
            get { return new PopupButton(UI.OK, "confirm"); }
        }

        public PopupButton WarningCancel
        {
            get { return new PopupButton(UI.Cancel, "confirm"); }
        }

        public PopupButton CloneCancel
        {
            get { return new PopupButton(UI.Cancel, "cloneAssignmentPopUp"); }
        }

        public Label PopUpContent(string id)
        {
            return new Label(id);
        }
    }
}