using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ClaimRolesFlow : BtecMasterFlow<ClaimRolesFlow>
    {
        private readonly ClaimRolesPage page;

        public ClaimRolesFlow(INavigator navigator, ClaimRolesPage page)
            : base(navigator, page)
        {
            this.page = page;
        }


        public ClaimRolesFlow SelectSubject(int index, string subject)
        {
            if (!page.SubjectRole(index).Displayed)
                SelectAddSubject();

            Dropdown actionsDropdown = page.SubjectRole(index);
            actionsDropdown.Text = subject;

            return this;
        }

        public ClaimRolesFlow SelectSubject(int index)
        {
            if (!page.SubjectRole(index).Displayed)
                SelectAddSubject();

            Dropdown actionsDropdown = page.SubjectRole(index);
            actionsDropdown.Text = actionsDropdown.ElementOptions.ElementAt(1).Text;

            return this;
        }

        public ClaimRolesFlow CheckSubject(int index, string subject)
        {
            Dropdown actionsDropdown = page.SubjectRole(index);
            Assert.AreEqual(actionsDropdown.Text, subject, "Selected subject was incorrect");

            return this;
        }

        public ClaimRolesFlow SelectAddSubject(bool yes = true)
        {
            page.AddSubject(yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectLIV(int index, bool yes = true)
        {
            page.IsLIV(index, yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectCL(int index, bool yes = true)
        {
            page.IsCL(index, yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectIV(int index, bool yes = true)
        {
            page.IsIV(index, yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectAssessor(int index, bool yes = true)
        {
            page.IsAssessor(index, yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectExamOfficer(bool yes = true)
        {
            page.IsExamOfficer(yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectBursar(bool yes = true)
        {
            page.IsBursar(yes).Click();

            return this;
        }

        public ClaimRolesFlow SelectCA(bool yes = true)
        {
            page.IsCA(yes).Click();

            return this;
        }

        public ClaimRolesFlow ClaimRoles(bool clickYes = true)
        {
            SelectAddSubject(false);

            page.ClaimRolesBtn.Click();

            ClaimConfirm(clickYes);

            return this;
        }

        public ClaimRolesFlow ClaimConfirm(bool clickYes = true)
        {
            var claimRolesPage = navigator.Navigate<ClaimRolesPage>(page.ClaimRolesConfirm(clickYes).Click);

            return new ClaimRolesFlow(navigator, claimRolesPage);
        }

        public ClaimRolesFlow SelectRoleForSubject(int index, string subject, string roleToClaim)
        {

            return SelectSubject(index, subject)
                .SelectRole(index, roleToClaim);


        }

        public ClaimRolesFlow SelectRole(int index, string roleToClaim)
        {
            switch (roleToClaim)
            {
                case UiConst.Role.Liv:
                    return SelectLIV(index);
                case UiConst.Role.CourseLeader:
                    return SelectLIV(index, false)
                        .SelectCL(index);
                case UiConst.Role.Iv:
                    return SelectLIV(index, false)
                        .SelectCL(index, false)
                        .SelectIV(index);
                case UiConst.Role.Assessor:
                    return SelectLIV(index, false)
                        .SelectCL(index, false)
                        .SelectIV(index, false)
                        .SelectAssessor(index);
                case UiConst.Role.Teacher:
                    return SelectLIV(index, false)
                        .SelectCL(index, false)
                        .SelectIV(index, false)
                        .SelectAssessor(index, false);
            }
            return this;
        }

        public ClaimRolesFlow SelectRoleForAllSubjects(string roleToClaim)
        {
            int subjectsNumber = page.SubjectRole(0).ElementOptions.Count() - 1;

                    for (byte index = 0; index < subjectsNumber; index++)
                    {
                        SelectSubject(index)
                        .SelectRole(index,roleToClaim);
                    }
            
            return this;
        }
    }
}