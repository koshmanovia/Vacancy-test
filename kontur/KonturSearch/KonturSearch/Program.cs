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
            //FullName a0 = new FullName() {  Surname = "34" };
            //FullName a1 = new FullName() {  Surname = "ajfg hjf  ghjs" };
            //FullName a2 = new FullName() {  Surname = "d sjfgh fefenf gha"};

            FullName a0 = new FullName() {  Surname = "34"};
            FullName a1 = new FullName() {  Surname = "Петров" };
            FullName a2 = new FullName() {  Surname = "Сидоров" };


            AutoCompleter ac = new AutoCompleter();            
            List<FullName> fn = new List<FullName>() { a0, a1, a2,};
            ac.AddToSearch(fn);
            List<string> list = ac.Search("34");
            foreach (string s in list)
            {
                Console.WriteLine(s + "=" + s.Length);

            }
            Console.ReadKey();
        }
    }
}
