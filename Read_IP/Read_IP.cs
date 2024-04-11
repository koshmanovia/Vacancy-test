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

            Utilities u = new Utilities();
            Console.WriteLine(u.ConvertStringMaskToNum("255.255.0.0"));
            int[] a = u.GetRangeByIpAndMask(u.ConvertStringIpToArrayInt("25.55.22.13"), u.ConvertStringMaskToNum("255.255.0.0"));
            foreach (int i in a) { Console.Write(i + "."); }
            
            
            Console.WriteLine(    );

             a = u.GetRangeByIpAndMask(u.ConvertStringIpToArrayInt("192.168.1.1"), u.ConvertStringMaskToNum("255.255.255.0"));
            foreach (int i in a) { Console.Write(i + "."); }


            Console.WriteLine();

             a = u.GetRangeByIpAndMask(u.ConvertStringIpToArrayInt("10.10.10.10"), u.ConvertStringMaskToNum("255.0.0.0"));
            foreach (int i in a) { Console.Write(i + "."); }
        }
    }
}
