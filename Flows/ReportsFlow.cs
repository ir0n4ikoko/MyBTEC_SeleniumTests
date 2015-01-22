using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.Framework.CSV;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ReportsFlow : BtecMasterFlow<ReportsFlow>
    {
        private readonly ReportsPage page;

        public ReportsFlow(INavigator navigator, ReportsPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ReportsFlow CheckReportTypeOptions(IEnumerable<string> reportTypes)
        {
            string[] difference = page.ReportType.Options.Except(reportTypes).ToArray();

            Assert.IsFalse(difference.Any(), "Report types differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public ReportsFlow SelectReportType(string reportType)
        {
            page.ReportType.Text = reportType;

            return this;
        }

        public ReportsFlow SelectStartDate(DateTime date)
        {
            page.StartDate.SelectDate(date.ToString("dd/MM/yyyy"));

            return this;
        }

        public ReportsFlow SelectEndDate(DateTime date)
        {
            page.EndDate.SelectDate(date.ToString("dd/MM/yyyy"));

            return this;
        }

        public ReportsFlow GenerateReport(string reportfilename)
        {
            File.Delete(reportfilename);

            var reportsPage = navigator.Navigate<ReportsPage>(page.Generate.Click);

            navigator.WaitForFileDownloaded(reportfilename);

            return new ReportsFlow(navigator, reportsPage);
        }

        public ReportsFlow CheckReportHeaders(string reportfilename, IEnumerable<string> reportHeaders)
        {
            var header = new List<string>();

            Report.ReadCsvHeader(reportfilename, ref header);

            string[] difference = header.Except(reportHeaders).ToArray();

            Assert.IsFalse(difference.Any(), "Report headers differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public ReportsFlow CheckLoginReportCorrectDates(string reportfilename, DateTime start, DateTime end)
        {
            Assert.AreEqual(0, LoginReport.GetCountRowsOutPeriod(reportfilename, start, end),
                "Report logindatetime is not correct");

            return this;
        }

        public ReportsFlow CheckLoginReportContains(string reportfilename, LoginReport myLogin)
        {
            Assert.IsTrue(LoginReport.GetCountRowsForGivenLogin(reportfilename, myLogin) > 0,
                "Can not find row with my login");

            return this;
        }

        public ReportsFlow CheckClaimRolesReportCorrectDates(string reportfilename, DateTime start, DateTime end)
        {
            Assert.AreEqual(0, RoleClaimReport.GetCountRowsOutPeriod(reportfilename, start, end),
                "Report Date role claimed is not correct");

            return this;
        }

        public ReportsFlow CheckClaimRolesReportContains(string reportfilename, RoleClaimReport claimedRole, string role,
            string subject, string approved)
        {
            Assert.AreEqual(1,
                RoleClaimReport.GetCountRowsForGivenRole(reportfilename, claimedRole, role, subject, approved),
                "Can not find row with claimed role: {0},{1},{2}".F(subject, role, approved));

            return this;
        }

        public ReportsFlow CheckCourseReportCorrectDates(string reportfilename, DateTime start, DateTime end)
        {
            Assert.AreEqual(0, CourseReport.GetCountRowsOutPeriod(reportfilename, start, end),
                "Report course creation date is not correct");

            return this;
        }

        public ReportsFlow CheckCourseReportContains(string reportfilename, CourseReport courseData, string title,
            string qualificationName, string status, string courseTeam, string assignmentsLinked)
        {
            Assert.AreEqual(1,
                CourseReport.GetCountRowsForGivenCourse(reportfilename, courseData, title, qualificationName, status,
                    courseTeam, assignmentsLinked),
                "Can not find row with course: {0},{1},{2},{3},{4}".F(title, qualificationName, status, courseTeam,
                    assignmentsLinked));

            return this;
        }

        public ReportsFlow CheckAssignmentReportCorrectDates(string reportfilename, DateTime start, DateTime end)
        {
            Assert.AreEqual(0, AssignmentReport.GetCountRowsOutPeriod(reportfilename, start, end),
                "Report Date of assignment creation is not correct");

            return this;
        }

        public ReportsFlow CheckAssignmentReportContains(string reportfilename, AssignmentReport assignment)
        {
            Assert.AreEqual(1, AssignmentReport.GetCountRowsForGivenAssignment(reportfilename, assignment),
                "Can not find row with assignment: {0}, {1}, {2}, {3}".F(assignment.Title, assignment.Subject,
                    assignment.Qualification, assignment.CurrentStatus, assignment.CoursesLinked));

            return this;
        }

        public ReportsFlow CheckOptOutReportCorrectDates(string reportfilename, DateTime start, DateTime end)
        {
            Assert.AreEqual(0, OptOutReport.GetCountRowsOutPeriod(reportfilename, start, end),
                "Report Datetime opted out is not correct");

            return this;
        }

        public ReportsFlow CheckOptOutReportContains(string reportfilename, OptOutReport optOut)
        {
            Assert.AreEqual(1, OptOutReport.GetCountRowsForGivenOptOut(reportfilename, optOut),
                "Can not find row with opt out: {0}, {1}, {2}, {3}".F(optOut.Email, optOut.FirstName,
                    optOut.LastName,
                    optOut.DateTimeOptedOut.ToString(
                        CultureInfo.InvariantCulture)));

            return this;
        }
    }
}