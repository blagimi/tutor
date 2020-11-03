using System;
using System.Globalization;

namespace VoshodyashieNizhodyshiePreobrazovania
{
    class Program
    {
        static void Main()
        {
            Employee emp1 = new Employee("Tom", "Microsoft");   // Работник emp1 с именем Tom работает в Майкрософт
            Person person1 = emp1;                              // Человек person1 получает ссылку на emp1 и теперь представляет теже значения 
            Console.WriteLine(person1.Name);                    // Tom Но поскольку это восходящее преобразование person1 не содержит поля company 
                                                                // Преобразование от производного к базовому типу
            /* Еще примеры */
            
            Person person2 = new Employee("Tom", "Microsoft");  // от person к работнику    
            Person person3 = new Client("Bob", "ContosoBank");  // от person к клиент
            
            /* Конец восходящих примеров */
            
            Person person5 = new Client("Bob", "ContosoBank");  
            Client client1 = (Client)person5;                   // Нисходящее преобразование не каждый человек является клиентом
            Console.WriteLine(client1.Name) ;                   // Bob 
            
            /* Способы преобразований */
            
            /* Ключевое слово AS программа попытается преобразовать к определенному типу, без исключений null, при неудаче*/

            Person person7 = new Person("Jeff");
            Employee employee2 = person7 as Employee;  // Преобразование неудачно не каждый человек работник
            if (employee2 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(employee2.Company);
            }

            /* Отлавливание исключения */

            Person person8 = new Person("Tom");
            try
            {
                Employee employee3 = (Employee)person8; // Преобразование неудачно не каждый человек работник
                Console.WriteLine(employee3.Company);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message + " Преобразование неудачно");
            }

            /* Проверка допустимпости преобразования IS */

            Person person9 = new Person("Tom");
            if (person9 is Employee)
            {
                Employee employee4 = (Employee)person9; // Преобразование неудачно не каждый человек работник
                Console.WriteLine(employee4.Company);
            }
            else
            {
                Console.WriteLine("Преобразование недопустимо");
            }
        }
    }
    class Person                // Человек
    {
        public string Name { get; set; }    // Свойство Имя

        public Person (string name)         // Конструктор принимающий имя
        {
            Name = name;
        }
        public void Display()               // Метод возвращающий имя
        {
            Console.WriteLine($"Person name {Name}");
        }
    }
    class Employee : Person     // Работник
    {
        public string Company { get; set; }   // Свойство название компании
        public Employee (string name, string company) :base(name)   // Конструктор принимающий Имя и название компании, имя передаётся из базового класса
        {
            Company = company;
        }
    }
    class Client : Person       // Клиент
    {
        public string Bank { get; set; }        // Свойство название банка
        public Client (string name, string bank) :base(name)    // Конструктор принимающий имя и название банка, имя передаётся из базового класса
        {
            Bank = bank;
        }
    }
}
