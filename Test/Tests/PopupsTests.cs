using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace AutomateNowDemo
{

    [TestFixture]
    public class PopupsTests : BaseTest
    {
        [SetUp]
        public void NavigateToPopupsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickNavButton("Popups");
            test.Log(Status.Pass, "Navigated to Popups page");
        }

        [Test]
        public void VerifyAlertPopupText()
        {
            PopupsPage popupsPage = new PopupsPage(driver);
            popupsPage.ClickAlertButton();
            test.Log(Status.Pass, "Alert button clicked");
            Assert.That(popupsPage.GetAlertText().Equals("Hi there pal!"));
            test.Log(Status.Pass, "Alert popup text verified");
            popupsPage.DismissAlert();
        }

        [Test]
        public void VerifyConfirmPopupText()
        {
            PopupsPage popupsPage = new PopupsPage(driver);
            popupsPage.ClickConfirmButton();
            test.Log(Status.Pass, "Confirm button clicked");
            popupsPage.AcceptAlert();
            test.Log(Status.Pass, "Popup accepted");
            Assert.That(popupsPage.GetConfirmText().Equals("OK it is!"));
            test.Log(Status.Pass, "Confirm popup text verified");
        }

        [Test]
        public void VerifyConfirmPopupCancelText()
        {
            PopupsPage popupsPage = new PopupsPage(driver);
            popupsPage.ClickConfirmButton();
            test.Log(Status.Pass, "Confirm button clicked");
            popupsPage.DismissAlert();
            test.Log(Status.Pass, "Popup dismissed");
            Assert.That(popupsPage.GetConfirmText().Equals("Cancel it is!"));
            test.Log(Status.Pass, "Confirm popup cancel text verified");
        }

        [Test]
        [TestCase("Zoe")]
        public void VerifyPromptPopupText(string name)
        {
            PopupsPage popupsPage = new PopupsPage(driver);
            popupsPage.ClickPromptButton();
            test.Log(Status.Pass, "Prompt button clicked");
            popupsPage.InputAlertText(name);
            popupsPage.AcceptAlert();
            test.Log(Status.Pass, "Popup accepted");
            Assert.That(popupsPage.GetPromptText().Equals($"Nice to meet you {name}!"));
            test.Log(Status.Pass, "Prompt popup text verified");
        }

        [Test]
        public void VerifyPromptPopupCancelText()
        {
            PopupsPage popupsPage = new PopupsPage(driver);
            popupsPage.ClickPromptButton();
            test.Log(Status.Pass, "Prompt button clicked");
            popupsPage.DismissAlert();
            test.Log(Status.Pass, "Popup dismissed");
            Assert.That(popupsPage.GetPromptText().Equals("Fine, don't tell me then :("));
            test.Log(Status.Pass, "Prompt popup cancel text verified");
        }
    }
}
