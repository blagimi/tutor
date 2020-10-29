using System;
using System.Globalization;

namespace Massive
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Same */
            int[] nums2 = new int[4] { 1, 2, 3, 5 };

            int[] nums3 = new int[] { 1, 2, 3, 5 };

            int[] nums4 = new[] { 1, 2, 3, 5 };

            int[] nums5 = { 1, 2, 3, 5 };
            /* Обращение по индексу */
            int[] nums = new int[4];
            nums[0] = 1;
            nums[1] = 2;
            nums[2] = 3;
            nums[3] = 5;
            Console.WriteLine(nums[3]);  // 5
            Console.WriteLine();

            /* Перебор массива цикл foreach (только для чтения) */
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            /* Перебор массива цикл for */
            int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < numbers2.Length; i++)
            {
                Console.WriteLine(numbers2[i]);
            }
            Console.WriteLine();
            /* Цикл for изменение элементов массива */
            int[] numbers3 = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < numbers3.Length; i++)
            {
                numbers3[i] = numbers3[i] * 2;
                Console.WriteLine(numbers3[i]);
            }
            Console.WriteLine();
            /* Двумерные массивы same */
            int[,] numbs1;
            int[,] numbs2 = new int[2, 3];
            int[,] numbs3 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] numbs4 = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] numbs5 = new[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] numbs6 = { { 0, 1, 2 }, { 3, 4, 5 } };
            Console.WriteLine();
            /* Длина двумерного массива */
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            foreach (int i in mas)
                Console.Write($"{i} ");
            Console.WriteLine();
            
            /* каждая строка в таблице */
            int[,] mas2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            Console.WriteLine();
            int rows = mas2.GetUpperBound(0) + 1;
            int columns = mas2.Length / rows;
            // или так
            // int columns = mas.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas2[i, j]} \t");
                }
                Console.WriteLine();
            }

            /* Массив массивов (зубчатый массив) */
            Console.WriteLine();

            int[][] numbes = new int[3][];
            numbes[0] = new int[2] { 1, 2 };          // выделяем память для первого подмассива
            numbes[1] = new int[3] { 1, 2, 3 };       // выделяем память для второго подмассива
            numbes[2] = new int[5] { 1, 2, 3, 4, 5 }; // выделяем память для третьего подмассива

            Console.WriteLine();

            /* перебираем зубчатые массивы */
            int[][] numbers4 = new int[3][];
            numbers4[0] = new int[] { 1, 2 };
            numbers4[1] = new int[] { 1, 2, 3 };
            numbers4[2] = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("перебор foreach");
            foreach (int[] row in numbers4)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("перебор for");
            // перебор с помощью цикла for
            for (int i = 0; i < numbers4.Length; i++)
            {
                for (int j = 0; j < numbers4[i].Length; j++)
                {
                    Console.Write($"{numbers4[i][j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Перебор и вывод двумерного массива
            int[,] numbersTest = new int[3, 4];

            for (int i = 0; i < numbersTest.GetLength(0); i++)
            {
                for (int j = 0; j < numbersTest.GetLength(1); j++)
                {
                    Console.Write($"{numbersTest[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();


            /* перебор и вывод многомерного массива */
            int[,,] mass3 = { { { 1, 2 }, { 3, 4 } },
                            { { 4, 5 }, { 6, 7 } },
                            { { 7, 8 }, { 9, 10} },
                            { {10, 11}, {12, 13} } };
            for (int i = 0; i < mass3.GetLength(0); i++)
            {
                for (int j = 0; j < mass3.GetLength(1); j++)
                {
                    for (int k = 0; k < mass3.GetLength(2); k++)
                        Console.Write(mass3[i, j, k]);
                }
            }
            /* Форматирование массива */
            Console.WriteLine();
            Console.WriteLine();
            int[,,] mas4 = { { { 1, 2 }, { 3, 4 } },
            { { 4, 5 }, { 6, 7 } },
            { { 7, 8 }, { 9, 10} },
            { {10, 11}, {12, 13} } };
            Console.Write("{");
            for (int x = 0; mas4.GetLength(0) > x; x++)
            {
                Console.Write("{");
                for (int y = 0; mas4.GetLength(1) > y; y++)
                {
                    Console.Write("{ ");
                    for (int z = 0; mas4.GetLength(2) > z; z++)
                        Console.Write(mas4[x, y, z] + ",");
                    Console.Write("\b },");
                }
                Console.Write("\b},");
            }
            Console.Write("\b}");


        }
    }
}
