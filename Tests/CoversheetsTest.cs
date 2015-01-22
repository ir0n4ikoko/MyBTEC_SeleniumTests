using System;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CoversheetsTest : TestBase
    {
        [Test]
        [Category("Download")]
        [Category("WithCourse")]
        public void CheckUsersCanCreateCoversheets()
        {
            string assessor = UiConst.FirstName.Assessor + " " + UiConst.LastName.Assessor;
            string teacher = UiConst.FirstName.Teacher + " " + UiConst.LastName.Teacher;
            string iv = UiConst.FirstName.Iv + " " + UiConst.LastName.Iv;
            string courseLeader = UiConst.FirstName.CourseLeader + " " + UiConst.LastName.CourseLeader;
            string liv = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv;
            string qn = UiConst.FirstName.QualityNominee + " " + UiConst.LastName.QualityNominee;
            var courseContext = new CreateCourseContext
            {
                StartDate = DateTime.Today.AddDays(2),
                EndDate = DateTime.Today.AddDays(5)
            };

            var approvedAssignment = new CreateAssignmentContext
            {
                CourseTitle = courseContext.Title,
                Status = UI.Approved
            };
            var authAssignment = new CreateAssignmentContext {Status = UI.Authorised};

            string comment = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            Start
                .LoginWithDDM()
                .CreateAssignment(authAssignment).Flow
                .ClickLogout()
                .LoginWithQN()
                .CreateConfirmedCourse(courseContext).Flow
                .GoToAssignments()
                .LinkAssignmentToCourse(authAssignment.ID, courseContext.ID)
                .CreateAssignment(approvedAssignment).Flow
                .ClickLogout()
                .LoginWithQN()
                .GoToCourses()
                .ViewCourse(courseContext.ID)
                .ViewCourseAssignments()
                .SelectCreateCoversheet(approvedAssignment.ID)
                .CancelCreate()
                .SelectCreateCoversheet(approvedAssignment.ID)
                .CheckValidationAssessors(UI.ValidationNoTeamForCoversheet.F(UI.Assessor))
                .CheckValidationIVs(UI.ValidationNoTeamForCoversheet.F(UI.InternalVerifier))
                .CheckNoCreateButton()
                .CancelCreate()
                .ViewCourseTeam()
                .SelectTeamMember(qn)
                .SelectTeamMember(liv)
                .SelectTeamMember(courseLeader)
                .SelectTeamMember(teacher)
                .SelectTeamMember(assessor)
                .SelectTeamMember(iv)
                .AddToTeam()
                .AddCourseLeader(courseLeader)
                .AddCourseLeader(liv)
                .SaveTeam()
                .ViewCourseAssignments()
                .SelectCreateCoversheet(approvedAssignment.ID)
                //.CreateWithValidation()
                //.CheckValidationStartDate(UI.ValidationFieldRequired.F(UI.StartDate))
                //.CheckValidationFirstSubmissionDate(UI.ValidationFieldRequired.F(UI.FirstSubmission))
                //.CheckValidationFinalSubmissionDate(UI.ValidationFieldRequired.F(UI.FinalSubmission))
                //.SetStartDate(DateTime.Today)
                //.SetFirstSubmissionDate(DateTime.Today)
                //.SetFinalSubmissionDate(DateTime.Today)
                //.CreateWithValidation()
                //.CheckValidationAssessors(UI.ValidationAddAssessor)
                //.CheckValidationIVs(UI.ValidationAddIV)
                .AddAssessor(assessor)
                .AddAssessor(courseLeader)
                .AddIV(iv)
                .AddIV(qn)
                .AddIV(liv)
                //.CreateWithValidation()
                //.CheckValidationStartDate(UI.ValidationStartDateEarlierCourseStartDate)
                .SetStartDate(DateTime.Today.AddDays(2))
                //.CreateWithValidation()
                //.CheckValidationStartDate(UI.ValidationStartDateLaterFirst)
                .SetFirstSubmissionDate(DateTime.Today.AddDays(3))
                //.CreateWithValidation()
                //.CheckValidationFirstSubmissionDate(UI.ValidationFirstSubmissionLaterFinal)
                //.SetFinalSubmissionDate(DateTime.Today.AddDays(6))
                //.CreateWithValidation()
                //.CheckValidationFinalSubmissionDate(UI.ValidationFinalSubmissionLaterEndDate)
                .SetFinalSubmissionDate(DateTime.Today.AddDays(4))
                .SetComments(comment)
                .Create()
                .Download();
        }
    }
}