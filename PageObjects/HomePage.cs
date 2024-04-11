using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Helpers;

namespace TestTask.PageObjects
{
    public class HomePage: BasePage
    {
        private readonly By _homePageHeader = By.CssSelector("div[class*='home_header Container']");
        public HomePage(IWebDriver driver): base(driver) { }

        public bool IsLoaded
        {
            get
            {
                IWebElement? header = Driver.WaitForElementToBeVisible(drv => drv.FindElement(_homePageHeader));
                if (header == null)
                    return false;
                return header != null;
            }
        }

        public string GetHomePageUrl
        {
            get
            {
                return Driver.Url;
            }
        }
    }
}
