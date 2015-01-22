using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class AssignmentStep3Flow : BtecMasterFlow<AssignmentStep3Flow>
    {
        private readonly AssignmentStep3Page page;

        public AssignmentStep3Flow(INavigator navigator, AssignmentStep3Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public AssignmentStep3Flow SetScenario(string scenario)
        {
            page.Scenario.Text = scenario;

            return this;
        }

        public AssignmentStep3Flow SetTaskTile(string taskTitle)
        {
            page.Task1Tile.Text = taskTitle;

            return this;
        }

        public AssignmentStep3Flow SetTaskDescription(string taskDescription)
        {
            page.Task1Description.Text = taskDescription;

            return this;
        }

        public AssignmentStep3Flow SetEvidence(string evidence)
        {
            page.Evidence.Text = evidence;

            return this;
        }

        public AssignmentStep3Flow SetSourcesOfInformation(string evidence)
        {
            page.SourcesOfInformation.Text = evidence;

            return this;
        }

        public AssignmentStep3Flow ClickSelectCriteriaForTask()
        {
            navigator.ClickAndWaitForJQuery(page.SelectCriteriaForTask.Click);

            return this;
        }

        public AssignmentStep3Flow PopupTaskCriteriaClickOk()
        {
            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow CheckCriteriaThatTaskCovers(params string[] criteria)
        {
            criteria.Where(id => page.Criterion(id).Displayed).ToList().ForEach(id => page.Criterion(id).Click());

            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow AssertQualificationIs(string qualification)
        {
            string cellValue = page.Qualification.Text;

            Assert.AreEqual(qualification, cellValue);

            return this;
        }

        public AssignmentStep3Flow SetAssignmentDuration(string assignmentDuration)
        {
            page.AssignmentDuration.Text = assignmentDuration;

            return this;
        }

        public AssignmentStep4Flow SaveAndContinue()
        {
            var assignmentStep4Page =
                navigator.DoActionWaitForJQueryAndNavigate<AssignmentStep4Page>(page.SaveAndContinue.Click);

            return new AssignmentStep4Flow(navigator, assignmentStep4Page);
        }

        public AssignmentStep3Flow ClickSelectAllForUnit(string unitTitle)
        {
            Checkbox checkAll = page.SelectAll(unitTitle);

            checkAll.Click();

            return this;
        }

        public AssignmentStep3Flow ClickSelectAllLearningObjective(string unitTitle, string learningObjectiveTitle)
        {
            Checkbox selectAllLearningObjective = page.SelectAllLearningObjective(unitTitle, learningObjectiveTitle);

            selectAllLearningObjective.Click();

            return this;
        }

        public AssignmentStep3Flow AssertAllChildrenCheckboxesAreChecked(string unitTitle)
        {
            CheckboxList children = page.CriteriaForUnit(unitTitle);

            Assert.IsTrue(children.IsAllChecked);

            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow AssertAllChildrenCheckboxesAreUnchecked(string unitTitle)
        {
            CheckboxList children = page.CriteriaForUnit(unitTitle);

            Assert.IsTrue(children.IsAllUnchecked);

            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow ClickCriteria(string unitTitle, params string[] criteria)
        {
            CheckboxList children = page.CriteriaForUnit(unitTitle);

            List<Checkbox> slected = children.Items.Where(x => criteria.Contains(x.Text)).ToList();

            slected.ForEach(x => x.Click());

            return this;
        }

        public AssignmentStep3Flow AssertSelectAllGroupIsUnchecked(string unitTitle)
        {
            Checkbox unitCheckAll = page.SelectAll(unitTitle);

            Assert.IsFalse(unitCheckAll.IsChecked);

            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow AssertSelectAllGroupIsChecked(string unitTitle)
        {
            Checkbox unitCheckAll = page.SelectAll(unitTitle);

            Assert.IsTrue(unitCheckAll.IsChecked);

            navigator.ClickAndWaitForJQuery(page.OK.Click);

            return this;
        }

        public AssignmentStep3Flow CheckAllCheckboxes()
        {
            navigator.WaitForJQuery();
            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(By.Id("selectAll"));
            foreach (IWebElement webElement in chkbxs)
            {
                IWebElement chkbx = webElement;

                try
                {
                    new WebDriverWait(SeleniumContext.WebDriver, Configuration.Timeout).Until(d => chkbx.Displayed &&
                                                                                                   chkbx.Enabled);
                }
                catch (WebDriverException)
                {
                }

                if (webElement.Displayed)
                    webElement.Click();
            }
            return this;
        }

        public AssignmentStep3Flow AssertAllCheckboxesAreTicked()
        {
            navigator.WaitForJQuery();
            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(
                    By.XPath(".//div[@class='assignment_criterias']//input[@type='checkbox']"));

            chkbxs.Where(chkbx => chkbx.Displayed)
                .ToList()
                .ForEach(chkbx => Assert.IsTrue(chkbx.Selected, "Some checkboxes are not ticked"));

            return this;
        }

        public FlowResult<AssignmentStep3Flow> FillAllRequiredDataOnStep3(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }

            context.ID = page.Id;

            return new FlowResult<AssignmentStep3Flow>(page.Id)
            {
                Flow = SetScenario(context.Scenario)
                    .SetTaskTile(context.TaskTitle)
                    .SetTaskDescription(context.TaskDescription)
                    .SetEvidence(context.Evidence)
                    .ClickSelectCriteriaForTask()
                    .CheckAllCheckboxes()
                    .PopupTaskCriteriaClickOk()
                    .SetSourcesOfInformation(context.Sources)
                    .SetAssignmentDuration(context.Duration)
            };
        }

        public AssignmentStep3Flow CheckAllEnteredDataOnStep3(CreateAssignmentContext context)
        {
            string sourcesText = page.SourcesOfInformation.Text;
            sourcesText = sourcesText.Replace("\n", "");
            sourcesText = sourcesText.Replace("\r", "");
            sourcesText = Regex.Replace(sourcesText, "<.*?>", "");
            StringAssert.Contains(context.Scenario, page.Scenario.Text, "Scenario not saved");
            Assert.AreEqual(context.TaskTitle, page.Task1Tile.Text, "TaskTitle not saved");
            StringAssert.Contains(context.TaskDescription, page.Task1Description.Text, "TaskDescription not saved");
            Assert.AreEqual(context.Evidence, page.Evidence.Text, "Evidence not saved");
            StringAssert.Contains(context.Sources, sourcesText, "Sources not saved");
            Assert.AreEqual(context.Duration, page.AssignmentDuration.Text, "Duration not saved");
            ClickSelectCriteriaForTask();
            AssertAllCheckboxesAreTicked();

            return this;
        }
    }
}