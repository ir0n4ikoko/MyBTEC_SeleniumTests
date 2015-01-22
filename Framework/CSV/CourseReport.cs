using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class CourseReport : Report
    {
        private static List<CourseReport> courseReport;

        public CourseReport()
        {
        }

        public CourseReport(string[] values)
        {
            Email = values[0];
            FirstName = values[1];
            LastName = values[2];
            Title = values[3];
            CentreNumber = values[4];
            CentreName = values[5];
            CreationDate = DateTime.ParseExact(values[6], UiConst.DateTimeFormat.ShortDateFormat, null);
            QualificationName = values[7];
            CurrentStatus = values[8];
            CourseTeamAdded = values[9];
            AssignmentsLinked = values[10];
            CourseStartDate = DateTime.ParseExact(values[11], UiConst.DateTimeFormat.ShortDateFormat, null);
            CourseEndDate = DateTime.ParseExact(values[12], UiConst.DateTimeFormat.ShortDateFormat, null);
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }
        public DateTime CreationDate { get; set; }
        public string QualificationName { get; set; }
        public string CurrentStatus { get; set; }
        public string CourseTeamAdded { get; set; }
        public string AssignmentsLinked { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

        private static void ReadCourseReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            courseReport = new List<CourseReport>();

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
                courseReport.Add(new CourseReport(values));
            }
        }

        public static int GetCountRowsOutPeriod(string path, DateTime start, DateTime end)
        {
            if (courseReport == null)
            {
                ReadCourseReportCsv(path);
            }

            List<CourseReport> find = courseReport.FindAll(p => (p.CreationDate.CompareTo(start) < 0 ||
                                                                 p.CreationDate.CompareTo(end) > 0));

            return find.Count;
        }

        public static int GetCountRowsForGivenCourse(string path, CourseReport courseData, string title,
            string qualificationName, string status, string courseTeam, string assignmentsLinked)
        {
            if (courseReport == null)
            {
                ReadCourseReportCsv(path);
            }

            List<CourseReport> find = courseReport.FindAll(p => (p.FirstName.Equals(courseData.FirstName) &&
                                                                 p.LastName.Equals(courseData.LastName) &&
                                                                 p.Email.Equals(courseData.Email) &&
                                                                 p.CentreNumber.Equals(courseData.CentreNumber) &&
                                                                 p.CentreName.Equals(courseData.CentreName) &&
                                                                 p.CreationDate.Equals(courseData.CreationDate) &&
                                                                 p.CourseStartDate.Equals(courseData.CourseStartDate) &&
                                                                 p.CourseEndDate.Equals(courseData.CourseEndDate) &&
                                                                 p.Title.Equals(title) &&
                                                                 p.QualificationName.Equals(qualificationName) &&
                                                                 p.CurrentStatus.Equals(status) &&
                                                                 p.CourseTeamAdded.Equals(courseTeam) &&
                                                                 p.AssignmentsLinked.Equals(assignmentsLinked)));

            return find.Count;
        }
    }
}