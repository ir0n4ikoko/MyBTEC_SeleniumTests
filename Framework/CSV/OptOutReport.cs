using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class OptOutReport : Report
    {
        private static List<OptOutReport> optOutReport;

        public OptOutReport()
        {
        }

        public OptOutReport(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            Email = values[2];
            CentreNumber = values[3];
            CentreName = values[4];
            DateTimeOptedOut = DateTime.ParseExact(values[5], UiConst.DateTimeFormat.LongDateTimeFormat, null);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }
        public DateTime DateTimeOptedOut { get; set; }

        private static void ReadOptOutReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            optOutReport = new List<OptOutReport>();

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
                optOutReport.Add(new OptOutReport(values));
            }
        }

        public static int GetCountRowsOutPeriod(string path, DateTime start, DateTime end)
        {
            if (optOutReport == null)
            {
                ReadOptOutReportCsv(path);
            }

            List<OptOutReport> find = optOutReport.FindAll(p => (p.DateTimeOptedOut.CompareTo(start) < 0 ||
                                                                 p.DateTimeOptedOut.CompareTo(end) > 0));

            return find.Count;
        }

        public static int GetCountRowsForGivenOptOut(string path, OptOutReport optOut)
        {
            if (optOutReport == null)
            {
                ReadOptOutReportCsv(path);
            }

            List<OptOutReport> find = optOutReport.FindAll(p => (p.FirstName.Equals(optOut.FirstName) &&
                                                                 p.LastName.Equals(optOut.LastName) &&
                                                                 p.Email.Equals(optOut.Email) &&
                                                                 (optOut.DateTimeOptedOut.Subtract(p.DateTimeOptedOut)
                                                                     .TotalMinutes > -10) &&
                                                                 (optOut.DateTimeOptedOut.Subtract(p.DateTimeOptedOut)
                                                                     .TotalMinutes < 10) &&
                                                                 p.CentreNumber.Equals(optOut.CentreNumber) &&
                                                                 p.CentreName.Equals(optOut.CentreName)));

            return find.Count;
        }
    }
}