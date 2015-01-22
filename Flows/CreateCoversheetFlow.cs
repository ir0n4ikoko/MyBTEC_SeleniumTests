using System;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CreateCoversheetFlow : BtecMasterFlow<CreateCoversheetFlow>
    {
        private readonly CreateCoversheetPopup coversheetPopup;

        public CreateCoversheetFlow(INavigator navigator, CreateCoversheetPopup coversheetPopup)
            : base(navigator, coversheetPopup)
        {
            this.coversheetPopup = coversheetPopup;
        }

        public CourseViewAssignmentsFlow CancelCreate()
        {
            var assignmentsTab = navigator.Navigate<CourseViewAssignmentsTab>(coversheetPopup.Cancel.Click);

            return new CourseViewAssignmentsFlow(navigator, assignmentsTab);
        }

        public CreateCoversheetFlow Create()
        {
            coversheetPopup.Create.Click();

            return this;
        }

        public CreateCoversheetFlow CreateWithValidation()
        {
            coversheetPopup.Create.Click();

            return this;
        }

        public CourseViewAssignmentsFlow Download()
        {
            var assignmentsTab = navigator.Navigate<CourseViewAssignmentsTab>(coversheetPopup.Download.Click);

            return new CourseViewAssignmentsFlow(navigator, assignmentsTab);
        }

        public CourseViewAssignmentsFlow CancelDownload()
        {
            var assignmentsTab = navigator.Navigate<CourseViewAssignmentsTab>(coversheetPopup.CancelDownload.Click);

            return new CourseViewAssignmentsFlow(navigator, assignmentsTab);
        }

        public CreateCoversheetFlow SetStartDate(DateTime date)
        {
            coversheetPopup.StartDate.SelectDate(date.ToString("dd/MM/yyyy"));

            return this;
        }

        public CreateCoversheetFlow SetFirstSubmissionDate(DateTime date)
        {
            coversheetPopup.FirstSubmission.SelectDate(date.ToString("dd/MM/yyyy"));

            return this;
        }

        public CreateCoversheetFlow SetFinalSubmissionDate(DateTime date)
        {
            coversheetPopup.FinalSubmission.SelectDate(date.ToString("dd/MM/yyyy"));

            return this;
        }

        public CreateCoversheetFlow AddAssessor(string name)
        {
            coversheetPopup.Assessors.Text = name;

            coversheetPopup.AddAssessor.Click();

            return this;
        }

        public CreateCoversheetFlow AddAssessors(string[] names)
        {
            names.ForEach(name => AddAssessor(name));

            return this;
        }

        public CreateCoversheetFlow AddIV(string name)
        {
            coversheetPopup.IVs.Text = name;

            coversheetPopup.AddIV.Click();

            return this;
        }

        public CreateCoversheetFlow AddIVs(string[] names)
        {
            names.ForEach(name => AddIV(name));

            return this;
        }

        public CreateCoversheetFlow CheckValidationStartDate(string errMsg)
        {
            Assert.IsFalse(coversheetPopup.StartDate.IsValid,
                "Validation error '{0}' expected for Start date field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.StartDate.ValidationMessage,
                "Incorrect validation error for Start date field");

            return this;
        }

        public CreateCoversheetFlow CheckValidationFirstSubmissionDate(string errMsg)
        {
            Assert.IsFalse(coversheetPopup.FirstSubmission.IsValid,
                "Validation error '{0}' expected for First submission date field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.FirstSubmission.ValidationMessage,
                "Incorrect validation error for First submission date field");

            return this;
        }

        public CreateCoversheetFlow CheckValidationFinalSubmissionDate(string errMsg)
        {
            Assert.IsFalse(coversheetPopup.FinalSubmission.IsValid,
                "Validation error '{0}' expected for Final submission date field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.FinalSubmission.ValidationMessage,
                "Incorrect validation error for Final submission date field");

            return this;
        }

        public CreateCoversheetFlow CheckValidationAssessors(string errMsg)
        {
            Assert.IsFalse(coversheetPopup.SelectedAssessors.IsValid,
                "Validation error '{0}' expected for Assessors field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.SelectedAssessors.ValidationMessage,
                "Incorrect validation error for Assessors field");

            return this;
        }

        public CreateCoversheetFlow CheckValidationIVs(string errMsg)
        {
            Assert.IsFalse(coversheetPopup.SelectedIVs.IsValid,
                "Validation error '{0}' expected for IVs field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.SelectedIVs.ValidationMessage,
                "Incorrect validation error for IVs field");

            return this;
        }

        public CreateCoversheetFlow CheckCommentsHelp(string helpMsg)
        {
            Assert.AreEqual(helpMsg, coversheetPopup.HelpComments.GetAttribute("message"),
                "Incorrect help message for Comment field");

            return this;
        }

        public CreateCoversheetFlow CheckValidationComments(string errMsg)
        {
            coversheetPopup.Comments.Text = "aaa><bbb";

            Assert.IsFalse(coversheetPopup.Comments.IsValid,
                "Validation error '{0}' expected for Comments field".F(errMsg));

            Assert.AreEqual(errMsg, coversheetPopup.Comments.ValidationMessage,
                "Incorrect validation error for Comments field");

            return this;
        }

        public CreateCoversheetFlow CheckNoCreateButton()
        {
            Assert.IsFalse(coversheetPopup.Create.Enabled, "Create button should be hidden");

            return this;
        }

        public CreateCoversheetFlow SetComments(string comments)
        {
            coversheetPopup.Comments.Text = comments;

            return this;
        }
    }
}