using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Params
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер желаемой операции");
            int selection= Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1: //1-2 пример 1
                    /* Вызов метода с передачей по значению */
                    Console.WriteLine(Sum(10, 15));  //25
                    Console.ReadKey();
                    break;
                case 2:
                    /* Вызов метода с передачей по ссылке */
                    int x = 10;
                    int y = 15;
                    Addition(ref x, y);
                    Console.WriteLine(x); //25
                    Console.ReadKey();
                    break;
                case 3: //3-4 пример 2
                    /* Передача данных по значению */
                    int a = 5;
                    Console.WriteLine($"Начальное значение переменной a = {a}");
                    /* После выполнения этого кода по-прежнему а = 5, так как мы передали лишь ее копию */
                    IncrementalVal(a);
                    Console.WriteLine($"Переменная а после передачи по значению равна = {a}");
                    Console.ReadKey();
                    break;
                case 4:
                    /* Передача данных по ссылке */
                    int b = 5;
                    Console.WriteLine($"Начальное значение переменной b = {b}");
                    /* После выполнения этого когда b = 6, так как мы передали саму переменную */
                    IncrementRef(ref b);
                    Console.WriteLine($"Переменная b после передачи по ссылке равно = {b}");
                    Console.ReadKey();
                    break;
                case 5: //5-6 пример 3
                    /* Выходные параметры */
                    int x2 = 10;
                    int z;
                    Sum2(x2, 15,out z);
                    Console.WriteLine(z);   //25
                    Console.ReadKey();
                    break;
                case 6:
                    /* Возврещиние из метоад нескольких параметров */
                    int x3 = 10;
                    int area, perim;
                    GetData(x3, 15, out area, out perim);
                    Console.WriteLine($"Площадь: {area}");
                    Console.WriteLine($"Периметр: {perim}");
                    Console.ReadKey();
                    break;
                case 7: //7-8 Пример 4
                    /* Передача параметров с Params */
                    Addition2(1, 2, 3, 4, 5); //15
                    int[] array = { 1, 2, 3, 4 };   
                    Addition2(array);   //10
                    Addition2();    //0 
                    Addition2(new int[] { 1,2,3,4}); //10
                    Console.ReadKey();
                    break;
                case 8:
                    /* Передача массива в параметры */
                    int[] j = { 1, 2, 3, 4, 5 };
                    //AdditionMas(1,2,3,4,5);   не работает
                    AdditionMas(j,2);   //30
                    //AdditionMas();   не работает
                    AdditionMas(new int[] { 1, 2, 3, 4 }, 2);   //20
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Вы ввели неверное значение");
                    break;
                    
            }

        }

        /* Передача параметров по значению (Работа с копией) */
        static int Sum (int x, int y)
        {
            return x + y;
        }
        /* Передача значения по ссылке (Работа с переменной)*/
        static void Addition(ref int x, int y)
        {
            x += y;
        }
        /* Передача по значению */
        static void IncrementalVal(int x)
        {
            x++;
            Console.WriteLine($"IncrementedVal: {x}");
        }
        /* Передача по ссылке */
        static void IncrementRef (ref int x)
        {
            x++;
            Console.WriteLine($"incementRef: {x}");
        }
        /* Выходные параметры out */
        static void Sum2(int x, int y, out int a)
        {
            a = x + y;
        }
        /* Возвращение из метода несколько значений */
        static void GetData(int x, int y, out int area, out int perim)
        {
            area = x * y;
            perim = (x + y) * 2;
        }
        /* Передача по ссылке но только для чтения IN*/
        static void GetData2 (in int x, int y, out int area, out int perim)
        {
            //x = x + 10; Значение X нельзя изменить поскольку оно передаётся по ссылке но только для чтения
            y += 10;
            area = x * y;
            perim = (x + y) * 2;
        }
        /* Передача пареметров с Params */
        static void Addition2 (params int[] integers) //ключевое слово params должно стоять после других параметров
        {
            int result = 0;
            for (int i=0; i<integers.Length; i++)
            {
                result += integers[i];
            }
            Console.WriteLine(result);
        }
        /* Передача массива */
        static void AdditionMas(int [] integers, int k)
        {
            int result = 0;
            for (int i=0; i<integers.Length; i++)
            {
                result += integers[i] * k;
            }
            Console.WriteLine(result);
        }
    }
}
