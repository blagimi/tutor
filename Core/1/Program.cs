using System;

namespace First
{
    class Program
    {
        static void Main()
        {
            Calculator.Add(2, 3);
            Console.ReadKey();
        }
    }
    class Calculator
    { 
        public static void Add (int x, int y)
        {
            int z = x + y;
            Console.WriteLine($"Сумма двух чисел равна = {z}");
        }
    }
}
