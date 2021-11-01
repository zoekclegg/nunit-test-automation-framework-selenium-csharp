using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutomateNowDemo
{

    public abstract class BaseTest
    {
        
        public static ExtentTest test;
        public IWebDriver driver;
        public static ExtentReports extent;

        [SetUpFixture]
        public class OneTimeSetup
            {
            
            [OneTimeSetUp]
            public static void Setup()
            {
                var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var actualPath = path.Substring(0, path.LastIndexOf("bin"));
                var projectPath = new Uri(actualPath).LocalPath;
                Directory.CreateDirectory(projectPath.ToString() + "Reports");
                var reportPath = projectPath + "Reports\\ExtentReport.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Host Name", "LocalHost");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "TestUser"); 
            }
       }

        [SetUp]
        public void StartBrowser()
        {
            // Something to read the correct driver to use from a properties file?
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Log(Status.Info, "Test started");
            driver = new ChromeDriver("C:\\Users\\zcleg\\OneDrive\\Documents\\Automation\\AutomateNowDemo\\Main\\Resources");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://automatenow.io/sandbox-automation-testing-practice-website/";
            test.Log(Status.Pass, "Browser opened");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
: string.Format("{{ 0}}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test status: " + logstatus + stacktrace);
            driver.Close();

            extent.Flush();
        }

        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}
