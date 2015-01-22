using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class QualificationFilterPage : BtecMasterPage
    {
        public QualificationFilterPage(string url)
            : base(url)
        {
        }

        public Dropdown Subject
        {
            get { return new Dropdown("Subjectdropdown"); }
        }

        public Dropdown QualificationSuite
        {
            get { return new Dropdown("Qualificationdropdown"); }
        }

        public Dropdown Pathway
        {
            get { return new Dropdown("Pathwaydropdown"); }
        }

        public Dropdown Size
        {
            get { return new Dropdown("Sizedropdown"); }
        }

        public ValidableControl SubjectValid
        {
            get { return new ValidableControl("Subject"); }
        }

        public ValidableControl QualificationSuiteValid
        {
            get { return new ValidableControl("Qualification"); }
        }

        public ValidableControl PathwayValid
        {
            get { return new ValidableControl("Pathway"); }
        }

        public ValidableControl SizeValid
        {
            get { return new ValidableControl("Size"); }
        }
    }
}