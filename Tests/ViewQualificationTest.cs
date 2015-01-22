using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ViewQualificationTest : TestBase
    {
        [Test]
        public void CheckViewQualificationAvailableTest()
        {
            var confirmed = new CreateCourseContext();

            Start
                .LoginWithQN()
                .GoToViewQualification()
                .Exit()
                .GoToCourses()
                .ViewQualificationCourses()
                .Exit()
                .GoToCourses()
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .Exit()
                .CreateConfirmedCourse(confirmed)
                .Flow
                .ViewCourse(confirmed.ID)
                .ViewQualificationCourseSummary()
                .Exit();
        }

        [Test]
        public void CheckViewQualificationStep1Test()
        {
            Start
                .LoginWithQN()
                .GoToViewQualification()
                .CompleteStep1ViewQual(UiConst.Subject.AppliedScience, UiConst.QualificationSuite.BTEC_Nationals_2010_QCF, UiConst.Pathway.AppliedScience, UiConst.Size.Certificate_30_Credits)
                .Continue()
                .Previous()
                .Exit();
        }

        [Test]
        public void CheckViewQualificationStep2Test()
        {
            Start
                .LoginWithQN()
                .GoToViewQualification()
                .CompleteStep1ViewQual(UiConst.Subject.AppliedScience, UiConst.QualificationSuite.BTEC_Nationals_2010_QCF, UiConst.Pathway.AppliedScience, UiConst.Size.Certificate_30_Credits)
                .Continue()
                .AssertStep2HeadTextCorrect(UiConst.ViewQualificationStep2HeadTitle.TitleForApliedScience)
                //.DownloadGeneralSpecificationInformation()
                .CheckDownloadGeneralSpecificationInformationLinkIsActive()
                .Exit();
        }

        [Test]
        [Category("Big")]
        public void ViewAllPossibleQualifications()
        {
            Start
                .LoginWithQN()
                .GoToViewQualification()
                .CompleteStep1ViewQualWithAllPossibleCombinations()
                .Exit();
        }

    }
}