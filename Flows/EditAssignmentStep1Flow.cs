using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class EditAssignmentStep1Flow : BtecMasterFlow<EditAssignmentStep1Flow>
    {
        private readonly AssignmentStep1Page page;

        public EditAssignmentStep1Flow(INavigator navigator, EditAssignmentStep1Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public AssignmentStep2Flow SaveAndContinue()
        {
            var assignmentStep2Page =
                navigator.DoActionWaitForJQueryAndNavigate<AssignmentStep2Page>(page.SaveAndContinue.Click);

            return new AssignmentStep2Flow(navigator, assignmentStep2Page);
        }


        public EditAssignmentStep1Flow AssertExternalUnits(IEnumerable<string> units)
        {
            navigator.WaitForJQuery();

            string[] difference = page.Unit.Options.Except(units).ToArray();

            Assert.IsFalse(difference.Any(), "Units differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public EditAssignmentStep1Flow AssertMlnUnits(IEnumerable<string> units)
        {
            navigator.WaitForJQuery();

            units.ForEach(unit => { page.Unit.Text = unit; });

            return this;
        }
    }
}