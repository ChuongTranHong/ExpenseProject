using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
namespace DXWindowsApplication2.Controller
{
    public class ExcelController : IController
    {
        public void readExcel(string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            try
            {
                range = xlWorkSheet.UsedRange;
                Boolean checkLastRow = false;
                var range1 = range.Cells[3, 1] as Excel.Range;
                if (range1 != null)
                {
                    var currentValue = range1.Value2;
                    Console.WriteLine(currentValue.GetType());
                    Console.WriteLine(currentValue);
                    var date = DateTime.FromOADate(currentValue);
                    Console.WriteLine(date);

                }
//                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
//                {
//                    for (cCnt = 1; cCnt <= range.Columns.Count && cCnt <= 16; cCnt++)
//                    {
//                        str = valueOfCell(rCnt, cCnt, range);
//                        if (cCnt == 2 && str == "Summary") checkLastRow = true;
//                        Console.Write(str+"\t");
//                    }
//                    Console.WriteLine();
//                    if (checkLastRow) break;
//                }
            }
            catch (Exception)
            {

            }
            finally
            {
                xlWorkBook.Close(false, null, null);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }

        }
        //        public int fetchTheRangeExcel(Excel.Worksheet workSheet)
        //        {
        //            Excel.Range range = workSheet.UsedRange;
        //            var maxRow = range.Rows.Count;
        //            for 
        //        }
        public void OnLoad()
        {
            throw new NotImplementedException();
        }
        public string valueOfCell(int row, int col, Excel.Range range)
        {
            string str = "";
            var range1 = range.Cells[row, col] as Excel.Range;
            if (range1 != null)
            {
                var currentValue = range1.Value2;
                if (currentValue is Double) str = Convert.ToString(currentValue);
                else str = (string)range1.Value2;
            }
            return str;
        }

        public void SetView(XtraForm view)
        {
            throw new NotImplementedException();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
