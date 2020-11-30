using System;

namespace LocalFunc
{
    class Program
    {
        static void Main()
        {
            var result = GetResult(new int[] { -3, -2, -1, 0, 1, 2, 3 });
            Console.WriteLine(result);  //  6
        }
        static int GetResult(int[] numbers)
        {
            /* Здесь в методе GetResult определена локальная функция IsMoreThan(), 
             * которая может быть вызвана только внутри этого метода. Локальная функция
             * задает еще одну область видимости, где мы можем определять переменные и
             * выполнять над ними действия. В то же время ей доступны все переменные, 
             * которые определены в том же методе. */
            int limit = 0;
            bool isMoreThan(int number) //  Локальная функция
            {
                return number > limit;
            }
            /* Начиная с версии C# 8.0 можно определять статические локальные функции. 
             * Их особенностью является то, что они не могут обращаться к переменным 
             * окружения, то есть метода, в котором статическая функция определена. */
            static bool isMoreThanThis(int number)
            {
                int limit = 0;
                return number > limit;
            }
            int result = 0;
            for (int i=0; i<numbers.Length; i++)
            {
                if (isMoreThan(numbers[i]))
                {
                    result += numbers[i];
                }
            }
            return result;
        }
    }
}
