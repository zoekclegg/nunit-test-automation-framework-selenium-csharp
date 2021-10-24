using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomateNowDemo.Test.Base
{
    public class BaseTest
    {

        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            // Something to read the correct driver to use from a properties file?
            driver = new ChromeDriver("C:\\Users\\zcleg\\OneDrive\\Documents\\Automation\\AutomateNowDemo\\Main\\Resources");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://automatenow.io/sandbox-automation-testing-practice-website/";
            // Some logging to say 'Browser opened'
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}
