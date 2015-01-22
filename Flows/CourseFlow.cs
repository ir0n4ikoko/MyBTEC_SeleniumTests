using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseFlow : BtecMasterFlow<CourseFlow>
    {
        private readonly CoursePage page;

        public CourseFlow(INavigator navigator, CoursePage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public CourseViewFlow ViewCourse(string courseId)
        {
            var courseViewPage =
                navigator.DoActionWaitForJQueryAndNavigate<CourseViewPage>(() => page.SelectViewCourse(courseId));

            return new CourseViewFlow(navigator, courseViewPage);
        }
        
        public CourseFlow GoToCentreCourses()
        {
            page.CentreCoursesTab.Click();

            navigator.WaitForJQuery();

            return this;
        }

        public CourseFlow CheckCourseActions(string id, IEnumerable<string> actions)
        {
            navigator.WaitForJQuery();

            IEnumerable<string> courseActions = page.Actions(id).Options;

            CollectionAssert.AreEqual(actions.OrderBy(t => t), courseActions.OrderBy(t => t),
                StringComparer.OrdinalIgnoreCase);

            return this;
        }

        public CourseFlow CheckCourseActionsByName(string name, IEnumerable<string> actions)
        {
            navigator.WaitForJQuery();

            IEnumerable<string> courseActions = page.ActionsByName(name).Options;

            CollectionAssert.AreEqual(actions.OrderBy(t => t), courseActions.OrderBy(t => t),
                StringComparer.OrdinalIgnoreCase);

            return this;
        }

        public CourseFlow CheckCreateCourseButton(bool exist = true)
        {
            Assert.AreEqual(exist, page.CreateCourse.Enabled, "[Create course] button is hidden");

            return this;
        }


        public ViewQualificationStep1Flow ViewQualificationCourses()
        {
            var step1Page = navigator.Navigate<ViewQualificationStep1Page>(page.ViewQualificationCourses.Click);

            return new ViewQualificationStep1Flow(navigator, step1Page);
        }

        public CourseFlow CreateAllCourses()
        {
            var reader = new StreamReader(File.OpenRead(Configuration.DownloadDir + "\\Qualifications.txt"));

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(';');
                for (int i = 0; i < values.Count(); i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                var courseContext = new CreateCourseContext
                {
                    Subject = values[0],
                    Qualification = values[1],
                    Pathway = values[2],
                    Size = values[3]
                };
                CreateCourseAsDraft(courseContext);
            }

            return this;
        }

        public CourseViewFlow ClickOnThisCourse(string courseName)
        {
            var openCoursePage = navigator.DoActionWaitForJQueryAndNavigate<CourseViewPage>(page.ThisCourse(courseName).Click);

            return new CourseViewFlow(navigator, openCoursePage);
        }

        public CourseFlow CheckCourseVisiblity(string courseTitle, bool isVisible = true)
        {
            Assert.AreEqual(page.ThisCourse(courseTitle).Exists, isVisible);
            return this;
        }
    }
}