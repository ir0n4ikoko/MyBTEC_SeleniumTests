using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CreateCoversheetPopup : CourseViewPage
    {
        public Calendar StartDate
        {
            get { return new Calendar("StartDate"); }
        }

        public Calendar FirstSubmission
        {
            get { return new Calendar("FirstSubmission"); }
        }

        public Calendar FinalSubmission
        {
            get { return new Calendar("FinalSubmission"); }
        }

        public Dropdown Assessors
        {
            get { return new Dropdown("AssessorList"); }
        }

        public Dropdown IVs
        {
            get { return new Dropdown("IvList"); }
        }

        public Label SelectedAssessors
        {
            get { return new Label("Assessors"); }
        }

        public Label SelectedIVs
        {
            get { return new Label("Ivs"); }
        }

        public TextField Comments
        {
            get { return new TextField("Comments"); }
        }

        public ControlBase HelpComments
        {
            get { return new ControlBase(".//div[contains(@class,'helpImage ')]", By.XPath); }
        }

        public ClickableControl AddAssessor
        {
            get { return new ClickableControl("addAssessor"); }
        }

        public ClickableControl AddIV
        {
            get { return new ClickableControl("addIv"); }
        }

        public PopupButton Create
        {
            get { return new PopupButton(UI.Create, "coverSheetPopup"); }
        }

        public PopupButton Cancel
        {
            get { return new PopupButton(UI.Cancel, "coverSheetPopup"); }
        }

        public PopupButton Download
        {
            get { return new PopupButton(UI.Download, "downloadCoverSheetPopup"); }
        }

        public PopupButton CancelDownload
        {
            get { return new PopupButton(UI.Cancel, "downloadCoverSheetPopup"); }
        }
    }
}