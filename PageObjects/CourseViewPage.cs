using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseViewPage : BtecMasterPage
    {
        public CourseViewPage()
            : base(UI.CourseViewPage)
        {
        }

        public Link CourseSummaryTab
        {
            get { return new Link("courseSummaryLink"); }
        }

        public Link CourseUnitsTab
        {
            get { return new Link("courseUnitsLink"); }
        }

        public Link PlanningTab
        {
            get { return new Link("planningLink"); }
        }

        public Link SupportTab
        {
            get { return new Link("courseResourcesLink"); }
        }

        public Link AssignmentsTab
        {
            get { return new Link("courseAssignmentsLink"); }
        }

        public Link TeamTab
        {
            get { return new Link("courseTeamLink"); }
        }

        public Link CoversheetsTab
        {
            get { return new Link("coverSheetsLink"); }
        }

        public Link FoldersTab
        {
            get { return new Link("courseFoldersLink"); }
        }

        public Link EditCourse
        {
            get { return new Link(UI.EditCourse, By.LinkText); }
        }

        public Link CloneCourse
        {
            get { return new Link(UI.CloneCourse, By.LinkText); }
        }

        public Link DownloadCourse
        {
            get { return new Link(UI.DownloadCourse, By.LinkText); }
        }
        public Link ViewQualificationCourseSummary
        {
            get { return new Link(".//div[contains(@class, 'course_menu')]//a[text()='View qualification']", By.XPath); }
        }
    }
}