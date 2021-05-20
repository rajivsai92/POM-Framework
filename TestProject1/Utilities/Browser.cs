using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestProject1.TestInitiaze;

namespace TestProject1.Utilities
{
    public class Browser : BaseTest
    {
        
        static string browserType = "Chrome";

      

        public  void LaunchBrowser(string URL = "https://ondemand.questionmark.com/home/403160/")
        {
            try
            {
              
                

                if (browserType == "Chrome")
                {
                    KillBrowserProcess("chrome");
                    KillBrowserProcess("chromedriver");
                    var optionsChrome = new ChromeOptions();
                    optionsChrome.AcceptInsecureCertificates = true;
                    optionsChrome.PageLoadStrategy = PageLoadStrategy.Eager;

                    browserRefference = new ChromeDriver(optionsChrome);
                    browserRefference.Manage().Window.Maximize();
                    browserRefference.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                    browserRefference.Manage().Cookies.DeleteAllCookies();
                    browserRefference.Navigate().GoToUrl(URL);
                    browserRefference.WaitTillPageLoads(100);
                  
                    
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while Launching browser <br>Exception : " + ex);
            }
            
        }

        public static void KillBrowserProcess(string name)
        {

            Process[] p1 = Process.GetProcesses();
            foreach (Process p in p1)
            {
                if (p.ProcessName.Contains(name))
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception ex)
                    {

                    }
            }
        }

      
    }

}

