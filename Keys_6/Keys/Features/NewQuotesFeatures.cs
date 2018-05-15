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
    public class NewQuotesFeatures
    {
        public NewQuotesFeatures()
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

        [FindsBy(How = How.XPath, Using = ".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[2]/div/button[1]")]
        public IWebElement detailsLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[2]/div/button[2]")]
        public IWebElement acceptLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='notevalue']")]
        public IWebElement acceptDesc { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[3]/div/div/div/div[2]/div[3]/div/div/button[1]")]
        public IWebElement submitAccept { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[3]/div[1]/div/div[2]/div[1]")]
        public IWebElement editJobLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='jobDescription']")]
        public IWebElement editDesc { get; set; }

        [FindsBy(How = How.XPath, Using = " .//*[@id='marketJobEdit']/form/fieldset/div/div/div[3]/input")]
        public IWebElement editBudget { get; set; }
             
        [FindsBy(How = How.XPath, Using = ".//*[@id='saveButton']")]
        public IWebElement editSaveLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[3]/div/div/div[1]/div[1]/i")]
        public IWebElement deleteLinq { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='IWillDo']")]
        public IWebElement iwilldoitMyself { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='addJobDIY']")]
        public IWebElement deleteSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='jobDeleteModal']/div/div/div/div/div/div[1]/div[2]/div[1]/div/div[1]/textarea")]
        public IWebElement deleteDesc { get; set; }


        String detailsTitle = Driver.driver.Title;
        String acceptTitle = Driver.driver.Title;
        String editJobTitle = Driver.driver.Title;
        String newbudget = "20.00";

        internal void detailsSteps()
        {
            Driver.wait(1);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Quotes for test automation");
            searchClick.Click();
            Driver.wait(1);
            newQuotesLinq.Click();
            detailsLinq.Click();
            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(detailsTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quote details displayed");
            }
            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quote details is not displayed");
            }


        }

        internal void acceptQuoteSteps()
        {
            Driver.wait(1);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Accept Tenant Request");
            searchClick.Click();
            Driver.wait(1);
            newQuotesLinq.Click();
            acceptLinq.Click();
            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(acceptTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Accept Quote page is displayed");
                acceptDesc.SendKeys("testing accept for the quote");
                submitAccept.Click();
                //IWebElement result = Driver.driver.FindElement(By.TagName("Script"));
                //String htmlCode = (String)((IJavaScriptExecutor)Driver.driver).ExecuteScript("return arguments[0].innerHTML;", result);
                //Console.WriteLine(htmlCode);
                //String successmsg = success.GetAttribute("innerHTML");

            }

            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Accept Quote page is not displayed");
            }


        }

        internal void editSteps()
        {
            Driver.wait(1);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Test Job Request for automation");
            searchClick.Click();
            Driver.wait(1);
            editJobLinq.Click();

            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(editJobTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit Job page is displayed");
                editDesc.Clear();
                editDesc.SendKeys("description edited");
                editBudget.Clear();
                editBudget.SendKeys("20.00");
                editSaveLinq.Click();
                Driver.wait(2);
                searchField.Clear();
                searchField.SendKeys("20.00");
                searchClick.Click();
                String editBudgetNo = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div[3]/div/div/div[1]/div[2]/div[2]/div[1]/div[2]/span")).Text;
                if (editBudgetNo == newbudget)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit details is displayed in the Job Page");
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit details is not displayed in the Job Page");
                }

                //IWebElement result = Driver.driver.FindElement(By.TagName("Script"));
                //String htmlCode = (String)((IJavaScriptExecutor)Driver.driver).ExecuteScript("return arguments[0].innerHTML;", result);
                //Console.WriteLine(htmlCode);
                //String successmsg = success.GetAttribute("innerHTML");

            }

            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Job page is not displayed");
            }


        }

        internal void deleteSteps()
        {
            Driver.wait(1);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Test Job Request for automation");
            searchClick.Click();
            Driver.wait(1);
            deleteLinq.Click();

            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(editJobTitle));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit Job page is displayed");
                iwilldoitMyself.Click();
                deleteDesc.SendKeys("deleteing the job by automation");
                deleteSubmit.Click();

                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "job is deleted");
                //IWebElement result = Driver.driver.FindElement(By.TagName("Script"));
                //String htmlCode = (String)((IJavaScriptExecutor)Driver.driver).ExecuteScript("return arguments[0].innerHTML;", result);
                //Console.WriteLine(htmlCode);
                //String successmsg = success.GetAttribute("innerHTML");

            }

            catch (Exception)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "job is not deleted");
            }


        }
    }
}
