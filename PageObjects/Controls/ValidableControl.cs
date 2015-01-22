using System;
using System.Text.RegularExpressions;
using Edi.Advance.Core.Common;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects.Controls
{
    public class ValidableControl : WebDriverControl
    {
        private readonly string redCrossId;

        public ValidableControl(string validableControlId)
        {
            redCrossId = "{0}_validationMessage".F(validableControlId);
        }

        public bool IsValid
        {
            get
            {
                try
                {
                    return string.IsNullOrWhiteSpace(ValidationMessage);
                }
                catch
                {
                    return false;
                }
            }
        }

        public string ValidationMessage
        {
            get
            {
                try
                {
                    string onmouseover = WebDriver
                        .FindElement(By.XPath("//span[@id='{0}']/descendant::img".F(redCrossId)))
                        .GetAttribute("onmouseover");

                    return Regex.Replace(onmouseover, @"Tip\(""|""\)|Tip\('|'\)", string.Empty, RegexOptions.IgnoreCase);

                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }
    }
}