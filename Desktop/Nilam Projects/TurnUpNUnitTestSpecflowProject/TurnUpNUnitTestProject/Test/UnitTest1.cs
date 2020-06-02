using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

namespace TurnUpNUnitTestProject
{
 [TestFixture] 
    public class Tests 
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void BeforeTestFixture()
        {
            //create chrome drive instance
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Login instance
            Login loginpage = new Login(driver);
            loginpage.enterLoginDetail();
        }

        [OneTimeTearDown]
        public void AfterTestFixture()
        {
            driver.Quit();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            /*
            //create chrome drive instance
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            //Login instance
            Login loginpage = new Login(driver);
            loginpage.enterLoginDetail();
            */
            
        }

        [TearDown]
        public void AfterEachTest()
        {
            //close browser
            //driver.Quit();
        }

        [Test, Category("NUnit")]
        [TestCaseSource(typeof(MyDataClass), "TestCases")]
        
        public void CreateAndValidate(string code, string Description)
        {
            //HomePage instance
            HomePage homePage = new HomePage(driver);
            
            homePage.ClickAdministration();
            homePage.ClickTimeMaterial();

            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            timeMaterialPage.ClickCreateNew();
            timeMaterialPage.CreateNewRecord(code, Description);
            timeMaterialPage.ValidateNewRecord(code, Description);
            
        }

        [Test, Category("NUnit")]
        [TestCaseSource(typeof(MyDataClass), "TestCases")]
        public void EditAndValidate(string code, string Description)
        {
            //HomePage instance
            HomePage homePage = new HomePage(driver);
            homePage.ClickAdministration();
            homePage.ClickTimeMaterial();
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            timeMaterialPage.EditRecord(code, Description);
            timeMaterialPage.ValidateEditRecord(code, Description);
         
        }

        [Test, Category("NUnit")]
        public void DeleteARecord()
        {
                     
            //HomePage instance
            HomePage homePage = new HomePage(driver);
            homePage.ClickAdministration();
            homePage.ClickTimeMaterial();

            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            timeMaterialPage.DeleteRecord();
        }

    }
}