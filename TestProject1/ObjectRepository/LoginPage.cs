using OpenQA.Selenium;
using System;
using TestProject1.Utilities;
using TestProject1.TestInitiaze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.ObjectRepository
{
    public class LoginPage : BaseTest
    {

        #region Locators

        private string UserNameEdit = "Xpath>//input[@name='name']";
        private string PasswordEdit = "Xpath>//input[@name='pass']";
        private string LoginBtn = "Xpath>//button[@id='edit-submit']";
        private string ValidationMsg = "Xpath>//div[contains(@class,'alert alert-block alert-')]";
        private string RequestNewPasswordLink = "Xpath>//li//a[text()='Request new password']";
        private string EnterMailIEdit = "Xpath>//label[text()='Username or e-mail address ']/following-sibling::input";
        private string EmailNewPasswordBtn = "Xpath>//button[@value='E-mail new password']";



        #endregion


        #region Methods
        public void Login(string UserName, string Password)
        {

            try
            {
                browserRefference.FindElement(UserNameEdit, 30).SendKeys(UserName);
                browserRefference.FindElement(PasswordEdit, 30).SendKeys(Password);
                browserRefference.FindElement(LoginBtn, 5).Click();
                browserRefference.WaitTillPageLoads(60);

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("LoginPage", "Login", ex));

            }



        }

        public void VerifyValidationMsg(string msg)
        {
            try
            {

                string txt = browserRefference.FindElement(ValidationMsg, 30).Text;
                Assert.IsTrue(txt.Contains(msg), msg + "not found");

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("LoginPage", "VerifyValidationMsg", ex));
            }

        }

        public void RequestNewPassword(string mailID)
        {
            try
            {

                browserRefference.FindElement(RequestNewPasswordLink, 30).Click();
                browserRefference.FindElement(EnterMailIEdit,20).SendKeys(mailID);

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("LoginPage", "VerifyValidationMsg", ex));
            }

        }

        public void ClickEmailNewPasswordBtn()
        {

            try
            {
                browserRefference.FindElement(EmailNewPasswordBtn, 30).Click();

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("LoginPage", "ClickEmailNewPasswordBtn", ex));
            }

        }

        #endregion 
    }

}