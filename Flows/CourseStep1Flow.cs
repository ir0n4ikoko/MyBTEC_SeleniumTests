using System;
using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseStep1Flow : SelectQualificationFlow<CourseStep1Flow>
    {
        private readonly CourseStep1Page page;

        public CourseStep1Flow(INavigator navigator, CourseStep1Page page)
            : base(navigator, page)
        {
            this.page = page;
        }


        public CourseStep1Flow SetName(string name)
        {
            page.Name.Text = name;

            return this;
        }

        public CourseStep2Flow Continue()
        {
            var courseStep2Page = navigator.DoActionWaitForJQueryAndNavigate<CourseStep2Page>(page.Continue.Click);

            return new CourseStep2Flow(navigator, courseStep2Page);
        }

        public CourseStep1Flow CheckValidation()
        {
            page.Continue.Click();

            Assert.AreEqual(UI.ValidationFieldRequired.F(UI.Subject), page.SubjectValid.ValidationMessage);
            Assert.AreEqual(UI.ValidationFieldRequired.F(UI.QualificationSuite),
                page.QualificationSuiteValid.ValidationMessage);
            Assert.AreEqual(UI.ValidationFieldRequired.F(UI.Pathway), page.PathwayValid.ValidationMessage);
            Assert.AreEqual(UI.ValidationFieldRequired.F(UI.Size), page.SizeValid.ValidationMessage);

            return this;
        }

        public CourseStep1Flow Exit()
        {
            page.Exit.Click();

            return this;
        }

        public CourseFlow ExitConfirm()
        {
            var coursesPage = navigator.DoActionWaitForJQueryAndNavigate<CoursePage>(page.ExitConfirm().Click);

            return new CourseFlow(navigator, coursesPage);
        }

        public CourseFlow CheckExit()
        {
            Exit();

            Assert.AreEqual(UI.ConfirmExitCourseStep1New, page.ExitConfirmText.Text);

            page.ExitConfirm(false);

            Exit();

            var coursesPage = navigator.DoActionWaitForJQueryAndNavigate<CoursePage>(page.ExitConfirm().Click);

            return new CourseFlow(navigator, coursesPage);
        }

        public CourseStep1Flow SubjectListCheck(IEnumerable<string> subjectList)
        {
            IEnumerable<string> currentSubjectList = page.Subject.Options;
            IEnumerable<string> difference = currentSubjectList.Except(subjectList, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(difference.Last(), UI.SelectSubject);
            return this;
        }

        public CourseStep1Flow QualificationListCheck(IEnumerable<string> qualificationList)
        {
            navigator.WaitForJQuery();

            IEnumerable<string> difference = page.QualificationSuite.Options.Except(qualificationList,
                StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(difference.Last(), UI.SelectQualification);
            return this;
        }

        public CourseStep1Flow CompleteAllDropDowns(CreateCourseContext courseContext)
        {
            SelectSubject(courseContext.Subject, this)
                .SelectQualificationSuite(courseContext.Qualification, this)
                .SelectPathway(courseContext.Pathway, this)
                .SelectSize(courseContext.Size, this)
                ;

            return this;
        }
    }
}