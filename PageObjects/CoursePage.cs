using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CoursePage : BtecMasterPage
    {
        public CoursePage() : base(UI.CoursesPage)
        {
        }

        public Link CreateCourse
        {
            get { return new Link("createCourseLink"); }
        }

        public Link ViewQualificationCourses
        {
            get { return new Link(".//div[contains(@class, 'buttons_panel')]/a[text()='{0}']".F(UI.ViewQualification), By.XPath); }
        }

        public Link CentreCoursesTab
        {
            get { return new Link("courseSearchTab"); }
        }

        public ClickableControl CoursesGridNameColumn
        {
            get { return new ClickableControl("jqgh_table_myCoursesGrid_Name"); }
        }

        public void SelectViewCourse(string courseId)
        {
            Actions(courseId).Text = UI.View;
        }

        public Dropdown Actions(string id)
        {
            return new Dropdown("courseAction{0}".F(id));
        }

        public Dropdown ActionsByName(string courseName)
        {
            return
                new Dropdown(@"//tr[descendant::td[@title='{0}']]//select[contains(@id,'courseAction')]".F(courseName),
                    By.XPath);
        }

        public Link ThisCourse(string courseName)
        {
            return new Link("//a[text()='{0}']".F(courseName), By.XPath);
        }
    }
}