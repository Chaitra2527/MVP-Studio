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
    public class searchQuotes
    {
        public searchQuotes()
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

        [FindsBy(How = How.XPath, Using = ".//*[@id='stickynote']/p/a")]
        public IWebElement newQuotesLinq { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        //public IWebElement quotesSearch { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        //public IWebElement quotesSearchLinq { get; set; }

        
        String providerName = "Vincent";
        String companyName = "Vincent Service";
        String amount = "123000";

        internal void seacchingQuotesSteps()
        {
            try
            {
                //searching through title
                Driver.wait(2);
                ownersLinq.Click();
                jobQuotesLinq.Click();
                searchField.SendKeys("Quotes for test automation");
                searchClick.Click();
                Driver.wait(1);
                newQuotesLinq.Click();
                //quotesSearch.SendKeys("vincent");
                //quotesSearchLinq.Click();
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(providerName));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Provider Name Exists");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Provider Name doesnot exists");
                }
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(companyName));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Company Name Exists");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Company Name doesnot exists");
                }
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(amount));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Amount Exists");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Amount doesnot exists");
                }


            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
