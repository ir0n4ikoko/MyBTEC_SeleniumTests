using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseStep1Page : QualificationFilterPage
    {
        public CourseStep1Page()
            : base(UI.CourseStep1Page)
        {
        }


        public TextField Name
        {
            get { return new TextField("Name"); }
        }

        public Link Continue
        {
            get { return new Link("Continue", By.ClassName); }
        }

        public ClickableControl Exit
        {
            get { return new ClickableControl("Exit", By.ClassName); }
        }

        public Label ExitConfirmText
        {
            get { return new Label("confirm"); }
        }

        public PopupButton ExitConfirm(bool yes = true)
        {
            return new PopupButton(yes ? UI.Yes : UI.No, "confirm");
        }
    }
}