using System;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //В данном блоке проверям низкую зарплату, которая в диапазоне от 0 до 20 000.00(не включительно)
            Console.WriteLine(SalaryDetermination(100));
            Console.WriteLine(SalaryDetermination(19999.99m));
            //В данном блоке проверям среднюю зарплату, которая в диапазоне от 20 000.00(включительно) до 40 000.00(не включительно)
            Console.WriteLine(SalaryDetermination(20000.00m));
            Console.WriteLine(SalaryDetermination(39999.99m));
            //В данном блоке проверям хорошую зарплату, которая в диапазоне от 40 000.00(включительно) до 100 000.00(не включительно)
            Console.WriteLine(SalaryDetermination(40000.00m));
            Console.WriteLine(SalaryDetermination(99999.99m));
            //В данном блоке проверям очень хорошую зарплату, которая выше 100 000.00
            Console.WriteLine(SalaryDetermination(100000m));
            //В данном блоке проверям не корректный ввод
            Console.WriteLine(SalaryDetermination(-1m));
            Console.WriteLine(SalaryDetermination(0m));

            Console.Read();
        }
        static string SalaryDetermination(decimal Salary)
        { 
            if (Salary < 20000.00m && Salary > 0)
            {
                return "низкая зарплата";
            }
            if (Salary >= 20000.00m && Salary < 40000.00m)
            {
                return "средняя зарплата";
            }
            if (Salary >= 40000.00m && Salary < 100000.00m)
            {
                return "хорошая зарплата";
            }
            if (Salary >= 100000m)
            {
                return "очень хорошая зарплата";
            }
            return "не корректные данные";
        }
    }
}
