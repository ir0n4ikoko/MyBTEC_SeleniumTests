using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ErrorFeedbackPage : BtecMasterPage
    {
        public ErrorFeedbackPage()
            : base(UI.ErrorFeedbackPage)
        {
        }


        public Label SmthWrongText
        {
            get { return new Label(".//div[@id='page']/h2", By.XPath); }
        }

        public Label PleaseAddDetailsText
        {
            get { return new Label(".//div[@id='page']/h3[1]", By.XPath); }
        }

        public Label ThankYouText
        {
            get { return new Label(".//div[@id='page']/h3[2]", By.XPath); }
        }

        public HiddenControl ExceptionId
        {
            get { return new HiddenControl("ExceptionId"); }
        }

        public HiddenControl ExceptionMessage
        {
            get { return new HiddenControl("ExceptionMessage"); }
        }

        public HiddenControl Stacktrace
        {
            get { return new HiddenControl("StackTrace"); }
        }

        public CKeditor ErrorDescription
        {
            get { return new CKeditor("Description", By.Name); }
        }

        public ClickableControl ErrorSend
        {
            get { return new ClickableControl("Send"); }
        }
    }
}