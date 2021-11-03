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
            for(row=1; row <= NumRows; row++)
            {
                match = 0;
                for(column=1; column <= NumColumns; column++)
                {
                    if (driver.FindElement(By.XPath($"//tbody[@class='row-hover']/tr[{row}]/td[{column}]")).Text.Contains(text))
                    {
                        match++;
                    }
                }
                if (match == 0) {
                    result = false;
                    break;
                }
            }
            return result;
        }

    }
}
