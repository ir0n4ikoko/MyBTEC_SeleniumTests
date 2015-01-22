using System.Collections.ObjectModel;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class AssignmentStep4Flow : BtecMasterFlow<AssignmentStep4Flow>
    {
        private readonly AssignmentStep4Page page;

        public AssignmentStep4Flow(INavigator navigator, AssignmentStep4Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public string GetAssignmentId()
        {
            return page.Id;
        }

        public string GetAssignmentTitle()
        {
            return page.Title;
        }

        public AssignmentStep4Flow AssertQualificationIs(string qualification)
        {
            string cellValue = page.Qualification.Text;

            Assert.AreEqual(qualification, cellValue);

            return this;
        }

        public AssignmentsFlow ClickFinish()
        {
            var assignmentsPage = navigator.DoActionWaitUrlChangedAndNavigate<AssignmentsPage>(page.Finish.Click);

            return new AssignmentsFlow(navigator, assignmentsPage);
        }

        public FlowResult<AssignmentsFlow> ClickFinishResult()
        {
            return new FlowResult<AssignmentsFlow>(page.Id) {Flow = ClickFinish()};
        }

        public FlowResult<AssignmentsFlow> FinishWithStatusResult(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }

            context.ID = page.Id;

            if (context.Status.Equals(UI.WithIV))
            {
                return ClickSendToIv()
                    .SelectSendToIv(context.IV)
                    .ClickSaveandsendtoIVnow();
            }
            if (context.Status.Equals(UI.Approved))
            {
                return new FlowResult<AssignmentsFlow>(page.Id)
                {
                    Flow = ClickSendToIv()
                        .SelectSendToIv(context.IV)
                        .ClickSaveandsendtoIVnow()
                        .Next((asFlow, asId) => asFlow.ClickLogout()
                            .LoginWithAndGoToHomePage(context.IvLogin, context.IvPassword)
                            .GoToAssignments()
                            .Review(asId)
                            .ChooseIsAssignmentForWholeUnits()
                            .ChooseIsAssignmentApproved()
                            .CheckAllAcceptanceCriterias()
                            .SaveAndSend())
                };
            }
            if (context.Status.Equals(UI.NotApproved))
            {
                return new FlowResult<AssignmentsFlow>(page.Id)
                {
                    Flow = ClickSendToIv()
                        .SelectSendToIv(context.IV)
                        .ClickSaveandsendtoIVnow()
                        .Next((asFlow, asId) => asFlow.ClickLogout()
                            .LoginWithAndGoToHomePage(context.IvLogin, context.IvPassword)
                            .GoToAssignments()
                            .Review(asId)
                            .ChooseIsAssignmentForWholeUnits()
                            .ChooseIsAssignmentNotApproved()
                            .SetFeedback(context.IvFeedback)
                            .SaveAndSend())
                };
            }
            if (context.Status.Equals(UI.DDMReview) || context.Status.Equals(UI.ExternalTest) ||
                context.Status.Equals(UI.Authorised))
            {
                return new FlowResult<AssignmentsFlow>(page.Id)
                {
                    Flow = SetPearsonStatusAndNavigate(context.Status)
                };
            }

            return ClickFinishResult();
        }

        public ACSViewFlow SendtoAssignmentCheckingService()
        {
            page.SendtoAssignmentCheckingService.Click();

            return new ACSViewFlow(navigator, page.ACSPopUp);
        }

        public SendToIvFlow ClickSendToIv()
        {
            page.SendtoIV.Click();

            return new SendToIvFlow(navigator, page.SendToIvPopUp);
        }

        public AssignmentStep4Flow SetPearsonStatus(string status)
        {
            page.PearsonStatus.Text = status;

            return this;
        }

        public AssignmentStep4Flow AssertSendToAcsButtonExists(bool exists = true)
        {
            Assert.AreEqual(exists, page.SendtoAssignmentCheckingService.Enabled,
                "Unexpected [Send to ACS] button {0} on page".F(exists ? "does not exist" : "exists"));

            return this;
        }

        public AssignmentStep4Flow AssertSendToAcsButtonDisabled(string disabled = "true")
        {
            Assert.AreEqual(disabled, page.SendtoAssignmentCheckingService.GetAttribute("disabled"),
                "Unexpected [Send to ACS] button {0} on page".F(disabled.Equals("true") ? "is enabled" : "is disabled"));

            return this;
        }

        public AssignmentStep4Flow CheckWarningMessage(string text)
        {
            Assert.AreEqual(text, page.PopupWarningMessage.Text, "Incorrect popup warning message");
            SeleniumContext.WebDriver.FindElement(By.XPath("//div[contains(@aria-describedby, 'errorDiv')]//button[@type='button']")).Click();
            return this;
        }

        public AssignmentStep4Flow AssertSendToIvButtonDisabled(string disabled = "true")
        {
            Assert.AreEqual(disabled, page.SendtoIV.GetAttribute("disabled"),
                "Unexpected [Send to IV] button {0} on page".F(disabled.Equals("true") ? "is enabled" : "is disabled"));

            return this;
        }

        public AssignmentStep4Flow AssertSendToIvButtonExists(bool exists = true)
        {
            Assert.AreEqual(exists, page.SendtoIV.GetAttribute("disabled"),
                "Unexpected [Send to IV] button {0} on page".F(exists ? "does not exist" : "exists"));

            return this;
        }

        public AssignmentStep4Flow AssertRedWarningNoteExists(bool exists = true)
        {
            Assert.AreEqual(exists, page.RedWarningNote.Exists,
                "Red warning note {0} on page".F(exists ? "does not exist" : page.RedWarningNote.Text + " exists"));

            return this;
        }

        public AssignmentStep4Flow AssertRedWarningNoteTextCorrect(string text)
        {
            Assert.AreEqual(text, page.RedWarningNote.Text, "Incorrect text in red warning note");

            return this;
        }

        public AssignmentsFlow SetPearsonStatusAndNavigate(string status)
        {
            var asPage = navigator.DoActionWaitForJQueryAndNavigate<AssignmentsPage>(() => SetPearsonStatus(status));

            return new AssignmentsFlow(navigator, asPage);
        }

        public AssignmentStep4Flow CheckAssignmentStep4WarningMessageAndClosePopup(string text)
        {
            Assert.AreEqual(text, page.PopupWarningMessage.Text, "Incorrect popup warning message");
            SeleniumContext.WebDriver.FindElement(By.XPath("//div[contains(@aria-describedby, 'errorDiv')]//button[@type='button']")).Click();
            return this;
        }

        public AssignmentStep4Flow CheckTheQuantityOfUncoveredACs(int quantityOfAllACs)
        {
            ReadOnlyCollection<IWebElement> uncoveredACs = SeleniumContext.WebDriver.FindElements(By.CssSelector(".error"));
            Assert.AreEqual(quantityOfAllACs, uncoveredACs.Count, "Not all uncovered ACs are written with red color");

            return this;
        }


    }
}