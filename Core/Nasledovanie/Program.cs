using System;

namespace Nasledovanie
{
    class Program
    {
        static void Main()
        {
            Person bill = new Person("Bill");
            bill.Dispay();
            Employee tom = new Employee("Tom", 22, "Microsoft");
            tom.Dispay();
        }
    }
    class Person                            // Человек
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person (string name)         // Конструктор Person
        {
            this.Name = name;
            Console.WriteLine("Person(string name)");
        }
        public Person (string name, int age) :this (name)
        {
            this.Age = age;
            Console.WriteLine("Person(string name, int age)");
        }
        public void Dispay ()               // Метод выводящий имя
        {
            Console.WriteLine(Name);
        }
    }
    class Employee : Person                 // Сотрудник
    {
        public string Company { get; set; } // Свойство
        public Employee(string name, int age, string company) : base(name,age)   // Конструктор Employee который обращается за name в конструктор базового класса Person
        {
            this.Company = company;
            Console.WriteLine("Employee(string name, int age, string company)");
        }
    }
}
