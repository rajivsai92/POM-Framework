using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.TestInitiaze;
using TestProject1.Utilities;

namespace TestProject1.Reports
{
    public class ScreenShots : Browser
    {


        /// <summary>
        /// Used to capture web element
        /// </summary>
        /// <returns></returns>
        public static string CaptureWebElements()
        {

            string fileName = null;
            Random rad = new Random();
            string destFolder = Report.reportPath + @"\" + Report.SubFolderName + @"\" + @"\ScreenShots\";
            fileName = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + rad.Next(0, 10000000) + ".png";
            string filePath = Path.Combine(destFolder, fileName);

            Screenshot screenshot = ((ITakesScreenshot)browserRefference).GetScreenshot();

            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            fileName = @"./ScreenShots/" + fileName;
            return fileName;
        }

        /// <summary>
        /// Used to capture desktop
        /// </summary>
        /// <returns></returns>
        //public static string CaptureDesktop(ExtentTest tst)
        //{
        //    string fileName = null;
        //    try

        //    {
        //        Random rad = new Random();

        //        string destFolder = Report.reportPath + @"\" + Report.SubFolderName + @"\" + @"\ScreenShots\";
        //        fileName = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + rad.Next(0, 10000000) + ".png";
        //        string filePath = Path.Combine(destFolder, fileName);

        //        //Creating a new Bitmap object
        //        Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

        //        //Creating a Rectangle object which will 
        //        //capture our Current Screen
        //        Rectangle captureRectangle = Screen.AllScreens[0].Bounds; //Screen.AllScreens[0].Bounds; new Rectangle(new Point(0,0),new Size(1920,1080))



        //        //Creating a New Graphics Object
        //        Graphics captureGraphics = Graphics.FromImage(captureBitmap);


        //        //Copying Image from The Screen
        //        captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

        //        captureBitmap.Save(filePath, ImageFormat.Jpeg);
        //        fileName = @"./ScreenShots/" + fileName;

        //    }

        //    catch (Exception ex)
        //    {
        //        tst.Log(Status.Fail, ex.Message + ex.StackTrace);

        //    }
        //    return fileName;
        //}
    }
}
