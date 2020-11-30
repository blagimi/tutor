using System;

/* Деконструкторы (не путать с деструкторами) позволяют выполнить декомпозицию объекта
 * на отдельные части. */

namespace Deconstructor
{
    class Program
    {
        static void Main()
        {
            Person person = new Person { Name = "Tom", Age = 33 };
            (string name, int age) = person;
            Console.WriteLine(name);
            Console.WriteLine(age);
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Deconstruct (out string name, out int age)
        {
            name = this.Name;
            age = this.Age;
        }
    }
}
