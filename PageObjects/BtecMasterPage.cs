using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class BtecMasterPage : PageBase
    {
        public BtecMasterPage(string url)
            : base(url)
        {
        }

        public MenuItem Home
        {
            get { return new MenuItem(UI.Home); }
        }

        public MenuItem Courses
        {
            get { return new MenuItem(UI.Courses); }
        }

        public Link MyCourses
        {
            get { return new Link(UI.MyCourses, By.PartialLinkText); }
        }

        public Link CentreCourses
        {
            get { return new Link(UI.CentreCourses, By.PartialLinkText); }
        }

        public Link CreateACourse
        {
            get { return new Link(UI.CreateACourse, By.PartialLinkText); }
        }

        public MenuItem Assignments
        {
            get { return new MenuItem(UI.Assignments); }
        }

        public Link MyAssignments
        {
            get { return new Link(UI.MyAssignments, By.PartialLinkText); }
        }

        public Link CentreAssignments
        {
            get { return new Link(UI.CentreAssignments, By.PartialLinkText); }
        }

        public Link CreateAnAssignment
        {
            get { return new Link(UI.CreateAnAssignment, By.PartialLinkText); }
        }

        public MenuItem Resources
        {
            get { return new MenuItem(UI.Resources); }
        }

        public MenuItem Reports
        {
            get { return new MenuItem(UI.Reports); }
        }

        public MenuItem ExternalLinks
        {
            get { return new MenuItem(UI.ExternalLinks); }
        }

        public MenuItem Links
        {
            get { return new MenuItem(UI.Links); }
        }

        public Link ClaimRoles
        {
            get { return new Link("claimRolesLink"); }
        }

        public Link Help
        {
            get { return new Link(UI.Help, By.LinkText); }
        }

        public Link Broadcast
        {
            get { return new Link(UI.Broadcast.ToLower(), By.LinkText); }
        }

        public Link Feedback
        {
            get { return new Link(UI.Feedback, By.LinkText); }
        }

        public Dropdown MyRole
        {
            get { return new Dropdown("roles"); }
        }

        public Label FooterLinks
        {
            get { return new Label("helpful_links"); }
        }

        public Link LearnMore
        {
            get { return new Link(".//div[@id='helpful_links']//a[text()='" + UI.LearnMore + "']", By.XPath); }
        }

        public Link CookiePolicy
        {
            get { return new Link(".//div[@id='helpful_links']//a[text()='" + UI.CookiePolicy + "']", By.XPath); }
        }
        public Link ViewQualification
        {
            get { return new Link("//a[text()='" + UI.ViewQualification + "']", By.XPath); }
        }
        public Link PrivacyPolicy
        {
            get { return new Link(".//div[@id='helpful_links']//a[text()='" + UI.PrivacyPolicy + "']", By.XPath); }
        }

        public Link TermsOfUse
        {
            get { return new Link(".//div[@id='helpful_links']//a[text()='" + UI.TermsOfUse + "']", By.XPath); }
        }

        public Label CookieMsgBoxTitle
        {
            get { return new Label(".//div[@id='cookiemsgbox']/span", By.XPath); }
        }

        public Label CookieMsgBoxText
        {
            get { return new Label(".//div[@id='cookiemsgbox']/p", By.XPath); }
        }

        public ClickableControl CookieMsgBoxLearnMoreBtn
        {
            get { return new ClickableControl(".//div[@id='cookiemsgbox']/input[@name='Learn more']", By.XPath); }
        }

        public ClickableControl CookieMsgBoxCloseBtn
        {
            get
            {
                return new ClickableControl(".//div[@id='cookiemsgbox']/input[@name='Close this message']", By.XPath);
            }
        }

        public Label SessionExpiredMsgBoxCountdown
        {
            get { return new Label("countDownHolder"); }
        }

        public Label SessionExpiredMsgBoxText
        {
            get { return new Label(".//div[@id='session-expiratin-popup']/b", By.XPath); }
        }

        public PopupButton SessionExpiredPopupOk
        {
            get { return new PopupButton(UI.OK, "session-expiratin-popup"); }
        }

        public PopupButton SessionExpiredPopupCancel
        {
            get { return new PopupButton(UI.Cancel, "session-expiratin-popup"); }
        }

        public Link UserRoleApproval
        {
            get { return new Link("roleApprovalLink"); }
        }

        public Label InfoMessage
        {
            get { return new Label("msgSpan"); }
        }

        public Link Logout
        {
            get { return new Link(UI.LogOut, By.LinkText); }
        }

        public Link WishListBasketBox
        {
            get { return new Link("//div[@id='mybtecbasket']/a[contains(@class,'wishlist')]", By.XPath); }
        }

        public Label ResourcePacksRunningTotal
        {
            get { return new Label("//div[@id='mybtecbasket']/p[@id='wishListSummary']", By.XPath); }
        }

        public ControlBase BasketBox
        {
            get { return new ControlBase("mybtecbasket"); }
        }

        public Link MenuLink(string title)
        {
            return new Link(".//div[@class='menu_items_btec']/ul[@class='static_links']/li/a[text()='{0}']".F(title),
                By.XPath);
        }

        public Dropdown Subject
        {
            get { return new Dropdown("Subjectdropdown"); }
        }

        public Dropdown QualificationSuite
        {
            get { return new Dropdown("Qualificationdropdown"); }
        }

        public Dropdown Pathway
        {
            get { return new Dropdown("Pathwaydropdown"); }
        }

        public Dropdown Size
        {
            get { return new Dropdown("Sizedropdown"); }
        }
    }
}