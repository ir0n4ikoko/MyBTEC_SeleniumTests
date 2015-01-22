using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class AssignmentsFlow : BtecMasterFlow<AssignmentsFlow>
    {
        private readonly AssignmentsPage page;

        public AssignmentsFlow(INavigator navigator, AssignmentsPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public AssignmentsFlow GoToCentreAssignments()
        {
            navigator.WaitForJQuery();
            navigator.ClickAndWaitForJQuery(page.CentreAssignmentsLink.Click);

            return this;
        }

        public AssignmentsFlow GoToMyAssignments()
        {
            navigator.ClickAndWaitForJQuery(page.MyAssignmentsLink.Click);

            return this;
        }

        public AssignmentsFlow SelectAction(string action, string id)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";

            navigator.WaitForJQuery();
            
            Dropdown actionsDropdown = page.Actions(grid, id);
            actionsDropdown.Click();

            navigator.WaitForJQuery();

            actionsDropdown.Text = action;

            navigator.WaitForJQuery();

            return this;
        }

        public AssignmentsFlow SelectActionForAssignment(string action, string assignmentTitle)
        {
            Dropdown actionsDropdown = page.ActionsByName(assignmentTitle);

            actionsDropdown.Text = action;

            navigator.WaitForJQuery();

            return this;
        }

        public AssignmentsFlow ConfirmRemoving(bool ok = true)
        {
            page.ConfirmRemoving(ok).Click();

            navigator.WaitForJQuery();

            return this;
        }

        public AssignmentsFlow ConfirmRestore(bool ok = true)
        {
            page.ConfirmRestore(ok).Click();

            return this;
        }

        public AssignmentsFlow AssertAssignmentDisplayed(string id, bool displayed = true)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";

            navigator.WaitForJQuery();

            Assert.AreEqual(displayed, page.Actions(grid, id).Displayed,
                "Assignment with id {0} was {1} found".F(id, (displayed ? "not" : "")));

            return this;
        }

        public AssignmentsFlow SelectStatus(string status, string id)
        {
            Dropdown statusDropdown = page.Statuses(id);
            statusDropdown.Text = status;

            return this;
        }

        public SendToIvFlow SelectActionSendToIv(string id)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";
            
            SelectAction(UI.SendToIV, id);

            return new SendToIvFlow(navigator, page.SendToIvPopUp);
        }

        public ReviewFlow Review(string id)
        {
            var reviewPage = navigator.DoActionWaitForJQueryAndNavigate<ReviewPage>(() => SelectAction(UI.Review, id));

            return new ReviewFlow(navigator, reviewPage);
        }

        public EditAssignmentStep1Flow Edit(string id)
        {
            navigator.WaitForJQuery();

            var editPage = navigator.Navigate<EditAssignmentStep1Page>(() => SelectAction(UI.Edit, id));

            return new EditAssignmentStep1Flow(navigator, editPage);
        }

        public AssignmentsFlow SelectAddToCourse(string courseId)
        {
            page.GridEntity(courseId).Click();

            navigator.ClickAndWaitForJQuery(page.AddToCourse.Click);

            return this;
        }

        public AssignmentsFlow LinkAssignmentToCourse(string assignmentId, string courseId)
        {
            return SelectAction(UI.LinkToCourses, assignmentId).SelectAddToCourse(courseId);
        }

        public ACSViewFlow SendtoAssignmentCheckingService(string assignmentId)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";

            SelectAction(UI.SendToACS, assignmentId);
            return new ACSViewFlow(navigator, page.ACSPopUp);
        }

        public CloneAssignmentFlow Clone(string assignmentId)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";
            
            SelectAction(UI.Clone, assignmentId);

            return new CloneAssignmentFlow(navigator, page.CloneAssignmentPopUp);
        }

        public AssignmentsFlow CheckCreateAssignmentButton(bool exist)
        {
            Assert.AreEqual(exist, page.CreateAssignment.Enabled, "[Create assignment] button is hidden");

            return this;
        }

        public AssignmentsFlow CheckCentreAssignment(bool exist)
        {
            Assert.AreEqual(exist, page.CentreAssignmentsLink.Enabled);

            return this;
        }

        public AssignmentsFlow CheckActionList(string assignmentTitle, IEnumerable<string> actions)
        {
            navigator.WaitForJQuery();
            IEnumerable<string> actualActions = page.ActionsByName(assignmentTitle).Options;
            IEnumerable<string> difference = actualActions.Except(actions, StringComparer.OrdinalIgnoreCase);
            Assert.IsEmpty(difference);
            return this;
        }

        public AssignmentsFlow CheckAssignmentGridWarningMessageAndClosePopup(string text)
        {
            Assert.AreEqual(text, page.PopupWarningMessage.Text, "Incorrect popup warning message");
            SeleniumContext.WebDriver.FindElement(By.XPath("//div[contains(@aria-describedby, 'errorDiv')]//button[@type='button']")).Click();

            return this;
        }


        public AssignmentsFlow CreateAllAssignments()
        {
            var reader = new StreamReader(File.OpenRead(Configuration.DownloadDir + "\\Qualifications.txt"));

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(';');
                for (int i = 0; i < values.Count(); i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                var assignmentContext = new CreateAssignmentContext
                {
                    Subject = values[0],
                    Qualification = values[1],
                    Pathway = values[2],
                    Size = values[3],
                    FirstUnit = true
                };
                CreateAssignment(assignmentContext);
            }

            return this;
        }

        #region Asserts..

        public AssignmentsFlow AssertAssignmentStatusIs(string status, string id)
        {
            navigator.WaitForJQuery();

            Assert.AreEqual(status, page.Status(id).Text, "Incorrect assignment status for id={0}".F(id));

            return this;
        }

        public AssignmentsFlow AssertActions(IEnumerable<string> actions, string id)
        {
            navigator.WaitForJQuery();

            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";
            page.Actions(grid, id).Click();

            navigator.WaitForJQuery();
            CollectionAssert.AreEqual(actions.OrderBy(t => t), page.Actions(grid, id).Options.ToList().OrderBy(t => t),
                StringComparer.OrdinalIgnoreCase);

            return this;
        }

        public AssignmentsFlow AssertPearsonStatusesDropdown(IEnumerable<string> statuses, string id)
        {
            string[] difference = page.Statuses(id).Options.Except(statuses).ToArray();

            Assert.IsFalse(difference.Any(), "Statuses differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public AssignmentsFlow AssertCreatorIs(string creatorName, string id)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";

            string creatorCellValue = page.Creator(grid, id).Text;

            Assert.AreEqual(creatorName, creatorCellValue);

            return this;
        }

        public AssignmentsFlow AssertQualificationIs(string qualification, string id)
        {
            string grid = page.MyAssignmentsLink.GetAttribute("class").Equals("active")
                ? "myAssignmentsGrid"
                : "centreAssignmentsGrid";

            string cellValue = page.Qualification(grid, id).Text;

            Assert.AreEqual(qualification, cellValue);

            return this;
        }

        public AssignmentsFlow AssertSubjectDropdownAreEqual(string subject)
        {
            Assert.AreEqual(page.SubjectDropdown().Text, subject);

            return this;
        }

        public AssignmentsFlow AssertQualificationDropdownAreEqual(string subject)
        {
            Assert.AreEqual(page.QualificationDropdown().Text, subject);

            return this;
        }

        public AssignmentsFlow AssertPathwayDropdownAreEqual(string subject)
        {
            Assert.AreEqual(page.PathwayDropdown().Text, subject);

            return this;
        }

        public AssignmentsFlow AssertSizeDropdownAreEqual(string subject)
        {
            Assert.AreEqual(page.SizeDropdown().Text, subject);

            return this;
        }

        public AssignmentsFlow AssertAllUnitsAreSelected(long unitCount)
        {
            string[] pageUnitsList = page.UnitsSelected().Text.Split(',');

            Assert.AreEqual(unitCount, pageUnitsList.Count());

            return this;
        }

        public AssignmentsFlow AssertInfoMessage(string message)
        {
            StringAssert.Contains(page.InfoMessage.Text, message, "Incorrect info message");

            return this;
        }

        #endregion
    }
}