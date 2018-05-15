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
    public class Navigation
    {
        public Navigation()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/a")]
        public IWebElement Owners { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/nav/div/ul/li[2]/ul/li[1]/a")]
        public IWebElement Properties { get; set; }

        public ListARental NavigationSteps()
        {
           // Driver.manage().window().maximize();
            Owners.Click();
            Properties.Click();
            return new ListARental();
        }

    }
}
