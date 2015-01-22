using System;
using Edi.Advance.Core.Common;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CreateCourseContext
    {
        public DateTime EndDate = DateTime.Today.AddDays(4);

        public string ID = "";
        public string Pathway = UiConst.Pathway.AppliedScience;
        public string Qualification = UiConst.QualificationSuite.BTEC_Nationals_2010_QCF;

        public string Size = UiConst.Size.Certificate_30_Credits;

        public DateTime StartDate = DateTime.Today.AddDays(1);
        public string Subject = UiConst.Subject.AppliedScience;
        public string Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
        
        public CreateCourseContext()
        {
        }

        public CreateCourseContext(string title)
        {
            Title = title;
        }

        public CreateCourseContext(string title, string subj, string qualif, string path, string size,
            DateTime startDate, DateTime endDate)
        {
            Title = title;
            Subject = subj;
            Qualification = qualif;
            Pathway = path;
            Size = size;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}