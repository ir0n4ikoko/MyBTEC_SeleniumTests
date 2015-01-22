using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class UserPermissionsTest : TestBase
    {
        [Test]
        public void CheckAssessorPermissions()
        {
            Start
                .LoginWithAssessor()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton(false)
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(true)
                .CheckUserApprovalButton(false);
        }

        [Test]
        public void CheckCourseLeaderPermissions()
        {
            Start
                .LoginWithCL()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton()
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(true)
                .CheckUserApprovalButton(false);
        }

        [Test]
        public void CheckIVPermissions()
        {
            Start
                .LoginWithIV()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton(false)
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(true)
                .CheckUserApprovalButton(false);
        }

        [Test]
        public void CheckLIVPermissions()
        {
            Start
                .LoginWithLIV()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton()
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(true)
                .CheckUserApprovalButton();
        }

        [Test]
        public void CheckQNPermissions()
        {
            Start
                .LoginWithQN()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton()
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(true)
                .CheckUserApprovalButton();
        }

        [Test]
        public void CheckTeacherPermissions()
        {
            Start
                .LoginWithTeacher()
                .GoToClaimRoles()
                .GoToCourses()
                .CheckCreateCourseButton(false)
                .GoToCentreCourses()
                .ViewQualificationCourses()
                .GoToAssignments()
                .CheckCreateAssignmentButton(false)
                .CheckCentreAssignment(false)
                .CheckUserApprovalButton(false);
        }
    }
}