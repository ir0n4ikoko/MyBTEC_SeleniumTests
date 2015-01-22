using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CourseSummaryTest : TestBase
    {
        [Test]
        public void CheckCourseSummaryCreator()
        {
            var course = new CreateCourseContext();

            Start
                .LoginWithQN()
                .CreateCourseAsDraft(course)
                .ViewCourse(course.ID)
                .EditCourse()
                .Continue()
                .SaveContinue()
                .ConfirmCourse()
                .ConfirmCoursePopup()
                .ClickOnThisCourse(course.Title)
                //.DownloadCourse()
                .ViewQualificationCourseSummary()
                .Continue()
                .DownloadGeneralSpecificationInformation()
                .Exit();
        }
    }
}