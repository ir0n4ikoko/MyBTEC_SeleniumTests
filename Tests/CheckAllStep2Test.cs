using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CheckAllStep2Test : TestBase
    {
        [Test]
        public void ChildrenCheckedWithGroup()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickPassGroupAllForUnit(unitTitle)
                .AssertAllPassChildrenCheckboxesAreChecked(unitTitle)
                .ClickPassGroupAllForUnit(unitTitle)
                .AssertAllPassChildrenCheckboxesAreUnchecked(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .AssertAllMeritChildrenCheckboxesAreChecked(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .AssertAllMeritChildrenCheckboxesAreUnchecked(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertAllDistinctionChildrenCheckboxesAreChecked(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertAllDistinctionChildrenCheckboxesAreUnchecked(unitTitle);
        }

        [Test]
        public void ChildrenCheckedWithUnit()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickUnitSelectAll(unitTitle)
                .AssertAllPassChildrenCheckboxesAreChecked(unitTitle)
                .AssertAllMeritChildrenCheckboxesAreChecked(unitTitle)
                .AssertAllDistinctionChildrenCheckboxesAreChecked(unitTitle)
                .ClickUnitSelectAll(unitTitle)
                .AssertAllPassChildrenCheckboxesAreUnchecked(unitTitle)
                .AssertAllMeritChildrenCheckboxesAreUnchecked(unitTitle)
                .AssertAllDistinctionChildrenCheckboxesAreUnchecked(unitTitle);
        }

        [Test]
        public void GroupCheckedWithUnit()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickUnitSelectAll(unitTitle)
                .AssertSelectAllGroupPassIsChecked(unitTitle)
                .AssertSelectAllGroupMeritIsChecked(unitTitle)
                .AssertSelectAllGroupDistinctionIsChecked(unitTitle)
                .ClickUnitSelectAll(unitTitle)
                .AssertSelectAllGroupPassIsUnchecked(unitTitle)
                .AssertSelectAllGroupMeritIsUnchecked(unitTitle)
                .AssertSelectAllGroupDistinctionIsUnchecked(unitTitle);
        }

        [Test]
        public void UnitCheckedWithGroup()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickPassGroupAllForUnit(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickPassGroupAllForUnit(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreUnchecked(unitTitle);
        }

        [Test]
        public void UnitUncheckedWithChildren()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickPassGroupAllForUnit(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickPassChidren(unitTitle, UiConst.Criteria.P1)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickPassChidren(unitTitle, UiConst.Criteria.P1)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickMeritChidren(unitTitle, UiConst.Criteria.M1)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickMeritChidren(unitTitle, UiConst.Criteria.M1)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickDistinctionChidren(unitTitle, UiConst.Criteria.D1)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickDistinctionChidren(unitTitle, UiConst.Criteria.D1)
                .AssertSelectAllForUnitAreChecked(unitTitle);
        }

        [Test]
        public void UnitUncheckedWithGroup()
        {
            string unitTitle = UiConst.UnitCriteriaTitle.U_1_Fundamentals_of_Science;

            Start.LoginWithLIV()
                .CreateDefaultAssignmentTillStep2()
                .ClickPassGroupAllForUnit(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickPassGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickPassGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickMeritGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreUnchecked(unitTitle)
                .ClickDistinctionGroupAllForUnit(unitTitle)
                .AssertSelectAllForUnitAreChecked(unitTitle);
        }
    }
}