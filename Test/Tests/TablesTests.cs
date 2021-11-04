using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;

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

        [Test]
        [TestCase("25")]
        [TestCase("100")]
        public void VerifyCountFilter(string count)
        {
            TablesPage tablesPage = new TablesPage(driver);
            tablesPage.SelectCountFilter(count);
            test.Log(Status.Pass, "Selected count filter");
            if(Convert.ToInt32(count) <= tablesPage.GetTotalCount())
            {
                Assert.That(tablesPage.GetVisibleRowCount() == Convert.ToInt32(count));
                test.Log(Status.Pass, "Selected filter count is displayed");
            }
            else
            {
                Assert.That(tablesPage.GetVisibleRowCount() == tablesPage.GetTotalCount());
                test.Log(Status.Pass, "Maximum results shown");
            }
        }

        [Test]
        [TestCase(3)]
        public void VerifySort(int column)
        {
            TablesPage tablesPage = new TablesPage(driver);
            tablesPage.SortColumn(column);
            test.Log(Status.Pass, "Sort by column");
            List<string> results = tablesPage.GetVisibleColumnResults(column);
            results.Sort();
            Assert.AreEqual(results, tablesPage.GetVisibleColumnResults(column));
        }

    }
}
