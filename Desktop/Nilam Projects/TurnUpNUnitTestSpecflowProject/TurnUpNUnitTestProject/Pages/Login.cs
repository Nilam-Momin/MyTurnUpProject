using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TurnUpNUnitTestProject
{
    internal class Login: DriverClass
    {
        
    
        internal void enterLoginDetail(IWebDriver driver)

        {
            //open website
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Check if website is opening
            Assert.That(driver.FindElement(By.XPath("//*[@id='loginForm']/form/h2")).Text, Is
                .EqualTo("Log In"), "Login Page is not opened");

            //find username element
            IWebElement username = driver.FindElement(By.Id("UserName"));
            //write username
            username.SendKeys("hari");

            //find password element and enter the password
            IWebElement password = driver.FindElement(By.Id("Password"));
            //write password
            password.SendKeys("123123");


            //find login button and click it
            IWebElement Loginbtn = driver.FindElement(By.XPath("//input[@type='submit']"));
            Loginbtn.Click();
        }

    }
}