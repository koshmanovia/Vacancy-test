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

            DictionaryIpAndDate dtip = new DictionaryIpAndDate();
            dtip.AddIP(Utilities.ConvertStringIpToArrayInt("222.112.102.122"), DateTime.Now);
            foreach(var c  in dtip)
            {
                Console.WriteLine(c);
            }

        }
    }
}
