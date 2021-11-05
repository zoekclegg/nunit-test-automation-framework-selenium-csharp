using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AutomateNowDemo.Main.Pages
{
    class ModalsPage
    {
        IWebDriver driver;
        public ModalsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "simpleModal")]
        [CacheLookup]
        private IWebElement SimpleModalButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='popmake-1318']//button[contains(@class,'pum-close')]")]
        [CacheLookup]
        private IWebElement CloseSimpleModalIcon;

        [FindsBy(How = How.Id, Using = "formModal")]
        [CacheLookup]
        private IWebElement FormModalButton;

        [FindsBy(How = How.Id, Using = "g1051-name")]
        [CacheLookup]
        private IWebElement NameField;

        [FindsBy(How = How.Id, Using = "g1051-email")]
        [CacheLookup]
        private IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "contact-form-comment-g1051-message")]
        [CacheLookup]
        private IWebElement MessageField;

        [FindsBy(How = How.ClassName, Using = "pushbutton-wide")]
        [CacheLookup]
        private IWebElement SubmitButton;

        public void ClickSimpleModalButton()
        {
            SimpleModalButton.Click();
        }

        public void CloseSimpleModal()
        {
            CloseSimpleModalIcon.Click();
        }

        public bool IsSimpleModalDisplayed()
        {
            return CloseSimpleModalIcon.Displayed;
        }

        public void ClickFormModalButton()
        {
            FormModalButton.Click();
        }

        public void InputName(string name)
        {
            NameField.SendKeys(name);
        }

        public void InputEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void InputMessage(string message)
        {
            MessageField.SendKeys(message);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public bool IsFormSubmitted()
        {
            return driver.Url.Contains("contact-form-sent");
        }

    }

}