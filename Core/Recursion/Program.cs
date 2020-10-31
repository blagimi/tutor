using System;
using System.Security.Cryptography.X509Certificates;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Factorial(5);
            Fib(5);
            Console.WriteLine(Fib(3));
            Console.WriteLine(Fib2(0));
        }
        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
                /*  5 * 4 = 20   4!=0
                 *  20 * 3 = 60  3!=0
                 *  60 * 2 = 120 2!=0
                 *  120 * 1 = 120 1!=0
                 */
            }
        }
        static int Fib(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }
            else
            {
                return Fib(x - 1) + Fib(x - 2);
                /* Сумма двух предыдущих числе */
            }
        }
        static int Fib2(int x)
        {
            int a, b, temp;
            a = 0;
            b = 1;
            for (int i = 0; i < x; i++)
            {
                temp = a;   //0     1       1   2
                a = b;      //1     1       2   3
                b += temp;  //1+0   2       3   5
            }
            return a;
        }
        
    }
}
