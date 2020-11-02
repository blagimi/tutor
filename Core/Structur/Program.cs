using System;
using System.Runtime.CompilerServices;

namespace Structur
{
    /* Отличие структуры от класса заключается в типе значений, класс ссылочный тип, структуры имеют тип значений */
    struct User
    {
        public string name;
        //public string name2 = "jill"; Нельзя присваивать значения по умолчанию
        public int age;
        public User(string name, int age)   //Конструктор в структурах должен описывать ВСЕ поля
        {
            this.name = name;
            this.age = age;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name} Age: {age}");
        }
    }
    class Program
    {
        static void Main()
        {
            User tom = new User("Tom", 34); // "Tom" 34
            tom.DisplayInfo();
            User bob = new User();  // " " 0 
            bob.DisplayInfo();
            User person = new User { name = "Carl", age = 31 }; //Инициализация
            person.DisplayInfo();
            Console.ReadKey();
        }
    }
}
