using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseViewCoversheetsFlow : CourseViewFlow
    {
        private readonly CourseViewCoversheetsTab coversheetsTab;

        public CourseViewCoversheetsFlow(INavigator navigator, CourseViewCoversheetsTab coversheetsTab)
            : base(navigator, coversheetsTab)
        {
            this.coversheetsTab = coversheetsTab;
        }
    }
}