using System;
/* Анонимные типы позволяют создать объект с некоторым набором свойств без 
 * определения класса. Анонимный тип определяется с помощью ключевого слова 
 * var и инициализатора объектов */

namespace AnonimType
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Инициализация анонимных типов */
            var user = new { Name = "Tom", Age = 34 };
            var student = new { Name = "Alice", Age = 21 };
            var manager = new { Name = "Bob", Age = 26, Company = "Microsoft" };
            Console.WriteLine(user.Name);
            Console.WriteLine(user.GetType().Name);
            Console.WriteLine(student.GetType().Name);
            Console.WriteLine(manager.GetType().Name);
            // manager.Age = 35; //Объект доступен только для чтения

            /* Пример2 Инициализаторы с проекцией 
            Кроме исользованной выше формы инициализации, когда мы присваиваем свойствам 
            некоторые значения, также можно использовать инициализаторы с проекцией 
            (projection initializers), когда мы можем передать в инициализатор некоторые 
            идиентификаторы, имена которых будут использоваться как названия свойств*/

            User tom = new User("Tom");
            int age = 34;
            var student2 = new { tom.Name, age };   // Инициализатор с проекцией
            Console.WriteLine(student2.Name);       //  Tom
            Console.WriteLine(student2.age);        //  34

            /* Пример 3 Массивы анонимных типов */

            var people = new[]

            {
                new{Name="Tom"},
                new{Name="Bob"}
            };
            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
            }
        }
    }

    class User
    {
        public string Name { get; set; }
        public User (string name)
        {
            Name = name;
        }
    }
}
