using System;

namespace Cikl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для запуска операций 1)while 2) for while 3) infinity (don't) 4) for switch ");
            int switcher = Convert.ToInt32(Console.ReadLine());
            switch (switcher)
            {
                case 1:
                    {
                        int i = 5;
                        while (i > 0)
                        {
                            i *= 3;
                            i *= -1;
                        }
                        Console.WriteLine(i);
                        break;
                    }
                case 2:
                    {
                        int j = 2;
                        for (int i = 1; i < 100; i = i + 2)
                        {
                            j = j - 1;
                            while (j < 15)
                            {
                                j = j + 5;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        int j = 2;
                        for (int i = 2; i < 32; i = i * 2)
                        {
                            while (i < j)
                            {
                                j = j * 2;
                            }
                            i = j - i;
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            switch (i)
                            {
                                default:
                                    Console.WriteLine($"i = {i++}");
                                    break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вы ввели неправильное значение");
                        break;
                    }
            }
        }


    }
}
