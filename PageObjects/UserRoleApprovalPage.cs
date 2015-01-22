using System;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class UserRoleApprovalPage : BtecMasterPage
    {
        public UserRoleApprovalPage()
            : base(UI.UserRoleApprovalPage)
        {
        }

        public GridControl ClaimedRolesGrid
        {
            get { return new GridControl("gbox_table_CourseDeliveryTeamList", "CourseDeliveryTeamList"); }
        }

        public GridCheckbox Approve(string name, string subject, string role, string approve)
        {
            string approveRadioBtnPath =
                "//tr/td[contains(text(),'" + name + "')]" +
                "/following-sibling::td[contains(text(),'" + subject + "')]" +
                "/following-sibling::td/img[contains(@name,'" + role + "')]" +
                "/parent::td/following-sibling::td/.//input[@value='" + approve + "']";

            var approveRole = new GridCheckbox(approveRadioBtnPath, "CourseDeliveryTeamList");

            try
            {
                approveRole.Click();
            }
            catch (NullReferenceException)
            {
                Assert.Fail("Not found role:" + name + "," + subject + "," + role);
            }
            return approveRole;
        }

        public void Approve(string name, string role)
        {
            string approveRadioBtnPath =
                "//tr/td[contains(text(),'" + name + "')]" +
                "/following-sibling::td/img[contains(@name,'" + role + "')]" +
                "/parent::td/following-sibling::td/.//input[@value='" + UI.Yes + "']";

            var approveRole = new GridCheckbox(approveRadioBtnPath, "CourseDeliveryTeamList");

            try
            {
                approveRole.CheckAll(approveRadioBtnPath);
            }
            catch (NullReferenceException e)
            {
                Assert.Fail("Not found role:" + name + "," + role);
            }
        }

        public ClickableControl Confirm()
        {
            return new ClickableControl("confirmClaim");
        }

        public PopupButton ConfirmApprove(bool clickYes = true)
        {
            return new PopupButton(clickYes ? UI.Yes : UI.No, "confirmClaimDialog");
        }
    }
}