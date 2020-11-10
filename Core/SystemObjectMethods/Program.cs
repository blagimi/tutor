using System;

namespace SystemObjectMethods
{
    class Program
    {
        static void Main()
        {
            Person person = new Person();
            Console.WriteLine(person.ToString());           // выведет значение по умолчанию. Полное название класса Person, ПространствоИмён.НазваниеКласса
            Person person1 = new Person { Name = "Tom" };
            Console.WriteLine(person1.ToString());          // Tom
            Person person2 = new Person() { Name = "Sara" };
            Console.WriteLine(person2.GetHashCode());       // Получение хэшкода
            Console.WriteLine(person2.GetType());           // Получение типа обьекта
            Person person3 = new Person() { Name = "Scot" };
            if (person3.GetType() == typeof(Person))        // Получение типа и проверка является ли он заданным типом
                Console.WriteLine("Это действительно класс Person");
            Clock clock = new Clock { Hours = 15, Minutes = 34, Seconds = 53 };
            Console.WriteLine(clock.ToString());            // 15:34:53

            Person person4 = new Person { Name = "Tom" };
            bool p1p4 = person1.Equals(person4);
            Console.WriteLine(p1p4);                        // True
            bool p1p3 = person1.Equals(person3);
            Console.WriteLine(p1p3);                        // False


        }
    }
    class Clock
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public override string ToString()                   // Переопределяем метод базового класса System.Object 
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }
    class Person
    {
        public string Name { get; set; }
        
        public override string ToString()                   // Переоредяем метод базового класса для проверки заполнения свойства Name и его вывода, если нет вызов стандартной реализации. 
        {
            if (string.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /* Метод Equals принимает в качестве параметра объект любого типа, который мы затем приводим к текущему,
         * если они являются объектами одного класса. Затем сравниваем по именам. Если имена равны, возвращаем true, 
         * что будет говорить, что объекты равны. */

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            
            Person person = (Person)obj;
            return this.Name == person.Name;
        }
    }
}
