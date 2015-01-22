using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CloneAssignmentFlow : FlowBase<CloneAssignmentFlow>
    {
        private readonly CloneAssignmentPage page;

        public CloneAssignmentFlow(INavigator navigator, CloneAssignmentPage page)
            : base(navigator)
        {
            this.page = page;
        }

        public CloneAssignmentFlow AssertWarningPopUpHasOpened()
        {
            Assert.AreEqual(UI.NoteCloneAssignment, page.PopUpContent("confirm").Text);

            return this;
        }

        public CloneAssignmentFlow AssertWarningConfirmation()
        {
            Assert.AreEqual(UI.NoteCloneAssignment, page.PopUpContent("confirm").Text);

            page.WarningConfirm.Click();

            return this;
        }

        public CloneAssignmentFlow AssertClonePopUpHasOpened()
        {
            page.CloneCancel.Click();

            return this;
        }

        public CloneAssignmentFlow AssertClonePopUpWithNote()
        {
            Assert.AreEqual(UI.NoteCloneAssignment, page.PopUpContent("cloneAssignmentNote").Text);
            page.CloneCancel.Click();

            return this;
        }

        public void AssertWarningNotificationWhenCloneHasPerformed()
        {
            AssertWarningPopUpHasOpened();
            AssertWarningConfirmation();
            AssertClonePopUpHasOpened();
        }
    }
}