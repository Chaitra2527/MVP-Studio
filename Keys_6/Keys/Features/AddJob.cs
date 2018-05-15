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

namespace Keys.Features
{
    public class AddJob
    {
        public AddJob()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[1]/a")]
        public IWebElement dashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[2]/div[1]/div/div[2]/div[2]/div/div/div[3]/a/div[2]")]
        public IWebElement addMarketJob { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='NewJobForm']/div[3]/form/fieldset/div[1]/div/div/select")]
        public IWebElement selectProperty { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='NewJobForm']/div[3]/form/fieldset/div[2]/div/div/input")]
        public IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='NewJobForm']/div[3]/form/fieldset/div[3]/div/div/textarea")]
        public IWebElement jobDescription { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='NewJobForm']/div[3]/form/fieldset/div[4]/div/div/input")]
        public IWebElement maximumBudget { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='NewJobForm']/div[3]/form/fieldset/div[7]/div/button[1]")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        public IWebElement owners { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[4]/a")]
        public IWebElement jobQuotes { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchJob { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement clickSearch { get; set; }

        String jobtitle="Add New Job";

        public void AddJobSteps()
        {
            try
            {
                dashboard.Click();
                Driver.wait(2);
                addMarketJob.Click();
                System.Threading.Thread.Sleep(2000);

                //verfiy the add new job is opening
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(jobtitle));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "We are in Add New Job Page");
                }
                catch(Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Expected page is not displayed");
                    throw;
                }

                //selecting value from dropdown
                System.Threading.Thread.Sleep(2000);
                var selectValue = new SelectElement(selectProperty);
                selectValue.SelectByValue("4738");
                
                title.SendKeys("Testing the job");
                jobDescription.SendKeys("Adding the job by using automation script");
                maximumBudget.SendKeys("245000");

                //verify if submit button is enabled
                if (submit.Enabled)
                {
                    submit.Click();
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Form not filled correctly");
                }

                //verify if job is created
                owners.Click();
                jobQuotes.Click();
                Driver.wait(3);
                searchJob.SendKeys("Testing the job");
                clickSearch.Click();
                System.Threading.Thread.Sleep(2000);
                String jobDisplayed = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[2]/h4")).Text;
                if (jobDisplayed == "Testing the job")
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Job added Successfully");

                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Job is not added");
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
