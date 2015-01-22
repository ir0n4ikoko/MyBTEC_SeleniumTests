using System;
using ActiveUp.Net.Mail;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    //using Gallio.Framework.Assertions;

    public static class MailHelper
    {
        public static void CheckEmailReceived(string email, string from, string subject, string bodyText)
        {
            CheckEmailReceived(UiConst.Email.SmtpServer, UiConst.Email.Port, true, email, UiConst.Email.DefaultPassword,
                from, subject, bodyText);
        }

        public static void EmptyInbox(string email)
        {
            EmptyInbox(UiConst.Email.SmtpServer, UiConst.Email.Port, true, email, UiConst.Email.DefaultPassword);
        }

        private static void EmptyInbox(string host, int port, bool ssl, string email, string password)
        {
            try
            {
                var client = new Imap4Client();

                if (ssl)
                    client.ConnectSsl(host, port);
                else
                    client.Connect(host, port);

                client.Login(email, password);

                client.SelectMailbox("Inbox").Empty(true);

                client.Disconnect();
            }
            catch (Exception e)
            {
                Assert.Fail("Something is wrong with inbox empting.\nEmail: {0}\nException: {1}".F(email, e));
            }
        }

        private static void CheckEmailReceived(string host, int port, bool ssl, string email, string password,
            string from, string subject, string bodyText)
        {
            try
            {
                var client = new Imap4Client();

                if (ssl)
                    client.ConnectSsl(host, port);
                else
                    client.Connect(host, port);

                client.Login(email, password);

                Mailbox inbox = client.SelectMailbox("Inbox");
                var flag = new FlagCollection {"SEEN"};

                if (inbox.MessageCount > 0)
                {
                    for (int i = inbox.MessageCount; i > 0; i--)
                    {
                        inbox.AddFlags(i, flag);
                        Message message = inbox.Fetch.MessageObject(i);
                        if (message.Subject.Equals(subject) &&
                            message.BodyHtml.TextStripped.TrimEnd(' ').Equals(bodyText))
                        {
                            return;
                        }
                    }
                    Assert.Fail("Email not found. From: {0} To: {1}\nSubject: {2}\nText: {3}".F(from, email, subject,
                        bodyText));
                }
                else
                {
                    Assert.Fail("Unread emails not found\nFrom: {0} To: {1}\nSubject: {2}\nText: {3}".F(from, email,
                        subject, bodyText));
                }
            }
            catch (AssertionException)
            {
                throw;
            }
            catch (Exception e)
            {
                Assert.Fail(
                    "Something is wrong with email checking.\nFrom: {0} To: {1}\nSubject: {2}\nText: {3}\n\n\n\n\n{4}".F
                        (from, email, subject, bodyText, e));
            }
        }
    }
}