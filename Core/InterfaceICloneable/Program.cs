using System;
/* Поскольку классы представляют ссылочные типы, объекты p1 и p2 будут указывать на один 
 * и тот же объект в памяти, поэтому изменения свойств в переменной p2 затронут 
 * также и переменную p1. */

namespace InterfaceICloneable
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Копирование объектов 
             * Чтобы переменная p2 указывала на новый объект, но со значениями из p1, 
             * мы можем применить клонирование с помощью реализации интерфейса ICloneable.*/
            Person person1 = new Person { Name = "Tom", Age = 23, Work=new Company {Name="Microsoft" } };
            Person person2 = (Person)person1.Clone();
            person2.Name = "Alice";
            person2.Work.Name = "Google";
            Console.WriteLine(person1.Name);        //  Tom
            Console.WriteLine(person2.Name);        //  Alice
            Console.WriteLine(person1.Work.Name);   //  Microsoft
            Console.WriteLine(person2.Work.Name);   //  Google
        }
    }

    class Person: ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }           //  Ссылка на объект Company
        public object Clone()
        {
            Company company = new Company { Name = this.Work.Name };
            return new Person { Name = this.Name, Age = this.Age, Work=company };
        }
    }
    class Company
    {
        public string Name { get; set; }
    }
}
