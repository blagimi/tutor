using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Korteji
{
    class Program
    {
        static void Main(string[] args)
        {
            var tuple = (5, 10);
            Console.WriteLine(tuple.Item1); //5
            Console.WriteLine(tuple.Item2); //10
            tuple.Item1 += 26;
            Console.WriteLine(tuple.Item1);//31
            Console.ReadKey();
            /* Указание типа переменных */
            (int, int) tuple2 = (5, 10);
            Console.WriteLine(tuple2.Item1);
            Console.WriteLine(tuple2.Item2);
            (string,int,double) person = ("Tom",25,81.23);
            Console.WriteLine(person);
            /* Присваивание полям кортежа названий */
            var tuple3 = (count: 5, sum: 10);
            Console.WriteLine(tuple3.count); //5
            Console.WriteLine(tuple3.sum);  //10
            /* Указание только полей кортежа */
            var (name, age) = ("Tom",23);
            Console.WriteLine(name); //Tom
            Console.WriteLine(age); //23
            /* Возвращение из метоад 2+ значений */
            var tuple4 = GetValues();
            Console.WriteLine(tuple4.Item1); // 1
            Console.WriteLine(tuple4.Item2); // 3
            /* Кортеж с массивом */
            var tuple5 = GetNamedValues(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine(tuple5.count);
            Console.WriteLine(tuple5.sum);

            Console.Read();

            var (name2, age2) = GetTuple(("Tom", 23), 12);
            Console.WriteLine(name2);    // Tom
            Console.WriteLine(age2);     // 35
            Console.Read();
        }
        /* Кортеж метод */
        private static (int,int) GetValues()
        {
            var result = (1, 3);
            return result;
        }
        /* Кортеж с массивом */
        private static (int sum, int count) GetNamedValues(int[] numbers)
        {
            var result = (sum: 0, count: 0);
            for (int i = 0; i < numbers.Length; i++)
            {
                result.sum += numbers[i];
                result.count++;
            }
            return result;
        }
        /* Передача кортежа в параметры метода */
        private static (string name2, int age2) GetTuple((string n, int a) tuple, int x)
        {
            var result = (name: tuple.n, age: tuple.a + x);
            return result;
        }
    }
}
