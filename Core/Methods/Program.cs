using System;

namespace Methods
{
    class Program
    {
        static void Main()
        {  
            /* Методы */
            SayHello();
            SayGoodBye();
            /* Использование возвращаемых значений*/
            string message = GetHello();
            int sum = GetSum();
            Console.WriteLine(message);
            Console.WriteLine(sum);
            /* Вывод метода с параметрами */
            Console.WriteLine(Sum(6, 3));
            /* Еще один вызов метода с передачей аргментов в параметры */
            int a = 25;
            int b = 35;
            int result = Sum(a, b); //60
            Console.WriteLine(result);

            result = Sum(b, 45);    //80
            Console.WriteLine(result);

            result = Sum(a + b + 12, 18);   
            Console.WriteLine(result);  //90
            /* Вызов метода с параметрами разных типов */
            Display("Tom", 23);
            /* Вызов метода с необязательными параметрами */
            OptimalParam(2, 3); //Первые 2 поля обязательные, два последующие имеют значения по умолчанию определенные в методе
            OptimalParam(2, 3, 10);
            OptimalParam(2, 3, 4, 6);
            /* Передача значений параметрам по имени а не по порядку */
            OptimalParam(y:2, x:3, s:10);

            int i = 0;
            Console.Write(i++ + Calculate(i));
            Console.WriteLine(i);
            Console.ReadKey();
        }
        /* Методы */
        static void SayHello() 
        {
            Console.WriteLine("Hello");
        }
        /* Укороченая запись метода с одним действием */
        static void SayGoodBye() => Console.WriteLine("GoodBye");
        /* Возвращаемые значения */
        static string GetHello()
        {
            return "Hello";
        }
        static int GetSum()
        {
            int x = 2;
            int y = 3;
            int z = x + y;
            return z;
        }
        /* Метод с параметрами */
        static int Sum (int x, int y)
        {
            return x + y;
        }
        /* Типы передаваемых параметров */
        static void Display (string name, int age)
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}");
        }
        /* Необязательные параметры */
        static int OptimalParam(int x, int y, int z=5, int s=4)
        {
            return x + y + z + s;
        }
        public static int Calculate(int i)
        {
            Console.Write(i++);
            return i;
        }
    }
}
