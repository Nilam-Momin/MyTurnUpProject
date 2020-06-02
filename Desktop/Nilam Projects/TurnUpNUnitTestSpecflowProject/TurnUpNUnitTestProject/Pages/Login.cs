using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TurnUpNUnitTestProject
{
    internal class Login
    {
        private IWebDriver driver;

        //find username element
        IWebElement username => driver.FindElement(By.Id("UserName"));

        //find password element and enter the password
        IWebElement password => driver.FindElement(By.Id("Password"));

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal void enterLoginDetail()

        {
            //open website
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Check if website is opening
            Assert.That(driver.FindElement(By.XPath("//*[@id='loginForm']/form/h2")).Text, Is
                .EqualTo("Log In"), "Login Page is not opened");

            //write username
            username.SendKeys("hari");
            Assert.That(username.GetProperty("value"), Is.EqualTo("hari"));

            //write password
            password.SendKeys("123123");
            

            //find login button and click it
            IWebElement Loginbtn = driver.FindElement(By.XPath("//input[@type='submit']"));
            Loginbtn.Click();
        }

    }
}