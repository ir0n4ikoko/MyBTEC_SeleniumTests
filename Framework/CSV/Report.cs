using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Edi.Advance.BTEC.UiTests.Framework.CSV
{
    public class Report
    {
        public static List<Report> report;
        public static List<string> Values;

        public Report()
        {
        }

        public Report(IEnumerable<string> values)
        {
            Values = values.ToList();
        }

        public static void ReadReportCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));

            report = new List<Report>();

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
                report.Add(new Report(values));
            }
        }

        public static void ReadCsvHeader(string path, ref List<string> formattedHeader)
        {
            var reader = new StreamReader(File.OpenRead(path));

            formattedHeader = new List<string>();
            if (!reader.EndOfStream)
            {
                List<string> header = reader.ReadLine().Split(',').ToList();

                formattedHeader.AddRange(header.Select(column => column.Substring(1, column.Length - 2)));
            }
        }
    }
}