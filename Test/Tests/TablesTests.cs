using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutomateNowDemo
{

    [TestFixture]
    public class TablesTests : BaseTest
    {
        [SetUp]
        public void NavigateToTableFieldsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickNavButton("Tables");
            test.Log(Status.Pass, "Navigated to Form Fields page");
        }

        [Test]
        [TestCase("Brazil")]
        [TestCase("21")]
        [TestCase("80")]
        public void VerifySearchResults(string text)
        {
            TablesPage tablesPage = new TablesPage(driver);
            tablesPage.InputTextInSearchField(text);
            test.Log(Status.Pass, "Input search text");
            Assert.That(tablesPage.VerifySearchRow(text));
            test.Log(Status.Pass, "Search result verified");
        }

    }
}
