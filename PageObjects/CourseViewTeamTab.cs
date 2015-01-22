using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class CourseViewTeamTab : CourseViewPage
    {
        public Link AddToTeamButton
        {
            get { return new Link("btnAddTeam"); }
        }

        public Link AddCourseLeader
        {
            get { return new Link("btnAdd"); }
        }

        public Link RemoveFromTeam
        {
            get { return new Link("btnRemTeam"); }
        }

        public Link RemoveCourseLeader
        {
            get { return new Link("btnRemove"); }
        }

        public Link SaveTeamButton
        {
            get { return new Link("saveTeam"); }
        }

        public Link FirstTeamPage
        {
            get { return new Link("first_pager_TeamGrid"); }
        }

        public Dropdown CourseLeader
        {
            get { return new Dropdown("CourseLeaders"); }
        }

        public IEnumerable<string> GetNameColumnRows
        {
            get
            {
                ReadOnlyCollection<IWebElement> elements =
                    SeleniumContext.WebDriver.FindElements(
                        By.XPath(
                            "//tr[@role='row' and @class[contains(.,'content')]]//td[@aria-describedby='table_TeamGrid_FullName']"));
                return elements.Select(webElement => webElement.Text);
            }
        }

        public GridControl OtherTeamMembersGrid
        {
            get { return new GridControl("gbox_table_TeamGrid", "TeamGrid"); }
        }

        public GridCheckbox TeamMember(string memberName)
        {
            string memberInputPath =
                "//td[text() [contains(.,'{0}')]]/preceding-sibling::td/input[@type='checkbox']".F(memberName);

            return new GridCheckbox(memberInputPath, "TeamGrid");
        }

        public Checkbox AddedTeamMember(string memberName)
        {
            string memberInputPath =
                "//td[contains(text(),'{0}')]/preceding-sibling::td/input[@type='checkbox']".F(memberName);

            return new Checkbox(memberInputPath, By.XPath);
        }

        public Checkbox AddedCourseLeader(string courseLeader)
        {
            return new Checkbox(".//input/following-sibling::label[text()='" + courseLeader + "']", By.XPath);
        }
    }
}