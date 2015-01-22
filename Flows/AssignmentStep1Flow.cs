using System;
using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class AssignmentStep1Flow : SelectQualificationFlow<AssignmentStep1Flow>
    {
        private readonly AssignmentStep1Page page;

        public AssignmentStep1Flow(INavigator navigator, AssignmentStep1Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public AssignmentStep1Flow SetAssignmentTitle(string assignmentName)
        {
            page.Title.Text = assignmentName;

            return this;
        }

        public AssignmentStep1Flow SetAssignmentAuthor(string author, bool pearsonAssignment = false)
        {
            if (!pearsonAssignment)
            {
                return this;
            }
            page.Author.Text = author;

            return this;
        }

        public AssignmentStep1Flow AssociateWithACourse()
        {
            page.AssociateWithACourse.Click();

            return this;
        }

        public AssignmentStep1Flow SelectCourse(string course, bool courseExists = true)
        {
            navigator.WaitForJQuery();

            if (courseExists)
            {
                page.Course.Text = course;
            }
            else
            {
                Assert.IsTrue(!page.Course.Options.Contains(course),
                    "Course " + course + " exists in dropdown but should not");
            }

            return this;
        }

        public AssignmentStep1Flow SelectCourseById(string courseId, bool courseExists = true)
        {
            navigator.WaitForJQuery();

            if (courseExists)
            {
                page.Course.Value = courseId;
            }
            else
            {
                Assert.IsTrue(!page.Course.Values.Contains(courseId),
                    "Course " + courseId + " exists in dropdown but should not");
            }

            return this;
        }

        public AssignmentStep1Flow ChooseFromAllSubjectsAndQualifications(bool pearsonAssignment = false)
        {
            if (pearsonAssignment)
            {
                return this;
            }
            page.ChooseFromAllSubjectsAndQualifications.Click();

            return this;
        }

        public AssignmentStep1Flow FillAllRequiredDataOnStep1(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }
            if (context.Status.Equals(UI.Authorised) || context.Status.Equals(UI.Editing) ||
                context.Status.Equals(UI.DDMReview) || context.Status.Equals(UI.ExternalTest))
            {
                context.IsPearson = true;
            }

            SetAssignmentTitle(context.Title)
                .SetAssignmentAuthor(context.Author, context.IsPearson);

            if (context.CourseTitle.IsNotNullOrEmpty())
            {
                SelectCourse(context.CourseTitle);
            }
            else if (context.CourseId.IsNotNullOrEmpty())
            {
                SelectCourseById(context.CourseId);
            }
            else
            {
                ChooseFromAllSubjectsAndQualifications(context.IsPearson)
                    .CompleteAllDropDowns(context);
            }

            return SelectUnits(context);
        }

        public AssignmentStep1Flow SelectUnits(CreateAssignmentContext context)
        {
            return (context.FirstUnit)
                ? SelectUnit(
                    page.Unit.Options.Where(unit => !unit.Contains("MLN") && !unit.Equals(UI.SelectUnit)).ToArray()[0])
                : ((context.AllUnits)
                    ? SelectUnits(
                        page.Unit.Options.Where(unit => !unit.Contains("MLN") && !unit.Equals(UI.SelectUnit)).ToArray())
                    : SelectUnits(context.Units));
        }

        public AssignmentStep1Flow SelectUnit(string unit)
        {
            navigator.WaitForJQuery();

            SetUnit(unit);

            return this;
        }

        private void SetUnit(string unit)
        {
            page.Unit.Text = unit;

            page.AddUnit.Click();

            navigator.WaitForJQuery();
        }

        public AssignmentStep1Flow SelectUnits(params string[] units)
        {
            navigator.WaitForJQuery();

            units.ForEach(SetUnit);

            return this;
        }

        public AssignmentStep1Flow AssertExternalUnits(IEnumerable<string> units)
        {
            navigator.WaitForJQuery();

            string[] difference = page.Unit.Options.Except(units).ToArray();

            Assert.IsFalse(difference.Any(), "Units differ: {0}".F(string.Join(", ", difference)));

            return this;
        }

        public AssignmentStep1Flow AssertMlnUnits(IEnumerable<string> units)
        {
            navigator.WaitForJQuery();

            units.ForEach(unit => { page.Unit.Text = unit; });

            return this;
        }

        public AssignmentStep2Flow SaveAndContinue()
        {
            var assignmentStep2Page =
                navigator.DoActionWaitForJQueryAndNavigate<AssignmentStep2Page>(page.SaveAndContinue.Click);

            return new AssignmentStep2Flow(navigator, assignmentStep2Page);
        }

        public AssignmentStep1Flow SaveAndContinueWithError()
        {
            page.SaveAndContinue.Click();

            return this;
        }

        public AssignmentStep1Flow CheckTitleValidation(string errText)
        {
            Assert.IsTrue(!page.Title.IsValid, "Title field has not validation");

            Assert.AreEqual(errText, page.Title.ValidationMessage, "Incorrect validation error message for field Title");

            return this;
        }

        public AssignmentStep1Flow CheckAuthorValidation(string errText)
        {
            Assert.IsTrue(!page.Author.IsValid, "Author field has not validation");

            Assert.AreEqual(errText, page.Author.ValidationMessage,
                "Incorrect validation error message for field Author");

            return this;
        }

        public AssignmentStep1Flow CheckSubjectValidation(string errText)
        {
            Assert.IsTrue(!page.SubjectValid.IsValid, "Subject field has not validation");

            Assert.AreEqual(errText, page.SubjectValid.ValidationMessage,
                "Incorrect validation error message for field Subject");

            return this;
        }

        public AssignmentStep1Flow CheckQualificationValidation(string errText)
        {
            Assert.IsTrue(!page.QualificationSuiteValid.IsValid, "QualificationSuite field has not validation");

            Assert.AreEqual(errText, page.QualificationSuiteValid.ValidationMessage,
                "Incorrect validation error message for field QualificationSuite");

            return this;
        }

        public AssignmentStep1Flow CheckNoUnitsValidation()
        {
            Assert.AreEqual(UI.ValidationNoUnitsAdded, page.ErrorNoUnits.Text,
                "Incorrect validation error message for no units added");

            page.ErrorNoUnitsOk.Click();

            return this;
        }

        public AssignmentStep1Flow CheckValidation(bool isPearson = false)
        {
            SaveAndContinueWithError();
            CheckTitleValidation(UI.ValidationFieldRequired.F(UI.Title));
            if (isPearson)
            {
                CheckAuthorValidation(UI.ValidationFieldRequired.F(UI.Author));
            }
            CheckSubjectValidation(UI.ValidationFieldRequired.F(UI.Subject));
            CheckQualificationValidation(UI.ValidationFieldRequired.F(UI.QualificationSuite));

            string char50 = UI.Char50;
            page.Title.Text = char50 + char50 + char50 + char50 + "aa";
            SaveAndContinueWithError();
            CheckTitleValidation(UI.ValidationSpecialChars);

            if (isPearson)
            {
                page.Author.Text = char50 + char50 + char50 + "x";
                SaveAndContinueWithError();
                CheckAuthorValidation(UI.ValidationLength.F(UI.Author, "150"));
            }

            page.Title.Text = "@";
            SaveAndContinueWithError();
            CheckTitleValidation(UI.ValidationSpecialChars);

            if (isPearson)
            {
                page.Author.Text = "<html>";
                SaveAndContinueWithError();
                CheckAuthorValidation(UI.ValidationHtmlTags);
            }

            return this;
        }

        public AssignmentStep1Flow CreateDraftAssignment(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }

            ChooseFromAllSubjectsAndQualifications()
                .CompleteAllDropDowns(context)
                .SetAssignmentTitle(context.Title);

            page.Unit.ElementOptions.Where(unit => unit.Text != UI.SelectUnit)
                .ToList()
                .ForEach(unit => SetUnit(unit.Text));

            SaveAndContinue()
                .SelectAllCriteria()
                .SaveAndContinue()
                .SetScenario(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskDescription(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .CheckAllCheckboxes()
                .PopupTaskCriteriaClickOk()
                .SetEvidence(UI.TestText.F(DateTime.Now.Ticks))
                .SetAssignmentDuration(UI.TestText.F(DateTime.Now.Ticks))
                .SaveAndContinue()
                .ClickFinish()
                .PressCreateAssignment();
            return this;
        }

        public AssignmentStep1Flow CreateAssignmentAndSendToIV(CreateAssignmentContext assignmentContext, string nameIV)
        {
            ChooseFromAllSubjectsAndQualifications().CompleteAllDropDowns(assignmentContext).SetAssignmentTitle(assignmentContext.Title);
                

            page.Unit.ElementOptions.Where(unit => unit.Text != UI.SelectUnit)
                .ToList()
                .ForEach(unit => SetUnit(unit.Text));

            SaveAndContinue()
                .SelectAllCriteria()
                .SaveAndContinue()
                .SetScenario(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskDescription(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .CheckAllCheckboxes()
                .PopupTaskCriteriaClickOk()
                .SetEvidence(UI.TestText.F(DateTime.Now.Ticks))
                .SetAssignmentDuration(UI.TestText.F(DateTime.Now.Ticks))
                .SaveAndContinue()
                .ClickSendToIv()
                .SelectSendToIv(nameIV)
                .SaveAndSendToIVnow()
                .PressCreateAssignment();
            return this;
        }

        public AssignmentStep1Flow SubjectListCheck(IEnumerable<string> subjectList)
        {
            IEnumerable<string> currentSubjectList = page.Subject.Options;
            IEnumerable<string> difference = currentSubjectList.Except(subjectList, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(difference.Last(), UI.SelectSubject);
            return this;
        }

        public AssignmentStep1Flow CompleteAllDropDowns(CreateAssignmentContext assignmentContext)
        {
            SelectSubject(assignmentContext.Subject, this)
                .SelectQualificationSuite(assignmentContext.Qualification, this)
                .SelectPathway(assignmentContext.Pathway, this)
                .SelectSize(assignmentContext.Size, this)
                ;

            return this;
        }
    }
}