using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Read_IP
{
    internal class Utilities
    {
        public int[] GetCorrectRangeByIpAndMask(int[] ip, int mask)
        {
            return new int[0];
        }
        public int[] ConvertStringIpToArrayInt(string ip)
        {
            if (CheckingCorrectIP(ip))
            {
                int[] arrayIp = ip.Split('.').Select(x => int.Parse(x)).ToArray();
                return arrayIp;
            }
            else
            {
                throw new ArgumentException("Некорректный IP адрес");
            }
        }
        public int ConvertMask(string mask) 
        {
            return new int;
        }
        public int CheckMask(int mask) 
        { 
            if (mask > 0 && mask < 33)
            {
                return mask;
            }
            else
            {
                throw new ArgumentException("Не верно задана маска");
            }
        }
        public static bool CheckingCorrectIP(string IP)
        {
            Regex validateIPv4Regex = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return validateIPv4Regex.IsMatch(IP);
        }
    }
}
