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
    public class AddProperty
    {
        public AddProperty()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[1]/div[1]/div[1]/div[2]/a[1]")]
        public IWebElement addNewProperty { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[1]/div[1]/div/input")]
        public IWebElement propertyName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='autocomplete']")]
        public IWebElement searchAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[1]")]
        public IWebElement selectSearch { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='street_number']")]
        public IWebElement number { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[2]/div[2]/div/textarea")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[3]/div[1]/div/input")]
        public IWebElement yearBuilt { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[3]/div[2]/div/input")]
        public IWebElement targetRent { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[5]/div[1]/div/input")]
        public IWebElement bedrooms { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[5]/div[2]/div/input")]
        public IWebElement bathrooms { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[6]/div[1]/div/input")]
        public IWebElement carParks { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[9]/div/button[1]")]
        public IWebElement next1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[1]/div[1]/div/input")]
        public IWebElement purchasePrice { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[1]/div[2]/div/input")]
        public IWebElement mortgage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[2]/div[1]/div/input")]
        public IWebElement homeValue { get; set; }
       
        [FindsBy(How = How.XPath, Using = " .//*[@id='financeSection']/div[9]/div/button[3]")]
        public IWebElement next2 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[1]/div/input")]
        public IWebElement tenantEmail { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[2]/div[1]/div/input")]
        public IWebElement tenantFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[2]/div[2]/div/input")]
        public IWebElement tenantLastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[3]/div[1]/div/input")]
        public IWebElement startDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[3]/div[1]/div/div/ul/li[1]/div/div[1]/table/tbody/tr[2]/td[4]")]
        public IWebElement selectDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[4]/div[1]/input")]
        public IWebElement rentAmount { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[4]/div[2]/div/select")]
        public IWebElement paymentFrequency { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[5]/div[1]/div/input")]
        public IWebElement paymentStartDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[5]/div[1]/div/div/ul/li[1]/div/div[1]/table/tbody/tr[2]/td[4]")]
        public IWebElement selectPaymentDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[5]/div[2]/div/select")]
        public IWebElement paymentDueDay { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[8]/div/button[2]")]
        public IWebElement save { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchProperty { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement searchClick { get; set; }

        String title = "Add New Property";

        public void AddPropertySteps()
        {
            try
            {

                System.Threading.Thread.Sleep(2000);
                    addNewProperty.Click();

                  //verifying we are in add new property page
                    Assert.IsTrue(Driver.driver.FindElement(By.TagName("body")).Text.Contains(title));
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "We are in Add New Property Page");

                    propertyName.SendKeys("Property C120");
                    searchAddress.SendKeys("Unit");
                    System.Threading.Thread.Sleep(2000);
                    selectSearch.Click();
                    number.SendKeys("12");
                    description.SendKeys("automation testing for add property");
                    yearBuilt.SendKeys("1999");
                    targetRent.SendKeys("1474");
                    bedrooms.SendKeys("3");
                    bathrooms.SendKeys("2");
                    carParks.SendKeys("2");
                    //navigate to finance page
                    next1.Click();
                    System.Threading.Thread.Sleep(2000);
                    purchasePrice.SendKeys("123000");
                    mortgage.SendKeys("125000");
                    homeValue.SendKeys("120000");
                    //navigate to tenant page
                    next2.Click();
                    tenantEmail.SendKeys("tenant@gmail.com");
                    tenantFirstName.SendKeys("chai");
                    tenantLastName.SendKeys("auto");
                    startDate.Click();
                    selectDate.Click();
                    rentAmount.SendKeys("1474");
                    paymentFrequency.Click();
                    paymentStartDate.Click();
                    selectPaymentDate.Click();
                    paymentDueDay.Click();
                    save.Click();

                //verifying whether property is created
                    System.Threading.Thread.Sleep(3000);
                    searchProperty.SendKeys("Property C120");
                    searchClick.Click();
                    System.Threading.Thread.Sleep(2000);
                    String propertydisplayed = Driver.driver.FindElement(By.XPath(".//*[@id='mainPage']/div[4]/div[1]/div/div/div[2]/div[2]/div[1]/div[1]/div[1]")).Text;
                    if (propertydisplayed == "Property C120")
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property added Successfully");

                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property is not added");
                    }

            }
                catch (Exception e)
                {
                    Console.WriteLine( e);
                }

              
        }
    }
}
