using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AutomateNowDemo.Main.Pages
{
    class TablesPage
    {
        IWebDriver driver;
        public TablesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        [CacheLookup]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//tbody[@class='row-hover']/tr")]
        [CacheLookup]
        private IList<IWebElement> TableRows;

        [FindsBy(How = How.XPath, Using = "//thead/tr/th")]
        [CacheLookup]
        private IList<IWebElement> TableColumns;

        [FindsBy(How = How.XPath, Using = "//select[@name='tablepress-1_length']")]
        [CacheLookup]
        private IWebElement CountFilter;

        [FindsBy(How = How.XPath, Using = "//div[@id='tablepress-1_info']")]
        [CacheLookup]
        private IWebElement TableInfo;

        public void InputTextInSearchField(String text)
        {
            SearchField.SendKeys(text);
        }

        public bool VerifySearchRow(string text)
        {
            int NumRows = TableRows.Count;
            int NumColumns = TableColumns.Count;
            int row, column, match;
            bool result = true;
            for (row = 1; row <= NumRows; row++)
            {
                match = 0;
                for (column = 1; column <= NumColumns; column++)
                {
                    if (driver.FindElement(By.XPath($"//tbody[@class='row-hover']/tr[{row}]/td[{column}]")).Text.Contains(text))
                    {
                        match++;
                    }
                }
                if (match == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public void SelectCountFilter(string count)
        {
            SelectElement CountDropdown = new SelectElement(CountFilter);
            CountDropdown.SelectByText(count);
        }

        public int GetVisibleRowCount()
        {
            return TableRows.Count;
        }

        public int GetTotalCount()
        {
            int StartIndex = TableInfo.Text.IndexOf("of ") + 3;
            int Length = TableInfo.Text.Length - StartIndex - 7;
            return Convert.ToInt32(TableInfo.Text.Substring(StartIndex, Length));
        }

        public void SortColumn(int column)
        {
            driver.FindElement(By.XPath($"//table[@id='tablepress-1']//th[{column}]")).Click();
        }

        public List<string> GetVisibleColumnResults(int column)
        {
            int NumRows = TableRows.Count;
            int row;
            List<string> results = new List<string> { };
            for (row = 1; row <= NumRows; row++)
            {
                results.Add(driver.FindElement(By.XPath($"//tbody[@class='row-hover']/tr[{row}]/td[{column}]")).Text);
            }
            return results;
        }
    }

}