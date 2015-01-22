using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ReportsPage : BtecMasterPage
    {
        public ReportsPage()
            : base(UI.ReportsPage)
        {
        }

        public Dropdown ReportType
        {
            get { return new Dropdown("ReportType"); }
        }

        public Calendar StartDate
        {
            get { return new Calendar("StarDate"); }
        }

        public Calendar EndDate
        {
            get { return new Calendar("EndDate"); }
        }

        public ClickableControl Generate
        {
            get { return new ClickableControl("btnGenerate"); }
        }
    }
}