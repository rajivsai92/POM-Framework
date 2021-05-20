using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.TestInitiaze;
using TestProject1.Utilities;

namespace TestProject1.ObjectRepository.People
{
    public class UsersPage : BaseTest

    {

        #region Locators

        private string ImportPraticipantsBtn = "Xpath>//i[@class='fa fa-upload']";
        private string BrowseBtn = "Xpath>//div[@class='input-group']//span[text()='Browse...']/input";
        private string ImportBtn = "Xpath>//button[text()='Import']";
        private string ValidationMsg = "Xpath>//div[contains(@class,'alert alert-block alert-')]";

        #endregion

        #region Methods


        public void WaitUntillUsersPageLoaded()
        {
            try
            {
                browserRefference.WaitUntillTitleContains("User", 30);

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("UsersPage", "WaitUntillUsersPageLoaded", ex));


            }



        }

       public void ClickImportParticipantsButton()
        {

            try
            {
                browserRefference.FindElement(ImportPraticipantsBtn, 30).Click();
                browserRefference.WaitUntillTitleContains("Import Participants",30);
            }
            catch(Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("UsersPage", "ClickImportParticipantsButton", ex));

            }


        }


        public void UploadParticipantsFromComputer(String FileName)
        {

            try
            {

                string path = CommonFunctions.GetProjectPathOfFolder("TestData")+@"\" + FileName;

                browserRefference.FindElement(BrowseBtn, 20).SendKeys(path);
                browserRefference.FindElement(ImportBtn,20).Click();

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("UsersPage", "UplaodParticipantsFromComputer", ex));

            }

        }

        public void VerifyValidationMsg(string msg)
        {
            try
            {

                string txt = browserRefference.FindElement(ValidationMsg, 60).Text;
                Assert.IsTrue(txt.Contains(msg), msg + "not found");

            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHandler.ReturnExceptionMessage("UsersPage", "VerifyValidationMsg", ex));
            }

        }

        #endregion

    }
}

