using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Read_IP
{
    internal class DictionaryIpAndDate : IEnumerable
    {
        private Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>> _ipAndDate;
        private int _countDate = 0;

        public Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>> IpAndDate
        {
            set { _ipAndDate = value; }
            get { return _ipAndDate; }
        }
        public int CountDate { get { return _countDate; } }
        public DictionaryIpAndDate()
        {
            IpAndDate = new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>>();
        }
        public void AddIP(int[] ip, DateTime dt)
        {
            if (ip.Length > 4)
            {
                throw new ArgumentException("Неверный IP");
            }
            if (!IpAndDate.ContainsKey(ip[0]))
            {
                IpAndDate.Add(ip[0], new Dictionary<int, Dictionary<int, Dictionary<int, List<DateTime>>>>());
            }
            if (!IpAndDate[ip[0]].ContainsKey(ip[1]))
            {
                IpAndDate[ip[0]].Add(ip[1], new Dictionary<int, Dictionary<int, List<DateTime>>>());
            }
            if (!IpAndDate[ip[0]][ip[1]].ContainsKey(ip[2]))
            {
                IpAndDate[ip[0]][ip[1]].Add(ip[2], new Dictionary<int, List<DateTime>>());
            }
            if (!IpAndDate[ip[0]][ip[1]][ip[2]].ContainsKey(ip[3]))
            {
                IpAndDate[ip[0]][ip[1]][ip[2]].Add(ip[3], new List<DateTime>());
            }
            IpAndDate[ip[0]][ip[1]][ip[2]][ip[3]].Add(dt);
            _countDate++;
        }

        public IEnumerator GetEnumerator()
        {
            return new DictionaryIpAndDateEnumerator(this);
        }

    }
}
