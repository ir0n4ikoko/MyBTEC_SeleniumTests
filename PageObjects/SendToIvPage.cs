using Edi.Advance.BTEC.UiTests.PageObjects.Controls;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class SendToIvPage : WithIdPage
    {
        public SendToIvPage()
            : base(UI.SendToIvPage)
        {
        }

        public Dropdown IV
        {
            get { return new Dropdown("IV"); }
        }

        public PopupButton Cancel
        {
            get { return new PopupButton(UI.Cancel, "sendToIvContent"); }
        }

        public PopupButton SendToIV
        {
            get { return new PopupButton(UI.SendToIV, "sendToIvContent"); }
        }

        public Link SaveandsendToIVnow
        {
            get { return new Link("sendNowButton"); }
        }

        public Link SaveandsendtoIVlater
        {
            get { return new Link("sendLaterButton"); }
        }
    }
}