using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseViewFlow : BtecMasterFlow<CourseViewFlow>
    {
        private readonly CourseViewPage page;

        public CourseViewFlow(INavigator navigator, CourseViewPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public CourseStep1Flow EditCourse()
        {
            var step1 = navigator.Navigate<CourseStep1Page>(page.EditCourse.Click);

            return new CourseStep1Flow(navigator, step1);
        }

        public CourseViewFlow DownloadCourse()
        {
            page.DownloadCourse.Click();

            return this;
        }

        public CourseViewAssignmentsFlow ViewCourseAssignments()
        {
            var assignmentsTab = navigator.Navigate<CourseViewAssignmentsTab>(page.AssignmentsTab.Click);

            return new CourseViewAssignmentsFlow(navigator, assignmentsTab);
        }

        public CourseViewTeamFlow ViewCourseTeam()
        {
            var teamTab = navigator.Navigate<CourseViewTeamTab>(page.TeamTab.Click);

            return new CourseViewTeamFlow(navigator, teamTab);
        }

        public CourseViewCoversheetsFlow GoToCoversheetsTab()
        {
            var coversheetsTab = navigator.Navigate<CourseViewCoversheetsTab>(page.CoversheetsTab.Click);

            return new CourseViewCoversheetsFlow(navigator, coversheetsTab);
        }

        public CourseViewFlow CheckCourseAssignmentsTabHidden()
        {
            Assert.IsFalse(page.AssignmentsTab.Enabled, "Assignments tab should be hidden");

            return this;
        }

        public CourseViewFlow CheckCoversheetsTabHidden()
        {
            Assert.IsFalse(page.CoversheetsTab.Enabled, "Coversheets tab should be hidden");

            return this;
        }

        public CourseViewFlow CheckFoldersTabHidden()
        {
            Assert.IsFalse(page.FoldersTab.Enabled, "Folders tab should be hidden");

            return this;
        }

        public ViewQualificationStep1Flow ViewQualificationCourseSummary()
        {
            var step1Page = navigator.Navigate<ViewQualificationStep1Page>(page.ViewQualificationCourseSummary.Click);

            return new ViewQualificationStep1Flow(navigator, step1Page);
        }
    }
}