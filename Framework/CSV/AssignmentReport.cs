using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Flows;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class AssignmentReport : Report
    {
        private static List<AssignmentReport> assignmentReport;

        public AssignmentReport()
        {
        }

        public AssignmentReport(string[] values)
        {
            UserID = values[0];
            FirstName = values[1];
            LastName = values[2];
            Title = values[3];
            Email = values[4];
            CentreNumber = values[5];
            CentreName = values[6];
            CreationDate = DateTime.ParseExact(values[7], UiConst.DateTimeFormat.ShortDateFormat, null);
            Subject = values[8];
            Qualification = values[9];
            Qan = values[10];
            CurrentStatus = values[11];
            CoursesLinked = int.Parse(values[11]);
            DateApproved = DateTime.ParseExact(values[12], UiConst.DateTimeFormat.LongDateTimeFormat, null);
        }

        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Subject { get; set; }
        public string Qualification { get; set; }
        public string Qan { get; set; }
        public string CurrentStatus { get; set; }
        public int CoursesLinked { get; set; }
        public DateTime DateApproved { get; set; }
        public CreateAssignmentContext context { get; set; }

        private static void ReadAssignmentReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            assignmentReport = new List<AssignmentReport>();

            if (!reader.EndOfStream)
            {
                reader.ReadLine(); // read header line
            }

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(',');
                for (int i = 0; i < values.Count(); i++)
                {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
                assignmentReport.Add(new AssignmentReport(values));
            }
        }

        public static int GetCountRowsOutPeriod(string path, DateTime start, DateTime end)
        {
            if (assignmentReport == null)
            {
                ReadAssignmentReportCsv(path);
            }

            List<AssignmentReport> find = assignmentReport.FindAll(p => (p.CreationDate.CompareTo(start) < 0 ||
                                                                         p.CreationDate.CompareTo(end) > 0));

            return find.Count;
        }

        public static int GetCountRowsForGivenAssignment(string path, AssignmentReport assignment)
        {
            if (assignmentReport == null)
            {
                ReadAssignmentReportCsv(path);
            }

            List<AssignmentReport> find = assignmentReport.FindAll(p => (p.FirstName.Equals(assignment.FirstName) &&
                                                                         p.LastName.Equals(assignment.LastName) &&
                                                                         p.Email.Equals(assignment.Email) &&
                                                                         p.CentreNumber.Equals(assignment.CentreNumber) &&
                                                                         p.CentreName.Equals(assignment.CentreName) &&
                                                                         (p.CreationDate.Subtract(DateTime.Now)
                                                                             .TotalMinutes < 25)) &&
                                                                        p.Title.Equals(assignment.Title) &&
                                                                        p.Subject.Equals(assignment.Subject) &&
                                                                        p.Qualification.Equals(assignment.Qualification) &&
                                                                        p.CurrentStatus.Equals(assignment.CurrentStatus) &&
                                                                        p.CoursesLinked.Equals(
                                                                            assignment.CoursesLinked));

            return find.Count;
        }
    }
}