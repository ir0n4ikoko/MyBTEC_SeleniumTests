using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseStep3Page : BtecMasterPage
    {
        public CourseStep3Page()
            : base(UI.CourseStep3Page)
        {
        }

        public string Id
        {
            get { return new HiddenControl("Id").Text; }
        }

        public Link ConfirmCourse
        {
            get { return new Link("ValidateCourse", By.ClassName); }
        }

        public Link SaveAsDraftButton
        {
            get { return new Link("SaveAsDraft", By.ClassName); }
        }

        public PopupButton DraftPopupYes
        {
            get { return new PopupButton(UI.Yes, "confirmDraft"); }
        }

        public PopupButton ConfirmCoursePopupButton
        {
            get { return new PopupButton(UI.ConfirmCourse, "confirmCoursePopup"); }
        }

        public Label RedWarningNote
        {
            get { return new Label("redWarning", By.ClassName); }
        }
    }
}