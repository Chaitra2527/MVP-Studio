using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Keys.Features
{
    public class AddTenant
    {
        public AddTenant()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchProperty { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement searchClick { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/section/div[1]/div[1]/div[4]/div[1]/div/div/div[2]/div[2]/div[2]/div/a[1]")]
        public IWebElement addTenant { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[2]/div[1]/div/input")]
        public IWebElement tenantEmail { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[2]/div[2]/div/select")]
        public IWebElement isMainTenant { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[3]/div[1]/div/input")]
        public IWebElement tenantFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[3]/div[2]/div/input")]
        public IWebElement tenantLastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[4]/div[1]/div/input")]
        public IWebElement rentStartDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[4]/div[1]/div/div/ul/li[1]/div/div[1]/table/tbody/tr[2]/td[5]")]
        public IWebElement selectRentDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[5]/div[1]/div/input")]
        public IWebElement rentAmount { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[5]/div[2]/div/select")]
        public IWebElement paymentFrequency { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[6]/div[1]/div/input")]
        public IWebElement paymentStartDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[6]/div[1]/div/div/ul/li[1]/div/div[1]/table/tbody/tr[2]/td[5]")]
        public IWebElement selectPaymentDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[6]/div[2]/div/select")]
        public IWebElement paymentDueDate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div[7]/div/div/input[1]")]
        public IWebElement next1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[2]/button[2]")]
        public IWebElement next2 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[10]/div/button[2]")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='mainPage']/div[4]/div[1]/div/div/div[3]/div/a")]
        public IWebElement manageTenant { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='searchId']")]
        public IWebElement searchProperty1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='search-wrap']/form/div/div/button")]
        public IWebElement searchClick1 { get; set; }



        public void AddTenantSteps()
        {
            try
            {

                searchProperty.SendKeys("Property C120");
                searchClick.Click();
                System.Threading.Thread.Sleep(2000);

                //verifying whether property name exists
                String propertydisplayed = Driver.driver.FindElement(By.XPath(".//*[@id='mainPage']/div[4]/div[1]/div/div/div[2]/div[2]/div[1]/div[1]/div[1]")).Text;
                if (propertydisplayed == "Property C120")
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property Displayed");


                    addTenant.Click();
                    tenantEmail.SendKeys("automate120@gmail.com");
                    isMainTenant.Click();
                    System.Threading.Thread.Sleep(1000);

                        bool fnameenabled = tenantFirstName.Enabled;
                        if (fnameenabled)
                        {
                            tenantFirstName.SendKeys("autotenant");
                            tenantLastName.SendKeys("testing");
                        }
                                                                       
                                        
                    String rentDate = DateTime.Now.ToString("DD/MM/yyyy");
                    rentStartDate.SendKeys(rentDate);
                    //selectRentDate.Click();
                    rentAmount.SendKeys("1458");
                    paymentFrequency.Click();
                    paymentStartDate.SendKeys(rentDate + 1);
                    //selectPaymentDate.Click();
                    paymentDueDate.Click();

                    // verify if next button is enabled.
                    bool isenabled = next1.Enabled;
                    if (isenabled)
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Form filled correctly");
                        next1.Click();
                        next2.Click();
                        submit.Click();

                        //Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Tenant added Successfully");
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Form not filled correctly");
                    }

                    //verify if tenant added successfully
                    System.Threading.Thread.Sleep(3000);
                    searchProperty1.SendKeys("Property C120");
                    searchClick1.Click();
                    System.Threading.Thread.Sleep(2000);
                    manageTenant.Click();
                    IWebElement bodyTag = Driver.driver.FindElement(By.TagName("body"));
                    if (bodyTag.Text.Contains("automate120@gmail.com") )
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Tenant added succesfully");
                    }

                }

                
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property not created");
                }

            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }


    }
}

