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
            int[] a = u.ConvertStringIpToArrayInt("233.494.42.123");
            foreach (int i in a) { Console.WriteLine( i  ); }

        }
    }
}
