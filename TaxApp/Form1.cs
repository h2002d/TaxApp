using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxApp
{
    public partial class Form1 : Form
    {

        String connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Windows.Forms.Application.StartupPath + "\\Database1.accdb;Persist Security Info=False;";
        bool isClicked = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox_ByDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_From.Enabled = dateTimePicker_To.Enabled = checkBox_ByDate.Checked;
        }

        private void button_ExportExcel_Click(object sender, EventArgs e)
        {
            
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                StringBuilder query = new StringBuilder("SELECT DebitTable.CompanyName, DebitTable.resta, Sum(DebitTable.Cost) AS SumOfDebit,SUM(DebitTable.CostCredit) AS SumOfCredit FROM DebitTable WHERE DebitTable.CompanyName<>''");
                if(checkBox_ByDate.Checked)
                    query.Append(" AND DebitTable.Date >= #" + dateTimePicker_From.Value.ToString("dd/MM/yyyy") + "# AND DebitTable.Date <= #" + dateTimePicker_To.Value.ToString("dd/MM/yyyy") + "# ");
                if (!checkBox_All.Checked)
                {
                    if (String.IsNullOrEmpty(textBoxCompanyId.Text))
                    {
                        MessageBox.Show("ՀՎՀՀ-ն նշված չէ:");
                        return;
                    }
                    query.Append(" AND DebitTable.resta='" + textBoxCompanyId.Text + "'");
                }
                query.Append("GROUP BY DebitTable.resta,DebitTable.CompanyName");
                using (OleDbCommand cmd = new OleDbCommand(query.ToString(), conn))
                {
                    conn.Open();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    OleDbDataAdapter dbA = new OleDbDataAdapter(cmd);
                    dbA.SelectCommand = cmd;
                    dbA.Fill(dt);
                    CreateExcelDoc excell_app = new CreateExcelDoc();
                    excell_app.createHeaders(1, 1, "Իրավաբանական անձի անվանումը կամ ֆիզիկական անձի (անհատ ձեռնարկատեր) անունը, ազգանունը");
                    excell_app.createHeaders(1, 2, "Հարկ վճարողի հաշվառման համարը (ՀՎՀՀ)");
                    excell_app.createHeaders(1, 3, "Ընդամենը Debit");
                    excell_app.createHeaders(1, 4, "Ընդամենը Credit");
                    int k = 2;
                    foreach (DataRow row in dt.Rows)
                    {

                        excell_app.addData(k, 1, row[0].ToString());
                        excell_app.addData(k, 2, row[1].ToString());
                        excell_app.addData(k, 3, row[2].ToString());
                        excell_app.addData(k, 4, row[3].ToString());
                        k++;
                    }
                    excell_app.showExcel();

                }
            }
        }

        private void btndebit_Click(object sender, EventArgs e)
        {
            ExcelImport(true);
        }
        private void btncredit_Click(object sender, EventArgs e)
        {
            ExcelImport(false);

        }
        private void ExcelImport(bool isDebt)
        {
            if(!isClicked)
                ExecuteToDb("DELETE FROM DebitTable;");
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        GetExcellValuesQuery(openFileDialog1, isDebt);
                    }
                    isClicked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void GetExcellValuesQuery(OpenFileDialog openDialog,bool isDebt)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Open(openDialog.FileName);
            var workSheet = wb.Worksheets["Sheet1"];
            Range UsedRange = workSheet.UsedRange;

            

            foreach (Microsoft.Office.Interop.Excel.Range row in workSheet.UsedRange.Rows)
            {
                if (row.Row < 3)
                    continue;
                if (isDebt)
                {
                    StringBuilder query = new StringBuilder("INSERT INTO DebitTable ([resta],[CompanyName],[Cost],[Date]) Values(");
                    query.Append("'" + workSheet.Cells[row.Row, "C"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "B"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "H"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "E"].Value2.ToString().Replace(".", "/") + "'");
                    query.Append(");");
                    ExecuteToDb(query.ToString());
                }
                else
                {
                    StringBuilder query = new StringBuilder("INSERT INTO DebitTable ([resta],[CompanyName],[CostCredit],[Date]) Values(");
                    query.Append("'" + workSheet.Cells[row.Row, "C"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "B"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "H"].Value2.ToString() + "',");
                    query.Append("'" + workSheet.Cells[row.Row, "E"].Value2.ToString().Replace(".", "/") + "'");
                    query.Append(");");
                    ExecuteToDb(query.ToString());
                }
            }
            MessageBox.Show("Excel-ը հաջողությամբ մշակված է:");
        }

        private void ExecuteToDb(string query)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionstring))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox_All_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCompanyId.Enabled = !checkBox_All.Checked;
        }

        
    }
}
