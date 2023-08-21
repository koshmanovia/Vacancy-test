using System;
using System.Text.RegularExpressions;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "dssdr";
            DataTable dtIncorrectInput = new DataTable("safsgwergt>sdfgsdfgsdfgsdfgsdfgs" +
            "dfgsdfgsdfgsdfgsdfgsdfgwergtwreg3t5g4tgvrfcefrvtgbyhunjbyvtcrf" +
            "tvgybhunjhygtfrderftgybhnujmnhbgvftgvybhunjminuhbygtvfrtgyhujnimy" +
            "fghyetdy65redfghjyutrgfvbhjyu675t4redfghtyrfdvghtyr</.//.,><><", new System.DateTime(2022, 11, 11, 11, 11, 11));
            Console.WriteLine(dtIncorrectInput.Name.Length);
            Console.WriteLine(  Regex.IsMatch(str, @"[<>/\\]+$"));
            Console.WriteLine(str.Contains("/"));
            Console.WriteLine(str.Contains("\\"));
            Console.WriteLine(str.Contains(">"));
            Console.WriteLine(str.Contains("<"));
            Console.Read();
        }
    }
}
