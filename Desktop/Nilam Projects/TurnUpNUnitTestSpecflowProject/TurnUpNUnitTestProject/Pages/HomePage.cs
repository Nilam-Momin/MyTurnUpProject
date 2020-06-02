using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TurnUpNUnitTestProject
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal void ClickAdministration()
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Text, Is.EqualTo("Administration"));
            }
            catch (Exception message)
            {
                Console.WriteLine(message.ToString());
                Assert.Fail();
            }
            //find Administration tab and click
            IWebElement AdministrationBtn = driver.FindElement(By.ClassName("dropdown"));
            AdministrationBtn.Click();
        }

        internal void ClickTimeMaterial()
        {
            //find Time and Material option and click
            IWebElement TimeandMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeandMaterial.Click();
        }
    }
}