using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace AutomateNowDemo.Main.Pages
{
    class FormFieldsPage
    {
        IWebDriver driver;
        public FormFieldsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "g1103-inputfield")]
        [CacheLookup]
        private IWebElement InputField;

        [FindsBy(How = How.ClassName, Using = "pushbutton-wide")]
        [CacheLookup]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Input field:')]")]
        [CacheLookup]
        private IWebElement InputFieldSubmission;

        public void InputTextIntoInputField(String text)
        {
            InputField.SendKeys(text);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public bool VerifyInputFieldText(String text)
        {
            return InputFieldSubmission.Text.Contains(text);
        }
    }
}
