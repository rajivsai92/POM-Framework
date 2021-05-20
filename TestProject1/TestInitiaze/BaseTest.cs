using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject1.ObjectRepository;
using TestProject1.Reports;
using TestProject1.Utilities;

namespace TestProject1.TestInitiaze
{

    [TestClass]
    public class BaseTest
    {
        public static List<int> HashList;
        //public static POM objRepo = new POM();
        public static IWebDriver browserRefference = null;


        [AssemblyInitialize]
        public static void Reports(TestContext context)
        {
            Report.InitializeReports();

        }
        
        [AssemblyCleanup]
        public static void Flush()
        {
            //Closing the Logger file
            Report.extent.Flush();
        }

        [TestInitialize]
        public void TestInitializeMethod()
        {

            Thread.Sleep(4000);
            HashList = new List<int>();



        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Thread.Sleep(2000);
            browserRefference.Quit();

        }
    }
}


