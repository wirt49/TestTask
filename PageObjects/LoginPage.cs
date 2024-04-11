using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using TestTask.Helpers;

namespace TestTask.PageObjects
{
    public class LoginPage: BasePage
    {
        private readonly By _loginHeader = By.CssSelector("div[class*='modal__holder']");
        private readonly By _companyLogoHeader = By.CssSelector("a[class='header__logo']");

        private readonly By _emailFieldSelector = By.CssSelector("input[id='email']");
        private readonly By _passwordSelector = By.CssSelector("input[id='password']");
        private readonly By _submitButtonSelector = By.CssSelector("button[class*='SubmitButton']");
        private IWebElement? emailField => Driver.WaitForElementToBeVisible(drv => drv.FindElement((_emailFieldSelector)));
        private IWebElement? passwordField => Driver.WaitForElementToBeVisible(drv => drv.FindElement((_passwordSelector)));
        private IWebElement? submitBotton => Driver.WaitForElementToBeVisible(drv => drv.FindElement((_submitButtonSelector)));

        public LoginPage(IWebDriver driver) : base(driver) 
        {
        }

        public bool IsLoaded
        {
            get
            {
                IWebElement? header = Driver.WaitForElementToBeVisible(drv => drv.FindElement(_companyLogoHeader));
                if (header == null)
                    return false;
                IWebElement? loginHeader = Driver.WaitForElementToBeVisible(drv => drv.FindElement(_loginHeader));
                return loginHeader != null;
            }
        }

        public void EnterEmailField(string email)
        {
            if(emailField != null) 
            {
                emailField.Clear();
                emailField.Click();
                emailField.SendKeys(email); 
            }
        }

        public void EnterPasswordField(string pass)
        {
            if(passwordField != null)
            {
                passwordField.Clear();
                passwordField.Click();
                passwordField.SendKeys(pass);
            }
        }

        public void ClickSubmitButton()
        {
            if(submitBotton != null)
            {
                submitBotton.Click();
            }
        }

        public string GetPageURL
        {
            get
            {
                return Driver.Url;
            }
        }
    }
}
