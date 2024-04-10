using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Read_IP
{
    internal class Utilities
    {
        public int[] GetRangeByIpAndMask(int[] ip, int mask)
        {
            if (!CheckMask(mask)) { throw new ArgumentException("Некорректная маска"); }
            char[] inpByteCharArrayIp = ConvertIntArrayIpToCharArrayByteIp(ip);
            char[] minByteCharArrayIp = new char[32];
            char[] maxByteCharArrayIp = new char[32];
            int[] intRange = new int[8]; //массив, один как даипазон, 0-3 значение - нижняя планка, 4-7 верхняя планка
            for (int i = 0; i < 32; i++)
            {                
                if (i <= mask)
                {
                    minByteCharArrayIp[i] = inpByteCharArrayIp[i];
                }
                else
                {
                    minByteCharArrayIp[i] = '0';
                    maxByteCharArrayIp[i] = '1';
                }
                if (i == mask)
                {
                    minByteCharArrayIp.CopyTo(maxByteCharArrayIp, 0);
                }
            }
            for (int i = 0; i < intRange.Length; i++) 
            {
                if (i < 4)
                {

                    // преобразование из 2й в 10ю СС доделать и все полетит
                    intRange[i] = int.Parse(Convert.ToString(int.Parse(new string(minByteCharArrayIp, (0 + i * 8), 8)), 10));
                }
                else
                {
                    intRange[i] = int.Parse(new string(maxByteCharArrayIp, (0 + (i-4) * 8), 8));
                }
                
            }
            return intRange;
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
        public int ConvertStringMaskToNum(string mask) 
        {
            char[] charArray = new char[32];
            bool maskCorrect = true;
            bool wasZero = false;
            int maskNum = 0;

            charArray = ConvertIntArrayIpToCharArrayByteIp(ConvertStringIpToArrayInt(mask));
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
            return maskNum;
        }
        public bool CheckMask(int mask) 
        { 
            if (mask > 0 && mask < 33)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckingCorrectIP(string IP)
        {
            Regex validateIPv4Regex = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return validateIPv4Regex.IsMatch(IP);
        }
        private static char[] ConvertIntArrayIpToCharArrayByteIp(int[] ip)
        {
            string tempBinary = "";
            string binary = "";
            for (int i = 0; i < 4; i++)
            {
                tempBinary = Convert.ToString(ip[i], 2);
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

        
    }
}
