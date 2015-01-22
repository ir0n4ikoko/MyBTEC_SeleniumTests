using System;
using System.Collections.ObjectModel;
using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class CourseStep2Flow : BtecMasterFlow<CourseStep2Flow>
    {
        private readonly CourseStep2Page page;

        public CourseStep2Flow(INavigator navigator, CourseStep2Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public CourseStep2Flow SetStartDate(DateTime startDate)
        {
            page.StartDate.SelectDate(startDate.ToString("dd/MM/yyyy"));

            return this;
        }

        public CourseStep2Flow SetEndDate(DateTime endDate)
        {
            page.EndDate.SelectDate(endDate.ToString("dd/MM/yyyy"));

            return this;
        }

        public CourseStep2Flow OptionalUnitsView100()
        {
            navigator.WaitForJQuery();

            page.OptionalUnitsGrid.ElementsPerPage.Value = "100";
            return this;
        }

        public CourseStep2Flow CheckAllCheckboxes()
        {
            navigator.WaitForJQuery();
            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(By.XPath("//input[contains(@type,'checkbox')]"));
            chkbxs.Where(chkbx => chkbx.Displayed).ToList().ForEach(chkbx => chkbx.Click());

            try
            {
                string badUnitId =
                    SeleniumContext.WebDriver.FindElement(By.LinkText("Unit 16. Business Enterprise"))
                        .GetAttribute("unitrefval");
                SeleniumContext.WebDriver.FindElement(By.Id("checkbox_" + badUnitId)).Click();
            }
            catch (WebDriverException)
            {
            }

            return this;
        }

        public CourseStep2Flow ClickAddButton()
        {
            navigator.WaitForJQuery();

            if (page.AddUnits.Enabled)
            {
                page.AddUnits.Click();
            }

            return this;
        }

        public CourseStep2Flow Save()
        {
            navigator.WaitForJQuery();

            page.SaveButton.Click();

            return this;
        }

        public CourseStep3Flow SaveContinue()
        {
            navigator.WaitForJQuery();

            var courseStep3Page =
                navigator.DoActionWaitUrlChangedAndNavigate<CourseStep3Page>(
                    () =>
                    {
                        page.SaveContinueButton.Click();
                        navigator.WaitForJQuery();
                        if (page.ConfirmAsDraftPopupYes.Enabled)
                        {
                            page.ConfirmAsDraftPopupYes.Click();
                            navigator.WaitForJQuery();
                        }
                    });

            return new CourseStep3Flow(navigator, courseStep3Page);
        }


    }
}