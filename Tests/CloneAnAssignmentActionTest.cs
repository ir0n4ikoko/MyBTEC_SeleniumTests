using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CloneAnAssignmentActionTest : TestBase
    {
        [Test]
        public void Note_WhenSomeoneTriesToCloneAnAssignment()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithAssessor()
                .CreateAssignment(assignment).Flow
                .Clone(assignment.ID)
                .AssertClonePopUpWithNote();
        }
    }
}