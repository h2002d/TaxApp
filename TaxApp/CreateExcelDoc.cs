using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace TaxApp
{
    class CreateExcelDoc
    {
        private Application app = null;
        private Workbook workbook = null;
        private Worksheet worksheet = null;
        private Range workSheet_range = null;
        public CreateExcelDoc()
        {
            createDoc();
        }
        public void createDoc()
        {
            try
            {
                app = new Application();
                app.Visible = false;
                workbook = app.Workbooks.Add(1);
                worksheet = (Worksheet)workbook.Sheets[1];

                workSheet_range = worksheet.get_Range("A1", "D1");
                workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                workSheet_range.Font.Bold = true;
                workSheet_range = worksheet.get_Range("A1", "E100");
                workSheet_range.NumberFormat = "@";
                workSheet_range.Columns.AutoFit();
            }
            catch (Exception e)
            {
                Console.Write("Error");
            }
            finally
            {
            }
        }

        public void createHeaders(int row, int col, string htext)
        {
            worksheet.Cells[row, col] = htext;
        }

        public void addData(int row, int col, string data)
        {
            worksheet.Cells[row, col] = data;
        }

        public void showExcel()
        {
            //workSheet_range = worksheet.get_Range("A1", "E100");
            workSheet_range.Columns.AutoFit();
            app.Visible = true;
            
        }
    }
}
