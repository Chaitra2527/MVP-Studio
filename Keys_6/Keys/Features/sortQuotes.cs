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
using System.Collections;
namespace Keys.Features
{
    public class sortQuotes
    {
        public sortQuotes()
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

        [FindsBy(How = How.XPath, Using = ".//*[@id='viewQuotesArea']/div[2]/div[2]/div/div/select")]
        public IWebElement sortQuotesLinq { get; set; }

        internal void sortCompanyAsc()
        {
            Driver.wait(2);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Quotes for test automation");
            searchClick.Click();
            Driver.wait(3);
            newQuotesLinq.Click();

            //select sort quote
            var sortquote1 = new SelectElement(sortQuotesLinq);
            sortquote1.SelectByText("Company (A-Z)");

            List<String> companyName = new List<string>();
            IReadOnlyList<IWebElement> comname = Driver.driver.FindElements(By.XPath(".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[1]/div/div[2]/div[2]/div[2]/span"));
            foreach (IWebElement cell in comname)
            {
                companyName.Add(cell.Text);

            }

            List<String> companyNameSorted = new List<string>(companyName);
            companyNameSorted.Sort();
            if (companyName.SequenceEqual(companyNameSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quotes sorted according to Company");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quotes not sorted according to Company");
            }

        }

        internal void sortCompanyDesc()
        {
            Driver.wait(2);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Quotes for test automation");
            searchClick.Click();
            Driver.wait(3);
            newQuotesLinq.Click();

            //select sort quote
            var sortquote1 = new SelectElement(sortQuotesLinq);
            sortquote1.SelectByText("Company (Z-A)");

            List<String> companyName1 = new List<string>();
            IReadOnlyList<IWebElement> comnamedesc = Driver.driver.FindElements(By.XPath(".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[1]/div/div[2]/div[2]/div[2]/span"));
            foreach (IWebElement cell in comnamedesc)
            {
                companyName1.Add(cell.Text);

            }

            List<String> companyNameSortedDesc = new List<string>(companyName1);
            companyNameSortedDesc.Sort();
            companyNameSortedDesc.Reverse();
            if (companyName1.SequenceEqual(companyNameSortedDesc))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quotes sorted according to Company Descending");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quotes not sorted according to Company Descending");
            }


        }

        internal void sortLowestAmount()
        {
            Driver.wait(2);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Quotes for test automation");
            searchClick.Click();
            Driver.wait(3);
            newQuotesLinq.Click();

            //select sort quote
            var sortquote1 = new SelectElement(sortQuotesLinq);
            sortquote1.SelectByText("Lowest Amount");

            List<String> lowestAmount = new List<string>();
            IReadOnlyList<IWebElement> lowest = Driver.driver.FindElements(By.XPath(".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[1]/div/div[2]/div[3]/div[2]/span"));
            foreach (IWebElement cell in lowest)
            {
                lowestAmount.Add(cell.Text);

            }

            List<String> lowestAmountSorted = new List<string>(lowestAmount);
            lowestAmountSorted.Sort();
            //lowestAmountSorted.Reverse();
            if (lowestAmount.SequenceEqual(lowestAmountSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quotes sorted according to Lowest amount");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quotes not sorted according to Lowest Amount");
            }


        }

        internal void sortHighestAmount()
        {
            Driver.wait(2);
            ownersLinq.Click();
            jobQuotesLinq.Click();
            searchField.SendKeys("Quotes for test automation");
            searchClick.Click();
            Driver.wait(3);
            newQuotesLinq.Click();

            //select sort quote
            var sortquote1 = new SelectElement(sortQuotesLinq);
            sortquote1.SelectByText("Higest Amount");

            List<String> highestAmount = new List<string>();
            IReadOnlyList<IWebElement> highest = Driver.driver.FindElements(By.XPath(".//*[@id='viewQuotesArea']/div[4]/div[2]/div/div/div[1]/div/div[2]/div[3]/div[2]/span"));
            foreach (IWebElement cell in highest)
            {
                highestAmount.Add(cell.Text);

            }

            List<String> highestAmountSorted = new List<string>(highestAmount);
            highestAmountSorted.Sort();
            highestAmountSorted.Reverse();
            if (highestAmount.SequenceEqual(highestAmountSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Quotes sorted according to Highest amount");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Quotes not sorted according to Highest Amount");
            }


        }
    }
}
