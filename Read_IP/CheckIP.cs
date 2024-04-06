using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace Read_IP
{
    internal static class CheckIP
    {
        public static bool Check(string IP)
        {
            // Честно найденное в интернетах регулярное выражение
            // для проверки написания соответствия IP адреса 
            Regex validateIPv4Regex = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return validateIPv4Regex.IsMatch(IP);
        }
        public static string GetRangeAddressesByMask(string mask, string ipAddress)
        {   
            if(!Check(ipAddress)) 
            {
                throw new ArgumentException("Введен некорректный IP address");
            }
            if(Check(mask)) 
            {
                string[] temp = mask.Split(new char[] { ' ' });
                for (int i = 0; temp.Count(); i++)
                { 
                    
                }
                //mask = mask.Replace(".", "");
            }
            else
            {
                throw new ArgumentException("Введена некорректная маска сети");
            }
            return "";
        }
    }
}

