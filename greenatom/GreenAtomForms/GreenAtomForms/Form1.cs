using Microsoft.JScript;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace GreenAtomForms
{
    public partial class Form1 : Form
    {
        private static string path = @"C:\MyProg\MySQL2019\MSSQL15.EDUASPNET\MSSQL\DATA\INTERMECH_BASE.mdf";
        private string connectionString = 
            $"Database=INTERMECH_BASE;Data Source=localhost;AttachDbFilename={path};Integrated Security=True";        
        string sqlQuery = default;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sqlQuery = new SqlQuery(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text).ToString();           
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            label4.Text = command.ExecuteScalar().ToString();           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = FBD.SelectedPath;               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("Test"); //orig:ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Test");
                excel.Workbook.Worksheets.Add("List1");
                FileInfo excelFile = new FileInfo(textBox4.Text + @"\test.xlsx");//orig: FileInfo excelFile = new FileInfo(Server.MapPath("~/ExcelFile/test.xlsx"));

                var headerRow = new List<string[]>()
                  {
                    new string[] { "ID","Name","Email", "Notation" }
                  };

                string Range = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                worksheet = excel.Workbook.Worksheets["List1"];//orig:var worksheet = excel.Workbook.Worksheets["TestSheet1"];

                worksheet.Cells[Range].LoadFromArrays(headerRow);

                worksheet.Cells[Range].Style.Font.Bold = true;
                worksheet.Cells[Range].Style.Font.Size = 16;
                worksheet.Cells[Range].Style.Font.Color.SetColor(System.Drawing.Color.DarkBlue);

                var Data = new List<object[]>()
                {
                    new object[] {"Test","test@gmail.com"},
                    new object[] {"Test2","test2@gmail.com"},
                    new object[] {"Test3","test3@gmail.com"},

                };

                worksheet.Cells[2, 1].LoadFromArrays(Data);

                excel.SaveAs(excelFile);
            }
        }
    }
}
