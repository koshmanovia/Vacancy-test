using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq;

namespace GeernAtomForms
{
    [Table(Name = "Customers")]
    public class Customer
    {
        #region table
        private string _CustomerID;
        [Column(IsPrimaryKey = true, Storage = "_CustomerID")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
            }
        }
        #endregion
    }

    public partial class Form1 : Form
    {

        private static string connectionString = @"Database=INTERMECH_BASE;Data Source=localhost;AttachDbFilename=C:\MyProg\MySQL2019\MSSQL15.EDUASPNET\MSSQL\DATA\INTERMECH_BASE.mdf; Integrated Security=True";
        private static DataContext db = new DataContext(connectionString);
        private static SqlConnection _sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label4.Text = ;
        }
        private static string getDataDB()
        {
            OpenConnection();
            //TODO
            CloseConnection();
            return "test";
        }
        private static void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }
        private static void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }


    }
}
