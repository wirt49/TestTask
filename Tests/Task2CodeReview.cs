using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Tests
{
    public class Task2CodeReview
    {
        [SetUp]
        // Please add SetUp method there.
        // [SetUp] annotation marks a method that should be called before each test method.
        // For example you can add your 21-23 lines of code there. You should not do it in the every test.
        private void Login()// test methods should be public, not private
                            // also seems like you forgot to add [Test] annotation before this test method.
                            // In my opinion it is good practice to add [Test, Description("")]
                            // before the test and describe what you gonna test. 
                            // Tests with the describtion are easier to understand for others QEs.
        {
            string srtDriverPath = "lalal";//
            IWebDriver driver = new ChromeDriver();//
            driver.Manage().Window.Maximize();//
            driver.Navigate().GoToUrl("https://qa.sorted.com/newtrack");// we should initialize driver before the test
                                                                        // for example in SetUp method.
            
            Thread.Sleep(1000);// using Thread.Sleep() to wait for a page load complete is not the best solution.
                               // we should use selenium Implicit/Explicit waiters instead.
            
            IWebElement user = driver.FindElement(By.Id("//form[@id='loginForm']/input[1]"));// it looks you used like XPath locator here,
                                                                                             // not by ID
            IWebElement password = driver.FindElement(By.XPath("//form[@id='loginForm']/input[2]"));
            
            IWebElement login = driver.find_element_by_xpath("submit"));// Here IWebDriver does not contain a definition for method you used.
                                                                        // use driver.FindElement instead. Or add an Extension if 
                                                                        // you wonna use your own implementation of this method.
            
            username.SendKeys(usernameValue); // what is the 'username'? You previously created a local variable 'user'.
                                              // Did you mean to use this one variable here?
                                              // Also 'usernameValue' is not decleared yet.
            
            password.SendKeys(passwordValue); // Same here. 'passwordValue' is not decleared.
            
            string usernameValue = "john_smith@sorted.com";// You should decleare this variable before using.
                                                           // Please move it into beginning of the test
                                                           // However, better solution will be to add a DataProvider class and
                                                           // store the data you use for test there.
                                                           // Then you can use [TestCaseSource()] test fixture and add arguments to the test
                                                           // Smth like public void Login(string username, string password)
            
            string passwordValue = "123456";// Same as above here.

            string actualUrl = "awdalkwndlnsa";// Seems like you should change this variable name to 'expectedUrl'
                                               // and use driver.Url property to get the URL.

            string expectedUrl = driver.Url; // Vice versa here.  
            Assert.Equals(actualUrl, expectedUrl); // Please add an assertaion message for the case if this Assert fails.
        }

        [TearDown]
        public void TearDown()
        {
            driver.quit();// As you inizialized a 'driver' directly in the Login test. You cannot access it here. 
                          // Also a method to quit the driver and close every associater window is driver.Quit()
                          // so use it with upper case please.
        }

        // Also I would reccomend to implement a PageObject pattern.
        // It helps reduce code duplication and improves test case maintenance.
        // In Page Object Model, consider each web page of an application as a class file.
        // So you will not need to change tests there is a change in UI.
    }
}
