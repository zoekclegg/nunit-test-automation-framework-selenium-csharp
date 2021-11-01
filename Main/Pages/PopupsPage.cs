using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace AutomateNowDemo
{
    class PopupsPage
    {
        IWebDriver driver;
        public PopupsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "alert")]
        [CacheLookup]
        private IWebElement AlertButton;

        [FindsBy(How = How.Id, Using = "confirm")]
        [CacheLookup]
        private IWebElement ConfirmButton;

        [FindsBy(How = How.Id, Using = "confirmResult")]
        [CacheLookup]
        private IWebElement ConfirmText;

        [FindsBy(How = How.Id, Using = "prompt")]
        [CacheLookup]
        private IWebElement PromptButton;

        [FindsBy(How = How.Id, Using = "promptResult")]
        [CacheLookup]
        private IWebElement PromptText;

        public void ClickAlertButton()
        {
            AlertButton.Click();
        }

        public void ClickConfirmButton()
        {
            ConfirmButton.Click();
        }

        public void ClickPromptButton()
        {
            PromptButton.Click();
        }

        public string GetAlertText()
        {
            return driver.SwitchTo().Alert().Text;
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void InputAlertText(String text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        public String GetConfirmText()
        {
            return ConfirmText.Text;
        }

        public String GetPromptText()
        {
            return PromptText.Text;
        }

    }
}
