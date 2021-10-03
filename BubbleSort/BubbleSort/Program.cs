using System;
using System.Collections.Generic;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>(){3,2,1,0, -1, -2, -3};
            foreach (var value in array)
            {
                Console.Write($"{value} \t");
            }
            BubbleSort(array);
            Console.WriteLine();
            foreach (var value in array)
            {
                Console.Write($"{value} \t");
            }
            Console.ReadLine();
        }
        static void BubbleSort(List<int> loop)
        {
            int tmp = default;
            for (int i = loop.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (loop[i] < loop[j])
                    {
                        tmp = loop[i];
                        loop[i] = loop[j];
                        loop[j] = tmp;
                    }
                }
            }
        }
    }
}
