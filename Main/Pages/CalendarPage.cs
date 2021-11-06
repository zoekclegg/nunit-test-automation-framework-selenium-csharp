using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AutomateNowDemo.Main.Pages
{
    class CalendarPage
    {
        IWebDriver driver;
        public CalendarPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "g1065-selectorenteradate")]
        [CacheLookup]
        private IWebElement CalendarField;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'ui-datepicker-month')]")]
        [CacheLookup]
        private IWebElement CurrentMonth;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'ui-datepicker-year')]")]
        [CacheLookup]
        private IWebElement CurrentYear;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'ui-state-highlight')]")]
        [CacheLookup]
        private IWebElement HighLightedDay;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        [CacheLookup]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//blockquote[@class='contact-form-submission']/p")]
        [CacheLookup]
        private IWebElement SubmittedDate;


        

        public void ClickCalendarField()
        {
            CalendarField.Click();
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public void SelectDate(int date)
        {
            driver.FindElement(By.XPath($"(//a[contains(@class,'ui-state-default')])[{date}]")).Click();
        }

        public string GetSelectedDate()
        {
            return CalendarField.Text;
        }

        public string GetSubmittedDate()
        {
            return SubmittedDate.Text;
        }

        public List<String> GetHighlightedDate()
        {
            List<String> date = new List<string>() { };
            ClickCalendarField();
            date.Add(HighLightedDay.Text);
            date.Add(CurrentMonth.Text);
            date.Add(CurrentYear.Text);
            return date;
        }

    }

}