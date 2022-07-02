using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenAtomForms
{
    public partial class Form1 : Form
    {
        private static string path = @"C:\MyProg\MySQL2019\MSSQL15.EDUASPNET\MSSQL\DATA\INTERMECH_BASE.mdf";
        private string connectionString = 
            $"Database=INTERMECH_BASE;Data Source=localhost;AttachDbFilename={path};Integrated Security=True";
        string sql = "SELECT TOP(1) [F_GROUP_ID] FROM[INTERMECH_BASE].[dbo].[IMS_ATTR_IN_GROUPS]";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            label4.Text = command.ExecuteScalar().ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
