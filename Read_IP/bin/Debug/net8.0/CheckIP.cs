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
    }
}

