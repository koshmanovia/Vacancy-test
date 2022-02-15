using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoComplete;

namespace AutoComplete
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            FullName a0 = new FullName() { Name = "123456", Surname = "ewertyurtg", Patronymic = "3" };
            FullName a1 = new FullName() { Name = "11", Surname = "ajfghjfghjs", Patronymic = "3" };
            FullName a2 = new FullName() { Name = "111", Surname = "dsjfghfefenfgha", Patronymic = "3" };
            FullName a3 = new FullName() { Name = "1111", Surname = "fejrfdgje56r", Patronymic = "3" };            
            FullName a4 = new FullName() { Name = "1123", Surname = "fedsnfgfehue4rfg", Patronymic = "3" };
            FullName a5 = new FullName() { Name = "11234", Surname = "cvxu56dtjfgx", Patronymic = "3" };
            FullName a6 = new FullName() { Name = "1523", Surname = "ujyfghjrtyt", Patronymic = "3" };
            FullName a7 = new FullName() { Name = "16543", Surname = "iuuyrtyuuy", Patronymic = "3" };
            FullName a8 = new FullName() { Name = "1856", Surname = "ertrtyy2", Patronymic = "3" };
            FullName a9 = new FullName() { Name = "19657", Surname = "feqscrtfeyutre", Patronymic = "3" };            
            FullName a10 = new FullName() { Name = "176578", Surname = "jhfbdcfgfehjxg", Patronymic = "3" };
            FullName a11 = new FullName() { Name = "11111", Surname = "weuertdfefg", Patronymic = "3" };
            FullName a12 = new FullName() { Name = "176578", Surname = "sdftydfghjjfe2", Patronymic = "3" };
            FullName a13 = new FullName() { Name = "11111", Surname = "dfgyeuertdfefg", Patronymic = "3" };
            FullName a14 = new FullName() { Name = "11111", Surname = "ityuiweuertdfefg", Patronymic = "3" };
            FullName a15 = new FullName() { Name = "11111", Surname = "k,jhweuertdfefg", Patronymic = "3" };
            FullName a16 = new FullName() { Name = "11111", Surname = "bnmweuertdfefg", Patronymic = "3" };
            FullName a17 = new FullName() { Name = "11111", Surname = "vbnmweuertdfefg", Patronymic = "3" };
            FullName a18 = new FullName() { Name = "11111", Surname = "wvmnbeuertdfefg", Patronymic = "3" };
            FullName a19 = new FullName() { Name = "11111", Surname = "wvmnbeuertdfefg", Patronymic = "3" };


            AutoCompleter ac = new AutoCompleter();
            List<FullName> fn = new List<FullName>(){ a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19 };
            ac.AddToSearch(fn);
            //ac.TestInput();
            List<string> list = ac.Search("111");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
