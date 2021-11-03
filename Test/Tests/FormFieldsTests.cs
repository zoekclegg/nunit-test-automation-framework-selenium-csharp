using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;

namespace AutomateNowDemo
{

    [TestFixture]
    public class FormFieldsTests : BaseTest
    {
        [SetUp]
        public void NavigateToFormFieldsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickNavButton("Form Fields");
            test.Log(Status.Pass, "Navigated to Form Fields page");
        }

        [Test]
        public void CannotSubmitEmptyInputField()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.That(formFieldsPage.IsInputFieldVisible);
            test.Log(Status.Pass, "Verify form not submitted");
        }

        [Test]
        [TestCase("pirates")]
        public void CannotSubmitInvalidEmail(string email)
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.TypeInEmailField(email);
            test.Log(Status.Pass, "Inputted invalid email");
            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.That(formFieldsPage.IsInputFieldVisible);
            test.Log(Status.Pass, "Verify form not submitted");
        }

        [Test]
        [TestCase("Some text", "1", "3", "White", "Hexa", "test@email.com", "Some description")]
        public void VerifyFormFields(string inputText, string checkbox1, string checkbox2, string radio, string dropdown, string email, string description)
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            
            formFieldsPage.InputTextIntoInputField(inputText);
            test.Log(Status.Pass, "Input Text inputted");

            formFieldsPage.ClickCheckBox(checkbox1);
            formFieldsPage.ClickCheckBox(checkbox2);
            test.Log(Status.Pass, "Clicked checkboxes");

            formFieldsPage.ClickRadioButton(radio);
            test.Log(Status.Pass, "Clicked radio button");

            formFieldsPage.SelectDropdownOption(dropdown);
            test.Log(Status.Pass, "Selected dropdown option");

            formFieldsPage.TypeInEmailField(email);
            test.Log(Status.Pass, "Email inputted");

            formFieldsPage.TypeInInputBox(description);
            test.Log(Status.Pass, "Input Box text inputted");

            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.Multiple(() =>
            {
                Assert.That(formFieldsPage.VerifyInputFieldText(inputText));
                Assert.That(formFieldsPage.VerifyCheckboxText(checkbox1));
                Assert.That(formFieldsPage.VerifyCheckboxText(checkbox2));
                Assert.That(formFieldsPage.VerifyRadioButtonText(radio));
                Assert.That(formFieldsPage.VerifyDropdownMenuText(dropdown));
                Assert.That(formFieldsPage.VerifyEmailText(email));
                Assert.That(formFieldsPage.VerifyInputBoxText(description));
            });
            test.Log(Status.Pass, "Form fields verified");
        }

    }
}
