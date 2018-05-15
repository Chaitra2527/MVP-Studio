using Keys.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys.Features;
using Keys.Global;

namespace Keys.Test
{
    class Sprint_1
    {
        [TestFixture]
        [Category("Sprint_5")]
        class Sprint_1_Administration : Base
        {

            // Add a new user in the Account Managment
            //[Test]
            //public void Register_CreateNewUser()
            //{
            //    // creates a toggle for the given test, adds all log events under it    
            //    test = extent.StartTest("Register New Customer");
            //    Register obj = new Register();
            //    obj.register();

            //}

          
            //[Test]
            //public void NavigationPage()
            //{
            //    //Login loginobj1 = new Login();
            //    test = extent.StartTest("Register New Customer");
            //    Navigation navigationobj1 = new Navigation();
            //    navigationobj1.NavigationSteps();
                
            //}

            //[Test]
            //public void AddNewProperty()
            //{
            //    //Login loginobj2 = new Login
            //    test = extent.StartTest("Adding New Property");
                
            //    AddProperty addpropertyobj = new AddProperty();
            //    addpropertyobj.AddPropertySteps();

               
            //}

            //[Test]
            //public void AddTenantProperty()
            //{
            //    //Login loginobj2 = new Login
            //    test = extent.StartTest("Adding the tenant");
                

            //    AddTenant addtenantobj = new AddTenant();
            //    addtenantobj.AddTenantSteps();
            //}

            //[Test]
            //public void ListARental()
            //{
            //    //Login loginobj2 = new Login
            //    test = extent.StartTest("Adding the Rental Application");
                

            //    ListARental listrentalobj = new ListARental();
            //    listrentalobj.ListRentalSteps();
            //}

            [Test]
            public void AddMarketJob()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Adding the New job");


                AddJob jobobj = new AddJob();
                jobobj.AddJobSteps();
            }

            [Test]
            public void searchingJob()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Searching the Job");
                
                searchingJob searchobj = new searchingJob();
                searchobj.SearchingSteps();
            }

            [Test]
            public void SortByForJobs()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Sorting the Job");

                SortByForJobs sortbyobj = new SortByForJobs();
                sortbyobj.highestQuoteSteps();
                sortbyobj.LowestQuoteSteps();
                sortbyobj.titleAscSteps();
                sortbyobj.titleDescSteps();
                sortbyobj.highestBudgetSteps();
                sortbyobj.lowestBudgetSteps();
                sortbyobj.earliestListingSteps();
                sortbyobj.latestListingSteps();
            }

            [Test]
            public void searchQuotes()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Searching Quotes for the Job");

                searchQuotes searchquoteobj = new searchQuotes();
                searchquoteobj.seacchingQuotesSteps();
            }

            [Test]
            public void sortQuotes()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Sorting Quotes for the Job");

                sortQuotes sortQuotesObj = new sortQuotes();
                sortQuotesObj.sortCompanyAsc();
                sortQuotesObj.sortCompanyDesc();
                sortQuotesObj.sortLowestAmount();
                sortQuotesObj.sortHighestAmount();
            }

            [Test]
            public void newQuotesFeature()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Actions under New Quotes");

                NewQuotesFeatures newquotesobj = new NewQuotesFeatures();
                newquotesobj.detailsSteps();
                newquotesobj.acceptQuoteSteps();
                newquotesobj.editSteps();
                newquotesobj.deleteSteps();
            }

            [Test]
            public void SSMyJobs()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Test cases under Service Supplier Dashboard");

                MyJobs myjobsobj = new MyJobs();
                myjobsobj.myQuotesGraphStatus();
                myjobsobj.myJobsGraphStatus();
                myjobsobj.editJobSteps();
                myjobsobj.detailsSteps();

            }

            [Test]
            public void TenantInspection()
            {
                //Login loginobj2 = new Login
                test = extent.StartTest("Test cases under Tenant Inspection");

                TenantInspec tenInspecobj = new TenantInspec();
                tenInspecobj.InspectionDetailsSteps();

            }
        }


    }
}
