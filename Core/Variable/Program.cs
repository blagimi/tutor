using System;       //Подключение пространства имён 

namespace Variable  //Создание нового пространства имён
{
    class Program   //Описание базового класса 
    {
        static void Main(string[] args)         //Точка входа в программу
        {
            /* Инициализация пересенных и вывод их на консоль */
            string name = "Tom";
            int age = 33;
            bool isEmployed = false;
            double weight = 78.65;
            Console.WriteLine($"Имя : {name} Возраст: {age} Вес: {weight} Работает: {isEmployed}");
            Console.ReadKey();
            /* Ручной ввод и присвоения значений переменным и их вывод на консоль*/
            Console.WriteLine("Введите имя ");
            string secondName = Console.ReadLine();
            Console.WriteLine("Введите возраст ");
            int secondage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите рост ");
            double secondHeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите размер зарплаты ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"Имя : {secondName} Возраст: {secondage} Рост: {secondHeight} Зарплата: {salary}");

        
        }
    }
}
