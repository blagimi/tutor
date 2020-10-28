using System;

namespace LogicCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Логическое умножение
            int x1 = 2; //010
            int y1 = 5;//101
            Console.WriteLine(x1 & y1); // выведет 0

            int x2 = 4; //100
            int y2 = 5; //101
            Console.WriteLine(x2 & y2); // выведет 4
            
            //Логическое сложение
            int x3 = 2; //010
            int y3 = 5;//101
            Console.WriteLine(x3 | y3); // выведет 7 - 111
            int x4 = 4; //100
            int y4 = 5;//101
            Console.WriteLine(x4 | y4); // выведет 5 - 101

            //Логическое или XOR 
            int x = 45; // Значение, которое надо зашифровать - в двоичной форме 101101
            int key = 102; //Пусть это будет ключ - в двоичной форме 1100110
            int encrypt = x ^ key; //Результатом будет число 1001011 или 75
            Console.WriteLine("Зашифрованное число: " + encrypt);

            int decrypt = encrypt ^ key; // Результатом будет исходное число 45
            Console.WriteLine("Расшифрованное число: " + decrypt);

            //Логическое отрицание (инверсия)
            int z = 12;                 // 00001100
            Console.WriteLine(~z);      // 11110011   или -13

            int x5 = 12;
            int y5 = ~x5;
            y5 += 1;
            Console.WriteLine(y5);   // -12
        }
    }
}
