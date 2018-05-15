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
    public class searchingJob
    {
        public searchingJob()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        public IWebElement ownersLinq { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[4]/a")]
        public IWebElement jobQuotesLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement searchClick { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[2]/h4")]
        public IWebElement jobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[2]/div[2]/div[2]")]
        public IWebElement propertyAddress { get; set; }

        String titlesearch = "Testing the title";
        String serachaddress = "562 Great North Road Grey Lynn Auckland";

        internal void SearchingSteps()
        {
            try
            {


                //searching through title
                Driver.wait(2);
                ownersLinq.Click();
                jobQuotesLinq.Click();
                searchField.SendKeys("Testing the title");
                searchClick.Click();
                Driver.wait(3);
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(titlesearch));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Job Title Exists");
                }
                catch(Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Job Title doesnot exists");
                }

                //search through property address
                Driver.wait(2);
                ownersLinq.Click();
                jobQuotesLinq.Click();
                searchField.SendKeys("562 Great North Road Grey Lynn Auckland");
                searchClick.Click();
                Driver.wait(3);
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(serachaddress));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property Address Exists");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property Address doesnot exists");
                }

                

            }
            catch(Exception)
            {
                throw;
            }
        }


    }
}
