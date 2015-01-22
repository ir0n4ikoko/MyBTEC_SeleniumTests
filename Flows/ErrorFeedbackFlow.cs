using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ErrorFeedbackFlow : BtecMasterFlow<ErrorFeedbackFlow>
    {
        private readonly ErrorFeedbackPage page;

        public ErrorFeedbackFlow(INavigator navigator, ErrorFeedbackPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ErrorFeedbackFlow CheckErrorFeedbackText(string smthWrongText, string pleaseAddDetailsText)
        {
            Assert.AreEqual(smthWrongText, page.SmthWrongText.Text, "Error feedback page text is incorrect");
            Assert.AreEqual(pleaseAddDetailsText, page.PleaseAddDetailsText.Text,
                "Error feedback page text is incorrect");

            return this;
        }

        public ErrorFeedbackFlow SendEmptyErrorFeedback(string thankYouText, out string exceptionId,
            out string exceptionMessage, out string stacktrace)
        {
            exceptionId = page.ExceptionId.Text;
            exceptionMessage = page.ExceptionMessage.Text;
            stacktrace = page.Stacktrace.Text;
            //stacktrace = stacktrace.Replace("\r", string.Empty);
            stacktrace = stacktrace.Replace("<BeginProcessRequest>", string.Empty);
            stacktrace = stacktrace.Replace("<ProcessInApplicationTrust>", string.Empty);
            stacktrace = stacktrace.Replace("<>", string.Empty);

            page.ErrorSend.Click();

            Assert.AreEqual(thankYouText, page.ThankYouText.Text, "Error feedback page text is incorrect");

            return this;
        }

        public ErrorFeedbackFlow SendErrorFeedback(string description, string thankYouText, out string exceptionId,
            out string exceptionMessage, out string stacktrace)
        {
            RefreshPage();

            exceptionId = page.ExceptionId.Text;
            exceptionMessage = page.ExceptionMessage.Text;
            stacktrace = page.Stacktrace.Text;
            stacktrace = stacktrace.Replace("<BeginProcessRequest>", string.Empty);
            stacktrace = stacktrace.Replace("<ProcessInApplicationTrust>", string.Empty);
            stacktrace = stacktrace.Replace("<>", string.Empty);

            page.ErrorDescription.Text = description;
            page.ErrorSend.Click();

            Assert.AreEqual(thankYouText, page.ThankYouText.Text, "Error feedback page text is incorrect");

            return this;
        }
    }
}