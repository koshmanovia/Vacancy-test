using System;

namespace GreenAtomForms
{
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
        /*
         * 
         * 
         * написать нормальный запрос
         * 
         * 
         */
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
