using System;

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Account.bonus);       // 100
            Account.bonus += 200;                   // статическое поле bonus увеличивается на 200
            Account account1 = new Account(150);    // 150 + 300
            Console.WriteLine(account1.totalSum);   // 450
            Account account2 = new Account(1000);   // 1000 + 300
            Console.WriteLine(account2.totalSum);   // 1300
            Bank.MinSum = 100;
            decimal result = Bank.GetSum(100, 10,5);
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            User.DisplayCounter();
            Person tom;
            tom = new Person(34); // Вызов статического конструктора
            Person.retirementAge = 65;
            tom.Display();

        }
    }
    class Account
    {
        public static decimal bonus = 100;  // static распологается в куче который будет общим для всех обьектов класса
        public decimal totalSum;
        public Account (decimal sum)
        {
            totalSum = sum + bonus;
        }
    }
    class Bank
    {
        public Bank(decimal sum, decimal rate)
        {
            if (sum < MinSum) throw new Exception("Недопустимая сумма");
            Sum = sum; Rate = rate;
        }
        private static decimal minSum = 100; //Поле
        public static decimal MinSum    // Свойство
        {
            get { return minSum; }
            set { if (value>0) minSum = value; }
        }
        public decimal Sum { get; private set; }    // Сумма на счёте
        public decimal Rate { get; private set; }   // Процентная ставка
        public static decimal GetSum(decimal sum, decimal rate, int period)
        {
            decimal result = sum;
            for (int i = 1; i <= period; i++)
                result += result * rate / 100;      //100 * 10/100=10 // 100+10=110  х5
            return result;
        }
    }
    /* Использование статических полей для счётчика */
    class User
    {
        private static int counter = 0;
        public User ()
        {
            counter++;
        }

        public static void DisplayCounter()
        {
            Console.WriteLine($"Создано {counter} обьектов User");
        }
    }

    class Person
    {
        public static int retirementAge = 60;
        int _age;
        static Person()
        {
            Console.WriteLine(retirementAge);
        }
        public Person (int age)
        {
            _age = age;
        }
        public void Display()
        {
            if (_age >= retirementAge) Console.WriteLine("Вы уже на пенсии");
            else Console.WriteLine($"До пенсии осталось {retirementAge - _age} лет");
        }
    }
}
