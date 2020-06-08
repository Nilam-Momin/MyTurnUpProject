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
    public class UnitTests : SetUpTearDown
    {
      
     
        [Test, Category("NUnit")]
        [TestCaseSource(typeof(MyDataClass), "TestCases")]
        
        public void CreateAndValidate(string code, string Description)
        {
            //HomePage instance
            HomePage homePage = new HomePage();
            
            homePage.ClickAdministration(driver);
            homePage.ClickTimeMaterial(driver);

            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.ClickCreateNew(driver);
            timeMaterialPage.CreateNewRecord(driver, code, Description);
            timeMaterialPage.ValidateNewRecord(driver, code, Description);
            
        }

        [Test, Category("NUnit")]
        [TestCaseSource(typeof(MyDataClass), "TestCases")]
        public void EditAndValidate(string code, string Description)
        {
            //HomePage instance
            HomePage homePage = new HomePage();
            homePage.ClickAdministration(driver);
            homePage.ClickTimeMaterial(driver);
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.EditRecord(driver, code, Description);
            timeMaterialPage.ValidateEditRecord(driver, code, Description);
         
        }

        [Test, Category("NUnit")]
        public void DeleteARecord()
        {
                     
            //HomePage instance
            HomePage homePage = new HomePage();
            homePage.ClickAdministration(driver);
            homePage.ClickTimeMaterial(driver);

            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.DeleteRecord(driver);
        }

    }
}