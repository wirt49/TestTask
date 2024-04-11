using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTask.Tests
{
    public class TestBase
    {
        private readonly string url = "https://qa.sorted";
        private static IWebDriver? _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver(); 
                }

                return _driver;
            }
        }

        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}