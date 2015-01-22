using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    public static class CsvHelper
    {
        public enum csvTypes
        {
            LoginActivityReport,
            RoleClaimReport,
            CourseDataReport,
            AssignmentDataReport
        }

        public class LoginReport
        {
            public LoginReport(string[] values)
            {
                Email = values[0].Substring(1, values[0].Length - 2);
                FirstName = values[1].Substring(1, values[1].Length - 2);
                LastName = values[2].Substring(1, values[2].Length - 2);
                LoginDateTime = DateTime.ParseExact(values[3].Substring(1, values[3].Length - 2), @"dd/MM/yyyy hh:mm:ss", null);
            }
            public LoginReport(string email, string firstname, string lastname, DateTime loginDateTime)
            {
                Email = email;
                FirstName = firstname;
                LastName = lastname;
                LoginDateTime = loginDateTime;
            }

            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime LoginDateTime { get; set; }
        }

        public class RoleClaimReport
        {
            public RoleClaimReport(string[] values)
            {
                FirstName       = values[0].Substring(1, values[0].Length - 2);
                LastName        = values[1].Substring(1, values[1].Length - 2);
                Email           = values[2].Substring(1, values[2].Length - 2);
                RoleClaimed     = values[3].Substring(1, values[3].Length - 2);
                DateRoleClaimed = DateTime.ParseExact(values[4].Substring(1, values[4].Length - 2), @"MM/dd/yyyy hh:mm:ss", null);
                RoleForCentre   = values[5].Substring(1, values[5].Length - 2);
                Subject         = values[6].Substring(1, values[6].Length - 2);
                Approved        = values[7].Substring(1, values[7].Length - 2);
            }
            public RoleClaimReport(string firstname, string lastname, string email, string roleClaimed, DateTime dateRoleClaimed, string roleForCentre, string subject, string approved)
            {
                FirstName = firstname;
                LastName = lastname;
                Email = email;
                RoleClaimed = roleClaimed;
                DateRoleClaimed = dateRoleClaimed;
                RoleForCentre = roleForCentre;
                Subject = subject;
                Approved = approved;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string RoleClaimed { get; set; }
            public DateTime DateRoleClaimed { get; set; }
            public string RoleForCentre { get; set; }
            public string Subject { get; set; }
            public string Approved { get; set; }
        }

        public class CourseReport
        {
            public CourseReport(string[] values)
            {
                Email               = values[0].Substring(1, values[0].Length - 2);
                FirstName           = values[1].Substring(1, values[1].Length - 2);
                LastName            = values[2].Substring(1, values[2].Length - 2);
                Title               = values[3].Substring(1, values[3].Length - 2);
                CentreID            = values[4].Substring(1, values[4].Length - 2);
                LastName            = values[5].Substring(1, values[5].Length - 2);
                CreationDate        = DateTime.ParseExact(values[6].Substring(1, values[6].Length - 2), @"dd/MM/yyyy", null);
                QualificationName   = values[7].Substring(1, values[7].Length - 2);
                CurrentStatus       = values[8].Substring(1, values[8].Length - 2);
                CourseTeamAdded     = values[9].Substring(1, values[9].Length - 2);
                AssignmentsLinked   = values[10].Substring(1, values[10].Length - 2);
                CourseStartDate     = DateTime.ParseExact(values[11].Substring(1, values[11].Length - 2), @"dd/MM/yyyy", null);
                CourseEndDate       = DateTime.ParseExact(values[12].Substring(1, values[12].Length - 2), @"dd/MM/yyyy", null);

            }

            public CourseReport(string email, string firstname, string lastname, string title, string centreID,
                                DateTime creationDate, string qualificationName, string currentStatus,
                                string courseTeamAdded
                                , string assignmentsLinked, DateTime courseStartDate, DateTime courseEndDate)
            {
                Email = email;
                FirstName = firstname;
                LastName = lastname;
                Title = title;
                CentreID = centreID;
                CreationDate = creationDate;
                QualificationName = qualificationName;
                CurrentStatus = currentStatus;
                CourseTeamAdded = courseTeamAdded;
                AssignmentsLinked = assignmentsLinked;
                CourseStartDate = courseStartDate;
                CourseEndDate = courseEndDate;
            }

            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public string CentreID { get; set; }
            public DateTime CreationDate { get; set; }
            public string QualificationName { get; set; }
            public string CurrentStatus { get; set; }
            public string CourseTeamAdded { get; set; }
            public string AssignmentsLinked { get; set; }
            public DateTime CourseStartDate { get; set; }
            public DateTime CourseEndDate { get; set; }
        }

        public class AssignmentReport
        {
            public AssignmentReport(string[] values)
            {
                UserID          = values[0].Substring(1, values[0].Length - 2);
                FirstName       = values[1].Substring(1, values[1].Length - 2);
                LastName        = values[2].Substring(1, values[2].Length - 2);
                Title           = values[3].Substring(1, values[3].Length - 2);
                Email           = values[4].Substring(1, values[4].Length - 2);
                CentreID        = values[5].Substring(1, values[5].Length - 2);
                CreationDate    = DateTime.ParseExact(values[6].Substring(1, values[6].Length - 2), @"dd/MM/yyyy hh:mm:ss", null);
                Subject         = values[7].Substring(1, values[7].Length - 2);
                Qualification   = values[8].Substring(1, values[8].Length - 2);
                CurrentStatus   = values[9].Substring(1, values[9].Length - 2);
                LinkedToCourse  = values[10].Substring(1, values[10].Length - 2);
            }
            public AssignmentReport(string userID, string firstname, string lastname, 
                string title, string email, string centreID, DateTime creationDate,
                string subject, string qualification, string currentStatus, string linkedToCourse)
            {
                UserID = userID;
                FirstName = firstname;
                LastName = lastname;
                Title = title;
                Email = email;
                CentreID = centreID;
                CreationDate = creationDate;
                Subject = subject;
                Qualification = qualification;
                CurrentStatus = currentStatus;
                LinkedToCourse = linkedToCourse;
            }

            public string UserID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public string Email { get; set; }            
            public string CentreID { get; set; }
            public DateTime CreationDate { get; set; }
            public string Subject { get; set; }
            public string Qualification { get; set; }
            public string CurrentStatus { get; set; }
            public string LinkedToCourse { get; set; }
        }
        
        public static void ReadLoginReportCsv(string path, ref List<LoginReport> loginReport)
        {
            var reader = new StreamReader(File.OpenRead(path));
            
            loginReport = new List<LoginReport>();

            if (!reader.EndOfStream)
            {
                reader.ReadLine(); // read header line
            }

            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');

                loginReport.Add(new LoginReport(values));
            }
        }

        public static void ReadCsvHeader(string path, ref List<string> formattedHeader)
        {
            var reader = new StreamReader(File.OpenRead(path));
            
            formattedHeader = new List<string>();
            if (!reader.EndOfStream)
            {
                var header = reader.ReadLine().Split(',').ToList();

                foreach (var column in header)
                    formattedHeader.Add(column.Substring(1, column.Length - 2));
            }
        }
    }
}
