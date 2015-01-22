using System;
using System.Collections.Generic;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class AssignmentExternalUnitsTest : TestBase
    {
        private readonly IList<string> ApplicationOfScienceUnits = new List<string>
        {
            UI.SelectUnit,
            UiConst.Unit.U_5_Applications_of_Chemical_Substances,
            UiConst.Unit.U_6_Applications_of_Physical_Science,
            UiConst.Unit.U_7_Health_Applications_of_Life_Science
        };

        private readonly IList<string> BusinessMLNUnits = new List<string>
        {
            UiConst.Unit.HOSPITALITY_OPERATIONS_IN_TRAVEL_AND_TOURISM,
            UiConst.Unit.EVENTS_CONFERENCES_AND_EXHIBITIONS,
            UiConst.Unit.WORK_EXPERIENCE_IN_THE_TRAVEL_TOURISM_SECT
        };

        [Test]
        [Category("WithCourse")]
        public void CheckExternalUnitsCreationWithCourse()
        {
            var context = new CreateCourseContext
            {
                Subject = UiConst.Subject.Application_of_Science,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Application_of_Science,
                Size = UiConst.Size.Award_120_GLH
            };
            string coursename = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            Start.LoginWithCL()
                .CreateCourse()
                .SetName(coursename)
                .CompleteAllDropDowns(context)
                .Continue()
                .SetEndDate(DateTime.Today.AddDays(1))
                .SetStartDate(DateTime.Today)
                .SaveContinue()
                .ConfirmCourse()
                .ConfirmCoursePopup()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .AssociateWithACourse()
                .SelectCourse(coursename)
                .AssertExternalUnits(ApplicationOfScienceUnits);
        }

        [Test]
        public void CheckExternalUnitsCreationWithQualification()
        {
            var context = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.Application_of_Science,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Application_of_Science,
                Size = UiConst.Size.Award_120_GLH
            };
            Start.LoginWithAssessor()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .ChooseFromAllSubjectsAndQualifications()
                .CompleteAllDropDowns(context)
                .AssertExternalUnits(ApplicationOfScienceUnits);
        }

        [Test]
        [Category("WithCourse")]
        public void CheckExternalUnitsEditWithCourse()
        {

            var context = new CreateCourseContext
            {
                Subject = UiConst.Subject.Application_of_Science,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Application_of_Science,
                Size = UiConst.Size.Award_120_GLH
            };
            string coursename = UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' '));
            Start.LoginWithCL()
                .CreateCourse()
                .SetName(coursename)
                .CompleteAllDropDowns(context)
                .Continue()
                .SetEndDate(DateTime.Today.AddDays(1))
                .SetStartDate(DateTime.Today)
                .SaveContinue()
                .ConfirmCourse()
                .ConfirmCoursePopup()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .AssociateWithACourse()
                .SelectCourse(coursename)
                .SelectUnits(new[]
                {
                    UiConst.Unit.U_5_Applications_of_Chemical_Substances,
                    UiConst.Unit.U_6_Applications_of_Physical_Science,
                    UiConst.Unit.U_7_Health_Applications_of_Life_Science
                })
                .SaveAndContinue()
                .Previous()
                .AssertExternalUnits(ApplicationOfScienceUnits);
        }

        [Test]
        public void CheckExternalUnitsEditWithQualification()
        {
            var context = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.Application_of_Science,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Application_of_Science,
                Size = UiConst.Size.Award_120_GLH
            };
            Start.LoginWithAssessor()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .ChooseFromAllSubjectsAndQualifications()
                .CompleteAllDropDowns(context)
                .SelectUnits(new[]
                {
                    UiConst.Unit.U_5_Applications_of_Chemical_Substances,
                    UiConst.Unit.U_6_Applications_of_Physical_Science,
                    UiConst.Unit.U_7_Health_Applications_of_Life_Science
                })
                .SaveAndContinue()
                .Previous()
                .AssertExternalUnits(ApplicationOfScienceUnits)
                ;
        }

        [Test, Ignore]
        public void CheckMlnUnitsCreationWithQualification()
        {
            var context = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.Business,
                Qualification = UiConst.QualificationSuite.BTEC_Nationals_2010_QCF,
                Pathway = UiConst.Pathway.Business,
                Size = UiConst.Size.Extended_Diploma_180_Credits
            };
            Start.LoginWithAssessor()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .ChooseFromAllSubjectsAndQualifications()
                .CompleteAllDropDowns(context)
                .AssertMlnUnits(BusinessMLNUnits);
        }

        [Test]
        public void CheckMlnUnitsEditWithQualification()
        {
            var context = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.Business,
                Qualification = UiConst.QualificationSuite.BTEC_Nationals_2010_QCF,
                Pathway = UiConst.Pathway.Business,
                Size = UiConst.Size.Extended_Diploma_180_Credits
            };
            Start.LoginWithAssessor()
                .PressCreateAssignment()
                .SetAssignmentTitle(UI.TestText.F(Guid.NewGuid().ToString().Replace('-', ' ')))
                .ChooseFromAllSubjectsAndQualifications()
                .CompleteAllDropDowns(context)
                .SelectUnit(UiConst.Unit.U_1_The_Business_Environment)
                .SaveAndContinue()
                .Previous()
                .AssertMlnUnits(BusinessMLNUnits);
        }
    }
}