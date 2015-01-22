using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class TestAllSpecs : TestBase
    {
        [Test]
        [Category("Big")]
        public void CreateAllPossibleAssignments()
        {
            Start
                .LoginWithQN()
                .PressCreateAssignment()
                .ChooseFromAllSubjectsAndQualifications()
                .GetAllPosibleCombinations()
                .GoToAssignments()
                .CreateAllAssignments();
        }
    }
}