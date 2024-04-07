using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Threading.Tasks;

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
        public static string GetRangeAddressesByMask(string ipAddress, string mask)
        {
            char[] charArray = new char[32];
            int maskNum = 0;
            string ipMin = "";
            string ipMax = "";
            if (!Check(ipAddress))
            {
                throw new ArgumentException("Введен некорректный IP address");
            }
            if (Check(mask))
            {
                maskNum = ConvertMaskToNum(mask);
            }
            else
            {
                if (int.Parse(mask) < 33 && int.Parse(mask) > -1)
                {
                    maskNum = int.Parse(mask);
                }
                else
                {
                    throw new ArgumentException("Введена некорректная маска сети");
                }
            }
            charArray = ConvertStringIpToCharArrayByte(ipAddress);
            for(int i = 0;i < 32; i++) 
            {
                if (i <= maskNum)
                {
                    ipMin += charArray[i];
                    ipMax = ipMin;
                }
                else
                {
                    ipMin += 0;
                    ipMax += 1;
                }            
            }
            ipMin = ConvertStringByteIpToStringIntIp(ipMin);
            ipMax = ConvertStringByteIpToStringIntIp(ipMax);
            return $"{ipMin} - {ipMax}";
        }
        static public int ConvertMaskToNum(string mask)
        {
            char[] charArray = new char[32];
            bool maskCorrect = true;
            bool wasZero = false;
            int maskNum = 0;

            charArray = ConvertStringIpToCharArrayByte(mask);
            if (charArray[0] == '0')
            {
                throw new ArgumentException("Некорректная маска");
            }
            else
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == '0' && wasZero == false)
                    {
                        wasZero = true;
                        maskNum = i;
                    }
                    if (charArray[i] == '1' && wasZero == true)
                    {
                        throw new ArgumentException("Некорректная маска");
                    }
                }
            }
            if (maskNum == 0) { maskNum = 32; }
            return (maskNum);
        }
        static private char[] ConvertStringIpToCharArrayByte(string ip) 
        {
            string tempBinary = "";
            string binary = "";
            string[] temp = ip.Split(new char[] { '.' });
            for (int i = 0; i < 4; i++)
            {
                tempBinary = Convert.ToString(int.Parse(temp[i]), 2);
                if (tempBinary.Length < 8)
                {
                    for (int j = 0 + tempBinary.Length; j < 8; j++)
                    {
                        binary = binary + "0";
                    }
                }
                binary = binary + tempBinary;
            }
            return binary.ToCharArray();
        }    
        static private string ConvertStringByteIpToStringIntIp(string ip)
        {
            string temp ="";
            string returnStr ="";
            for(int i = 0; i < ip.Length; i++) 
            {
                temp += ip[i];
                if (i == 7 || i == 15 || i == 23)
                {
                    returnStr += Convert.ToByte(temp, 2) + ".";
                    temp = "";
                }
                else
                if (i == 31)
                {
                    returnStr += Convert.ToByte(temp, 2);
                }
            }
            return returnStr;
        }
    }
}

