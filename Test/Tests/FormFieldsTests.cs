using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;

namespace AutomateNowDemo
{

    [TestFixture]
    public class FormFieldsTests : BaseTest
    {
        [SetUp]
        public void NavigateToFormFieldsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickFormFieldsButton();
            // Some logging to confirm page navigation
        }

        [Test]
        public void VerifyInputFieldtext()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.InputTextIntoInputField("Some text");
            formFieldsPage.ClickSubmitButton();
            Assert.That(formFieldsPage.VerifyInputFieldText("Some text"));
        }
    }
}
