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
        //string sql = "SELECT TOP(1) [F_GROUP_ID] FROM[INTERMECH_BASE].[dbo].[IMS_ATTR_IN_GROUPS]";
        string sqlQuery = default;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sqlQuery = new SqlQuery(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text).ToString();
            // sqlQuery =
            //$"SELECT [F_OBJECT_TYPE],[F_OBJECT_ID],[F_LC_STEP],[F_ID],[F_OWNER_ID],[F_MODIFY_DATE],[F_OBJ_CREATE],[F_CREATOR_ID] FROM[INTERMECH_BASE].[dbo].[IMS_OBJECTS] WHERE[F_OBJECT_TYPE] = {textBox1.Text} ORDER BY[F_OBJECT_TYPE]";// =   ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            label4.Text = command.ExecuteScalar().ToString();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Добавить обзор..
        }
    }
    class SqlQuery
    {
        private int _id = int.MinValue;
        private string _name = null;
        private string _notation = null;
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Notation { get { return _notation; } }
        public SqlQuery()
        {
            throw new ArgumentException("Запрос не может быть пустым, введите значение");
        }
        public SqlQuery(int id) => _id = id;
        public SqlQuery(int id, string name){_id = id; _name = name; }
  
        public SqlQuery(int id, string name, string notation) { _id = id; _name = name; _notation = notation; }
        public override string ToString()
        {
            string sql =
                $"SELECT [F_OBJECT_ID],[F_OBJECT_TYPE],[F_LC_STEP],[F_ID],[F_OWNER_ID],[F_MODIFY_DATE],[F_OBJ_CREATE],[F_CREATOR_ID] FROM[INTERMECH_BASE].[dbo].[IMS_OBJECTS]";
            if (Id > int.MinValue) { sql += $" WHERE[F_OBJECT_TYPE] = {_id}"; }
            if (Name.Length != 0) { sql += $" WHERE[F_OBJECT_TYPE] = {_name}"; }
            if (Notation.Length != 0) { sql += $" WHERE[F_OBJECT_TYPE] = {_notation}"; }
            sql += " ORDER BY[F_OBJECT_TYPE]";
            return sql;
        }
    }
}
