using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;

namespace TestTask.Helpers
{
    public static class WebDriverExtensions
    {
        public static IWebElement? WaitForElementToBeVisible(this IWebDriver driver, Func<IWebDriver, IWebElement?> elementGetter, uint timeoutInMilliseconds = 25000)
        {
            Stopwatch sw = new();
            sw.Start();
            IWebElement? element = null;
            while (sw.ElapsedMilliseconds < timeoutInMilliseconds)
            {
                try
                {
                    element = elementGetter(driver);
                    if (element != null && element.Displayed)
                        break;
                    if (element != null && element.Displayed == false)
                        element = null;
                }
                catch
                {
                    // ignored
                }
            }

            sw.Stop();
            return element;
        }

    }
}
