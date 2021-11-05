using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;

namespace AutomateNowDemo
{

    [TestFixture]
    public class ModalTests : BaseTest
    {
        [SetUp]
        public void NavigateToModalsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickNavButton("Modals");
            test.Log(Status.Pass, "Navigated to Modals page");
        }

        [Test]
        public void CanOpenAndCloseSimpleModal()
        {
            ModalsPage modalsPage = new ModalsPage(driver);
            modalsPage.ClickSimpleModalButton();
            test.Log(Status.Pass, "Clicked Simple Modal Button");
            modalsPage.CloseSimpleModal();
            test.Log(Status.Pass, "Clicked to close Simple Modal");
            Assert.IsTrue(!modalsPage.IsSimpleModalDisplayed());
            test.Log(Status.Pass, "Simple Modal closed");
        }

        [Test]
        [TestCase("Dexter", "", "")]
        [TestCase("Rita", "test@email.com", "Some message")]
        public void CanSubmitFormModal(string name, string email, string message)
        {
            ModalsPage modalsPage = new ModalsPage(driver);
            modalsPage.ClickFormModalButton();
            test.Log(Status.Pass, "Clicked Form Modal Button");
            modalsPage.InputName(name);
            test.Log(Status.Pass, "Inputted name");
            if (email.Length > 0)
            {
                modalsPage.InputEmail(email);
                test.Log(Status.Pass, "Inputted email");
            }
            if (message.Length > 0)
            {
                modalsPage.InputMessage(message);
                test.Log(Status.Pass, "Inputted message");
            }
            modalsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Clicked submit button");
            Assert.IsTrue(modalsPage.IsFormSubmitted());
            test.Log(Status.Pass, "Verified form submitted");
        }

        [Test]
        public void CannotSubmitFormWithoutName()
        {
            ModalsPage modalsPage = new ModalsPage(driver);
            modalsPage.ClickFormModalButton();
            test.Log(Status.Pass, "Clicked Form Modal Button");
            modalsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Clicked submit button");
            Assert.IsTrue(!modalsPage.IsFormSubmitted());
            test.Log(Status.Pass, "Verified form not submitted");
        }

        [Test]
        [TestCase("Doakes", "testemail")]
        public void CannotSubmitFormWithInvalidEmail(string name, string email)
        {
            ModalsPage modalsPage = new ModalsPage(driver);
            modalsPage.ClickFormModalButton();
            test.Log(Status.Pass, "Clicked Form Modal Button");
            modalsPage.InputName(name);
            test.Log(Status.Pass, "Inputted name");
            modalsPage.InputEmail(email);
            test.Log(Status.Pass, "Inputted email");
            modalsPage.ClickSubmitButton();
            test.Log(Status.Pass, "Clicked submit button");
            Assert.IsTrue(!modalsPage.IsFormSubmitted());
            test.Log(Status.Pass, "Verified form not submitted");
        }

    }
}
