using OpenQA.Selenium;
using SeleniumExtras.PageObjects; //This is used for PageFactory, since the OpenQA one is now deprecated

namespace AutomateNowDemo.Main.Pages
{
    class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using ="Form Fields")]
        [CacheLookup]
        private IWebElement FormFieldsButton;

        [FindsBy(How = How.LinkText, Using = "Popups")]
        [CacheLookup]
        private IWebElement PopupsButton;

        public void ClickFormFieldsButton()
        {
            FormFieldsButton.Click();
        }

        public void ClickPopupsButton()
        {
            PopupsButton.Click();
        }
    }
}
