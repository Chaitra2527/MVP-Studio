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
    public class TenantInspec
    {
        public TenantInspec()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]")]
        public IWebElement tenantLinq { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/a[5]")]
        public IWebElement inspectionLinq { get; set; }

        //[FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/a[5]")]
        //public IWebElement inspectionLinq { get; set; }

        internal void InspectionDetailsSteps()
        {
            tenantLinq.Click();
            inspectionLinq.Click();
            List<String> inspectionDetails = new List<string>();
            // grab the cells that contain the display names you want to verify are sorted
            IReadOnlyList<IWebElement> details = Driver.driver.FindElements(By.XPath(".//*[@id='mainPage']/div[3]/div[1]/div[2]/div/div[2]/div/div[1]/div[1]/strong"));
            // loop through the cells and assign the display names into the ArrayList
            foreach (IWebElement cell in details)
            {
                inspectionDetails.Add(cell.Text);

            }

            String[] detailsCompare = new string[] { "Status:", "Landlord Name:", "Landlord Phone:", "Inspection Message:", "Percentage Done:", "Listed on:", "Due Date:" };
            if (inspectionDetails.Equals(detailsCompare))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "All details displayed for inspection");
            }
            foreach (string item in inspectionDetails)

                Console.WriteLine(item.ToString());
        }

    }

}

