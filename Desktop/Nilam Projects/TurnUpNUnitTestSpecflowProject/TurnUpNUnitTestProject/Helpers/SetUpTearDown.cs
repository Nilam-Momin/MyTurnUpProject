using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurnUpNUnitTestProject
{
   public class SetUpTearDown: DriverClass
    {
        [OneTimeSetUp]
        public void OpenBrowser()
        {
            //create chrome drive instance
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Login instance
            var loginpage = new Login();
            loginpage.enterLoginDetail(driver);
        }

        [OneTimeTearDown]
        public void AfterTestFixture()
        {
            driver.Quit();
        }

    }
}
