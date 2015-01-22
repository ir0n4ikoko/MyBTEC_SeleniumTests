using System;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseViewTeamFlow : CourseViewFlow
    {
        private readonly CourseViewTeamTab teamTab;

        public CourseViewTeamFlow(INavigator navigator, CourseViewTeamTab teamTab)
            : base(navigator, teamTab)
        {
            this.teamTab = teamTab;
        }

        public CourseViewTeamFlow CheckUserIsNotInTeamGrid(string name)
        {
            Assert.IsFalse(teamTab.TeamMember(name).Exists, "User {0} is in grid with Other team members".F(name));
            return this;
        }

        public CourseViewTeamFlow CheckTheTableOfUsersIsNotPresent()
        {
            Assert.IsFalse(teamTab.FirstTeamPage.Exists);
            return this;
        }

        public CourseViewTeamFlow GoToFirstTeampage()
        {
            navigator.ClickAndWaitForJQuery(teamTab.FirstTeamPage.Click);

            return this;
        }

        public CourseViewTeamFlow AddToTeam()
        {
            navigator.ClickAndWaitForJQuery(teamTab.AddToTeamButton.Click);

            return this;
        }

        public CourseViewTeamFlow SaveTeam()
        {
            teamTab.SaveTeamButton.Click();
            navigator.WaitForJQuery();

            return this;
        }

        public CourseViewTeamFlow CheckTeamMembers(string userName)
        {
            bool teamMemberFound = false;

            for (int i = 0; i < int.Parse(teamTab.OtherTeamMembersGrid.Pages.Text); i++)
            {
                IWebElement member = null;
                try
                {
                    member = SeleniumContext.WebDriver.FindElement(By.XPath("//td[@title='{0}']".F(userName)));
                }
                catch (Exception)
                {
                    teamTab.OtherTeamMembersGrid.NextPage.Click();
                    if (member != null)
                        teamMemberFound = true;
                }
            }


            Assert.IsFalse(teamMemberFound, "This user {0} is in the list of posible team members".F(userName));
            return this;
        }

        public CourseViewTeamFlow SelectTeamMember(string memberName)
        {
            teamTab.TeamMember(memberName).Click();
            return this;
        }

        public CourseViewTeamFlow RemoveTeamMember(string memberName)
        {
            teamTab.AddedTeamMember(memberName).Click();
            teamTab.RemoveFromTeam.Click();
            return this;
        }

        public CourseViewTeamFlow RemoveCourseleader(string courseLeader)
        {
            teamTab.AddedCourseLeader(courseLeader).Click();
            teamTab.RemoveCourseLeader.Click();
            return this;
        }

        public CourseViewTeamFlow AddCourseLeader(string courseLeaderName)
        {
            teamTab.CourseLeader.Text = courseLeaderName;

            ClickAddCourseLeader();

            return this;
        }

        public CourseViewTeamFlow ClickAddCourseLeader()
        {
            teamTab.AddCourseLeader.Click();
            return this;
        }
    }
}