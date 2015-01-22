using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Edi.Advance.BTEC.UiTests.Flows;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.Core.Common.Extentions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Edi.Advance.BTEC.UiTests
{

    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            string pathToDownloadDir = Configuration.DownloadDir;
            if (!Directory.Exists(pathToDownloadDir))
                Directory.CreateDirectory(pathToDownloadDir);

            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            switch (Configuration.Browser)
            {
                case "Firefox":
                    var profile = new FirefoxProfile();
                    profile.SetPreference("browser.download.folderList", 2);
                    profile.SetPreference("browser.download.dir", pathToDownloadDir);
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv, application/pdf, application/zip");
                    //profile.EnableNativeEvents = true;
                    capability.SetCapability("firefox_profile", profile.ToBase64String());
                    SeleniumContext.WebDriver = new FirefoxDriver(capability);
                    break;
                case "Chrome":
                    SeleniumContext.WebDriver =
                        new ChromeDriver(Path.GetFullPath(
                            @"..\..\..\..\..\packages\WebDriverChromeDriver.2.10\tools"));
                    break;
                case "InternetExplorer":
                    SeleniumContext.WebDriver = new InternetExplorerDriver();
                    break;
            }
            
            SeleniumContext.WebDriver.Manage().Window.Maximize();

            SeleniumContext.WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (SeleniumContext.WebDriver != null)
                {
                    if (TestContext.CurrentContext.Result.Status
                        == TestStatus.Failed)
                    {
                        string testName =
                            TestContext.CurrentContext.Test.Name.Split('(')[0]
                            + "_" + Configuration.Browser + "_"
                            + DateTime.Now.Ticks;
                        string pathToFailedTests = Configuration.DownloadDir
                                                   + "\\FailedTests";
                        string testPath = pathToFailedTests + "\\" + testName;

                        if (!Directory.Exists(pathToFailedTests))
                            Directory.CreateDirectory(pathToFailedTests);

                        Screenshot screenshot =
                            ((ITakesScreenshot) SeleniumContext.WebDriver)
                                .GetScreenshot();

                        //TestLog.EmbedImage(testName, new System.Drawing.Bitmap(new MemoryStream(screenshot.AsByteArray)));
                        var screenshotPath = "file://ci02/FailedTests/"+ testName + ".png";
                        screenshot.SaveAsFile(testPath + ".png", ImageFormat.Png);
                        Console.WriteLine(screenshotPath);
                    }
                    SeleniumContext.WebDriver.Quit();
                }

            }
            catch
                (InvalidOperationException)
            {
            }
            catch
                (IOException)
            {
            }
            catch
                (WebDriverException)
            {
            }
        }

        public StartFlow Start
        {
            get
            {
                var navigator = new Navigator();

                navigator.Start(Configuration.SiteUrl);

                return new StartFlow(navigator);
            }
        }

        //public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
        //{
        //    public ScreenShotRemoteWebDriver(Uri url, ICapabilities capabilities)
        //        : base(url, capabilities)
        //    {
        //    }

        //    public Screenshot GetScreenshot()
        //    {
        //        Response screenshotResponse = Execute(DriverCommand.Screenshot, null);
        //        string base64 = screenshotResponse.Value.ToString();
        //        return new Screenshot(base64);
        //    }
        //}
    }
}