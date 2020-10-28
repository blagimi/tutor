using System;

namespace ifelsecase
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Ведите номер необходимой операции 1) Сравнение 2)больше меньше 3)больше меньше 2 4)расчёты");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    Console.WriteLine("Вы запустили первый пример");
                    One();
                    break;
                case 2:
                    Console.WriteLine("Вы запустили второй пример");
                    Two();
                    break;
                case 3:
                    Console.WriteLine("Вы запустили третий пример");
                    Three();
                    break;
                case 4:
                    Console.WriteLine("Вы запустили четвёртый пример");
                    Four();
                    break;
                default:
                    Console.WriteLine("Вы указали неправильный номер");
                    break;
            }    
            
        }
        public static void One()
        {
            Console.WriteLine("Введите первое число");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            int second = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Вы ввели числа {first} и {second}");
            if (first > second)
            {
                Console.WriteLine($"Число {first} больше чем {second}");
            }
            else if (first < second)
            {
                Console.WriteLine($"Число {second} больше чем {first}");
            }
            else
            {
                Console.WriteLine($"Числа {first} и {second} равны");
            }
            Console.ReadKey();
        }
        public static void Two()
        {
            Console.WriteLine("Введите число от 1 до 10");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number>5 && number<10)
            {
                Console.WriteLine("Число больше 5 и меньше 10");
            }
            else
            {
                Console.WriteLine("Неизвестное число");
            }
            Console.ReadKey();
        }
        public static void Three()
        {
            Console.WriteLine("Введите число");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number==5 || number== 10)
            {
                Console.WriteLine("Число либо равно 5, либо равно 10");
            }
            else
            {
                Console.WriteLine("Неизвестное число");
            }
            Console.ReadKey();
        }
        public static void Four()
        {
            Console.WriteLine("Введите сумму вклада hint:0-200+");
            double summ = Convert.ToDouble(Console.ReadLine());
            double percent = 0;
            if (summ <= 100)
            {
                percent = 0.05;
            }
            else if (summ > 100 & summ < 200)
            {
                percent = 0.07;
            }
            else if (summ >= 200)
            {
                percent = 0.1;
            }
            summ += summ * percent + 15;
            Console.WriteLine($"Сумма вклада с процентами: {summ}");
            Console.ReadKey();
        }
    }
}
