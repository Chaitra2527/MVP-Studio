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
//using PrjTest;

namespace Keys.Features
{
    public class SortByForJobs
    {
        public SortByForJobs()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        public IWebElement ownersLinq1 { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[4]/a")]
        public IWebElement jobQuotesLinq1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[2]/div[2]/div/div/select")]
        public IWebElement sortByLinq { get; set; }



        internal void LowestQuoteSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Lowest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Lowest New Quotes");

            //verify sorting is correct
            List<String> displayQuotes = new List<string>();
            // grab the cells that contain the display names you want to verify are sorted
            IReadOnlyList<IWebElement> quotes = Driver.driver.FindElements(By.XPath(".//*[@id='stickynote']/p/a/span"));
            // loop through the cells and assign the display names into the ArrayList
            foreach (IWebElement cell in quotes)
            {
                displayQuotes.Add(cell.Text);

            }

            // make a copy of the displayNames array and sort ascending
            List<String> displayNamesSorted = new List<string>(displayQuotes);
            displayNamesSorted.Sort();
            if(displayQuotes.SequenceEqual(displayNamesSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to lowest quotes");
            }
            
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to lowest quotes");
            }

        }

        internal void highestQuoteSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Highest New Quotes");

            //verify sorting is correct
            List<String> highestQuotes = new List<string>();
            // grab the cells that contain the display names you want to verify are sorted
            IReadOnlyList<IWebElement> quotes = Driver.driver.FindElements(By.XPath(".//*[@id='stickynote']/p/a/span"));
            // loop through the cells and assign the display names into the ArrayList
            foreach (IWebElement cell in quotes)
            {
                highestQuotes.Add(cell.Text);

            }
            foreach (string item in highestQuotes)
            {
                Console.WriteLine(item.ToString());
            }

            // make a copy of the displayNames array and sort descending
            List<String> highestQuotesSorted = new List<string>(highestQuotes);
            highestQuotesSorted.Sort();
            highestQuotesSorted.Reverse();
            if (highestQuotes.SequenceEqual(highestQuotesSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to highest Quotes");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to highest Quotes");
            }

        }

        internal void titleAscSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Title");

            //verify sorting is correct
            List<String> displayTitle = new List<string>();
            // grab the cells that contain the display names you want to verify are sorted
            IReadOnlyList<IWebElement> titleasc = Driver.driver.FindElements(By.TagName("h4"));
            // loop through the cells and assign the display names into the ArrayList
            foreach (IWebElement cell in titleasc)
            {
                displayTitle.Add(cell.Text);
            }
            foreach (string item in displayTitle)
            {
                Console.WriteLine(item.ToString());
            }

            // make a copy of the displayNames array and sort descending
            List<String> titleAscSorted = new List<string>(displayTitle);
            titleAscSorted.Sort();
            foreach (string item1 in titleAscSorted)
            {
                Console.WriteLine(item1.ToString());
            }
            //Console.WriteLine(displayTitle.SequenceEqual(titleAscSorted));
            if (displayTitle.SequenceEqual(titleAscSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Title");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to Title");
            }

        }

        internal void titleDescSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Title(Desc)");

            //verify sorting is correct
            List<String> titleHeader = new List<string>();
            // grab the cells that contain the display names you want to verify are sorted
            IReadOnlyList<IWebElement> titleDesc = Driver.driver.FindElements(By.TagName("h4"));
            // loop through the cells and assign the display names into the ArrayList
            foreach (IWebElement cell in titleDesc)
            {
                titleHeader.Add(cell.Text);
            }
            foreach (string item in titleHeader)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            // make a copy of the displayNames array and sort descending

            List<String> titleDescSorted = new List<string>(titleHeader);
            titleDescSorted.Sort();
            titleDescSorted.Reverse();

            foreach (string item1 in titleDescSorted)
            {

                Console.WriteLine(item1.ToString());
            }
            //Console.WriteLine(titleHeader.SequenceEqual(titleDescSorted));
            if (titleHeader.SequenceEqual(titleDescSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Title descending");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to Title descending");
            }

        }

        internal void lowestBudgetSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Lowest Budget");

            //verify sorting is correct
            List<String> budgetValue = new List<String>();
            IReadOnlyList<IWebElement> budgetAsc = Driver.driver.FindElements(By.XPath(".//*[@class='col-md-12']/div/div[1]/div[2]/div[2]/div[1]/div[2]/span"));

            foreach (IWebElement cell in budgetAsc)
            {
                budgetValue.Add(cell.Text);

            }
            foreach (string item in budgetValue)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            // make a copy of the displayNames array and sort descending

            IEnumerable<string> budgetAscSorted = new List<string>(budgetValue);
            budgetAscSorted = budgetAscSorted.OrderBy(x => x.Length);
            foreach (string item1 in budgetAscSorted)
            {
                Console.WriteLine(item1.ToString());
            }
            //Console.WriteLine(budgetValue.SequenceEqual(budgetAscSorted));
            if (budgetValue.SequenceEqual(budgetAscSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Lowest Budget");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to Lowest Budget");
            }

        }

        internal void highestBudgetSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Highest Budget");

            //verify sorting is correct
            List<String> budgetValue1 = new List<String>();
            IReadOnlyList<IWebElement> budgetDesc = Driver.driver.FindElements(By.XPath(".//*[@class='col-md-12']/div/div[1]/div[2]/div[2]/div[1]/div[2]/span"));

            foreach (IWebElement cell in budgetDesc)
            {
                budgetValue1.Add(cell.Text);

            }
            foreach (string item in budgetValue1)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            // make a copy of the displayNames array and sort descending

            IEnumerable<string> budgetDescSorted = new List<string>(budgetValue1);
            budgetDescSorted = budgetDescSorted.OrderByDescending(x => x.Length);
            foreach (string item1 in budgetDescSorted)
            {
                Console.WriteLine(item1.ToString());
            }
            // Console.WriteLine(budgetValue1.SequenceEqual(budgetDescSorted));
            if (budgetValue1.SequenceEqual(budgetDescSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Highest Budget");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to Highest Budget");
            }

        }

        internal void earliestListingSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Earliest Listing");

            //verify sorting is correct
            List<String> earliest = new List<String>();
            IReadOnlyList<IWebElement> earliestListing = Driver.driver.FindElements(By.XPath(".//*[@class='col-md-12']/div/div[1]/div[2]/div[2]/div[3]/div[2]/span"));

            foreach (IWebElement cell in earliestListing)
            {
                earliest.Add(cell.Text);

            }
            foreach (string item in earliest)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            // make a copy of the displayNames array and sort descending

            List<String> earliestListingSorted = new List<string>(earliest);
            earliestListingSorted.Sort();
            foreach (string item1 in earliestListingSorted)
            {
                Console.WriteLine(item1.ToString());
            }
            //Console.WriteLine(earliest.SequenceEqual(earliestListingSorted));
            if (earliest.SequenceEqual(earliestListingSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Earliest Listing");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Jobs is not sorted according to Earliest Listing");
            }

        }

        internal void latestListingSteps()
        {
            Driver.wait(2);
            ownersLinq1.Click();
            jobQuotesLinq1.Click();
            //sort by Highest new quotes
            var selectSortby1 = new SelectElement(sortByLinq);
            selectSortby1.SelectByText("Latest Listing");
            Driver.wait(2);

            //verify sorting is correct
            List<String> latest = new List<String>();
            IReadOnlyList<IWebElement> latestListing = Driver.driver.FindElements(By.XPath(".//*[@class='col-md-12']/div/div[1]/div[2]/div[2]/div[3]/div[2]/span"));

            foreach (IWebElement cell in latestListing)
            {
                latest.Add(cell.Text);

            }
            foreach (string item in latest)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            // make a copy of the displayNames array and sort descending

            IEnumerable<string> latestListingSorted = new List<string>(latest);
            latestListingSorted = latestListingSorted.OrderBy(x => x.Length);
            foreach (string item1 in latestListingSorted)
            {
                Console.WriteLine(item1.ToString());
            }
            //Console.WriteLine(latest.SequenceEqual(latestListingSorted));
            if (latest.SequenceEqual(latestListingSorted))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs sorted according to Latest Listing");
            }

            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Jobs is not sorted according to Latest Listing");
            }

        }




    }


}
