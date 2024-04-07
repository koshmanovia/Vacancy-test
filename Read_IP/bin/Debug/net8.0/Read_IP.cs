using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Read_IP
{
    internal class Read_IP
    {
        static void Main(string[] args)
        {
            //CommandPromt cp = new CommandPromt();
            //cp.EnterCommand();
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("129.123.123.123", "9"));
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("33.214.112.21", "255.0.0.0"));
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("1.1.1.1", "255.255.128.0"));
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("42.234.221.123", "12"));
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("129.123.32.45", "30"));
            Console.WriteLine(CheckIP.GetRangeAddressesByMask("252.252.252.3", "4"));


        }
      

    }
}
