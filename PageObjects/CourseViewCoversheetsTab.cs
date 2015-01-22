using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseViewCoversheetsTab : CourseViewPage
    {
        public GridControl CoversheetsGrid
        {
            get { return new GridControl("gbox_table_TeamGrid", "TeamGrid"); }
        }
    }
}