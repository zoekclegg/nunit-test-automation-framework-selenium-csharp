using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "contact-form-comment-message")]
        [CacheLookup]
        private IWebElement InputBoxField;

        [FindsBy(How = How.ClassName, Using = "pushbutton-wide")]
        [CacheLookup]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Input field:')]")]
        [CacheLookup]
        private IWebElement InputFieldSubmission;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Checkboxes:')]")]
        [CacheLookup]
        private IWebElement CheckboxesSubmission;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Radio Buttons:')]")]
        [CacheLookup]
        private IWebElement RadioButtonsSubmission;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Dropdown Menu:')]")]
        [CacheLookup]
        private IWebElement DropdownMenuSubmission;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Email:')]")]
        [CacheLookup]
        private IWebElement EmailSubmission;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Input box:')]")]
        [CacheLookup]
        private IWebElement InputBoxSubmission;

        public void InputTextIntoInputField(String text)
        {
            InputField.SendKeys(text);
        }

        public bool IsInputFieldVisible()
        {
            return InputField.Displayed;
        }

        public void ClickCheckBox(int option)
        {
            driver.FindElement(By.XPath("//input[@value='Option " + option + "']")).Click();
        }

        public void ClickRadioButton(String option)
        {
            driver.FindElement(By.XPath("//input[@value='" + option + "']")).Click();
        }

        public void SelectDropdownOption(String option)
        {
            SelectElement DropdownMenu = new SelectElement(driver.FindElement(By.Id("g1103-dropdownmenu")));
            DropdownMenu.SelectByText(option);
        }

        public void TypeInEmailField(String text)
        {
            EmailField.SendKeys(text);
        }

        public void TypeInInputBox(String text)
        {
            InputBoxField.SendKeys(text);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public bool VerifyInputFieldText(String text)
        {
            return InputFieldSubmission.Text.Contains(text);
        }

        public bool VerifyCheckboxText(String option)
        {
            return CheckboxesSubmission.Text.Contains(option);
        }

        public bool VerifyRadioButtonText(String option)
        {
            return RadioButtonsSubmission.Text.Contains(option);
        }

        public bool VerifyDropdownMenuText(String option)
        {
            return DropdownMenuSubmission.Text.Contains(option);
        }

        public bool VerifyEmailText(String option)
        {
            return EmailSubmission.Text.Contains(option);
        }

        public bool VerifyInputBoxText(String option)
        {
            return InputBoxSubmission.Text.Contains(option);
        }

    }
}
