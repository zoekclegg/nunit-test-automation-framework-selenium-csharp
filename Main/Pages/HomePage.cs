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

        public void ClickNavButton(string text)
        {
            driver.FindElement(By.LinkText(text)).Click();
        }
    }
}
