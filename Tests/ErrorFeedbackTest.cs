using System;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ErrorFeedbackTest : TestBase
    {
        [Test]
        public void SendErrorFeedbackTest()
        {
            string errorDescription = UI.TestText.F(DateTime.Now.Ticks);

            string exceptionId;
            string exceptionMessage;
            string stacktrace;
            string centreName = "{0} - {1}".F(UI.TestCentreNumber,
                UI.TestCentreName);
            Start
                .RemoveInboxMessages(UiConst.Email.MyBtecAlerts)
                .LoginWithQN()
                .GoToHome()
                .GoToErrorFeedback()
                .CheckErrorFeedbackText(UI.ErrorFeedbackTitle, UI.ErrorFeedbackText)
                .SendEmptyErrorFeedback(UI.ErrorFeedbackThankYou, out exceptionId, out exceptionMessage, out stacktrace)
                .AssertEmailReceived(UiConst.Email.MyBtecAlerts, UI.EmailSubjectErrorFeedback,
                    UI.EmailBodyErrorFeedback.F(exceptionId, UiConst.Login.QualityNominee, centreName,
                        exceptionMessage, stacktrace), UiConst.Email.QualityNominee)
                .SendErrorFeedback(errorDescription, UI.ErrorFeedbackThankYou, out exceptionId, out exceptionMessage,
                    out stacktrace)
                .AssertEmailReceived(UiConst.Email.MyBtecAlerts, UI.EmailSubjectErrorFeedback,
                    UI.EmailBodyErrorFeedbackWithDscr.F(exceptionId, UiConst.Login.QualityNominee,
                        centreName, errorDescription, exceptionMessage,
                        stacktrace), UiConst.Email.QualityNominee);
        }
    }
}