using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using TurnUpNUnitTestProject.Helpers;

namespace TurnUpNUnitTestProject
{
    internal class TimeMaterialPage : DriverClass
    {
        
        internal void ClickCreateNew(IWebDriver driver)
        {
            //check if we are on time and material page
            Assert.That(driver.Title, Is.EqualTo("Index - Dispatching System"));

            //check if the create new button has text 'create new'
            Assert.That(driver.FindElement(By.XPath("//*[@id='container']/p/a")).Text, Is.EqualTo("Create New"));
                
               //find Create New Button and click
             IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();

        }


        internal void CreateNewRecord(IWebDriver driver,string code, string Description)
        {
            try
            {
                //check if new page opened to create new
                Assert.That((driver.Url).ToString, Is.EqualTo("http://horse-dev.azurewebsites.net/TimeMaterial/Create"));
            }
            catch(Exception message)
            {
                Console.WriteLine(message);
                Assert.Fail();
            }
 
            //find code textbox and write code

            IWebElement CodeTextBox = driver.FindElement(By.Id("Code"));
            CodeTextBox.SendKeys(code);

            //find Description textbox and write description

            IWebElement DescriptionTextbox = driver.FindElement(By.Id("Description"));
            DescriptionTextbox.SendKeys(Description);

            //find Price textbox and write price
            IWebElement Price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            Price.SendKeys("10.00");

            //find and click save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);
        }

        internal void DeleteRecord(IWebDriver driver)
        {
            Thread.Sleep(1000);

            //Check if the button text is Delete
            Assert.AreEqual("Delete", driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Text);
           
            //click delete button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            
            //Switch to Delete pop up
            IAlert popup = driver.SwitchTo().Alert();

            //cofirm delete
            popup.Accept();

        }

        internal void EditRecord(IWebDriver driver ,string code, string Description)
        {
            
            WaitHelper.ForElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"), driver, (1.5));

            //check the edit button has 'edit' text
            Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Text, Is.EqualTo("Edit"));

             //select and click 1st row edit button
             driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();
            
            Thread.Sleep(1000);

            //check if the edit page is opened
            try
            {
                
                Assert.That(driver.Title, Is.EqualTo("Edit - Dispatching System"));
            }catch(Exception message)
            {
                Console.WriteLine(message);
                Assert.Fail();
            }

            IWebElement testcode = driver.FindElement(By.Id("Code"));
            testcode.Clear();
            testcode.SendKeys(code);

            //find Description textbox and write description
            IWebElement testDescription = driver.FindElement(By.Id("Description"));
            testDescription.Clear();
            testDescription.SendKeys(Description);

            ///new WebDriverWait(driver, TimeSpan.FromSeconds(1500)).Until(ElementIsVisible(driver.FindElement(By.XPath("//input[contains(@class,'k-formatted-value k-input')]"))));

            //find Price textbox and write price
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(1500);
            IWebElement Price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            Price.Click();
            js.ExecuteScript("return document.getElementById('Price').value='99'");

            //find and click save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);
        }



        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };

        }

        //this method validates newly added row starting from last page and then going to previous pages
        internal void ValidateNewRecord(IWebDriver driver,string code, string Description)
        {
            //go to last page
            GoToLastPage(driver);
            // Wait for 1.5 second
            WaitHelper.ForElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"), driver, (1.5));
            
            //total number of pages
            var totalPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/ul/li[2]/span")).Text;
            int LastPageNumber = Convert.ToInt32(totalPage);
            try
            {
                //loop from last page to first until find the new record
                for (int i = LastPageNumber; i>=1; i--)
                {
                    if(validateRows(driver,code, Description))
                    {
                        Assert.Pass("Newly created row has found");
                        break;
                    }
                    if (validateRows(driver, code, Description).Equals(false) && i > 1)
                    {
                        GoToPreviousPage(driver);
                    }
                    if (validateRows(driver, code, Description).Equals(false) && i == 1)
                    {
                        Assert.Fail("newly created row not found");
                    }
                }
                        
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }
        }

        //This method validates the edited record
        internal void ValidateEditRecord(IWebDriver driver, string code, string Description)
        {
            // Wait for 1 second
            Thread.Sleep(1000);

            var testcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[1]")).Text;

            var testDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[3]")).Text;

            Assert.AreEqual(code, testcode, "Code doesn't match with actual code");
            Assert.AreEqual(Description, testDescription, "Description doesn't match with actual description");

        }

        //This method validates rows of a page
        internal bool validateRows(IWebDriver driver, string code, string Description)
        {
            bool IsMatched = false;
                    
            //loop through the rows
            for (int i = 1; i <= 10; i++)
            {
                //catch exception if total number of rows are less than 10 on the last page
                
                //Assign value of each column data of the selected row to the string variables
                 string FirstColumnData = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                 string ThirdColumnData = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[3]")).Text;
                 
                 //validate if the row data matches with the input
                 if (FirstColumnData == code && ThirdColumnData == Description)
                 {
                     //if all conditions matches then print confirmation message and stop the loop
                     //Assert.Pass("Code and Description of newly created row matched");
                    IsMatched = true;
                     break;
                 }                        
            }

            return IsMatched;
        }

        internal void GoToLastPage(IWebDriver driver)
        {

            try
            {
                //Find go to last page button and click it
                IWebElement lastPageBtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                Thread.Sleep(1500);
                lastPageBtn.Click();
                //check last page button is disabled
                
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
                Assert.Fail();
            }

        }

        internal void GoToPreviousPage(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//span[contains(.,'Go to the previous page')]")).Click();
            Thread.Sleep(1000);
        }

        internal void GoToNextPage(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//span[contains(.,'Go to the next page')]")).Click();
            Thread.Sleep(1000);
        }

    }

}   


