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
            CommandPromt cp = new CommandPromt();
            cp.EnterCommand();



            //Setting st = new Setting();
            //DataBaseIP db = new DataBaseIP(st);
            //Console.WriteLine(db.GetData("3.1.1.1"));
            //foreach (var c in db.GetData("3.1.1.1"))
            //{
            //    Console.WriteLine(c);
            //}
        }
    }
}
