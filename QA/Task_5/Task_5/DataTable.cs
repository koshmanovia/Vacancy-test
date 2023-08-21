using System;
using System.Linq;

namespace Task_5
{
   public class DataTable 
    {
        #region поле таблицы code
        private static Random random = new Random();
        private string code { get; set; }
        public string Code
        {
            get { return code; }
        }
        public static string GenerateCode()
        {
            int length = 15;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        #region поле таблицы Name
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            private set { name = CorrectNameEdit(value); }
        }
        static string CorrectNameEdit(string str) 
        {            
            str = str.Replace("/", "");
            str = str.Replace("\\", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            if (str.Length > 200)
            {
                str = str.Substring(0, 200);
            }            
            return str;
        }
        #endregion

        #region поле таблицы insert_dt
        private DateTime insert_dt { get; set; }
        public DateTime Insert_DT { get { return insert_dt; } }
        #endregion

        #region поле таблицы update_dt
        private DateTime update_dt { get; set; }
        public DateTime Update_dt { get { return update_dt; } }
        #endregion

        #region поле таблицы status
        private int status { get; set; }
        public int Status 
        { 
            get { return status; } 
            private set 
            { 
                if (value <= 2 && value >= 0)
                { status = value; }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Переданное значение вне обрабатываемого диапазона");
                }
            }
        }
        #endregion

        public DataTable(string Name)
        {
            code = GenerateCode();
            this.Name = Name;
            insert_dt = DateTime.Now;
            Status = 0;
        }
        public DataTable(string Name, DateTime dT)
        {
            code = GenerateCode();
            this.Name = Name;
            insert_dt = dT;
            Status = 0;
        }
        public void SetStatus(int num)
        {
            Status = num;
        }
        public void SetUpdateDate()
        {
            update_dt = DateTime.Now;
        }
        public void EditName(string Name)
        {
            this.Name = Name;
        }
    }
}
