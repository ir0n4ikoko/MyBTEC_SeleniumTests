using System;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.Framework.CSV;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ReportsTest : TestBase
    {
        [Test,Ignore]
        [Category("Download")]
        [Category("WithCourse")]
        public void GenerateAssignmentDataReportTest()
        {
            string today = DateTime.Today.Date.ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string tomorrow = DateTime.Today.Date.AddDays(1).ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string reportfilename = Configuration.DownloadDir + "\\" + "AssignmentData_" + today + "_" + tomorrow +
                                    ".csv";

            #region AssignmentsContextPreparation

            var draftAssignment = new AssignmentReport
            {
                FirstName = UiConst.FirstName.CourseLeader,
                LastName = UiConst.LastName.CourseLeader,
                Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')),
                Email = UiConst.Email.CourseLeader,
                CentreNumber = UI.TestCentreNumber,
                CentreName = UI.TestCentreName,
                Subject = UI.AppliedScience,
                Qualification = UI.QualificationCertificateAppliedScience,
                CurrentStatus = UI.Draft,
                CoursesLinked = 1
            };
            var courseDraftAssignment = new CreateCourseContext(draftAssignment.Title);
            var draft = new CreateAssignmentContext(draftAssignment);

            AssignmentReport withIvAssignment = draftAssignment;
            withIvAssignment.FirstName = UiConst.FirstName.Liv;
            withIvAssignment.LastName = UiConst.LastName.Liv;
            withIvAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            withIvAssignment.Email = UiConst.Email.Liv;
            withIvAssignment.CurrentStatus = UI.WithIV;
            var coursewithIvAssignment = new CreateCourseContext(withIvAssignment.Title);
            var withIV = new CreateAssignmentContext(withIvAssignment);

            AssignmentReport approvedAssignment = draftAssignment;
            approvedAssignment.FirstName = UiConst.FirstName.Assessor;
            approvedAssignment.LastName = UiConst.LastName.Assessor;
            approvedAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            approvedAssignment.Email = UiConst.Email.Assessor;
            approvedAssignment.CurrentStatus = UI.Approved;
            approvedAssignment.CoursesLinked = 0;
            var approved = new CreateAssignmentContext(approvedAssignment);

            AssignmentReport notApprovedAssignment = approvedAssignment;
            notApprovedAssignment.FirstName = UiConst.FirstName.Iv;
            notApprovedAssignment.LastName = UiConst.LastName.Iv;
            notApprovedAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            notApprovedAssignment.Email = UiConst.Email.Iv;
            notApprovedAssignment.CurrentStatus = UI.NotApproved;
            var notApproved = new CreateAssignmentContext(notApprovedAssignment)
            {
                IV = UiConst.FirstName.Liv + " " + UiConst.LastName.Liv,
                IvLogin = UiConst.Login.Liv,
                IvPassword = UiConst.Password.Liv
            };

            AssignmentReport authorisedAssignment = draftAssignment;
            authorisedAssignment.FirstName = UiConst.FirstName.Ddm;
            authorisedAssignment.LastName = UiConst.LastName.Ddm;
            authorisedAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            authorisedAssignment.Email = UiConst.Email.Ddm;
            authorisedAssignment.CentreNumber = UI.PearsonCentre;
            authorisedAssignment.CentreName = UI.PearsonCentre;
            authorisedAssignment.CurrentStatus = UI.Authorised;
            authorisedAssignment.CoursesLinked = 0;
            var authorised = new CreateAssignmentContext(authorisedAssignment);

            AssignmentReport editingPearsonAssignment = authorisedAssignment;
            editingPearsonAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            editingPearsonAssignment.CurrentStatus = UI.Editing;
            var editing = new CreateAssignmentContext(editingPearsonAssignment);

            AssignmentReport ddmReviewAssignment = authorisedAssignment;
            ddmReviewAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            ddmReviewAssignment.CurrentStatus = UI.DDMReview;
            var ddmReview = new CreateAssignmentContext(ddmReviewAssignment);

            AssignmentReport externalTestAssignment = authorisedAssignment;
            externalTestAssignment.Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            externalTestAssignment.CurrentStatus = UI.ExternalTest;
            var externalTest = new CreateAssignmentContext(externalTestAssignment);

            #endregion

            Start
                .LoginWithCL()
                .CreateConfirmedCourse(courseDraftAssignment).Flow
                .CreateAssignment(draft).Flow
                //.ClickLogout()
                //.LoginWithLIV()
                //.CreateConfirmedCourse(coursewithIvAssignment).Flow
                //.CreateAssignment(withIV).Flow
                //.ClickLogout()
                //.LoginWithAssessor()
                //.CreateAssignment(approved).Flow
                //.ClickLogout()
                //.LoginWithIV()
                //.CreateAssignment(notApproved).Flow
                //.ClickLogout()
                //.LoginWithDDM()
                //.CreateAssignment(authorised).Flow
                //.CreateAssignment(editing).Flow
                //.CreateAssignment(externalTest).Flow
                //.CreateAssignment(ddmReview).Flow
                .ClickLogout()
                .LoginWithPearsonManager()
                .GoToReports()
                .SelectReportType(UI.AssignmentsReport)
                .SelectStartDate(DateTime.Today)
                .SelectEndDate(DateTime.Today.AddDays(1))
                .SelectReportType(UI.LoginReport)
                .SelectReportType(UI.AssignmentsReport)
                .GenerateReport(reportfilename)
                .CheckReportHeaders(reportfilename, UiConst.Reports.AssignmentReportHeaders)
                .CheckAssignmentReportCorrectDates(reportfilename, DateTime.Today, DateTime.Today.AddDays(1))
                .CheckAssignmentReportContains(reportfilename, draftAssignment)
                //.CheckAssignmentReportContains(reportfilename, approvedAssignment)
                //.CheckAssignmentReportContains(reportfilename, notApprovedAssignment)
                //.CheckAssignmentReportContains(reportfilename, authorisedAssignment)
                //.CheckAssignmentReportContains(reportfilename, editingPearsonAssignment)
                //.CheckAssignmentReportContains(reportfilename, externalTestAssignment)
                //.CheckAssignmentReportContains(reportfilename, ddmReviewAssignment)
                ;
        }

        [Test,Ignore]
        [Category("Download")]
        [Category("WithCourse")]
        public void GenerateCourseDataReportTest()
        {
            string today = DateTime.Today.Date.ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string tomorrow = DateTime.Today.Date.AddDays(1).ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string reportfilename = Configuration.DownloadDir + "\\" + "CourseData_" + today + "_" + tomorrow + ".csv";
            var draftNN = new CreateCourseContext
            {
                Subject = UiConst.Subject.Sport,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Sport_Award,
                Size = UiConst.Size.Award_120_GLH
            };
            var confirmedNN = new CreateCourseContext();
            var confirmedYY = new CreateCourseContext();
            var assignment = new CreateAssignmentContext();
            var baseCourseData = new CourseReport
            {
                Email = UiConst.Email.CourseLeader,
                FirstName = UiConst.FirstName.CourseLeader,
                LastName = UiConst.LastName.CourseLeader,
                CentreNumber = UI.TestCentreNumber,
                CentreName = UI.TestCentreName,
                CreationDate = DateTime.Today,
                CourseStartDate = draftNN.StartDate,
                CourseEndDate = draftNN.EndDate
            };

            Start
                .LoginWithCL()
                .GoToCourses()
                .CreateCourseAsDraft(draftNN)
                .CreateConfirmedCourse(confirmedNN).Flow
                .CreateConfirmedCourse(confirmedYY).Flow
                .ViewCourse(confirmedYY.ID)
                .ViewCourseTeam()
                .SelectTeamMember(UiConst.FirstName.Iv + " " + UiConst.LastName.Iv)
                .AddToTeam()
                .SaveTeam()
                .ClickLogout()
                .LoginWithIV()
                .CreateAssignment(assignment).Flow
                .LinkAssignmentToCourse(assignment.ID, confirmedYY.ID)
                .ClickLogout()
                .LoginWithPearsonManager()
                .GoToReports()
                .SelectReportType(UI.CoursesReport)
                .SelectStartDate(DateTime.Today)
                .SelectEndDate(DateTime.Today.AddDays(1))
                .SelectReportType(UI.LoginReport)
                .SelectReportType(UI.CoursesReport)
                .GenerateReport(reportfilename)
                .CheckReportHeaders(reportfilename, UiConst.Reports.CourseReportHeaders)
                .CheckCourseReportCorrectDates(reportfilename, DateTime.Today, DateTime.Today.AddDays(1))
                .CheckCourseReportContains(reportfilename, baseCourseData, draftNN.Title, UI.QualificationAwardSport,
                    UI.Draft, "N", "N")
                .CheckCourseReportContains(reportfilename, baseCourseData, confirmedNN.Title,
                    UI.QualificationCertificateAppliedScience, UI.Confirmed, "N", "N")
                .CheckCourseReportContains(reportfilename, baseCourseData, confirmedYY.Title,
                    UI.QualificationCertificateAppliedScience, UI.Confirmed, "Y", "Y");
        }

        [Test,Ignore]
        [Category("Download")]
        public void GenerateLoginReportTest()
        {
            string today = DateTime.Today.Date.ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string tomorrow = DateTime.Today.Date.AddDays(1).ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string reportfilename = Configuration.DownloadDir + "\\" + "LoginActivity_" + today + "_" + tomorrow +
                                    ".csv";
            var myLogin = new LoginReport
            {
                Email = UiConst.Email.PearsonManager,
                FirstName = UiConst.FirstName.PearsonManager,
                LastName = UiConst.LastName.PearsonManager,
                LoginDateTime = DateTime.Now,
                CentreNumber = UI.PearsonCentre,
                CentreName = UI.PearsonCentre
            };

            Start.LoginWithPearsonManager()
                .GoToReports()
                .CheckReportTypeOptions(UiConst.Reports.ReportTypes)
                .SelectReportType(UI.LoginReport)
                .SelectStartDate(DateTime.Today)
                .SelectEndDate(DateTime.Today.AddDays(1))
                .SelectReportType(UI.OptOutReport)
                .SelectReportType(UI.LoginReport)
                .GenerateReport(reportfilename)
                .CheckReportHeaders(reportfilename, UiConst.Reports.LoginReportHeaders)
                .CheckLoginReportCorrectDates(reportfilename, DateTime.Today, DateTime.Today.AddDays(1))
                .CheckLoginReportContains(reportfilename, myLogin);
        }

        [Test,Ignore]
        [Category("Download")]
        public void GenerateOptOutReportTest()
        {
            string today = DateTime.Today.Date.ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string tomorrow = DateTime.Today.Date.AddDays(1).ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string reportfilename = Configuration.DownloadDir + "\\" + "OptOut_" + today + "_" + tomorrow + ".csv";
            var myOptOut = new OptOutReport
            {
                Email = UiConst.Email.PearsonManager,
                FirstName = UiConst.FirstName.PearsonManager,
                LastName = UiConst.LastName.PearsonManager,
                DateTimeOptedOut = DateTime.Now,
                CentreNumber = UI.PearsonCentre,
                CentreName = UI.PearsonCentre
            };
            var EULAOptOut = new OptOutReport
            {
                Email = UiConst.Email.UserNoRoles4,
                FirstName = UiConst.FirstName.UserNoRoles4,
                LastName = UiConst.LastName.UserNoRoles4,
                DateTimeOptedOut = DateTime.Now,
                CentreNumber = UI.TestCentreNumber,
                CentreName = UI.TestCentreName
            };

            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles4, UiConst.Password.UserNoRoles4)
                .CheckEulaOptOutText(UI.OptOutText)
                .TickEULAOptOut()
                .CancelEula()
                .LoginWithPearsonManager()
                .GoToTermsOfUse()
                .CheckOptOutText(UI.OptOutText)
                .TickOptOutCheckbox()
                .GoToReports()
                .SelectReportType(UI.OptOutReport)
                .SelectStartDate(DateTime.Today)
                .SelectEndDate(DateTime.Today.AddDays(1))
                .SelectReportType(UI.LoginReport)
                .SelectReportType(UI.OptOutReport)
                .GenerateReport(reportfilename)
                .CheckReportHeaders(reportfilename, UiConst.Reports.OptOutReportHeaders)
                .CheckOptOutReportCorrectDates(reportfilename, DateTime.Today, DateTime.Today.AddDays(1))
                .CheckOptOutReportContains(reportfilename, myOptOut)
                .CheckOptOutReportContains(reportfilename, EULAOptOut);
        }

        [Test,Ignore]
        [Category("Download")]
        public void GenerateRoleClaimReportTest()
        {
            string today = DateTime.Today.Date.ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string tomorrow = DateTime.Today.Date.AddDays(1).ToString(UiConst.DateTimeFormat.ShortDateFormatDots);
            string reportfilename = Configuration.DownloadDir + "\\" + "RoleClaim_" + today + "_" + tomorrow + ".csv";
            var baseRoleClaimed = new RoleClaimReport
            {
                FirstName = UiConst.FirstName.UserNoRoles1,
                LastName = UiConst.LastName.UserNoRoles1,
                Email = UiConst.Email.UserNoRoles1,
                CentreNumber = UI.TestCentreNumber,
                CentreName = UI.TestCentreName,
                SiteQn = new[] {UiConst.Email.QualityNominee, " "}
            };
            string approved = UI.Approved;
            string awaiting = UI.AwaitingApproval;
            string declined = UI.Declined;
            Start
                .LoginWithAndGoToHomePage(UiConst.Login.UserNoRoles1, UiConst.Password.UserNoRoles1)
                .ConfirmEulaRedirectClaimRoles()
                .SelectRoleForSubject(0, UiConst.Subject.Application_of_Science, UI.CourseLeader.Replace(" ", ""))
                .SelectRoleForSubject(1, UiConst.Subject.PerformingArts, UI.Assessor)
                .SelectRoleForSubject(2, UiConst.Subject.Principles_of_Applied_Science,
                    UI.InternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(3, UiConst.Subject.Sport, UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(4, UiConst.Subject.AppliedScience, UI.Teacher)
                .SelectRoleForSubject(5, UiConst.Subject.Information_and_Creative_Technology,
                    UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(6, UiConst.Subject.Engineering, UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(7, UiConst.Subject.Art_and_Design, UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(8, UiConst.Subject.Business, UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(9, UiConst.Subject.Childrens_Play_Learning_and_Development,
                    UI.LeadInternalVerifier.Replace(" ", ""))
                .SelectRoleForSubject(10, UiConst.Subject.Health_and_Social_Care,
                    UI.LeadInternalVerifier.Replace(" ", ""))
                .ClaimRoles()
                .ClickLogout()
                .LoginWithQN()
                .GoToUserRoleApproval()
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1, UiConst.Subject.Sport,
                    UI.LIV)
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.PerformingArts, UI.Assessor)
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Principles_of_Applied_Science, UI.InternalVerifier.Replace(" ", ""))
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Application_of_Science, UI.CourseLeader.Replace(" ", ""))
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.AppliedScience, UI.Teacher)
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Information_and_Creative_Technology, UI.LIV)
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Engineering, UI.LIV)
                .Approve(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Art_and_Design, UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1, UiConst.Subject.Business,
                    UI.LIV)
                .Decline(UiConst.FirstName.UserNoRoles1 + " " + UiConst.LastName.UserNoRoles1,
                    UiConst.Subject.Childrens_Play_Learning_and_Development.Substring(10), UI.LIV)
                .Confirm()
                .ClickLogout()
                .LoginWithPearsonManager()
                .GoToReports()
                .SelectReportType(UI.RolesReport)
                .SelectStartDate(DateTime.Today)
                .SelectEndDate(DateTime.Today.AddDays(1))
                .SelectReportType(UI.LoginReport)
                .SelectReportType(UI.RolesReport)
                .GenerateReport(reportfilename)
                .CheckReportHeaders(reportfilename, UiConst.Reports.RoleclaimReportHeaders)
                .CheckClaimRolesReportCorrectDates(reportfilename, DateTime.Today, DateTime.Today.AddDays(1))
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Sport, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.Assessor,
                    UiConst.Subject.PerformingArts, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.InternalVerifier,
                    UiConst.Subject.Principles_of_Applied_Science, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.CourseLeader,
                    UiConst.Subject.Application_of_Science, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.Teacher,
                    UiConst.Subject.AppliedScience, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Information_and_Creative_Technology, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Engineering, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Art_and_Design, approved)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Business, declined)
                .CheckClaimRolesReportContains(reportfilename, baseRoleClaimed, UI.LeadInternalVerifier,
                    UiConst.Subject.Health_and_Social_Care, awaiting);
        }
    }
}