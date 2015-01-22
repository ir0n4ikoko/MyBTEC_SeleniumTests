using System;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    public class SeleniumContext
    {
        [ThreadStatic] public static IWebDriver WebDriver;
    }
}