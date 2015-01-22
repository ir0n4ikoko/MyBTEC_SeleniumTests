using System.Collections.Generic;
using Edi.Advance.BTEC.UiTests.Flows;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CourseActionsTest : TestBase
    {

        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_CourseCreatorActions(string login, string password, string name)
        {
            var draft = new CreateCourseContext();
            var confirmed = new CreateCourseContext();

            Start
                .LoginWithAndGoToHomePage(login, password)
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.CourseCreator_Confirmed)
                .CheckCourseActions(draft.ID, UiConst.CourseActions.CourseCreator_Draft);
        }


        [Test]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_teacher@learntodive.org.uk", "67546B6", "Auto Teacher")]
        public void Assert_CourseOtherTeamMembersActions(string login, string password, string name)
        {
            var confirmed = new CreateCourseContext();
            var draft = new CreateCourseContext();

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ViewCourse(confirmed.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .GoToCourses()
                .ViewCourse(draft.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.Course_IV_A_T_OtherTeamMember)
                .CheckCourseActions(draft.ID, UiConst.CourseActions.Course_IV_A_T_OtherTeamMember)
                .GoToCentreCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title, false)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.Course_IV_A_T_OtherTeamMember);
        }


        [Test]
        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        public void Assert_CourseOtherTeamMemberCLActions(string login, string password, string name)
        {
            var confirmed = new CreateCourseContext();
            var draft = new CreateCourseContext();

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ViewCourse(confirmed.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .GoToCourses()
                .ViewCourse(draft.ID)
                .ViewCourseTeam()
                .SelectTeamMember(name)
                .AddToTeam()
                .SaveTeam()
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.ConfirmedCourse_QN_LIV_CL_NotCreator)
                .CheckCourseActions(draft.ID, UiConst.CourseActions.DraftCourse_QN_LIV_CL_OtherTeamMember)
                .GoToCentreCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title, false)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.ConfirmedCourse_QN_LIV_CL_NotCreator);
        }

        [Test]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939", "Auto LIV")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5", "Auto QN")]
        public void Assert_Course_QN_LIV_Actions(string login, string password, string name)
        {
            var confirmed = new CreateCourseContext();
            var draft = new CreateCourseContext();

            Start
                .LoginWithCL()
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.ConfirmedCourse_QN_LIV_CL_NotCreator)
                .CheckCourseActions(draft.ID, UiConst.CourseActions.DraftCourse_QN_LIV_CL_OtherTeamMember)
                .GoToCentreCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title, false)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.ConfirmedCourse_QN_LIV_CL_NotCreator);
        }

        [Test]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43", "Auto IV")]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E", "Auto Assessor")]
        [TestCase("test_teacher@learntodive.org.uk", "67546B6", "Auto Teacher")]
        public void Assert_CourseNotTeamMembersActions(string login, string password, string name)
        {
            var confirmed = new CreateCourseContext();
            var draft = new CreateCourseContext();

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title, false)
                .CheckCourseVisiblity(draft.Title, false)
                .GoToCentreCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title, false)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.CourseNotTeamMember);
        }

        [Test]
        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B", "Auto CL")]
        public void Assert_CourseNotTeamMemberCLActions(string login, string password, string name)
        {
            var confirmed = new CreateCourseContext();
            var draft = new CreateCourseContext();

            Start
                .LoginWithQN()
                .CreateConfirmedCourse(confirmed).Flow
                .CreateCourseAsDraft(draft)
                .ClickLogout()
                .LoginWithAndGoToHomePage(login, password)
                .GoToCourses()
                .CheckCourseVisiblity(confirmed.Title, false)
                .CheckCourseVisiblity(draft.Title, false)
                .GoToCentreCourses()
                .CheckCourseVisiblity(confirmed.Title)
                .CheckCourseVisiblity(draft.Title, false)
                .CheckCourseActions(confirmed.ID, UiConst.CourseActions.ConfirmedCourse_QN_LIV_CL_NotCreator);
        }

    }
}