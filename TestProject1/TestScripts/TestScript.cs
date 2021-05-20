using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using TestProject1.ObjectRepository;
using TestProject1.Reports;
using TestProject1.TestInitiaze;
using TestProject1.Utilities;

namespace TestProject1
{
    [TestClass]
    public class TestScript : BaseTest
    {
        #region Tesdata
        
        private string UserName = "TechTestUser";
        private string Password_1 = "Qs8W4T";
        private string Password_2 = "Qs5e8W4T";
        private string UploadFileName = "Participants.csv";
        private string URL = @"https://ondemand.questionmark.com/home/403160/";
        #endregion

        [Description("Verify login and import functionality")]
        [TestProperty("TestcaseID", "1,2")]
        [TestMethod]
        public void TestScript_1_2()
        {

            ExtentTest[] tests = Report.TestInstances(2);

            tests[0] = Report.extent.CreateTest("Verify Request New Password Functionality");
            tests[1] = Report.extent.CreateTest("Verify Import Participants Functionality");


            try
            {



                #region Verify Request New Password Functionality
                POM<Browser>.GetInstance.LaunchBrowser(URL);
                Report.Log("Launched application successfully", Status.Pass, tests);

                POM<LoginPage>.GetInstance.Login(UserName, Password_1);
                Report.Log("Entered Login Credentials", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.VerifyValidationMsg("Sorry, unrecognized username or password.");
                Report.Log("Validation msg - 'Sorry, unrecognized username or password.' is displayed", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.RequestNewPassword("test@gmail.com");
                Report.Log("Navigated to Request New password tab and enter new mail ID", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.ClickEmailNewPasswordBtn();
                Report.Log("Clicked on Email New Password button", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.VerifyValidationMsg("Further instructions have been sent to your e-mail address.");
                Report.Log("Validation msg - 'Further instructions have been sent to your e-mail address.' is displayed", Status.Pass, tests[0]);

                HashList.Add(tests[0].GetHashCode());
                #endregion

                //#region Verify Import Participants Functionality

                //objRepo.LoginPage.Login(UserName, Password_2);
                //Report.Log("Entered Login Credentials", Status.Pass, tests[1]);


                //objRepo.MyDashBoardPage.SelectTopNavigationLinks("People ", "Users");
                //Report.Log("Navigate to People-> Users Page", Status.Pass, tests[1]);


                //objRepo.UsersPage.WaitUntillUsersPageLoaded();
                //Report.Log("User Page is loaded sucessfully", Status.Pass, tests[1]);

                //objRepo.UsersPage.ClickImportParticipantsButton();
                //Report.Log("Clicked on Import participants button", Status.Pass, tests[1]);


                //objRepo.UsersPage.UploadParticipantsFromComputer(UploadFileName);
                //Report.Log("Uploaded file and clicked on Import button", Status.Pass, tests[1]);

                //objRepo.UsersPage.VerifyValidationMsg("Updated 1 user.");
                //Report.Log("Validation msg - 'Updated 1 user.' is displayed", Status.Pass, tests[1]);


                //HashList.Add(tests[1].GetHashCode());

                //#endregion

            }


            catch (Exception ex)
            {
                Report.Fail(tests, ex);
            }
            finally
            {

            }
        }

        [Description("Verify login and import functionality")]
        [TestProperty("TestcaseID", "1,2")]
        [TestMethod]
        public void TestScript_1()
        {

            ExtentTest[] tests = Report.TestInstances(2);

            tests[0] = Report.extent.CreateTest("Verify Request New Password Functionality");
            tests[1] = Report.extent.CreateTest("Verify Import Participants Functionality");


            try
            {



                #region Verify Request New Password Functionality
                POM<Browser>.GetInstance.LaunchBrowser(URL);
                Report.Log("Launched application successfully", Status.Pass, tests);

                POM<LoginPage>.GetInstance.Login(UserName, Password_1);
                Report.Log("Entered Login Credentials", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.VerifyValidationMsg("Sorry, unrecognized username or password.");
                Report.Log("Validation msg - 'Sorry, unrecognized username or password.' is displayed", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.RequestNewPassword("test@gmail.com");
                Report.Log("Navigated to Request New password tab and enter new mail ID", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.ClickEmailNewPasswordBtn();
                Report.Log("Clicked on Email New Password button", Status.Pass, tests[0]);

                POM<LoginPage>.GetInstance.VerifyValidationMsg("Further instructions have been sent to your e-mail address.");
                Report.Log("Validation msg - 'Further instructions have been sent to your e-mail address.' is displayed", Status.Pass, tests[0]);

                HashList.Add(tests[0].GetHashCode());
                #endregion

                //#region Verify Import Participants Functionality

                //objRepo.LoginPage.Login(UserName, Password_2);
                //Report.Log("Entered Login Credentials", Status.Pass, tests[1]);


                //objRepo.MyDashBoardPage.SelectTopNavigationLinks("People ", "Users");
                //Report.Log("Navigate to People-> Users Page", Status.Pass, tests[1]);


                //objRepo.UsersPage.WaitUntillUsersPageLoaded();
                //Report.Log("User Page is loaded sucessfully", Status.Pass, tests[1]);

                //objRepo.UsersPage.ClickImportParticipantsButton();
                //Report.Log("Clicked on Import participants button", Status.Pass, tests[1]);


                //objRepo.UsersPage.UploadParticipantsFromComputer(UploadFileName);
                //Report.Log("Uploaded file and clicked on Import button", Status.Pass, tests[1]);

                //objRepo.UsersPage.VerifyValidationMsg("Updated 1 user.");
                //Report.Log("Validation msg - 'Updated 1 user.' is displayed", Status.Pass, tests[1]);


                //HashList.Add(tests[1].GetHashCode());

                //#endregion

            }


            catch (Exception ex)
            {
                Report.Fail(tests, ex);
            }
            finally
            {

            }
        }
    }

}

