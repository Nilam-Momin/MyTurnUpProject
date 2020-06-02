using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TurnUpNUnitTestProject.HookUp
{
    [Binding]
    public class TimeAndMaterialSteps
    {
        IWebDriver driver;

        [Given(@"I have logged in to TurnUp portal")]
        public void GivenIHaveLoggedInToTurnUpPortal()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();           
            //Login instance
            Login loginpage = new Login(driver);
            loginpage.enterLoginDetail();
        }
        
        [Given(@"I have navigated to time and material page")]
        public void GivenIHaveNavigatedToTimeAndMaterialPage()
        {
            //HomePage instance
            HomePage homePage = new HomePage(driver);
            homePage.ClickAdministration();
            homePage.ClickTimeMaterial();

            
        }

        [When(@"I create new Time and material item using(.*) and (.*)")]
        public void WhenICreateNewTimeAndMaterialItemUsingAnd(string p0, string p1)
        {
            Thread.Sleep(3000);
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            timeMaterialPage.ClickCreateNew();
            timeMaterialPage.CreateNewRecord(p0, p1);
        }

        [Then(@"I can see the newly created item using(.*) and (.*)")]
        public void ThenICanSeeTheNewlyCreatedItemUsingAnd(string p0, string p1)
        {
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);

            timeMaterialPage.ValidateNewRecord(p0, p1);
            //close browser
            driver.Quit();
        }

        [When(@"I edit an existing Time and material item using(.*) and (.*)")]
        public void WhenIEditAnExistingTimeAndMaterialItemUsingAnd(string p0, string p1)
        {
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            Thread.Sleep(1500);
            timeMaterialPage.EditRecord(p0, p1);
        }

        [Then(@"I can see the edited item using(.*) and (.*)")]
        public void ThenICanSeeTheEditedItemUsingAnd(string p0, string p1)
        {
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            timeMaterialPage.ValidateEditRecord(p0, p1);
        }

       
        [When(@"I have navigated to time and material page")]
        public void WhenIHaveNavigatedToTimeAndMaterialPage()
        {
            //HomePage instance
            HomePage homePage = new HomePage(driver);
            homePage.ClickAdministration();
            homePage.ClickTimeMaterial();
        }

        [Then(@"I can delete an existing Time and material item")]
        public void ThenICanDeleteAnExistingTimeAndMaterialItem()
        {
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage(driver);
            Thread.Sleep(1500);
            timeMaterialPage.DeleteRecord();
        }

    }
}
