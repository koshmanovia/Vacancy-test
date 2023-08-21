using System;
using System.Collections.Generic;

namespace Task_5
{
    public class AbstactTable
    {
        private List<DataTable> table = new List<DataTable>();
        private List<DataTable> tempTable = new List<DataTable>();

        public void AddData(DataTable dT) 
        { 
            tempTable = new List<DataTable>(table);
            dT.SetStatus(0);
            tempTable.Add(dT);
        }
        public void EditData(int numInTable, DataTable dT)
        {
            if(table[numInTable-1].Status == 0 && table[numInTable-1].Status == 2)
            {
                tempTable = new List<DataTable>(table);
                tempTable[numInTable - 1] = dT;
            }
            else
            {
                throw new Exception( "Данные не могу быть изменены, т.к. статус карточки неверен");
            }

        }      
        public void DropData(int numInTable)
        {
            if (table[numInTable - 1].Status == 0)
            {
                tempTable = new List<DataTable>(table);
                tempTable.RemoveAt(numInTable - 1);
            }
            else
            {
                throw new Exception("Данные не могу быть удалены, т.к. статус не соответсвует \"Новый\"");
            }
        }
        public void ApplyChanges() 
        {
            table = new List<DataTable>(tempTable);
        }
        public void ConfimData(int numInTable)
        {
            table[numInTable - 1].SetStatus(1);
        }
        public List<DataTable> TakeDataNeedUpdate() 
        {
            List<DataTable> temp = new List<DataTable>();
            foreach (DataTable dT in tempTable)
            {
                if((int)DateTime.Now.Subtract(dT.Insert_DT).Days > 366)
                {
                    temp.Add(dT);
                }
            }
            return temp;
        }
    }
}
