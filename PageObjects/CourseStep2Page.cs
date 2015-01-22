using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseStep2Page : BtecMasterPage
    {
        public CourseStep2Page()
            : base(UI.CourseStep2Page)
        {
        }

        public Calendar StartDate
        {
            get { return new Calendar("StartDate"); }
        }

        public Calendar EndDate
        {
            get { return new Calendar("EndDate"); }
        }

        public Link SaveContinueButton
        {
            get { return new Link("SaveContinue", By.ClassName); }
        }

        public PopupButton ConfirmAsDraftPopupYes
        {
            get { return new PopupButton(UI.Yes, "saveDialog"); }
        }

        public Link SaveButton
        {
            get { return new Link("Save", By.ClassName); }
        }

        public ClickableControl AddUnits
        {
            get { return new ClickableControl("btnAdd1"); }
        }

        public GridControl OptionalUnitsGrid
        {
            get { return new GridControl("gbox_table_CourseCommonOptionalUnitsGrid", "CourseCommonOptionalUnitsGrid"); }
        }
    }
}