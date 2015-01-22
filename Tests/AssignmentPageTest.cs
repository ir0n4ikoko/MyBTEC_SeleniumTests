using System;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class AssignmentPageTest : TestBase
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

        [Test]
        public void CreateAssignment()
        {
            Start
                .LoginWithQN()
                .CreateAssignmentTillStep3()
                .SetScenario(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskDescription(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .CheckAllCheckboxes()
                .PopupTaskCriteriaClickOk()
                .SetEvidence(UI.TestText.F(DateTime.Now.Ticks))
                .SetAssignmentDuration(UI.TestText.F(DateTime.Now.Ticks))
                .SaveAndContinue()
                .ClickFinish();
        }

        [Test]
        public void CheckInvalidAssignment()
        {
            var assignment = new CreateAssignmentContext();
            Start
                .LoginWithQN()
                .CreateAssignmentTillStep2(assignment)
                .SelectAllCriteria()
                .GoToLastStep()
                .CheckAssignmentStep4WarningMessageAndClosePopup(UI.AssignmentStep4WarningMessage)
                .AssertSendToAcsButtonDisabled()
                .AssertSendToIvButtonDisabled()
                .CheckTheQuantityOfUncoveredACs(assignment.QuantityOfCriteriaToCover)
                .FinishWithStatusResult(assignment).Flow
                .SelectAction(UI.SendToACS, assignment.ID)
                .CheckAssignmentGridWarningMessageAndClosePopup(UI.AssignmentStep4WarningMessage)
                .SelectAction(UI.SendToIV, assignment.ID)
                .CheckAssignmentGridWarningMessageAndClosePopup(UI.AssignmentStep4WarningMessage)
                ;

        }
    }
}