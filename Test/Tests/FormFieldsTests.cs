using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;

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
            test.Log(Status.Pass, "Navigated to Form Fields page");
        }

        [Test]
        public void VerifyInputFieldtext()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.InputTextIntoInputField("Some text");
            test.Log(Status.Pass, "Input Text inputted");
            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.That(formFieldsPage.VerifyInputFieldText("Some text"));
        }

    }
}
