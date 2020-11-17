using System;

namespace LyambdiAndEvents
{
    class Program
    {
        /* Описываем делегаты */

        delegate int Operation(int x, int y);   // Для примера 1    
        delegate int Square(int x);             // Для примера 2
        delegate void Hello();                  // Для примера 3
        delegate void ChangeHandler(ref int x); // Для примера 4
        delegate void HelloDelegate();          // Для примера 5
        delegate bool IsEqual(int x);           // Для примера 6
        static void Main()
        {
            /* Пример 1*/

            Console.WriteLine("Пример 1: ");
            /* (x, y) => x + y; Лямбда-выражение, где x и y - это параметры, а x + y - выражение*/
            Operation operation = (x, y) => x + y;  // создаём делегат с лямбда выражением
            Console.WriteLine(operation(10,20));    // 30
            Console.WriteLine(operation(40,20));    // 60
            
            /* Пример 2*/

            Console.WriteLine("Пример 2: ");
            /* Если лямбда-выражение принимает один параметр, то скобки вокруг параметра можно опустить: */
            Square square = i => i * i;
            int z = square(6);
            Console.WriteLine(z);                   //36

            /* Пример 3 */

            Console.WriteLine("Пример 3: ");
            /* Если параметры не требуются, то в лямбда выражениях используются пустые скобки*/
            Hello hello1 = () => Console.WriteLine("Hello");
            Hello hello2 = () => Console.WriteLine("Welcome");
            hello1();                               // Hello
            hello2();                               // Welcome

            /* Пример 4 */

            Console.WriteLine("Пример 4: ");
            /* Обязательно нужно указывать тип, если делегат имеет параметры с модификаторами ref и out */
            int j = 9;
            ChangeHandler changeHandler = (ref int m) => m = m * 2;
            changeHandler(ref j);
            Console.WriteLine(j);                   // 18

            /* Пример 5 */

            Console.WriteLine("Пример 5: ");
            /* Лямбда выражения таже могут выполнять другие методы*/
            HelloDelegate helloDelegate = () => Show_Message();
            helloDelegate();

            /* Пример 6: */

            Console.WriteLine("Пример 6: ");
            /* Лямбды можно передавать в качестве аргументов методу для тех параметров, которые представляют делегат */
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result1 = Sum(integers, x => x > 5);
            Console.WriteLine(result1);              // 30
            int result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine(result2);              // 20
        }

        private static void Show_Message()           // Для примера 5
        {
            Console.WriteLine("Привет мир");
        }
        private static int Sum(int[] numbers, IsEqual func) // Для примера 6
        {
            int result = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    result += i;
            }
            return result;
        }
    }
}
