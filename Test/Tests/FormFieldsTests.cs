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
        public void CannotSubmitEmptyInputField()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.That(formFieldsPage.IsInputFieldVisible);
            test.Log(Status.Pass, "Verify form not submitted");
        }

        [Test]
        public void CannotSubmitInvalidEmail()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            formFieldsPage.TypeInEmailField("email");
            test.Log(Status.Pass, "Inputted invalid email");
            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.That(formFieldsPage.IsInputFieldVisible);
            test.Log(Status.Pass, "Verify form not submitted");
        }

        [Test]
        public void VerifyFormFields()
        {
            FormFieldsPage formFieldsPage = new FormFieldsPage(driver);
            
            formFieldsPage.InputTextIntoInputField("Some text");
            test.Log(Status.Pass, "Input Text inputted");

            formFieldsPage.ClickCheckBox(1);
            formFieldsPage.ClickCheckBox(3);
            test.Log(Status.Pass, "Clicked checkboxes");

            formFieldsPage.ClickRadioButton("White");
            test.Log(Status.Pass, "Clicked radio button");

            formFieldsPage.SelectDropdownOption("Hexa");
            test.Log(Status.Pass, "Selected dropdown option");

            formFieldsPage.TypeInEmailField("test@test.com");
            test.Log(Status.Pass, "Email inputted");

            formFieldsPage.TypeInInputBox("Some description");
            test.Log(Status.Pass, "Input Box text inputted");

            formFieldsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Form submitted");
            Assert.Multiple(() =>
            {
                Assert.That(formFieldsPage.VerifyInputFieldText("Some text"));
                Assert.That(formFieldsPage.VerifyCheckboxText("1"));
                Assert.That(formFieldsPage.VerifyCheckboxText("3"));
                Assert.That(formFieldsPage.VerifyRadioButtonText("White"));
                Assert.That(formFieldsPage.VerifyDropdownMenuText("Hexa"));
                Assert.That(formFieldsPage.VerifyEmailText("test@test.com"));
                Assert.That(formFieldsPage.VerifyInputBoxText("Some description"));
            });
            test.Log(Status.Pass, "Form fields verified");
        }

    }
}
