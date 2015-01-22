using System;
using Edi.Advance.BTEC.UiTests.Framework.CSV;
using Edi.Advance.Core.Common;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CreateAssignmentContext
    {
        public bool AllUnits = false;
        public string Author = UI.TestText.F(DateTime.Now.Ticks);
        public string CourseId = "";
        public string CourseTitle = "";

        public string Duration = UI.TestText.F(DateTime.Now.Ticks);
        public string Evidence = UI.TestText.F(DateTime.Now.Ticks);
        public bool FirstUnit = false;
        public string ID = "";

        public string IV = UiConst.FirstName.Iv + " " + UiConst.LastName.Iv;
        public bool IsPearson = false;
        public string IvFeedback = UI.NotApprovedFeedback;

        public string IvLogin = UiConst.Login.Iv;

        public string IvPassword = UiConst.Password.Iv;
        public string Pathway = UiConst.Pathway.AppliedScience;
        public string Qualification = UiConst.QualificationSuite.BTEC_Nationals_2010_QCF;
        public string Scenario = UI.TestText.F(DateTime.Now.Ticks);
        public string Size = UiConst.Size.Certificate_30_Credits;
        public string Sources = UI.TestText.F(DateTime.Now.Ticks);
        public string Status = UI.Draft;
        public string Subject = UiConst.Subject.AppliedScience;
        public string TaskDescription = UI.TestText.F(DateTime.Now.Ticks);
        public string TaskTitle = UI.TestText.F(DateTime.Now.Ticks);
        public string Title = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
        public string[] Units = { UiConst.Unit.U_1_Fundamentals_of_Science };

        public int QuantityOfCriteriaToCover = 17;

        public CreateAssignmentContext()
        {
        }

        public CreateAssignmentContext(AssignmentReport ar)
        {
            Subject = ar.Subject;

            if (ar.CoursesLinked == 1)
                CourseTitle = ar.Title;

            Title = ar.Title;

            if (ar.CurrentStatus.Equals(UI.Authorised) || ar.CurrentStatus.Equals(UI.Editing) ||
                ar.CurrentStatus.Equals(UI.DDMReview) || ar.CurrentStatus.Equals(UI.ExternalTest))
                IsPearson = true;

            FirstUnit = true;

            if (ar.CurrentStatus != null)
                Status = ar.CurrentStatus;

            if (ar.context != null)
            {
                if (ar.context.Qualification != null)
                    Qualification = ar.context.Qualification;

                if (ar.context.Pathway != null)
                    Pathway = ar.context.Pathway;

                if (ar.context.Size != null)
                    Size = ar.context.Size;

                if (ar.context.IV != null)
                    IV = ar.context.IV;

                if (ar.context.IvLogin != null)
                    IvLogin = ar.context.IvLogin;

                if (ar.context.IvPassword != null)
                    IvPassword = ar.context.IvPassword;

                if (ar.context.IvFeedback != null)
                    IvFeedback = ar.context.IvFeedback;
            }
        }

        public CreateAssignmentContext(string title, string subj, string qualif, string path, string size, string author,
            string[] units)
        {
            Title = title;
            Subject = subj;
            Qualification = qualif;
            Pathway = path;
            Size = size;
            Author = author;
            Units = units;
        }
    }
}