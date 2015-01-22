using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class RoleClaimReport : Report
    {
        private static List<RoleClaimReport> roleClaimReport;

        public RoleClaimReport()
        {
        }

        public RoleClaimReport(string[] values) : base(values)
        {
            FirstName = values[0];
            LastName = values[1];
            Email = values[2];
            RoleClaimed = values[3];
            DateRoleClaimed = DateTime.ParseExact(values[4], UiConst.DateTimeFormat.LongDateTimeFormat, null);
            CentreNumber = values[5];
            CentreName = values[6];
            Subject = values[7];
            Approved = values[8];
            SiteQn = values[9].Split(';');
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleClaimed { get; set; }
        public DateTime DateRoleClaimed { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }
        public string Subject { get; set; }
        public string Approved { get; set; }
        public string[] SiteQn { get; set; }

        private static void ReadRoleClaimReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            roleClaimReport = new List<RoleClaimReport>();

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
                roleClaimReport.Add(new RoleClaimReport(values));
            }
        }

        public static int GetCountRowsOutPeriod(string path, DateTime start, DateTime end)
        {
            if (roleClaimReport == null)
            {
                ReadRoleClaimReportCsv(path);
            }

            List<RoleClaimReport> find = roleClaimReport.FindAll(p => (p.DateRoleClaimed.CompareTo(start) < 0 ||
                                                                       p.DateRoleClaimed.CompareTo(end) > 0));

            return find.Count;
        }

        public static int GetCountRowsForGivenRole(string path, RoleClaimReport claimedRole, string role, string subject,
            string approved)
        {
            if (roleClaimReport == null)
            {
                ReadRoleClaimReportCsv(path);
            }

            List<RoleClaimReport> find = roleClaimReport.FindAll(p => (p.FirstName.Equals(claimedRole.FirstName) &&
                                                                       p.LastName.Equals(claimedRole.LastName) &&
                                                                       p.RoleClaimed.Equals(role) &&
                                                                       p.CentreNumber.Equals(claimedRole.CentreNumber) &&
                                                                       p.CentreName.Equals(claimedRole.CentreName) &&
                                                                       p.Subject.Contains(subject) &&
                                                                       p.Approved.Equals(approved)));

            return find.Count;
        }
    }
}