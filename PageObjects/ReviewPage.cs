using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public class ReviewPage : BtecMasterPage
    {
        public ReviewPage()
            : base(UI.ReviewPage)
        {
        }

        public Checkbox AreAssessmentCriteriaAddressedByEachTask
        {
            get { return new Checkbox("AcceptanceCriteria_5__IsSelected"); }
        }

        public Checkbox AreActivitiesAppropriate
        {
            get { return new Checkbox("AcceptanceCriteria_7__IsSelected"); }
        }

        public Checkbox IsAppropriateScenario
        {
            get { return new Checkbox("AcceptanceCriteria_8__IsSelected"); }
        }

        public Checkbox IsAppropriateLanguage
        {
            get { return new Checkbox("AcceptanceCriteria_9__IsSelected"); }
        }

        public Checkbox IsAssignmentFitForPurpose
        {
            get { return new Checkbox("AcceptanceCriteria_11__IsSelected"); }
        }

        public Radiobutton ChooseIsAssignmentApproved
        {
            get
            {
                return
                    new Radiobutton(
                        @"//div[@class='radioButton' and label[text()='" + UI.Approved + "']]//input[@type='radio']",
                        By.XPath);
            }
        }

        public Radiobutton ChooseIsAssignmentNotApproved
        {
            get
            {
                return
                    new Radiobutton(
                        @"//div[@class='radioButton' and label[text()='" + UI.NotApproved + "']]//input[@type='radio']",
                        By.XPath);
            }
        }

        public TextField ReviewFeedback
        {
            get { return new TextField("Feedback_Message"); }
        }

        public Link SaveAndSend
        {
            get { return new Link("btnSaveAndSend"); }
        }

        public RadiobuttonList AssignmentCoverage
        {
            get { return new RadiobuttonList("AssignmentCoverage"); }
        }

        public ControlBase Qualification()
        {
            return
                new ControlBase(
                    @"//*[@id='reviewContent']/div[contains(@class,'block')]/div[contains(@class,'review_info')]/div[contains(@class,'fieldspacer')]/div[contains(text(),'Qualification(s):')]/following-sibling::div//span",
                    By.XPath);
        }
    }
}