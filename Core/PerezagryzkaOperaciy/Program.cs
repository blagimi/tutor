using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace PerezagryzkaOperaciy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Примеры");

            Counter counter1 = new Counter { Seconds = 23 };    // Создание экземпляра объекта counter
            int x = (int)counter1;                              // Присваивание x значение counter1 с явным привидением
            Console.WriteLine(x);                               // 23
            Counter counter2 = x;                               // Создание нового экземпляра counter и добавление ссылки на х
            Console.WriteLine(counter2.Seconds);                // 23

            Counter counter3 = new Counter { Seconds = 115 };   // Создание обьекта счётчика со значением 115
            Timer timer = counter3;                             // Таймер получает ссылку на counter3
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}");    // 0:1:55
            Counter counter4 = (Counter)timer;                  // Явное преобразование
            Console.WriteLine(counter4.Seconds);                // 115
            
            Console.WriteLine("Упражнение 1");

            Clock clock = new Clock { Hours = 15 };             // Создание нового экземпляра класса 
            int y = (int)clock;                                 // Явное преобразование
            Console.WriteLine(y);                               // 15
            Clock clock2 = 13;                                  // Не явное преобразование
            Console.WriteLine(clock2.Hours);                    // 13
            clock2 = 34;
            Console.WriteLine(clock2.Hours);                    // 10

            Console.WriteLine("Упражение 2");

            /* Простые присвоения */

            Celcius celcius = new Celcius() { Gradus = 100 };   // 100
            double z = (double)celcius;
            Console.WriteLine(z);                               // 100
            Celcius celcius1 = 100.0;
            Console.WriteLine(celcius1.Gradus);                 // 100
            celcius1 = 150;
            Console.WriteLine(celcius1.Gradus);                 // 150

            /* Преобразование */

            Fahrenheit fahrenheit1 = celcius;
            Console.WriteLine(fahrenheit1.Gradus);              // 100*с =  212f
            celcius = fahrenheit1;
            Console.WriteLine(celcius.Gradus);                  // 212f = 100*c
            
            /* Простые присвоения */

            Fahrenheit fahrenheit = new Fahrenheit { Gradus = 247 };
            double f = (double)fahrenheit;
            Console.WriteLine(f);                               // 247
            Fahrenheit fahrenheit2 = 100;
            Console.WriteLine(fahrenheit2.Gradus);              // 100
            fahrenheit1 = 150;
            Console.WriteLine(fahrenheit1.Gradus);              // 150

            /* Преобразование */

            Celcius celcius2 = fahrenheit;
            Console.WriteLine(celcius2.Gradus);                 // 247f = 119*c
            fahrenheit = celcius2;
            Console.WriteLine(fahrenheit.Gradus);               // 247

            Console.WriteLine("Упражнение 3");

            Dollar dollar1 = new Dollar { Sum = 100 };          // 100
            Euro euro1 = dollar1;                               
            Console.WriteLine(euro1.Sum);                       // 87
            dollar1 = euro1;
            Console.WriteLine(dollar1.Sum);                     // 100

            decimal j = 150;
            j = (decimal)dollar1;
            Console.WriteLine(dollar1.Sum);

            Euro euro2 = new Euro { Sum = 100 };                // 100
            Dollar dollar2 = euro2;
            Console.WriteLine(dollar2.Sum);                     // 114
            euro2 = dollar2;
            Console.WriteLine(euro2.Sum);                       // 100

        }
    }
    class Counter                                               // Класс счётчик
    {
        public int Seconds { get; set; }                        // Свойство секунды
        public static implicit operator Counter (int x)         // Преобразование числа x к типу Counter
        {
            return new Counter { Seconds = x };                 // Создаётся новый объект counter со свойством seconds
        }
        public static explicit operator int (Counter counter)   // Преобразует объект counter к типу int
        {
            return counter.Seconds;                             // Получает из counter число
        }

        public static explicit operator Counter (Timer timer)   // Explicit - явное преобразование Counter counter = (Counter) timer
        {
            int h = timer.Hours * 3600;
            int m = timer.Minutes * 60;
            return new Counter { Seconds = h + m + timer.Seconds };
        }
        public static implicit operator Timer (Counter counter) // Implicit - неявное преобразование Timer timer = counter;
        {
            int h = counter.Seconds / 3600;
            int m = (counter.Seconds % 3600) / 60;
            int s = counter.Seconds % 60;
            return new Timer { Hours = h, Minutes = m, Seconds = s };
        }
    }

    class Timer
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
    /* Упражнения */

    class Clock
    {
        public int Hours { get; set; }

        public static implicit operator Clock(int x)
        {
            return new Clock { Hours = x % 24 };
        }
        public static explicit operator int (Clock clock)
        {
            return clock.Hours;
        }
    }

    class Celcius
    {
        public double Gradus { get; set; }

        public static implicit operator Celcius (double x)
        {
            return new Celcius { Gradus = x };
        }
        public static explicit operator double (Celcius celcius)  
        {
            return celcius.Gradus;                             
        }

        public static implicit operator Celcius (Fahrenheit fahrenheit)
        {
            return new Celcius { Gradus = (5.0 / 9 * (fahrenheit.Gradus - 32)) };
        }

    }
    class Fahrenheit
    {
        public double Gradus { get; set; }
        
        public static implicit operator Fahrenheit (double x)
        {
            return new Fahrenheit { Gradus = x };
        }

        public static explicit operator double (Fahrenheit fahrenheit)
        {
            return fahrenheit.Gradus;
        }

        public static implicit operator Fahrenheit(Celcius celcius)
        {
            return new Fahrenheit { Gradus = (9.0 / 5 * celcius.Gradus) + 32 };
        }

    }

    class Dollar
    {
        public decimal Sum { get; set; }

        public static implicit operator Dollar (decimal x)
        {
            return new Dollar { Sum = x };
        }
        
        public static explicit operator decimal (Dollar dollar)
        {
            return dollar.Sum;
        }

        public static implicit operator Dollar (Euro euro)
        {
            return new Dollar { Sum = euro.Sum * 1.14M };
        }
    }
    class Euro
    {
        public static explicit operator decimal (Euro euro)
        {
            return euro.Sum;
        }

        public static implicit operator Euro (Dollar dollar)
        {
            return new Euro { Sum = dollar.Sum / 1.14M };
        }
        public decimal Sum { get; set; }
    }

}
