using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class AssignmentStep2Flow : BtecMasterFlow<AssignmentStep2Flow>
    {
        #region Constants and Fields

        private readonly AssignmentStep2Page page;

        #endregion

        #region Constructors and Destructors

        public AssignmentStep2Flow(INavigator navigator, AssignmentStep2Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        #endregion

        #region Public Methods

        public AssignmentStep2Flow CheckAllForUnit(string unitTitle)
        {
            page.GetUnitCheckAll(unitTitle).Click();

            return this;
        }

        public AssignmentStep2Flow CheckCriteria(params string[] criteria)
        {
            criteria.Where(id => page.Criterion(id).Displayed).ForEach(id => page.Criterion(id).Click());

            return this;
        }

        public AssignmentStep2Flow ClickDistinctionGroupAllForUnit(string unitTitle)
        {
            page.GetUnitGroupCheckAll(unitTitle, UiConst.GradeLevel.Distinction).Click();

            return this;
        }

        public AssignmentStep2Flow CheckGroupAllForUnit(string unitTitle, string group)
        {
            page.GetUnitGroupCheckAll(unitTitle, group).Click();

            return this;
        }

        public AssignmentStep2Flow ClickMeritGroupAllForUnit(string unitTitle)
        {
            page.GetUnitGroupCheckAll(unitTitle, UiConst.GradeLevel.Merit).Click();

            return this;
        }

        public AssignmentStep2Flow ClickPassGroupAllForUnit(string unitTitle)
        {
            page.GetUnitGroupCheckAll(unitTitle, UiConst.GradeLevel.Pass).Click();

            return this;
        }

        public AssignmentStep2Flow ClickPassChidren(string unitTitle, params string[] criteria)
        {
            return ClickChidren(unitTitle, UiConst.GradeLevel.Pass, criteria);
        }

        public AssignmentStep2Flow ClickMeritChidren(string unitTitle, params string[] criteria)
        {
            return ClickChidren(unitTitle, UiConst.GradeLevel.Merit, criteria);
        }

        public AssignmentStep2Flow ClickDistinctionChidren(string unitTitle, params string[] criteria)
        {
            return ClickChidren(unitTitle, UiConst.GradeLevel.Distinction, criteria);
        }

        public AssignmentStep2Flow ClickChidren(string unitTitle, string group, params string[] criteria)
        {
            CheckboxList criteriaCheckboxes = page.GetGroupFromUnit(unitTitle, group);

            List<Checkbox> slected = criteriaCheckboxes.Items.Where(x => criteria.Contains(x.Text)).ToList();

            slected.ForEach(x => x.Click());

            return this;
        }

        public AssignmentStep3Flow SaveAndContinue()
        {
            navigator.WaitForJQuery();

            var assignmentStep3Page =
                navigator.DoActionWaitForJQueryAndNavigate<AssignmentStep3Page>(page.SaveAndContinue.Click);

            return new AssignmentStep3Flow(navigator, assignmentStep3Page);
        }

        public AssignmentStep4Flow GoToLastStep()
        {
            navigator.WaitForJQuery();

            var assignmentStep4Page =
                navigator.DoActionWaitForJQueryAndNavigate<AssignmentStep4Page>(page.Step4Tab.Click);

            return new AssignmentStep4Flow(navigator, assignmentStep4Page);
        }

        public AssignmentStep2Flow SaveAndContinueWithError()
        {
            navigator.WaitForJQuery();

            page.SaveAndContinue.Click();

            return this;
        }

        public AssignmentStep2Flow ValidationErrorOk()
        {
            page.ValidationOk.Click();

            return this;
        }

        public EditAssignmentStep1Flow Previous()
        {
            var editAssignmentStep1Page =
                navigator.DoActionWaitForJQueryAndNavigate<EditAssignmentStep1Page>(page.Previous.Click);

            return new EditAssignmentStep1Flow(navigator, editAssignmentStep1Page);
        }

        public AssignmentStep2Flow ClickUnitSelectAll(string unitTitle)
        {
            Checkbox unitSelectAll = page.GetUnitCheckAll(unitTitle);

            unitSelectAll.Click();

            return this;
        }

        public AssignmentStep2Flow ClickLearningObjective(string learningObjectiveValue)
        {
            Checkbox learningObjective = page.LearningObjective(learningObjectiveValue);

            learningObjective.Click();

            return this;
        }

        public AssignmentStep2Flow SelectAllCriteria()
        {
            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(By.XPath("//input[@id='unit_Title_selectAll']"));
            if (chkbxs.Count < 1)
            {
                chkbxs = SeleniumContext.WebDriver.FindElements(By.XPath("//input[@id='LearningObjective']"));
            }

            chkbxs.Where(chkbx => chkbx.Displayed).ForEach(chkbx => chkbx.Click());

            return this;
        }

        #endregion

        #region Asserts

        public AssignmentStep2Flow AssertAllChildrenCheckboxesAreChecked(string unitTitle, string gradeLevel)
        {
            CheckboxList list = page.GetGroupFromUnit(unitTitle, gradeLevel);

            Assert.IsTrue(list.IsAllChecked);

            return this;
        }

        public AssignmentStep2Flow AssertAllChildrenCheckboxesAreUnchecked(string unitTitle, string gradeLevel)
        {
            CheckboxList list = page.GetGroupFromUnit(unitTitle, gradeLevel);

            Assert.IsTrue(list.IsAllUnchecked);

            return this;
        }

        public AssignmentStep2Flow AssertAllDistinctionChildrenCheckboxesAreChecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreChecked(unitTitle, UiConst.GradeLevel.Distinction);
        }

        public AssignmentStep2Flow AssertAllMeritChildrenCheckboxesAreChecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreChecked(unitTitle, UiConst.GradeLevel.Merit);
        }

        public AssignmentStep2Flow AssertAllPassChildrenCheckboxesAreChecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreChecked(unitTitle, UiConst.GradeLevel.Pass);
        }

        public AssignmentStep2Flow AssertAllDistinctionChildrenCheckboxesAreUnchecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreUnchecked(unitTitle, UiConst.GradeLevel.Distinction);
        }

        public AssignmentStep2Flow AssertAllMeritChildrenCheckboxesAreUnchecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreUnchecked(unitTitle, UiConst.GradeLevel.Merit);
        }

        public AssignmentStep2Flow AssertAllPassChildrenCheckboxesAreUnchecked(string unitTitle)
        {
            return AssertAllChildrenCheckboxesAreUnchecked(unitTitle, UiConst.GradeLevel.Pass);
        }

        public AssignmentStep2Flow AssertQualificationIs(string qualification)
        {
            string cellValue = page.Qualification.Text;

            Assert.AreEqual(qualification, cellValue);

            return this;
        }

        public AssignmentStep2Flow AssertSelectAllForUnitAreChecked(string unitTitle)
        {
            Checkbox checkAll = page.GetUnitCheckAll(unitTitle);

            Assert.IsTrue(checkAll.IsChecked);

            return this;
        }

        public AssignmentStep2Flow AssertSelectAllForUnitAreUnchecked(string unitTitle)
        {
            Checkbox checkAll = page.GetUnitCheckAll(unitTitle);

            Assert.IsFalse(checkAll.IsChecked);

            return this;
        }

        public AssignmentStep2Flow AssertSelectAllGroupPassIsChecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsChecked(unitTitle, UiConst.GradeLevel.Pass);
        }

        public AssignmentStep2Flow AssertSelectAllGroupPassIsUnchecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsUnchecked(unitTitle, UiConst.GradeLevel.Pass);
        }

        public AssignmentStep2Flow AssertSelectAllGroupMeritIsChecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsChecked(unitTitle, UiConst.GradeLevel.Merit);
        }

        public AssignmentStep2Flow AssertSelectAllGroupDistinctionIsChecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsChecked(unitTitle, UiConst.GradeLevel.Distinction);
        }

        public AssignmentStep2Flow AssertSelectAllForGroupIsChecked(string unitTitle, string group)
        {
            Checkbox groupSelectAll = page.GetUnitGroupCheckAll(unitTitle, group);

            Assert.IsTrue(groupSelectAll.IsChecked);

            return this;
        }

        public AssignmentStep2Flow AssertSelectAllForGroupIsUnchecked(string unitTitle, string group)
        {
            Checkbox groupSelectAll = page.GetUnitGroupCheckAll(unitTitle, group);

            Assert.IsFalse(groupSelectAll.IsChecked);

            return this;
        }

        public AssignmentStep2Flow AssertSelectAllGroupMeritIsUnchecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsUnchecked(unitTitle, UiConst.GradeLevel.Merit);
        }

        public AssignmentStep2Flow AssertSelectAllGroupDistinctionIsUnchecked(string unitTitle)
        {
            return AssertSelectAllForGroupIsUnchecked(unitTitle, UiConst.GradeLevel.Distinction);
        }

        public AssignmentStep2Flow AssertValidationForUnits(string[] units)
        {
            var validationTextForUnits = new StringBuilder();

            units.ForEach(
                unit => validationTextForUnits.Append(UI.ValidationAssessmentAndGradingCriteriaForUnit.F(unit)));

            Assert.AreEqual(UI.ValidationDidNotSucceed, page.ValidationErrorPopupTitle.Text);
            Assert.AreEqual(UI.ValidationAssessmentCriteriaMissing, page.ValidationErrorText.Text);
            Assert.AreEqual(validationTextForUnits.ToString(), page.ValidationErrorForUnits.Text);

            return this;
        }

        #endregion
    }
}