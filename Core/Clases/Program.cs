using System;

namespace Clases
{
    /* Пример 2 */
    class Registration
    {
        public string name = "Ben";
        public int age = 18;
        public string email = "ben@gmail.com";
        public Registration (string name)                                           //this шаг3
        {                                                                           //Шаг 4, установка значения "bob" и запуск второго конструктора
            this.name = name;
        }
        public Registration(string name, int age) : this(name)                      // this шаг2 передача в первый конструктор "bob"
                                                                                    //Шаг 5 age присваивается 31 и запускается третий конструктор
        {
            this.age = age;
        }
        public Registration(string name, int age, string email) :this("Bob",age)    // this шаг 1 передача во второй конструктор "bob", age
                                                                                    //Шаг 6 email присваивается tom@gmail.com результат становится bob 31 to@gmail.com
        {
            this.email = email;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}, Почта: {email}");
        }
    }
    /* Пример 1 */
    class Person
    {
        public string name;
        public int age;
        /*Конструкторы класса */
        public Person() { name = "Неизвестно"; age = 0; }
        public Person(string n) { name = n; age = 0; }
        public Person(string n, int a) { name = n; age = a; }
        /* Метод вывода значений содержимого класса */
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name} Возраст: {age}");
        }
    }
    class Program
    {
        static void Main()
        {
            /* Конструктор по умолчанию */
            Person tom = new Person();
            tom.GetInfo(); //Имя: Возраст:0
            tom.name = "Tom";
            tom.age = 34;
            tom.GetInfo(); //Имя: Tom Возраст:34
            Console.ReadKey();
            /* Присваивание значений через конструкторы */
            Person jack = new Person();
            Person bob = new Person("Bob");
            Person sam = new Person("Sam", 25);
            Person kyle = new Person("Kyle", 15) { name = "Kartman", age = 15 };
            kyle.GetInfo();
            /* Инициализацоры обьектов, заменяют конструкторы */
            Person jeff = new Person { name = "Jeff", age = 31 };
            jack.GetInfo(); //
            bob.GetInfo();  // Вызов содержимого заполненого Конструктором
            sam.GetInfo();  //
            jeff.GetInfo(); // Инициализатором
            /* Пример 2 */
            Registration reg = new Registration("Tom", 31, "tom@gmail.com"); // bob 31 tom@gmail.com
            reg.GetInfo();
            Registration reg2 = new Registration("Carl",22);
            reg2.GetInfo();

        }
    }
}
