using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Keys.Features
{
    public class MyJobs
    {
        //initializing the web elements
        public MyJobs()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        //Finding the Dashboard Linq
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[1]/a")]
        public IWebElement dashboard { get; set; }

        //Finding the My Jobs Linq in dashboard
        [FindsBy(How = How.XPath, Using = ".//*[@id='my-jobs-button']")]
        public IWebElement myJobsLinq { get; set; }

        //Finding the Edit button for the job
        [FindsBy(How = How.XPath, Using = ".//*[@id='mainPage']/div[3]/div[2]/div/div/div/div[2]/button[2]")]
        public IWebElement editJob { get; set; }

        //Finding the percentage done field
        [FindsBy(How = How.XPath, Using = ".//*[@id='jobFormModal']/div/form/fieldset/div[2]/select")]
        public IWebElement percentage { get; set; }

        //Finding the Note Description field in edit job page
        [FindsBy(How = How.XPath, Using = ".//*[@id='jobFormModal']/div/form/fieldset/div[4]/textarea")]
        public IWebElement noteDescp { get; set; }

        //Finding the save button in edit job page
        [FindsBy(How = How.XPath, Using = ".//*[@id='saveButton']")]
        public IWebElement btnSave { get; set; }

        //Finding the Details button in the My Job page
        [FindsBy(How = How.XPath, Using = ".//*[@id='mainPage']/div[3]/div[1]/div/div/div/div[2]/button[1]")]
        public IWebElement detailsLinq { get; set; }

        //Finding the Note descp text in the Detail Job page
        [FindsBy(How = How.XPath, Using = ".//*[@id='Progress']/div/div/div[1]/div[1]/div[7]/div[2]/span[1]/span")]
        public IWebElement noteVerify { get; set; }

        //Storing the status of the My Quotes graph
        String[] myQuotesStatus = { "New", "Pending", "Accepted", "Rejected" };
        //Storing the status of My JOb graph to verify
        String[] myJobsStatus = { "New", "Pending", "Accepted", "Rejected" };
        //verify the edit job title
        String editJobTitle = "Edit Job";
        //Verifying the Details job title
        String detailsJobTitle = "Job Details";


        // Checking the status of tickets in My Quotes Graph in Service Suppler Dashboard
        internal void myQuotesGraphStatus()
        {
            //Cliking on dashboard linq
            dashboard.Click();
            try
            {
                // getting the status in My Quotes graph to a List
                List<String> quotesStatusFull = new List<String>();
                //List<String> status1 = new List<String>();
                IReadOnlyList<IWebElement> statusValue = Driver.driver.FindElements(By.XPath(".//*[@id='my-quotes-legend']/ul/li"));
                foreach (IWebElement cell in statusValue)
                {
                    //Trimming the numbers from the status
                    String celltext = Regex.Replace(cell.Text, "[^a-zA-Z]", "");
                    quotesStatusFull.Add(celltext);
                }

                //displaying the list of status
                foreach (string item in quotesStatusFull)
                {
                    Console.WriteLine(item);
                }
                //verifying the fetched status equals displayed status
                if (quotesStatusFull.SequenceEqual(myQuotesStatus))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All status displayed under My Quotes Graph in Dashboard");
                }

                //screen shot of My Quotes Graph
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "My Quotes Graph");

            }
            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Status not displaying correctly");
                throw;
            }
        }


        // Checking the status of tickets in My JObs Graph in Service Suppler Dashboard
        internal void myJobsGraphStatus()
        {
            // clicking on dashbaord
            dashboard.Click();
            try
            {
                //get the status from My JObs graph
                List<String> jobsStatusFull = new List<String>();
                //List<String> status1 = new List<String>();
                IReadOnlyList<IWebElement> statusValue = Driver.driver.FindElements(By.XPath(".//*[@id='my-jobs-legend']/ul/li"));
                foreach (IWebElement cell in statusValue)
                {
                    //trim the numbers from the status in the list
                    String celltext = Regex.Replace(cell.Text, "[^a-zA-Z]", "");
                    jobsStatusFull.Add(celltext);
                }

                //display the list of sttaus in my jobs graph
                foreach (string item in jobsStatusFull)
                {
                    Console.WriteLine(item);
                }
                //verify if the status display equals in My JOb status 
                if (jobsStatusFull.Equals(myJobsStatus))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All status displayed under My Jobs Graph in Dashboard");
                }

                //screen shot for My JObs graph
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "My Jobs Graph");

            }
            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Status not displaying correctly");
                throw;
            }
        }


        // Edit Job under My Jobs Page
        internal void editJobSteps()
        {
            //populate data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "MyJob");
            
            try
            {
                //click on dashboard linq
                dashboard.Click();
                //click on My jobs linq
                myJobsLinq.Click();
                //Click on edit button fro the job
                editJob.Click();

                //verify we are in Edit Job Page
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(editJobTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Page is navigated to Edit JOb page");

                //screen shot for edit job page
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edit Job Page");

                //select value from percentage done dropdown
                var selectValue = new SelectElement(percentage);
                selectValue.SelectByValue("60");

                //send text to note description field
                noteDescp.Clear();
                noteDescp.SendKeys(ExcelLib.ReadData(2, "Note"));
                //verify if save button is disabled
                if (btnSave.Enabled)
                {
                    btnSave.Click();
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Job page is not filled correctly");
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Details of the job and verify editing in the job s succesful.
        internal void detailsSteps()
        {
            //populate data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "MyJob");
            try
            {
                //click on dashboard linq
                dashboard.Click();
                //click on My JObs linq
                myJobsLinq.Click();
                //click on Details button for the job
                detailsLinq.Click();

                //verify if details job page is open
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(detailsJobTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Page is navigated to Details Job page");

                //screen shot for Details JOb page
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Details Page");

                //verify if edit has done succesfully comparing note text
                String noteValue = noteVerify.Text;
                if (noteValue.Equals(noteDescp))
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Job has edited succesfully");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Job has not edited correctly");
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
