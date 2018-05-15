using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Features;

namespace Keys.Global
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = ".//*[@id='UserName']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@id='sign_in']/div[3]/button[1]")]
        private IWebElement loginButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        //public IWebElement Owners { get; set; }

        //[FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[1]/a")]
        //public IWebElement Properties { get; set; }

        public void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));

            // Sending the username 
            Driver.wait(1);
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));
            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(2, "Password"));
            // Clicking on the login button
            loginButton.Click();
            Driver.driver.Manage().Window.Maximize();

            //Navigation to properties page
            //Owners.Click();
            //Properties.Click();

            //return new Navigation();
        }


    }
}
