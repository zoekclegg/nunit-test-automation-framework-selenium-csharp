using AutomateNowDemo.Test.Base;
using AutomateNowDemo.Main.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;

namespace AutomateNowDemo
{

    [TestFixture]
    public class CalendarTests : BaseTest
    {
        [SetUp]
        public void NavigateToCalendarsPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickNavButton("Calendars");
            test.Log(Status.Pass, "Navigated to Calendars page");
        }

        [Test]
        public void VerifyTodayIsHighlighted()
        {
            CalendarPage calendarPage = new CalendarPage(driver);
            List<string> highlightedDate = calendarPage.GetHighlightedDate();

            DateTime now = DateTime.Now;
            string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            string day = Convert.ToString(now.Day);
            string month = months[now.Month-1];
            string year = Convert.ToString(now.Year);

            Assert.Multiple(() =>
            {
                Assert.That(day.Equals(highlightedDate[0]));
                Assert.That(month.Equals(highlightedDate[1]));
                Assert.That(year.Equals(highlightedDate[2]));
            });
            test.Log(Status.Pass, "Verified today is highlighted");
        }

        [Test]
        [TestCase(15)]
        public void CanSubmitDate(int date)
        {
            CalendarPage calendarPage = new CalendarPage(driver);
            calendarPage.ClickCalendarField();
            calendarPage.SelectDate(date);
            string selectedDate = calendarPage.GetSelectedDate();
            calendarPage.ClickSubmitButton();
            Assert.That(calendarPage.GetSubmittedDate().Contains(selectedDate));
            test.Log(Status.Pass, "Verified date submitted");
        }

    }
}
