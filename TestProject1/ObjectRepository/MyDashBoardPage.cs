using OpenQA.Selenium;
using System;
using TestProject1.Utilities;
using TestProject1.TestInitiaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.ObjectRepository
{
    public class MyDashBoardPage :BaseTest
    {
        #region Locators
        private string TopNavigationLinks = "Xpath>//div[@id='nav']//li/a[text()='{0}']";
        private string TopNavigationSublinks = "Xpath>//ul[@class='dropdown-menu']/li/a[text()='{0}']";

        #endregion



        #region Methods

        public void SelectTopNavigationLinks(string LinkName, string SubLinkName=null)
        {

            try
            {
                browserRefference.FindElement(string.Format(TopNavigationLinks, LinkName), 30).Click();
                if (SubLinkName != null)
                    browserRefference.FindElement(string.Format(TopNavigationSublinks, SubLinkName), 30).Click();
            }

            catch(Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("MyDashBoardPage", "ClickTopNavigationLinks", ex));
            }


        }

        #endregion

    }
}
