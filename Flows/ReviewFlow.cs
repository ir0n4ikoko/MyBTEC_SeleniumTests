using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ReviewFlow : BtecMasterFlow<ReviewFlow>
    {
        private readonly ReviewPage page;

        public ReviewFlow(INavigator navigator, ReviewPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ReviewFlow ChooseIsAssignmentForWholeUnits()
        {
            page.AssignmentCoverage.Value = "WholeUnits";

            return this;
        }

        public ReviewFlow SelectAreAssessmentCriteriaAddressedByEachTask()
        {
            page.AreAssessmentCriteriaAddressedByEachTask.Click();

            return this;
        }

        public ReviewFlow SelectAreActivitiesAppropriate()
        {
            page.AreActivitiesAppropriate.Click();

            return this;
        }

        public ReviewFlow SelectIsAppropriateScenario()
        {
            page.IsAppropriateScenario.Click();

            return this;
        }

        public ReviewFlow SelectIsAppropriateLanguage()
        {
            page.IsAppropriateLanguage.Click();

            return this;
        }

        public ReviewFlow SelectIsAssignmentFitForPurpose()
        {
            page.IsAssignmentFitForPurpose.Click();

            return this;
        }

        public ReviewFlow CheckAllAcceptanceCriterias()
        {
            return SelectAreAssessmentCriteriaAddressedByEachTask()
                .SelectAreActivitiesAppropriate()
                .SelectIsAppropriateScenario()
                .SelectIsAppropriateLanguage()
                .SelectIsAssignmentFitForPurpose();
        }

        public ReviewFlow ChooseIsAssignmentApproved()
        {
            page.ChooseIsAssignmentApproved.Click();

            return this;
        }

        public ReviewFlow ChooseIsAssignmentNotApproved()
        {
            page.ChooseIsAssignmentNotApproved.Click();

            return this;
        }

        public ReviewFlow SetFeedback(string text)
        {
            page.ReviewFeedback.Text = text;

            return this;
        }

        public AssignmentsFlow SaveAndSend()
        {
            var assignmentsPage = navigator.Navigate<AssignmentsPage>(page.SaveAndSend.Click);

            return new AssignmentsFlow(navigator, assignmentsPage);
        }

        public ReviewFlow ClickSaveAndSendError()
        {
            page.SaveAndSend.Click();

            return this;
        }

        public ReviewFlow AssertAssignmentCoverageIsNotValid()
        {
            Assert.IsFalse(page.AssignmentCoverage.IsValid);

            Assert.AreEqual(UI.ValidationAssignmentCoverage, page.AssignmentCoverage.ValidationMessage);

            return this;
        }

        public ReviewFlow AssertQualificationIs(string qualification)
        {
            string cellValue = page.Qualification().Text;

            Assert.AreEqual(qualification, cellValue);

            return this;
        }
    }
}