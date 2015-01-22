using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class UserRoleApprovalFlow : BtecMasterFlow<UserRoleApprovalFlow>
    {
        private readonly UserRoleApprovalPage page;

        public UserRoleApprovalFlow(INavigator navigator, UserRoleApprovalPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public UserRoleApprovalFlow Approve(string name, string subject, string role)
        {
            page.Approve(name, subject, role, UI.Yes).Click();

            navigator.WaitForJQuery();

            Confirm();

            return this;
        }

        public UserRoleApprovalFlow ApproveAll(string name, string role)
        {
            page.ClaimedRolesGrid.ElementsPerPage.Value = "100";

            navigator.WaitForJQuery();

            page.Approve(name, role);

            navigator.WaitForJQuery();

            Confirm();

            return this;
        }

        public UserRoleApprovalFlow Decline(string name, string subject, string role)
        {
            page.Approve(name, subject, role, UI.No).Click();

            navigator.WaitForJQuery();

            Confirm();

            return this;
        }

        public UserRoleApprovalFlow Confirm()
        {
            page.Confirm().Click();

            var userRoleApprovalPage =
                navigator.DoActionWaitForJQueryAndNavigate<UserRoleApprovalPage>(page.ConfirmApprove().Click);

            return new UserRoleApprovalFlow(navigator, userRoleApprovalPage);
        }

        public UserRoleApprovalFlow SetElementsPerPage100()
        {
            if (!page.ClaimedRolesGrid.ElementsPerPage.Value.Equals("100"))
            {
                navigator.WaitForJQuery();
                page.ClaimedRolesGrid.ElementsPerPage.Value = "100";
            }
            return this;
        }
    }
}