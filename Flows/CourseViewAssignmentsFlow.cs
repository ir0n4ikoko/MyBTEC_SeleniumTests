using System;
using System.Collections.Generic;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseViewAssignmentsFlow : CourseViewFlow
    {
        private readonly CourseViewAssignmentsTab assignmentsTab;

        public CourseViewAssignmentsFlow(INavigator navigator, CourseViewAssignmentsTab assignmentsTab)
            : base(navigator, assignmentsTab)
        {
            this.assignmentsTab = assignmentsTab;
        }

        public AssignmentsFlow SearchForAssignment()
        {
            var assignmentsPage = navigator.Navigate<AssignmentsPage>(assignmentsTab.SearchAssignment.Click);

            return new AssignmentsFlow(navigator, assignmentsPage);
        }

        public CourseViewAssignmentsFlow AssertAssignmentStatusIs(string status, string id)
        {
            Assert.AreEqual(status, assignmentsTab.Status(id).Text);

            return this;
        }

        public CourseViewAssignmentsFlow AssertActions(IEnumerable<string> actions, string id)
        {
            assignmentsTab.Actions(id).Click();

            navigator.WaitForJQuery();

            CollectionAssert.AreEqual(actions.OrderBy(t => t),
                assignmentsTab.Actions(id).Options.ToList().OrderBy(t => t), StringComparer.OrdinalIgnoreCase);

            return this;
        }

        public CourseViewAssignmentsFlow CheckRemoveFromCourseForbiddenNotInTeam(string id)
        {
            SelectAssignmentAction(UI.RemoveFromCourse, id);

            Assert.AreEqual(UI.ErrorCanNotRemoveAssignment, assignmentsTab.InfoMessage.Text);

            return this;
        }

        public CourseViewAssignmentsFlow CheckCreateCoversheetForbiddenNotInTeam(string id)
        {
            SelectAssignmentAction(UI.CreateCoversheet, id);

            Assert.AreEqual(UI.ErrorCanNotCreateCoversheet, assignmentsTab.InfoMessage.Text);

            return this;
        }

        public CourseViewAssignmentsFlow SelectAssignmentAction(string action, string id)
        {
            assignmentsTab.Actions(id).Click();

            navigator.WaitForJQuery();

            assignmentsTab.Actions(id).Text = action;

            navigator.WaitForJQuery();

            return this;
        }

        public CourseViewAssignmentsFlow ConfirmRemoving(bool ok = true)
        {
            assignmentsTab.ConfirmRemoving(ok).Click();

            return this;
        }

        public EditAssignmentStep1Flow Edit(string id)
        {
            var editPage = navigator.Navigate<EditAssignmentStep1Page>(() => SelectAssignmentAction(UI.Edit, id));

            return new EditAssignmentStep1Flow(navigator, editPage);
        }

        public CreateCoversheetFlow SelectCreateCoversheet(string id)
        {
            var coversheetPopup =
                navigator.Navigate<CreateCoversheetPopup>(() => SelectAssignmentAction(UI.CreateCoversheet, id));

            return new CreateCoversheetFlow(navigator, coversheetPopup);
        }

        public CourseViewAssignmentsFlow AssertAssignmentDisplayed(string id, bool displayed = true)
        {
            Assert.AreEqual(displayed, assignmentsTab.Actions(id).Displayed,
                "Assignment was {0} found".F(displayed ? "not" : ""));

            navigator.WaitForJQuery();

            return this;
        }

        public CourseViewAssignmentsFlow AssertAssignmentCreatorIs(string creatorName, string assignmentId)
        {
            string creatorCellValue = assignmentsTab.AssignmentCreator(assignmentId).Text.Trim();

            Assert.AreEqual(creatorName, creatorCellValue);

            return this;
        }

        public CourseViewAssignmentsFlow AssertAssignmentQualificationIs(string qualification, string assignmentId)
        {
            string qualificationCellValue = assignmentsTab.AssignmentQualification(assignmentId).Text.Trim();

            Assert.AreEqual(qualification, qualificationCellValue);

            return this;
        }
    }
}