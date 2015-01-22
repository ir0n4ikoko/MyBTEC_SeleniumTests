using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class SendToIvFlow : BtecMasterFlow<SendToIvFlow>
    {
        private readonly SendToIvPage page;

        public SendToIvFlow(INavigator navigator, SendToIvPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public SendToIvFlow SelectSendToIv(string ivName = "Auto IV")
        {
            page.IV.Text = ivName;

            navigator.WaitForJQuery();

            return this;
        }

        public SendToIvFlow ClickSendToIvError()
        {
            page.SendToIV.Click();

            return this;
        }

        public FlowResult<AssignmentsFlow> ClickSendToIv()
        {
            string id = page.Id;

            var assignmentsPage = navigator.DoActionWaitForJQueryAndNavigate<AssignmentsPage>(page.SendToIV.Click);

            return new FlowResult<AssignmentsFlow>(id)
            {
                Flow = new AssignmentsFlow(navigator, assignmentsPage)
            };
        }

        public SendToIvFlow AssertIVRequiredErrorIsPresent()
        {
            navigator.WaitForJQuery();

            Assert.IsFalse(page.IV.IsValid);

            Assert.AreEqual(page.IV.ValidationMessage, UI.ValidationFieldRequired.F(UI.IV));

            return this;
        }

        public FlowResult<AssignmentsFlow> ClickSaveandsendtoIVnow()
        {
            string id = page.Id;

            var assignmentsPage =
                navigator.DoActionWaitUrlChangedAndNavigate<AssignmentsPage>(page.SaveandsendToIVnow.Click);

            return new FlowResult<AssignmentsFlow>(id) {Flow = new AssignmentsFlow(navigator, assignmentsPage)};
        }

        public SendToIvFlow ClickSaveandsendtoIVnowWithError()
        {
            page.SaveandsendToIVnow.Click();

            return this;
        }

        public AssignmentsFlow SaveAndSendToIVnow()
        {
            var assignmentPage =
                navigator.DoActionWaitUrlChangedAndNavigate<AssignmentsPage>(page.SaveandsendToIVnow.Click);
            return new AssignmentsFlow(navigator, assignmentPage);
        }

        public FlowResult<AssignmentsFlow> ClickSaveandsendtoIVlater()
        {
            string id = page.Id;

            var assignmentsPage =
                navigator.DoActionWaitUrlChangedAndNavigate<AssignmentsPage>(page.SaveandsendtoIVlater.Click);

            return new FlowResult<AssignmentsFlow>(id) {Flow = new AssignmentsFlow(navigator, assignmentsPage)};
        }
    }
}