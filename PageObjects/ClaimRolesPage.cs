using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ClaimRolesPage : BtecMasterPage
    {
        public ClaimRolesPage(string url)
            : base(url)
        {
        }

        public ClaimRolesPage()
            : base(UI.ClaimRolesPage)
        {
        }

        public Link ClaimRolesBtn
        {
            get { return new Link("submitButton"); }
        }

        public Dropdown SubjectRole(int index)
        {
            return new Dropdown("SubjectRoles_{0}__SubjectRoledropdown".F(index));
        }

        public Radiobutton AddSubject(bool yes = true)
        {
            return new Radiobutton(@"//input[@id='addSubject_'and @value='{0}']".F(yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsLIV(int index, bool yes = true)
        {
            return
                new Radiobutton(
                    @"//input[@id='SubjectRoles_{0}__IsLIV'and @value='{1}']".F(index, yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsCL(int index, bool yes = true)
        {
            return
                new Radiobutton(
                    @"//input[@id='SubjectRoles_{0}__IsCL'and @value='{1}']".F(index, yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsIV(int index, bool yes = true)
        {
            return
                new Radiobutton(
                    @"//input[@id='SubjectRoles_{0}__IsIV'and @value='{1}']".F(index, yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsAssessor(int index, bool yes = true)
        {
            return
                new Radiobutton(
                    @"//input[@id='SubjectRoles_{0}__IsAssessor'and @value='{1}']".F(index, yes ? "True" : "False"),
                    By.XPath);
        }

        public Radiobutton IsExamOfficer(bool yes = true)
        {
            return new Radiobutton(@"//input[@id='IsExamOfficer'and @value='{0}']".F(yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsBursar(bool yes = true)
        {
            return new Radiobutton(@"//input[@id='IsBursar'and @value='{0}']".F(yes ? "True" : "False"), By.XPath);
        }

        public Radiobutton IsCA(bool yes = true)
        {
            return new Radiobutton(@"//input[@id='IsCA'and @value='{0}']".F(yes ? "True" : "False"), By.XPath);
        }

        public PopupButton ClaimRolesConfirm(bool clickYes = true)
        {
            return new PopupButton(clickYes ? UI.Yes : UI.No, "claimConfirm");
        }
    }
}