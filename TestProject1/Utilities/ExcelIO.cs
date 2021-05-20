using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utilities
{
   public  class ExcelIO
    {

        #region Excel reading via spread sheet 
        public static string[] returnArrayValue(string fileName, string sheetName, string name, string dataType)
        {

            fileName = Path.Combine(CommonFunctions.GetProjectPathOfFolder("TestData").ToString(), fileName);

            string excel_name = null;
            string[] excel_value = null;// = new string[3];
            try
            {
                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    Workbook workbook = spreadSheetDocument.WorkbookPart.Workbook;
                    WorksheetPart worksheetPart = GetWorksheetFromSheetName(workbookPart, sheetName);

                    Worksheet workSheet = worksheetPart.Worksheet;
                    string sheetName1 = workSheet.InnerText;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();

                    foreach (Row row in rows) //this will also include your header row... 
                    {
                        // for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                        //{

                        excel_name = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(0), "string");
                        //if (excel_name.Equals(name))
                        if (excel_name == name)
                        {
                            int count = row.Descendants<Cell>().Count();
                            excel_value = new string[count - 1];
                            for (int i = 1; i < count; i++)
                            {
                                excel_value[i - 1] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i), dataType).TrimStart().TrimEnd();
                            }
                            break;
                        }
                    }

                    // Console.WriteLine("End!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return excel_value;
        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell, string dataType)
        {
            string value = null;
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue != null)
            {

                value = cell.CellValue.InnerText;

                switch (dataType)
                {
                    case "string":

                        try
                        {
                            value = stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                        }
                        catch (Exception e)
                        {

                        }
                        break;
                    case "date":

                        try
                        {
                            value = DateTime.FromOADate(double.Parse(value)).ToShortDateString();
                        }
                        catch (Exception e)
                        {

                        }
                        break;

                    case "boolean":
                        {
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                case "1":
                                    value = "TRUE";
                                    break;
                                default:
                                    Console.WriteLine("Invalid value entered in excel for boolean type data");
                                    value = "Invalid value entered in excel for boolean type data";
                                    break;
                            }
                            break;
                        }
                    case "number":

                        break;
                    default:
                        Console.WriteLine("Invalid value passed in GetCellValue for format type argument");
                        value = "Invalid value passed in GetCellValue for format type argument";
                        break;
                }
            }
            return value;
        }

        private static WorksheetPart GetWorksheetFromSheetName(WorkbookPart workbookPart, string sheetName)
        {
            Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == sheetName);
            if (sheet == null)
                throw new Exception(string.Format("Could not find sheet with name {0}", sheetName));
            else
                return workbookPart.GetPartById(sheet.Id) as WorksheetPart;
        }


        public static string returnCellValue(string fileName, string sheetName, string name, string dataType)
        {
            string excel_name = null, excel_value = null;
            SpreadsheetDocument spreadSheetDocument = null;
            try
            {
                using (spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
                {

                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    Workbook workbook = spreadSheetDocument.WorkbookPart.Workbook;

                    WorksheetPart worksheetPart = GetWorksheetFromSheetName(workbookPart, sheetName);

                    Worksheet workSheet = worksheetPart.Worksheet;

                    string sheetName1 = workSheet.InnerText;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();

                    foreach (Row row in rows) //this will also include your header row... 
                    {
                        excel_name = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(0), "string");

                        // Console.WriteLine("excel_name : " + excel_name);
                        //if(excel_name.Equals(name))
                        if (excel_name == name)
                        {
                            excel_value = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(1), dataType);


                            //  Console.WriteLine("excel_value : " + excel_value);
                            //spreadSheetDocument.Close();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Check if Excel file is closed before running the program234567\n\n");
                Console.WriteLine(ex.ToString());
            }
            return excel_value;
        }
        #endregion


    }
}
