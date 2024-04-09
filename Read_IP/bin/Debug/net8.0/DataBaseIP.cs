using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Read_IP
{
    internal class DataBaseIP
    {
        /*<БЫЛ!! Реализован словарь IP Адресов Возможно будет время, допилю
         * 
         *  словарь 1 актет > 
         *  словарь 2 актет > 
         *  словарь 3 актет > 
         *  словарь 4 актет > массив времени
         * 
         * Резонный вопрос, для чего так сложно и громоздко? 
         * А для поиска, когда прочитаем весь лог, 
         * и растусуем по словарю, выводить можно быстрее и легче
         * нужные диапазоны. В расчете на то, что можем запустить 
         * несколько выборок за одну сессию программы. Это еще не самое наркоманское, 
         * сначала думал делать это побитово, но передумал изза перевода из двоичной 
         * в десятичную при записи, съело бы много ресурсов
        
       
        int i = 0;
        //private List<string> data = new List<string>();
        private Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>> db
            = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>>();
        public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>> DB { get { return db; } }
        public static void AddIP(string ip)
        {
            if(CheckIP.Check(ip))
            {
                i++;
            }
        }
        public static void AddIPAndDate(string data)
        {

        } */

        private Dictionary<string, List<DateTime>> _data;

        public Dictionary<string, List<DateTime>> Data 
        {  
            get { return _data; } 
            set { _data = value; }
        }
        public DataBaseIP()
        {
        
        }
            public DataBaseIP(Setting st) 
        {
            Data = new Dictionary<string, List<DateTime>>();
            StreamReader sr = new StreamReader(st.PathLogFile);
            string line;
            string[] temp;
            DateOnly dt;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                temp = line.Split(new char[] { ':' },2);
                try
                {
                    this.AddData(temp[0], DateTime.Parse(temp[1]));
                }
                catch (IndexOutOfRangeException)
                {
                    //пропуск пустой строки 
                    continue;
                }
            }
            sr.Close();
        }
        public void AddData(string key, DateTime value)
        { 
            if (CheckIP.Check(key))
            {            
                if (Data.ContainsKey(key))
                {
                    Data[key].Add(value);
                }
                else 
                {
                    Data.Add(key, new List<DateTime>(){value});
                }
            }
            else { throw new ArgumentException ("Не правильный формат IP адреса"); }
        }
        public List<DateTime> GetData(string key) 
        {
            if (CheckIP.Check(key))
            {
                return Data[key];
            }
            else { throw new ArgumentException("Не правильный формат IP адреса"); }            
        }
        public List<string> GetKeys() {return new List<string>(Data.Keys); }
    
    }
}
