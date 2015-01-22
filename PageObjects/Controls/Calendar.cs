using System;
using System.Globalization;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class Calendar : ClickableControl
    {
        public Calendar(string id)
            : base(id)
        {
        }

        public Calendar(string id, Func<string, By> by)
            : base(id, by)
        {
        }

        public Dropdown Month
        {
            get { return new Dropdown("ui-datepicker-month", By.ClassName); }
        }

        public Dropdown Year
        {
            get { return new Dropdown("ui-datepicker-year", By.ClassName); }
        }

        public ClickableControl Now
        {
            get { return new ClickableControl("//div[@id='ui-datepicker-div']/div/button[text()='Now']", By.XPath); }
        }

        public ClickableControl Done
        {
            get { return new ClickableControl("//div[@id='ui-datepicker-div']/div/button[text()='Done']", By.XPath); }
        }

        public ClickableControl Minutes
        {
            get { return new ClickableControl(".//dd[@class='ui_tpicker_minute']/div/a", By.XPath); }
        }

        public ClickableControl Hours
        {
            get { return new ClickableControl(".//dd[@class='ui_tpicker_hour']/div/a", By.XPath); }
        }

        public ClickableControl Day(string id)
        {
            return new ClickableControl("//table[@class='ui-datepicker-calendar']/tbody/tr/td/a[text()='{0}']".F(id),
                By.XPath);
        }

        public void SelectDate(string date)
        {
            (SeleniumContext.WebDriver as IJavaScriptExecutor).ExecuteScript("$('#" + id + "').removeAttr('readonly')");

            (SeleniumContext.WebDriver as IJavaScriptExecutor).ExecuteScript("document.getElementById('" + id +
                                                                             "').value='" + date + "'");
        }

        public void SelectDateTime(DateTime dateTime)
        {
            Click();
            Year.Text = dateTime.Year.ToString("G");
            Month.Text = dateTime.ToString("MMM", CultureInfo.InvariantCulture);
            Day(dateTime.Day.ToString("G")).Click();

            int hourWidth = WebDriver.FindElement(By.ClassName("ui_tpicker_hour_slider")).Size.Width;
            int minuteWidth = WebDriver.FindElement(By.ClassName("ui_tpicker_minute_slider")).Size.Width;
            Hours.MoveByOffset(hourWidth*dateTime.Hour/23, 0);
            Minutes.MoveByOffset(minuteWidth*dateTime.Minute/60, 0);
            Done.Click();
        }
    }
}