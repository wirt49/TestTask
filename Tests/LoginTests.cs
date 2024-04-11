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
    public class LoginTests: TestBase
    {
        LoginPage loginPage = new LoginPage(Driver);

        [Test, Description("This test validates user is able to sign in with valid credentials")]
        [TestCaseSource(typeof(ReadData), nameof(ReadData.ValidLoginTestData))]
        public void VerifyUserIsAbleToLogInWithValidCred(string username, string password, string expectedURL)
        {
            Assume.That(loginPage.IsLoaded, Is.True, "Login page is not loaded");
            loginPage.EnterEmailField(username);
            loginPage.EnterPasswordField(password);
            loginPage.ClickSubmitButton();
            HomePage homePage = new HomePage(Driver);
            Assume.That(homePage.IsLoaded, Is.True, "Home page is not loaded");
            string actualURL = homePage.GetHomePageUrl;
            Assert.IsTrue(actualURL == expectedURL, $"Urls don't match! Expected url was {expectedURL}, but was {actualURL}");
        }

    }
}
