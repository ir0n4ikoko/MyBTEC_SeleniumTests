using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseStep3Flow : BtecMasterFlow<CourseStep3Flow>
    {
        private readonly CourseStep3Page page;

        public CourseStep3Flow(INavigator navigator, CourseStep3Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public string GetCourseId()
        {
            return page.Id;
        }

        public CourseStep3Flow ConfirmCourse()
        {
            navigator.ClickAndWaitForJQuery(page.ConfirmCourse.Click);
            return this;
        }

        public CourseStep3Flow AssertConfirmCourseHidden()
        {
            Assert.IsFalse(page.ConfirmCourse.Enabled, "[Confirm] button should be hidden");

            return this;
        }

        public CourseFlow ConfirmCoursePopup()
        {
            var coursePage = navigator.DoActionWaitForJQueryAndNavigate<CoursePage>(page.ConfirmCoursePopupButton.Click);

            return new CourseFlow(navigator, coursePage);
        }

        public FlowResult<CourseFlow> ConfirmCoursePopupResult()
        {
            return new FlowResult<CourseFlow>(page.Id) {Flow = ConfirmCoursePopup()};
        }

        public CourseStep3Flow SaveAsDraft()
        {
            page.SaveAsDraftButton.Click();
            navigator.WaitForJQuery();
            return this;
        }

        public CourseFlow DraftPopupClickYes()
        {
            var coursePage = navigator.DoActionWaitForJQueryAndNavigate<CoursePage>(page.DraftPopupYes.Click);

            return new CourseFlow(navigator, coursePage);
        }

        public CourseStep3Flow AssertRedWarningNoteExists(bool exists = true)
        {
            Assert.AreEqual(exists, page.RedWarningNote.Exists,
                "Red warning note {0} on page".F(exists ? "does not exist" : page.RedWarningNote.Text + " exists"));

            return this;
        }

        public CourseStep3Flow AssertRedWarningNoteTextCorrect(string text)
        {
            Assert.AreEqual(text, page.RedWarningNote.Text, "Incorrect text in red warning note");

            return this;
        }
    }
}