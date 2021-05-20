using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestProject1.Utilities;
using TestProject1.TestInitiaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Reports
{
    public class Report : BaseTest
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
        public static string reportPath = CommonFunctions.GetProjectPathOfFolder("TestReports");
        public static string SubFolderName;


        /// <summary>
        ///  Initialize the Reports  method
        /// </summary>
        public static void InitializeReports()
        {
            //Prepare ExtentReport

            SubFolderName = "AutomationResults" + DateTime.Today.ToString("ddMMyyyy") + "_" + DateTime.Now.ToShortTimeString().Replace(':', '_');
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\");
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\" + @"\" + "ScreenShots" + @"\");

            string fileName = reportPath + @"\" + SubFolderName + @"\" + "AutomationResult" + "_" + DateTime.Now.ToString("ddMMyyyy_hh-mm-ss") + ".html";

            htmlReporter = new ExtentHtmlReporter(fileName);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Regression";
            htmlReporter.Config.ReportName = "";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        /// <summary>s
        /// Test Instance 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static ExtentTest[] TestInstances(int number)
        {
            ExtentTest[] extentTestInstanaces = new ExtentTest[number];
            return extentTestInstanaces;
        }
        public static void Fail(ExtentTest[] test, Exception exception)
        {
            foreach (ExtentTest t in test)
            {
                if (!HashList.Contains(t.GetHashCode()))
                {
                    Log(string.Format("Test Case Failed with exception {0} ", exception.Message), Status.Fail, t);
                }
            }
            Assert.Fail(exception.Message);

        }


        /// <summary>
        /// Used to log results into extent reports along with screen shots
        /// </summary>
        /// <param name="stepInfo">Loggin information</param>
        /// <param name="status">Step result</param>
        /// <param name="testInstancesList">No.of related tests</param>
        public static void Log(string stepInfo, Status status, params ExtentTest[] testInstancesList)
        {

            foreach (ExtentTest test in testInstancesList)
            {
                //Record every step with out ScreenShot s
                // test.Log(status, stepInfo);

                //Takes ScreenShots for every step                        
                test.Log(status, stepInfo, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShots.CaptureWebElements()).Build());

                //// Takes ScreenShots for failed steps
                //    if (status.Equals(Status.Fail))  
                //    test.Log(status, stepInfo, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshots.CaptureDesktop()).Build());
                //else
                //    test.Log(status, stepInfo);
            }
        }






    }
}

