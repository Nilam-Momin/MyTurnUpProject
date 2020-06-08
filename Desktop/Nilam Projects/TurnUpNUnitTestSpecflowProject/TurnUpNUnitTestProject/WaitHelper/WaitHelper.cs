using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
// dotseleniumextras

namespace TurnUpNUnitTestProject.Helpers
{
    public class WaitHelper
    {
        public static void ForElement(By by, IWebDriver driver, double time)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

    }
}




