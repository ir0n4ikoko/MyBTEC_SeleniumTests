using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class AssignmentQualificationNameTest : TestBase
    {
        [Test, Ignore]
        [Category("WithCourse")]
        public void QualificationName_SubjectQualification()
        {
            string subQualName = string.Format(
                "{0} {1}", UiConst.Subject.AppliedScience, UiConst.QualificationSuite.BTEC_First_2012_NQF);

            var course = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Certificate_360_GLH
            };
            var subQual = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = "",
                Size = "",
                FirstUnit = true
            };

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .PressCreateAssignment()
                .FillAllRequiredDataOnStep1(subQual)
                .SaveAndContinue()
                .SelectAllCriteria()
                .AssertQualificationIs(subQualName)
                .SaveAndContinue()
                .FillAllRequiredDataOnStep3(subQual).Flow
                .AssertQualificationIs(subQualName)
                .SaveAndContinue()
                .AssertQualificationIs(subQualName)
                .ClickSendToIv()
                .SelectSendToIv()
                .SaveAndSendToIVnow()
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(subQual.ID)
                .CheckAllAcceptanceCriterias()
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .AssertQualificationIs(subQualName)
                .SaveAndSend()
                .ClickLogout()
                .LoginWithQN()
                .GoToAssignments()
                .AssertQualificationIs(subQualName, subQual.ID)
                .GoToCentreAssignments()
                .AssertQualificationIs(subQualName, subQual.ID)
                .LinkAssignmentToCourse(subQual.ID, course.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentQualificationIs(subQualName, subQual.ID);
        }

        [Test, Ignore]
        [Category("WithCourse")]
        public void QualificationName_SubjectQualificationPathway()
        {
            string subQualPathName = string.Format("{0} {1}",
                UiConst.Pathway.AppliedScience,
                UiConst.QualificationSuite.BTEC_First_2012_NQF);

            var course = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Certificate_360_GLH
            };
            var subQualPath = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = "",
                FirstUnit = true
            };

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .PressCreateAssignment()
                .FillAllRequiredDataOnStep1(subQualPath)
                .SaveAndContinue()
                .SelectAllCriteria()
                .AssertQualificationIs(subQualPathName)
                .SaveAndContinue()
                .FillAllRequiredDataOnStep3(subQualPath).Flow
                .AssertQualificationIs(subQualPathName)
                .SaveAndContinue()
                .AssertQualificationIs(subQualPathName)
                .ClickSendToIv()
                .SelectSendToIv()
                .SaveAndSendToIVnow()
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(subQualPath.ID)
                .CheckAllAcceptanceCriterias()
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .AssertQualificationIs(subQualPathName)
                .SaveAndSend()
                .ClickLogout()
                .LoginWithQN()
                .GoToAssignments()
                .AssertQualificationIs(subQualPathName, subQualPath.ID)
                .GoToCentreAssignments()
                .AssertQualificationIs(subQualPathName, subQualPath.ID)
                .LinkAssignmentToCourse(subQualPath.ID, course.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentQualificationIs(subQualPathName, subQualPath.ID);
        }

        [Test, Ignore]
        [Category("WithCourse")]
        public void QualificationName_SubjectQualificationPathwaySize()
        {
            string subQualPathSizeName = UI.QualificationCertificateAppliedScience;

            var course = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Certificate_360_GLH
            };
            var subQualPathSize = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Certificate_360_GLH,
                FirstUnit = true
            };

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .PressCreateAssignment()
                .FillAllRequiredDataOnStep1(subQualPathSize)
                .SaveAndContinue()
                .SelectAllCriteria()
                .AssertQualificationIs(subQualPathSizeName)
                .SaveAndContinue()
                .FillAllRequiredDataOnStep3(subQualPathSize).Flow
                .AssertQualificationIs(subQualPathSizeName)
                .SaveAndContinue()
                .AssertQualificationIs(subQualPathSizeName)
                .ClickSendToIv()
                .SelectSendToIv()
                .SaveAndSendToIVnow()
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(subQualPathSize.ID)
                .CheckAllAcceptanceCriterias()
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .AssertQualificationIs(subQualPathSizeName)
                .SaveAndSend()
                .ClickLogout()
                .LoginWithQN()
                .GoToAssignments()
                .AssertQualificationIs(subQualPathSizeName, subQualPathSize.ID)
                .GoToCentreAssignments()
                .AssertQualificationIs(subQualPathSizeName, subQualPathSize.ID)
                .LinkAssignmentToCourse(subQualPathSize.ID, course.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentQualificationIs(subQualPathSizeName, subQualPathSize.ID);
        }

        [Test, Ignore]
        [Category("WithCourse")]
        public void QualificationName_SubjectQualificationSize()
        {
            string subQualSizeName = string.Format("{0} {1}",
                UiConst.Pathway.AppliedScience,
                UiConst.QualificationSuite.BTEC_First_2012_NQF);

            var course = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Certificate_360_GLH
            };
            var subQualSize = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = "",
                Size = UiConst.Size.Extended_Certificate_360_GLH,
                FirstUnit = true
            };

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(course).Flow
                .PressCreateAssignment()
                .FillAllRequiredDataOnStep1(subQualSize)
                .SaveAndContinue()
                .SelectAllCriteria()
                .AssertQualificationIs(subQualSizeName)
                .SaveAndContinue()
                .FillAllRequiredDataOnStep3(subQualSize).Flow
                .AssertQualificationIs(subQualSizeName)
                .SaveAndContinue()
                .AssertQualificationIs(subQualSizeName)
                .ClickSendToIv()
                .SelectSendToIv()
                .SaveAndSendToIVnow()
                .ClickLogout()
                .LoginWithIV()
                .GoToAssignments()
                .Review(subQualSize.ID)
                .CheckAllAcceptanceCriterias()
                .ChooseIsAssignmentForWholeUnits()
                .ChooseIsAssignmentApproved()
                .AssertQualificationIs(subQualSizeName)
                .SaveAndSend()
                .ClickLogout()
                .LoginWithQN()
                .GoToAssignments()
                .AssertQualificationIs(subQualSizeName, subQualSize.ID)
                .GoToCentreAssignments()
                .AssertQualificationIs(subQualSizeName, subQualSize.ID)
                .LinkAssignmentToCourse(subQualSize.ID, course.ID)
                .GoToCourses()
                .ViewCourse(course.ID)
                .ViewCourseAssignments()
                .AssertAssignmentQualificationIs(subQualSizeName, subQualSize.ID);
        }
    }
}