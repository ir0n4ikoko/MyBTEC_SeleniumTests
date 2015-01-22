using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Edi.Advance.BTEC.UiTests
{
    public class UiConst
    {
        public class AssignmentActions
        {
            public static IEnumerable<string> PendingAssignmentCreator = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Edit,
                UI.Clone,
                UI.Delete
            };

            public static IEnumerable<string> AssignmentCreator_Draft = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Edit,
                UI.Clone,
                UI.Delete,
                UI.SendToACS,
                UI.SendToIV,
                UI.LinkToCourses
            };

            public static IEnumerable<string> AssignmentCreator_WithIv = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ChangeIV
            };

            public static IEnumerable<string> AssignmentCreator_NotApproved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback,
                UI.Delete,
                UI.Edit,
                UI.SendToIV
            };

            public static IEnumerable<string> AssignmentCreator_Approved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback,
                UI.Delete,
                UI.LinkToCourses,
                UI.Clone
            };

            public static IEnumerable<string> AssignmentCreator_Deleted = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Restore
            };

            public static IEnumerable<string> TeacherActions = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> Iv_WithIV = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Review,
                UI.SendToACS
            };

            public static IEnumerable<string> Iv_Approved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone,
                UI.LinkToCourses,
                UI.ViewIvFeedback
            };

            public static IEnumerable<string> Iv_NotApproved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback
            };

            public static IEnumerable<string> CL_LIV_Draft = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> CL_LIV_WithIV = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> CL_LIV_Approved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback,
                UI.LinkToCourses,
                UI.Clone
            };

            public static IEnumerable<string> CL_LIV_NotApproved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback,
                UI.Delete
            };

            public static IEnumerable<string> CL_LIV_Authorised = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone,
                UI.LinkToCourses
            };

            public static IEnumerable<string> Assessor_IV_Draft = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> Assessor_IV_WithIV = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> Assessor_IV_Approved = new[]
            {
                UI.Select,
                UI.Preview,
                UI.ViewIvFeedback,
                UI.LinkToCourses,
                UI.Clone
            };

            public static IEnumerable<string> Assessor_IV_NotApproved = new[]
            {
                UI.Select,
                UI.Preview
            };

            public static IEnumerable<string> Assessor_IV_Authorised = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone,
                UI.LinkToCourses
            };

            public static IEnumerable<string> PearsonEditor_Editing = new[]
            {
                UI.Select,
                UI.Edit,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonDDM_Editing = new[]
            {
                UI.Select,
                UI.Delete,
                UI.Edit,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonEditor_DDMreview = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonDDM_DDMreview = new[]
            {
                UI.Select,
                UI.Delete,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonEditor_ExternalTesting = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonDDM_ExternalTesting = new[]
            {
                UI.Select,
                UI.Delete,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonEditor_Authorised = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone
            };

            public static IEnumerable<string> PearsonDDM_Authorised = new[]
            {
                UI.Select,
                UI.Preview,
                UI.Clone,
                UI.LiveEdit
            };

            public static IEnumerable<string> PearsonTester_ExternalTesting = new[]
            {
                UI.Select,
                UI.Preview
            };
        }

        public class AssignmentStatus
        {
            public static IEnumerable<string> DDM_Editing = new[]
            {
                UI.Editing,
                UI.DDMReview,
                UI.ExternalTest,
                UI.Authorised
            };

            public static IEnumerable<string> DDM_DDMReview = new[]
            {
                UI.Editing,
                UI.DDMReview,
                UI.ExternalTest,
                UI.Authorised
            };

            public static IEnumerable<string> DDM_ExternalTest = new[]
            {
                UI.Editing,
                UI.DDMReview,
                UI.ExternalTest,
                UI.Authorised
            };

            public static IEnumerable<string> DDM_Authorised = new[]
            {
                UI.Authorised
            };

            public static IEnumerable<string> Editor_Editing = new[]
            {
                UI.Editing,
                UI.DDMReview
            };

            public static IEnumerable<string> Editor_DDMReview = new[]
            {
                UI.DDMReview
            };

            public static IEnumerable<string> Editor_ExternalTest = new[]
            {
                UI.ExternalTest
            };

            public static IEnumerable<string> Editor_Authorised = new[]
            {
                UI.Authorised
            };

            public static IEnumerable<string> Tester_ExternalTest = new[]
            {
                UI.ExternalTest
            };
        }

        public class CourseActions
        {
            public static IEnumerable<string> PendingCourseCreator = new[]
            {
                UI.Select,
                UI.View,
                UI.Edit,
                UI.Delete,
                UI.Clone,
                UI.Download
            };

            public static IEnumerable<string> Teacher = new[]
            {
                UI.Select,
                UI.View
            };

            public static IEnumerable<string> CourseCreator_Confirmed = new[]
            {
                UI.Select,
                UI.View,
                UI.Edit,
                UI.Delete,
                UI.Clone,
                UI.Download,
                UI.ExportAsExcel
            };

            public static IEnumerable<string> CourseCreator_Draft = new[]
            {
                UI.Select,
                UI.View,
                UI.Edit,
                UI.Delete,
                UI.Clone,
                UI.Download
            };

            public static IEnumerable<string> CourseNotTeamMember = new[]
            {
                UI.Select,
                UI.View
            };

            public static IEnumerable<string> Course_IV_A_T_OtherTeamMember = new[]
            {
                UI.Select,
                UI.View
            };

            public static IEnumerable<string> DraftCourse_QN_LIV_CL_OtherTeamMember = new[]
            {
                UI.Select,
                UI.View,
                UI.Clone,
                UI.Download
            };

            public static IEnumerable<string> ConfirmedCourse_QN_LIV_CL_NotCreator = new[]
            {
                UI.Select,
                UI.View,
                UI.Clone,
                UI.Download,
                UI.ExportAsExcel
            };
        }

        public sealed class Criteria
        {
            public static readonly string P1 = "P1";
            public static readonly string M1 = "M1";
            public static readonly string D1 = "D1";
            public static readonly string L_2A_P1 = "2A.P1";
        }

        public sealed class DateTimeFormat
        {
            public static readonly string ShortDateFormat = "dd/MM/yyyy";
            public static readonly string ShortDateFormatDots = "dd.MM.yyyy";
            public static readonly string LongDateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        }

        public sealed class Email
        {
            public static readonly string QualityNominee = "test.qualitynominee@gmail.com";
            public static readonly string Liv = "test.leadinternalverifier@gmail.com";
            public static readonly string CourseLeader = "mybtec.test.courseleader@gmail.com";
            public static readonly string Iv = "test.internalverifier@gmail.com";
            public static readonly string Assessor = "mybtec.test.assessor@gmail.com";
            public static readonly string Teacher = "mybtec.test.teacher@gmail.com";
            public static readonly string Ddm = "test_ddm@learntodive.org.uk";
            public static readonly string Editor = "test_editor@learntodive.org.uk";
            public static readonly string Tester = "test_tester@learntodive.org.uk";
            public static readonly string Support = "test_support@learntodive.org.uk";
            public static readonly string PearsonManager = "test_pearsonmanager@learntodive.org.uk";
            public static readonly string UserNoRoles0 = "automation.testX@gmail.com";
            public static readonly string UserNoRoles1 = "automation.testX@gmail.com";
            public static readonly string UserNoRoles2 = "test_2@learntodive.org.uk";
            public static readonly string UserNoRoles3 = "mybtec.test.3@gmail.com";
            public static readonly string UserNoRoles4 = "test_4@learntodive.org.uk";
            public static readonly string UserNoRoles5 = "test_5@learntodive.org.uk";
            public static readonly string UserNoRoles6 = "test_6@learntodive.org.uk";
            public static readonly string UserNoRoles7 = "test_7@learntodive.org.uk";
            public static readonly string UserNoRoles8 = "test_8@learntodive.org.uk";
            public static readonly string UserNoRoles9 = "test_9@learntodive.org.uk";
            public static readonly string MyBtec = "mybtec.amdaris@gmail.com";
            public static readonly string MyBtecAlerts = "mybtec.amdaris@gmail.com";
            public static readonly string DefaultPassword = "1Secret123";
            public static readonly string SmtpServer = "imap.gmail.com";
            public static readonly int Port = 993;
        }

        public sealed class FirstName
        {
            public static readonly string QualityNominee = "Auto";
            public static readonly string Liv = "Auto";
            public static readonly string CourseLeader = "Auto";
            public static readonly string Iv = "Auto";
            public static readonly string Assessor = "Auto";
            public static readonly string Teacher = "Auto";
            public static readonly string Ddm = "Auto";
            public static readonly string Editor = "Auto";
            public static readonly string Tester = "Auto";
            public static readonly string Support = "Auto";
            public static readonly string PearsonManager = "Test Pearson";

            public static readonly string UserNoRoles0 = "Test";
            public static readonly string UserNoRoles1 = "Test";
            public static readonly string UserNoRoles2 = "Test";
            public static readonly string UserNoRoles3 = "Test";
            public static readonly string UserNoRoles4 = "Test";
            public static readonly string UserNoRoles5 = "Test";
            public static readonly string UserNoRoles6 = "Test";
            public static readonly string UserNoRoles7 = "Test";
            public static readonly string UserNoRoles8 = "Test";
            public static readonly string UserNoRoles9 = "Test";
        }

        public sealed class GradeLevel
        {
            public static readonly string Pass = "Pass";
            public static readonly string Merit = "Merit";
            public static readonly string Distinction = "Distinction";
        }

        public sealed class LastName
        {
            public static readonly string QualityNominee = "QN";
            public static readonly string Liv = "LIV";
            public static readonly string CourseLeader = "CL";
            public static readonly string Iv = "IV";
            public static readonly string Assessor = "Assessor";
            public static readonly string Teacher = "Teacher";
            public static readonly string Ddm = "DDM";
            public static readonly string Editor = "Editor";
            public static readonly string Tester = "Tester";
            public static readonly string Support = "Support";
            public static readonly string PearsonManager = "Manager";

            public static readonly string UserNoRoles0 = "Zero";
            public static readonly string UserNoRoles1 = "One";
            public static readonly string UserNoRoles2 = "Two";
            public static readonly string UserNoRoles3 = "Three";
            public static readonly string UserNoRoles4 = "Four";
            public static readonly string UserNoRoles5 = "Five";
            public static readonly string UserNoRoles6 = "Six";
            public static readonly string UserNoRoles7 = "Seven";
            public static readonly string UserNoRoles8 = "Eight";
            public static readonly string UserNoRoles9 = "Nine";
        }

        public sealed class LearningObjective
        {
            public static readonly string L_503_6471_LOA = "L_503_6471.LOA";

            public static readonly string L_503_6471_LOA_Title =
                "A : take part in the preparations for a live performance";
        }

        public sealed class Login
        {
            public static readonly string QualityNominee = "test_qn@learntodive.org.uk";
            public static readonly string Liv = "test_leadinternalverifier@learntodive.org.uk";
            public static readonly string CourseLeader = "test_courseleader@learntodive.org.uk";
            public static readonly string Iv = "test_internalverifier@learntodive.org.uk";
            public static readonly string Assessor = "test_assessor@learntodive.org.uk";
            public static readonly string Teacher = "test_teacher@learntodive.org.uk";
            public static readonly string Ddm = "test_ddm@learntodive.org.uk";
            public static readonly string Editor = "test_editor@learntodive.org.uk";
            public static readonly string Tester = "test_tester@learntodive.org.uk";
            public static readonly string Support = "test_support@learntodive.org.uk";
            public static readonly string PearsonManager = "test_pearsonmanager@learntodive.org.uk";
            public static readonly string UserNoRoles0 = "test_0@learntodive.org.uk";
            public static readonly string UserNoRoles1 = "test_1@learntodive.org.uk";
            public static readonly string UserNoRoles2 = "test_2@learntodive.org.uk";
            public static readonly string UserNoRoles3 = "test_3@learntodive.org.uk";
            public static readonly string UserNoRoles4 = "test_4@learntodive.org.uk";
            public static readonly string UserNoRoles5 = "test_5@learntodive.org.uk";
            public static readonly string UserNoRoles6 = "test_6@learntodive.org.uk";
            public static readonly string UserNoRoles7 = "test_7@learntodive.org.uk";
            public static readonly string UserNoRoles8 = "test_8@learntodive.org.uk";
            public static readonly string UserNoRoles9 = "test_9@learntodive.org.uk";
            public static readonly string UserNoRoles10 = "test_10@learntodive.org.uk";
        }

        public sealed class Password
        {
            public static readonly string QualityNominee = "FBE4BD5";
            public static readonly string Liv = "D65D939";
            public static readonly string CourseLeader = "2CD767B";
            public static readonly string Iv = "C9D4D43";
            public static readonly string Assessor = "5B56C3E";
            public static readonly string Teacher = "67546B6";
            public static readonly string Ddm = "7FF2F6A";
            public static readonly string Editor = "4CDABFC";
            public static readonly string Tester = "335A7F6";
            public static readonly string Support = "C38AB37";
            public static readonly string PearsonManager = "FBEF932";

            public static readonly string UserNoRoles0 = "3C26553";
            public static readonly string UserNoRoles1 = "5ED9966";
            public static readonly string UserNoRoles2 = "D374B8D";
            public static readonly string UserNoRoles3 = "DDFC98B";
            public static readonly string UserNoRoles4 = "F7E3BE2";
            public static readonly string UserNoRoles5 = "8233B46";
            public static readonly string UserNoRoles6 = "6B769A5";
            public static readonly string UserNoRoles7 = "9229CAC";
            public static readonly string UserNoRoles8 = "57EB7E5";
            public static readonly string UserNoRoles9 = "35A62AB";
            public static readonly string UserNoRoles10 = "35A62AB";
        }

        public class Pathway
        {
            public static readonly string AppliedScience = UI.AppliedScience;
            public static readonly string Performing_Arts_Acting = "Performing Arts (Acting)";
            public static readonly string Business_Accounting = "Business (Accounting)";
            public static readonly string Business = "Business";
            public static readonly string Application_of_Science = "Application of Science";
            public static readonly string Sport_Award = "Sport";
            public static readonly string ICT_Award = "Information and Creative Technology (Award)";
        }

        public class QualificationSuite
        {
            public static readonly string BTEC_First_2010_QCF = "BTEC Firsts 2010 (QCF)";
            public static readonly string BTEC_First_2012_NQF = "BTEC Firsts 2012 (NQF)";
            public static readonly string BTEC_Nationals_2010_QCF = "BTEC Nationals 2010 (QCF)";
        }

        public class Reports
        {
            public static readonly IList<string> ReportTypes = new List<string>
            {
                UI.SelectAction,
                UI.LoginReport,
                UI.RolesReport,
                UI.CoursesReport,
                UI.AssignmentsReport,
                UI.OptOutReport,
                UI.ResourceDownloadReport
            };

            public static readonly IList<string> LoginReportHeaders = new List<string>
            {
                UI.UserEmailAddress,
                UI.FirstName,
                UI.LastName,
                UI.LoginDateTime,
                UI.CentreNumber,
                UI.CentreName
            };

            public static readonly IList<string> RoleclaimReportHeaders = new List<string>
            {
                UI.FirstName,
                UI.LastName,
                UI.UserEmailAddress,
                UI.RoleClaimed,
                UI.DateRoleClaimed,
                UI.CentreNumber,
                UI.CentreName,
                UI.Subject,
                UI.Approved,
                UI.SiteQN
            };

            public static readonly IList<string> CourseReportHeaders = new List<string>
            {
                UI.UserEmailAddress,
                UI.FirstName,
                UI.LastName,
                UI.Title,
                UI.CentreNumber,
                UI.CentreName,
                UI.CreationDate,
                UI.QualificationName,
                UI.CurrentStatus,
                UI.CourseTeamAdded,
                UI.AssignmentsLinked,
                UI.CourseStartDate,
                UI.CourseEndDate
            };

            public static readonly IList<string> AssignmentReportHeaders = new List<string>
            {
                UI.UserID,
                UI.FirstName,
                UI.LastName,
                UI.Title,
                UI.UserEmailAddress,
                UI.CentreNumber,
                UI.CentreName,
                UI.CreationDate,
                UI.Subject,
                UI.Qualification,
                UI.QAN,
                UI.CurrentStatus,
                UI.CoursesLinked,
                UI.DateApproved
            };

            public static readonly IList<string> OptOutReportHeaders = new List<string>
            {
                UI.FirstName,
                UI.LastName,
                UI.UserEmailAddress,
                UI.CentreNumber,
                UI.CentreName,
                UI.DatetimeOptedOut
            };
        }

        public class Resources
        {
            public static readonly string FirstPackName = "BTEC Art and Design Delivery Guide (25 items)";

            public static readonly string FirstPackTooltip =
                "A Teacher-facing overview of [SUBJECT] by unit, with assessment guidance and suggested delivery activities.";

            public static readonly string FirstResourceName = "Introduction to BTEC First Art and Design Delivery Guide";

            public static readonly string FirstResourceTooltip =
                "A teacher-facing overview of BTEC Firsts in Art and Design containing an introduction to BTEC Firsts at Award/Certificate/Diploma, with key features of the qualification explained and assessment guidance.";

            public static readonly string ICTPackName = "BTEC ICT Schemes of Work (5 items)";

            public static readonly string ICTPackTooltip =
                "A pack of teacher-facing schemes of work to support your delivery of this qualification. ";

            public static readonly string BusinessPackName = "BTEC Business Delivery Guide (19 items)";

            public static readonly string BusinessPackTooltip =
                "A teacher-facing overview of Business by unit, with assessment guidance and suggested delivery activities.";
        }

        public sealed class Role
        {
            public const string Liv = "LeadInternalVerifier";
            public const string CourseLeader = "CourseLeader";
            public const string Iv = "InternalVerifier";
            public const string Assessor = "Assessor";
            public const string Teacher = "Teacher";
        }

        public class Roles
        {
            public static readonly string CourseDelivery = "Course delivery";
        }

        public class Size
        {
            public static readonly string Certificate_15_Credits = "Certificate (15 Credits)";
            public static readonly string Certificate_30_Credits = "Certificate (30 Credits)";
            public static readonly string Award_120_GLH = "Award (120 GLH)";
            public static readonly string FirstAward_120_GLH = "First Award (120 GLH)";
            public static readonly string Extended_Diploma_180_Credits = "Extended Diploma (180 Credits)";
            public static readonly string Extended_Certificate_360_GLH = "Extended Certificate (360 GLH)";
        }

        public class Subject
        {
            public static readonly string AppliedScience = UI.AppliedScience;
            public static readonly string PerformingArts = "Performing Arts";
            public static readonly string Business = "Business";
            public static readonly string Application_of_Science = "Application of Science";
            public static readonly string Principles_of_Applied_Science = "Principles of Applied Science";
            public static readonly string Art_and_Design = "Art and Design";
            public static readonly string Engineering = "Engineering";
            public static readonly string Health_and_Social_Care = "Health and Social Care";
            public static readonly string Information_and_Creative_Technology = "Information and Creative Technology";
            public static readonly string Sport = "Sport";

            public static readonly string Childrens_Play_Learning_and_Development =
                "Children's Play, Learning and Development";

            public static readonly string Construction_and_the_Built_Environment =
                "Construction and the Built Environment";
            public static readonly string Creative_Digital_Media_Production =
                "Creative Digital Media Production";
            public static readonly string Creative_Media_Production =
                "Creative Media Production";
            public static readonly string Hospitality =
                "Hospitality";
            public static readonly string Information_Technology = "Information Technology";
            public static readonly string Music = "Music";
            public static readonly string Music_and_Music_Technology = "Music and Music Technology";
            public static readonly string Travel_and_Tourism = "Travel and Tourism";
        }

        public class Unit
        {
            //Applied Science
            public static readonly string U_1_Chemistry_and_Our_Earth = "2. Chemistry and Our Earth (H_503_6525)";
            public static readonly string U_1_Fundamentals_of_Science = "1. Fundamentals of Science (R_502_5536)";
            //Application of Science
            public static readonly string U_5_Applications_of_Chemical_Substances =
                "5. Applications of Chemical Substances (M_503_6527)";

            public static readonly string U_6_Applications_of_Physical_Science =
                "6. Applications of Physical Science (T_503_6528)";

            public static readonly string U_7_Health_Applications_of_Life_Science =
                "7. Health Applications of Life Science (A_503_6529)";

            public static readonly string U_8_Scientific_Skills = "8. Scientific Skills (M_503_6530)";

            //MLN units Business
            public static readonly string HOSPITALITY_OPERATIONS_IN_TRAVEL_AND_TOURISM =
                "HOSPITALITY OPERATIONS IN TRAVEL AND TOURISM (MLN) (M_500_2331)";

            public static readonly string EVENTS_CONFERENCES_AND_EXHIBITIONS =
                "EVENTS, CONFERENCES AND EXHIBITIONS (MLN) (K_500_2327)";

            public static readonly string WORK_EXPERIENCE_IN_THE_TRAVEL_TOURISM_SECT =
                "WORK EXPERIENCE IN THE T&T INDUSTRY (MLN) (A_500_2333)";

            //Business
            public static readonly string U_1_The_Business_Environment = "1. The Business Environment (Y_502_5408)";
            public static readonly string U_2_Finance_For_Business = "2. Finance for Business (D_503_6488)";
        }

        public class UnitCriteriaTitle
        {
            public static readonly string U_1_Fundamentals_of_Science =
                "Assessment and grading criteria for unit: Fundamentals of Science";

            public static readonly string U_Fundamentals_of_Science = "Fundamentals of Science";

            public static readonly string U_Preparation_Performance_and_Production =
                "Preparation, Performance and Production";
        }

        public class ViewQualificationStep2HeadTitle
        {
            public static readonly string TitleForApliedScience =
                "Edexcel BTEC Level 3 Certificate in Applied Science (30 Credits)";
        }
    }
}