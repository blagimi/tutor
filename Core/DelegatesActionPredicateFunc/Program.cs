using System;

namespace DelegatesActionPredicateFunc
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Action
             делегат передается в качестве параметра метода и предусматривает вызов 
            определенных действий в ответ на произошедшие действия*/

            Action<int, int> op;
            op = Add;
            Operation(10, 6, op);
            op = Subtract;
            Operation(10, 6, op);

            /* Пример 2 Predicate
             Делегат Predicate<T>, как правило, используется для сравнения, 
            сопоставления некоторого объекта T определенному условию. 
            В качестве выходного результата возвращается значение true, если условие 
            соблюдено, и false, если не соблюдено*/

            Predicate<int> isPositive = delegate (int x) { return x > 0; };
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            /* Пример 3 Func 
             Возвращает результат действия и может принимать параметры.*/

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);  // 720
            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2);  // 36
        }

        /* Пример 1 */
        static void Operation(int x1, int x2, Action<int,int> op)
        {
            if (x1>x2)
            {
                op(x1, x2);
            }
        }
        static void Add (int x1, int x2)
        {
            Console.WriteLine("Сумма чисел: "+(x1+x2));
        }
        static void Subtract (int x1, int x2)
        {
            Console.WriteLine("Разность чисел: "+(x1-x2));
        }

        /* Пример 3 */

        static int GetInt(int x1, Func<int,int> retF)
        {
            int result = 0;
            if (x1>0)
            {
                result = retF(x1);
            }
            return result;
        }
        static int Factorial (int x)
        {
            int result = 1;
            for (int i = 1; i<=x; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
