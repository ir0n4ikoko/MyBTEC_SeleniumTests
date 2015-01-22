using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class LoginReport : Report
    {
        private static List<LoginReport> loginReport;

        public LoginReport()
        {
        }

        public LoginReport(string[] values) : base(values)
        {
            Email = values[0];
            FirstName = values[1];
            LastName = values[2];
            LoginDateTime = DateTime.ParseExact(values[3], UiConst.DateTimeFormat.LongDateTimeFormat, null);
            CentreNumber = values[4];
            CentreName = values[5];
        }

        public LoginReport(LoginReport loginReport)
        {
            Email = loginReport.Email;
            FirstName = loginReport.FirstName;
            LastName = loginReport.LastName;
            LoginDateTime = loginReport.LoginDateTime;
            CentreNumber = loginReport.CentreNumber;
            CentreName = loginReport.CentreName;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }

        private static void ReadLoginReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            loginReport = new List<LoginReport>();

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
                loginReport.Add(new LoginReport(values));
            }
        }

        public static int GetCountRowsOutPeriod(string path, DateTime start, DateTime end)
        {
            if (loginReport == null)
            {
                ReadLoginReportCsv(path);
            }

            List<LoginReport> find = loginReport.FindAll(p => (p.LoginDateTime.CompareTo(start) < 0 ||
                                                               p.LoginDateTime.CompareTo(end) > 0));

            return find.Count;
        }

        public static int GetCountRowsForGivenLogin(string path, LoginReport myLogin)
        {
            if (loginReport == null)
            {
                ReadLoginReportCsv(path);
            }

            List<LoginReport> find = loginReport.FindAll(p => (p.FirstName.Equals(myLogin.FirstName) &&
                                                               p.LastName.Equals(myLogin.LastName) &&
                                                               (myLogin.LoginDateTime.Subtract(p.LoginDateTime)
                                                                   .TotalMinutes > 0) &&
                                                               (myLogin.LoginDateTime.Subtract(p.LoginDateTime)
                                                                   .TotalMinutes < 5) &&
                                                               p.CentreNumber.Equals(myLogin.CentreNumber) &&
                                                               p.CentreName.Equals(myLogin.CentreName)));

            return find.Count;
        }
    }
}