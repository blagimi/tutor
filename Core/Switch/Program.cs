using System;

/* Паттерны */

namespace Switch
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Обычное использование switch */

            try
            {
                int x = Select(1, 2, 3);
                Console.WriteLine(x);
                int y = SelectNew(1, 5, 10);
                Console.WriteLine(y);
                int z = SelectNew2(1, 10, 20);
                Console.WriteLine(z);
                x = Select(12, 4, 10);
                Console.WriteLine(x);
            
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
        /* Пример 1 Обычное использование switch */
        static int Select (int op, int a, int b)
        {
            switch (op)
            {
                case 1: return a + b;
                case 2: return a - b;
                case 3: return a * b;
                default: throw new ArgumentException("Недопустимый код операции");
            }
        }
        /* Пример 2 Паттерны switch
         * C# 8.0 позволяет сократить конструкцию switch, которая возвращает значение */
        static int SelectNew(int op,int a,int b)
        {
            int result = op switch
            {
                1 => a + b,
                2 => a - b,
                3 => a * b,
                _ => throw new ArgumentException("Недопустимый код операции")
            };
            return result;
        }
        /* Пример 3 или еще более упрощеный вид */
        static int SelectNew2(int op, int a, int b) => op switch
        {
            1 => a + b,
            2 => a - b,
            3 => a * b,
            _ => throw new ArgumentException("Недопустимый код операции")
        };
    }
}
