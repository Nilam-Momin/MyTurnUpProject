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
            Login loginpage = new Login();
            loginpage.enterLoginDetail(driver);
        }
        
        [Given(@"I have navigated to time and material page")]
        public void GivenIHaveNavigatedToTimeAndMaterialPage()
        {
            //HomePage instance
            HomePage homePage = new HomePage();
            homePage.ClickAdministration(driver);
            homePage.ClickTimeMaterial(driver);

            
        }

        [When(@"I create new Time and material item using(.*) and (.*)")]
        public void WhenICreateNewTimeAndMaterialItemUsingAnd(string p0, string p1)
        {
            Thread.Sleep(3000);
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.ClickCreateNew(driver);
            timeMaterialPage.CreateNewRecord(driver, p0, p1);
        }

        [Then(@"I can see the newly created item using(.*) and (.*)")]
        public void ThenICanSeeTheNewlyCreatedItemUsingAnd(string p0, string p1)
        {
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();

            timeMaterialPage.ValidateNewRecord(driver, p0, p1);
            //close browser
            driver.Quit();
        }

        [When(@"I edit an existing Time and material item using(.*) and (.*)")]
        public void WhenIEditAnExistingTimeAndMaterialItemUsingAnd(string p0, string p1)
        {
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            Thread.Sleep(1500);
            timeMaterialPage.EditRecord(driver, p0, p1);
        }

        [Then(@"I can see the edited item using(.*) and (.*)")]
        public void ThenICanSeeTheEditedItemUsingAnd(string p0, string p1)
        {
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.ValidateEditRecord(driver, p0, p1);
        }

       
        [When(@"I have navigated to time and material page")]
        public void WhenIHaveNavigatedToTimeAndMaterialPage()
        {
            //HomePage instance
            HomePage homePage = new HomePage();
            homePage.ClickAdministration(driver);
            homePage.ClickTimeMaterial(driver);
        }

        [Then(@"I can delete an existing Time and material item")]
        public void ThenICanDeleteAnExistingTimeAndMaterialItem()
        {
            //TimeNMaterialPage instance
            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            Thread.Sleep(1500);
            timeMaterialPage.DeleteRecord(driver);
        }

    }
}
