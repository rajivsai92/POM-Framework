using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utilities
{
    public static class JavaSE
    {

        public static void WaitTillPageLoads(this IWebDriver _browser, int timeoutInSeconds)
        {


            try
            {
                timeoutInSeconds = timeoutInSeconds * 1000;
                WebDriverWait wait = new WebDriverWait(Browser.browserRefference, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until((x) =>
                {
                    return ((IJavaScriptExecutor)Browser.browserRefference).ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)");
                });
            }
            catch (Exception e)
            
            {
                throw new Exception("Exception oocurs while page is loading" + e.Message);
            
            }

            
        }
    }
}
