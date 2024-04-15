using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.PageObjects;

namespace TestTask.Tests
{
    [TestFixture]
    [TestOf("Login")]
    public class LoginTestsTask1: TestBase
    {
        LoginPage loginPage = new LoginPage(Driver);

        [Test, Description("This test validates that if not logged user is trying to open any page of the tracking site not being registered," +
            "login page is shown")]
        public void VerifyLoginPageIsShownWhenUserIsNotLoggedIn()
        {
            HomePage homePage = new HomePage(Driver);
            Assume.That(homePage.IsLoaded, Is.True, "Home page was not loaded");
            string actualUrl = homePage.GetCurrentPageUrl;
            Assert.IsTrue(!actualUrl.EndsWith("/logged"), "User has been already logged in successfully!");
            Assert.IsTrue(loginPage.IsLoaded, "Login page was not opened!");
        }

        [Test, Description("This test validates user is able to sign in with valid already registered credentials")]
        [TestCaseSource(typeof(ReadData), nameof(ReadData.ValidLoginTestData))]
        public void VerifyUserIsAbleToLogInWithValidCred(string username, string password, string expectedURL)
        {
            Assume.That(loginPage.IsLoaded, Is.True, "Login page was not loaded");
            loginPage.EnterEmailField(username);
            loginPage.EnterPasswordField(password);
            loginPage.ClickSubmitButton();
            HomePage homePage = new HomePage(Driver);
            Assume.That(homePage.IsLoaded, Is.True, "Home page was not loaded");
            string actualURL = homePage.GetCurrentPageUrl;
            Assert.IsTrue(actualURL == expectedURL, $"Urls don't match! Expected url was {expectedURL}, but was {actualURL}");
        }

    }
}
