using System;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class BtecMasterFlow<TFlow> : FlowBase<TFlow>
        where TFlow : FlowBase<TFlow>
    {
        private readonly BtecMasterPage page;

        public BtecMasterFlow(INavigator navigator, BtecMasterPage page)
            : base(navigator)
        {
            this.page = page;
        }

        public StartFlow ClickLogout()
        {
            navigator.WaitForJQuery();
            page.Logout.Click();

            SeleniumContext.WebDriver.Manage().Cookies.DeleteAllCookies();

            RefreshPage();

            return new StartFlow(navigator);
        }

        public HomeFlow GoToHome()
        {
            navigator.WaitForJQuery();
            var homePage = navigator.Navigate<HomePage>(page.Home.Click);

            return new HomeFlow(navigator, homePage);
        }

        public CourseFlow GoToCourses()
        {
            navigator.WaitForJQuery();
            page.Courses.Click();

            var coursePage = navigator.Navigate<CoursePage>(page.MyCourses.Click);

            return new CourseFlow(navigator, coursePage);
        }


        public CourseStep1Flow CreateCourse()
        {
            page.Courses.Click();

            var step1Page = navigator.Navigate<CourseStep1Page>(page.CreateACourse.Click);

            return new CourseStep1Flow(navigator, step1Page);
        }


        public AssignmentStep1Flow PressCreateAssignment()
        {
            page.Assignments.Click();
            var assignmentStep1Page = navigator.Navigate<AssignmentStep1Page>(page.CreateAnAssignment.Click);

            return new AssignmentStep1Flow(navigator, assignmentStep1Page);
        }

        public AssignmentsFlow GoToAssignments()
        {
            page.Assignments.Click();
            var assignmentsPage = navigator.Navigate<AssignmentsPage>(page.MyAssignments.Click);

            return new AssignmentsFlow(navigator, assignmentsPage);
        }

        public ReportsFlow GoToReports()
        {
            var reportsPage = navigator.Navigate<ReportsPage>(page.Reports.Click);

            return new ReportsFlow(navigator, reportsPage);
        }

        public ExternalLinksFlow GoToExternalLinks()
        {
            var extLinksPage = navigator.Navigate<ExternalLinksPage>(page.ExternalLinks.Click);

            return new ExternalLinksFlow(navigator, extLinksPage);
        }

        public FeedbackFlow GoToFeedback()
        {
            var feedbackPage = navigator.Navigate<FeedbackPage>(page.Feedback.Click);

            return new FeedbackFlow(navigator, feedbackPage);
        }

        public ViewQualificationStep1Flow GoToViewQualification()
        {
            var viewQualificationPage = navigator.Navigate<ViewQualificationStep1Page>(page.ViewQualification.Click);

            return new ViewQualificationStep1Flow(navigator, viewQualificationPage);
        }

        public UserRoleApprovalFlow GoToUserRoleApproval()
        {
            var userRoleApprovalpage = navigator.Navigate<UserRoleApprovalPage>(page.UserRoleApproval.Click);

            return new UserRoleApprovalFlow(navigator, userRoleApprovalpage);
        }

        public ClaimRolesFlow GoToClaimRoles()
        {
            var claimRolepage = navigator.Navigate<ClaimRolesPage>(page.ClaimRoles.Click);

            return new ClaimRolesFlow(navigator, claimRolepage);
        }

        public TermsFlow GoToTermsOfUse()
        {
            var termsPage = navigator.NavigateNewTab<TermsPage>(page.TermsOfUse.Click);

            return new TermsFlow(navigator, termsPage);
        }

        public ResourcesFlow GoToResources()
        {
            var resourcesPage = navigator.Navigate<ResourcesPage>(page.Resources.Click);

            return new ResourcesFlow(navigator, resourcesPage);
        }

        public ResourcesFlow GoToWishListFromBasket()
        {
            var resourcesPage = navigator.Navigate<ResourcesPage>(page.WishListBasketBox.Click);

            return new ResourcesFlow(navigator, resourcesPage);
        }

        public BtecMasterFlow<TFlow> CheckResourcesNotAccessible()
        {
            Assert.IsFalse(page.UserRoleApproval.Displayed, "Resources menu button should be hidden");

            return this;
        }

        public BtecMasterFlow<TFlow> CheckBasketBox(bool displayed = true)
        {
            Assert.AreEqual(displayed, page.BasketBox.Displayed, "Basketbox unexpectedly shown/hidden");

            return this;
        }

        public BtecMasterFlow<TFlow> CheckWishListRunningTotal(int packs, decimal price)
        {
            Assert.AreEqual(((packs == 1) ? UI.WishListSummaryOnePack : UI.WishListSummaryPacks).F(packs, price),
                page.ResourcePacksRunningTotal.Text, "Incorrect packs number or price");

            return this;
        }

        public BtecMasterFlow<TFlow> CheckMenuLink(string title, string url)
        {
            navigator.WaitForJQuery();

            page.Links.Click();

            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.MenuLink(title).Click),
                "New tab with link {0} is not opened".F(title));

            Assert.IsTrue(navigator.CheckUrlNewTabOpened(url),
                "New tab with link {0} is not redirected to {1}".F(title, url));

            return this;
        }

        public HelpFlow GoToHelp()
        {
            var helpPage = navigator.Navigate<HelpPage>(page.Help.Click);

            return new HelpFlow(navigator, helpPage);
        }

        public BroadcastFlow GoToBroadcast()
        {
            var broadcastPage = navigator.DoActionWaitForJQueryAndNavigate<BroadcastPage>(page.Broadcast.Click);

            return new BroadcastFlow(navigator, broadcastPage);
        }

        public BtecMasterFlow<TFlow> AssertFooterTextCorrect(string footerText)
        {
            Assert.AreEqual(page.FooterLinks.Text, footerText);

            return this;
        }

        public BtecMasterFlow<TFlow> CheckUserApprovalButton(bool exists = true)
        {
            Assert.AreEqual(exists, page.UserRoleApproval.Enabled);

            return this;
        }

        public BtecMasterFlow<TFlow> AssertFooterLinksAreOpenedInNewTabs(string learnMoreUrl, string cookiePolicyUrl,
            string privacyPolicyUrl, string termsOfUseUrl)
        {
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.LearnMore.Click), "New tab Learn More is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(learnMoreUrl), "New tab Learn More is not redirected");
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.CookiePolicy.Click),
                "New tab Cookie Policy is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(cookiePolicyUrl), "New tab Cookie Policy is not redirected");
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.PrivacyPolicy.Click),
                "New tab Privacy Policy is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(privacyPolicyUrl), "New tab Privacy Policy is not redirected");
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.TermsOfUse.Click),
                "New tab Terms of Use is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(termsOfUseUrl), "New tab Terms of Use is not redirected");

            return this;
        }

        public BtecMasterFlow<TFlow> AssertCookieMsgBoxTextCorrect(string cookieTitle, string cookieText)
        {
            Assert.AreEqual(page.CookieMsgBoxTitle.Text, cookieTitle);
            Assert.AreEqual(page.CookieMsgBoxText.Text, cookieText);

            return this;
        }

        public BtecMasterFlow<TFlow> AssertCookieMsgBoxLearnMoreLinkIsOpened(string learnMoreUrl)
        {
            Assert.IsTrue(navigator.DoActionCheckNewTabOpened(page.CookieMsgBoxLearnMoreBtn.Click),
                "New tab Learn More is not opened");
            Assert.IsTrue(navigator.CheckUrlNewTabOpened(learnMoreUrl), "New tab Learn More is not redirected");

            return this;
        }

        public BtecMasterFlow<TFlow> CloseCookieMsgBox()
        {
            page.CookieMsgBoxCloseBtn.Click();

            return this;
        }

        public BtecMasterFlow<TFlow> AssertCookieMsgBoxClosed()
        {
            Assert.IsFalse(page.CookieMsgBoxTitle.Displayed, "Cookie message box was not closed");

            return this;
        }

        public BtecMasterFlow<TFlow> AssertSessionExpiredPopupAppeared()
        {
            Assert.AreEqual(page.SessionExpiredMsgBoxText.Text, UI.SessionExpires);

            return this;
        }

        public StartFlow AssertSessionExpiredPopupAppearedDoNothing()
        {
            Assert.AreEqual(page.SessionExpiredMsgBoxText.Text, UI.SessionExpires);
            Wait(60*1000);

            return new StartFlow(navigator);
        }

        public StartFlow BreakSession()
        {
            navigator.DoActionWaitUrlChangedAndNavigate<LoginPage>(page.SessionExpiredPopupCancel.Click);

            return new StartFlow(navigator);
        }

        public BtecMasterFlow<TFlow> ContinueSession()
        {
            page.SessionExpiredPopupOk.Click();

            return this;
        }

        public CourseStep3Flow CreateCourseTillStep3(CreateCourseContext context = null)
        {
            if (context == null)
            {
                context = new CreateCourseContext();
            }
            return CreateCourse()
                .SetName(context.Title)
                .CompleteAllDropDowns(context)
                .Continue()
                .SetEndDate(context.EndDate)
                .SetStartDate(context.StartDate)
                //.OptionalUnitsView100()
                .CheckAllCheckboxes()
                .ClickAddButton()
                .SaveContinue();
        }

        public FlowResult<CourseFlow> CreateConfirmedCourse(CreateCourseContext context = null)
        {
            if (context == null)
            {
                context = new CreateCourseContext();
            }

            CourseStep3Flow flow = CreateCourseTillStep3(context);

            context.ID = flow.GetCourseId();

            return new FlowResult<CourseFlow>(flow.GetCourseId()) {Flow = flow.ConfirmCourse().ConfirmCoursePopup()};
        }

        public CourseFlow CreateCourseAndConfirmIt(CreateCourseContext context)
        {
            CourseStep3Flow flow = CreateCourseTillStep3(context);

            context.ID = flow.GetCourseId();
            return flow
                .ConfirmCourse()
                .ConfirmCoursePopup();
        }

        public CourseFlow CreateCourseAsDraft(CreateCourseContext context)
        {
            CourseStep3Flow flow = CreateCourseTillStep3(context);

            context.ID = flow.GetCourseId();
            return flow
                .SaveAsDraft()
                .DraftPopupClickYes();
        }

        public FlowResult<AssignmentsFlow> CreateAssignment(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }
            return PressCreateAssignment()
                .FillAllRequiredDataOnStep1(context)
                .SaveAndContinue()
                .SelectAllCriteria()
                .SaveAndContinue()
                .FillAllRequiredDataOnStep3(context).Flow
                .SaveAndContinue()
                .FinishWithStatusResult(context);
           
        }

        public AssignmentStep2Flow CreateDefaultAssignmentTillStep2(bool isPearson = false)
        {
            var context = new CreateAssignmentContext {IsPearson = isPearson};
            return CreateAssignmentTillStep2(context);
        }

        public AssignmentStep2Flow CreateAssignmentTillStep2(CreateAssignmentContext context = null)
        {
            if (context == null)
            {
                context = new CreateAssignmentContext();
            }
            return PressCreateAssignment()
                .FillAllRequiredDataOnStep1(context)
                .SaveAndContinue();
        }

        public AssignmentStep3Flow CreateDefaultAssignmentTillStep3(bool isPearson = false)
        {
            return CreateDefaultAssignmentTillStep2(isPearson)
                .SelectAllCriteria()
                .SaveAndContinue();
        }

        public AssignmentStep3Flow CreateAssignmentTillStep3(CreateAssignmentContext context = null)
        {
            return CreateAssignmentTillStep2(context)
                .SelectAllCriteria()
                .SaveAndContinue();
        }

        public AssignmentStep4Flow CreateDefaultAssignmentTillStep4(bool isPearson = false)
        {
            return CreateDefaultAssignmentTillStep3(isPearson)
                .SetScenario(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskTile(UI.TestText.F(DateTime.Now.Ticks))
                .SetTaskDescription(UI.TestText.F(DateTime.Now.Ticks))
                .ClickSelectCriteriaForTask()
                .CheckAllCheckboxes()
                .PopupTaskCriteriaClickOk()
                .SetEvidence(UI.TestText.F(DateTime.Now.Ticks))
                .SetAssignmentDuration(UI.TestText.F(DateTime.Now.Ticks))
                .SaveAndContinue();
        }


        public AssignmentStep4Flow CreateAssignmentTillStep4(CreateAssignmentContext context = null)
        {
            return CreateAssignmentTillStep3(context)
                .FillAllRequiredDataOnStep3(context).Flow
                .SaveAndContinue();
        }


        public AssignmentStep4Flow CreateAssignmentWithCourseIdTillStep4(string courseId)
        {
            var context = new CreateAssignmentContext {CourseId = courseId};

            return CreateAssignmentTillStep4(context);
        }

        public FlowResult<AssignmentsFlow> CreateAssignmentSendAndApprove()
        {
            FlowResult<AssignmentsFlow> result = CreateDefaultAssignmentTillStep4()
                .ClickSendToIv()
                .SelectSendToIv()
                .ClickSaveandsendtoIVnow();

            return new FlowResult<AssignmentsFlow>(result.CreatedId)
            {
                Flow = result.Flow.ClickLogout()
                    .LoginWithIV()
                    .GoToAssignments()
                    .Review(result.CreatedId)
                    .ChooseIsAssignmentForWholeUnits()
                    .CheckAllAcceptanceCriterias()
                    .ChooseIsAssignmentApproved()
                    .SaveAndSend()
            };
        }

        public AssignmentStep3Flow CreateDefaultNQFAssignmentTillStep3()
        {
            var context = new CreateAssignmentContext
            {
                Subject = UiConst.Subject.PerformingArts,
                Qualification = UiConst.QualificationSuite.BTEC_First_2012_NQF,
                Pathway = UiConst.Pathway.Performing_Arts_Acting,
                Size = UiConst.Size.Award_120_GLH,
                FirstUnit = true
            };

            return CreateAssignmentTillStep2(context)
                .ClickLearningObjective(UiConst.LearningObjective.L_503_6471_LOA)
                .SaveAndContinue();
        }
    }
}