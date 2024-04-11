using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace TestTask.PageObjects
{
    public class BasePage
    {
        protected BasePage(IWebDriver driver) 
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
    }
}
