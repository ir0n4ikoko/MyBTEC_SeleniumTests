using System;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CheckAllStep3Test : TestBase
    {
        [Test]
        public void ChildrenCheckedWithUnitStep3()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep3()
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreChecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreUnchecked(unitTitle);
        }

        [Test]
        public void GroupCheckedWithUnitStep3()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep3()
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreChecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickCriteria(unitTitle, UiConst.Criteria.P1)
                .AssertSelectAllGroupIsUnchecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickCriteria(unitTitle, UiConst.Criteria.P1)
                .AssertSelectAllGroupIsChecked(unitTitle);
        }

        [Test]
        public void NQFChildrenCheckedWithGroupStep3()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_Preparation_Performance_and_Production;

            Start.LoginWithLIV()
                .CreateDefaultNQFAssignmentTillStep3()
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .ClickSelectAllLearningObjective(unitTitle, UiConst.LearningObjective.L_503_6471_LOA_Title)
                .AssertAllChildrenCheckboxesAreChecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickSelectAllLearningObjective(unitTitle, UiConst.LearningObjective.L_503_6471_LOA_Title)
                .AssertAllChildrenCheckboxesAreUnchecked(unitTitle);
        }

        [Test]
        public void NQFChildrenCheckedWithUnitStep3()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_Preparation_Performance_and_Production;

            Start.LoginWithLIV()
                .CreateDefaultNQFAssignmentTillStep3()
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreChecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreUnchecked(unitTitle);
        }

        [Test]
        public void NQFGroupCheckedWithUnitStep3()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_Preparation_Performance_and_Production;

            Start.LoginWithLIV()
                .CreateDefaultNQFAssignmentTillStep3()
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .ClickSelectAllForUnit(unitTitle)
                .AssertAllChildrenCheckboxesAreChecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickCriteria(unitTitle, UiConst.Criteria.L_2A_P1)
                .AssertSelectAllGroupIsUnchecked(unitTitle)
                .ClickSelectCriteriaForTask()
                .ClickCriteria(unitTitle, UiConst.Criteria.L_2A_P1)
                .AssertSelectAllGroupIsChecked(unitTitle);
        }
    }
}