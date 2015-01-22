using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class CreateCourseTest : TestBase
    {
        [Test,Ignore]
        public void CheckCoreDataCashedForCentres()
        {
            var courseContextOne = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_Nationals_2010_QCF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Extended_Diploma_180_Credits,
                
            };

            var courseContextTwo = new CreateCourseContext
            {
                Subject = UiConst.Subject.AppliedScience,
                Qualification = UiConst.QualificationSuite.BTEC_First_2010_QCF,
                Pathway = UiConst.Pathway.AppliedScience,
                Size = UiConst.Size.Certificate_15_Credits,
            };

            Start
                .LoginWithQN()
                .CreateCourse()
                .CompleteAllDropDowns(courseContextOne)
                .Continue()
                .ClickLogout()
                .LoginWithAndGoToHomePage("ohirons.312@lgflmail.org", "j")
                .SelectCenterContinue("12926 12926A 12926 - WOOD END GREEN ROAD")
                .CreateCourse()
                .CompleteAllDropDowns(courseContextTwo)
                .Continue();
        }

        [Test]
        [Category("WithCourse")]
        public void CreateCourseAssertEmailsOnAddRemoveTeamMembers()
        {
            string teamMember = UiConst.FirstName.Iv + " " + UiConst.LastName.Iv;
            string courseLeader = UiConst.FirstName.CourseLeader + " " + UiConst.LastName.CourseLeader;
            var context = new CreateCourseContext();

            Start
                .RemoveInboxMessages(UiConst.Email.CourseLeader)
                .RemoveInboxMessages(UiConst.Email.Iv)
                .LoginWithQN()
                .CreateConfirmedCourse(context).Flow
                .ViewCourse(context.ID)
                .ViewCourseTeam()
                .SelectTeamMember(teamMember)
                .AddToTeam()
                .AddCourseLeader(courseLeader)
                .SaveTeam()
                .AssertEmailReceived(UiConst.Email.CourseLeader, UI.EmailSubjectCourseLeaderAdded,
                    UI.EmailBodyAddedInCourseTeam.F(UiConst.FirstName.CourseLeader, UiConst.LastName.CourseLeader,
                        context.Title, "Course Leader", UiConst.FirstName.QualityNominee,
                        UiConst.LastName.QualityNominee, UiConst.Email.QualityNominee, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.Iv, UI.EmailSubjectTeamMemberAdded,
                    UI.EmailBodyAddedInCourseTeam.F(UiConst.FirstName.Iv, UiConst.LastName.Iv, context.Title,
                        "Team Member", UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee,
                        UiConst.Email.QualityNominee, UI.DoNotReplyMessage))
                .GoToCourses()
                .ViewCourse(context.ID)
                .ViewCourseTeam()
                .RemoveCourseleader(courseLeader)
                .RemoveTeamMember(teamMember)
                .SaveTeam()
                .AssertEmailReceived(UiConst.Email.Iv, UI.EmailSubjectRemovedFromCourseTeam,
                    UI.EmailBodyRemovedFromCourseTeam.F(UiConst.FirstName.Iv, UiConst.LastName.Iv, "Team Member",
                        context.Title, UiConst.FirstName.QualityNominee, UiConst.LastName.QualityNominee,
                        UiConst.Email.QualityNominee, UI.DoNotReplyMessage))
                .AssertEmailReceived(UiConst.Email.CourseLeader, UI.EmailSubjectRemovedFromCourseTeam,
                    UI.EmailBodyRemovedFromCourseTeam.F(UiConst.FirstName.CourseLeader, UiConst.LastName.CourseLeader,
                        "Course Leader", context.Title, UiConst.FirstName.QualityNominee,
                        UiConst.LastName.QualityNominee, UiConst.Email.QualityNominee, UI.DoNotReplyMessage));
        }

        [Test]
        [Category("Big")]
        [Category("WithCourse")]
        public void CreatePossibleCourses()
        {
            Start
                .LoginWithQN()
                .CreateCourse()
                .GetAllPosibleCombinations()
                .GoToCourses()
                .CreateAllCourses();
        }
    }
}