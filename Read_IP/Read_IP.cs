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

            //Utilities u = new Utilities();
            //Console.WriteLine(u.ConvertStringMaskToNum("255.255.0.0"));
            //int[] a = u.GetRangeByIpAndMask(u.ConvertStringIpToArrayInt("25.55.22.13"),u.ConvertStringMaskToNum("255.255.0.0"));
            //foreach (int i in a) { Console.WriteLine( i  ); }



            int intRange = 0;

            char[] c = new char[] {'1','1','1','1','1' };

            intRange = int.Parse(new string(c, 0, 5).ToArray());

            Console.WriteLine(intRange);


            string s = new string(c);
            s = s.ToString();
            Console.WriteLine(s);
            intRange = int.Parse(s, );
            Console.WriteLine(intRange);
        }
    }
}
