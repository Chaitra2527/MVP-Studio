using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace Keys.Features
{
    public class ListARental
    {
        public ListARental()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[1]/div[1]/div[1]/div[2]/a[2]")]
        public IWebElement listARental { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[2]/form/fieldset/div[1]/div/div/select")]
        public IWebElement selectProperty { get; set; }

        //[FindsBy(How = How.]
        ////public IWebElement selectProperty { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[2]/form/fieldset/div[2]/div[1]/div[1]/div/div/input")]
        public IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[2]/div[2]/div/textarea")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[2]/div[1]/div[2]/div/div/input")]
        public IWebElement movingCost { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[3]/div[1]/div/input")]
        public IWebElement targetRent { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[4]/div[1]/div/input")]
        public IWebElement availableDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[4]/div[1]/div/div/ul/li[1]/div/div[1]/table/tbody/tr[2]/td[5]")]
        public IWebElement selectDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[5]/div[1]/div/input")]
        public IWebElement occupantsCount { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='add-new-property']/fieldset/div[8]/div/button[1]")]
        public IWebElement save { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        public IWebElement owners { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[2]/a")]
        public IWebElement rentalApplication { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchTitle { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement clickSearch { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        //public IWebElement clickSearch { get; set; }




        String title1 = "List A Rental";
       // String rentalTitle = "adding a tenant";

        public void ListRentalSteps()
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                listARental.Click();

                //verifying we are in List a rental page
                try
                {
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(title1));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "We are in List A Rental Page");
                }
                catch (Exception)
                {
                    throw;
                    
                }
            

                selectProperty.SendKeys("99 Queen Street, Auckland, Auckland, 1010");
                title.SendKeys("Testing Renatl");
                description.SendKeys("testing list as rental");
                movingCost.SendKeys("1234");
                targetRent.SendKeys("1478");
                String currentDate = DateTime.Now.ToString("DD/MM/yyyy");
                availableDate.SendKeys(currentDate);
                occupantsCount.SendKeys("2");
                save.Click();
                IAlert alert = Driver.driver.SwitchTo().Alert();
                alert.Accept();


                //verify if rental application is added
                owners.Click();
                rentalApplication.Click();
                searchTitle.SendKeys("Testing Renatl");
                clickSearch.Click();

                String rentalDisplayed = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div[3]/div[1]/div/div[1]/div[2]/div[2]/h4")).Text;                                                                         
                if (rentalDisplayed == "Testing Renatl")
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "rental is added successfully");

                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "rental is not added ");
                }
                    
                }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }











    }

}
