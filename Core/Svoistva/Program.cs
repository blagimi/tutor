using System;
using System.Net.Cache;
using System.Reflection.Metadata.Ecma335;

namespace Svoistva
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Age = 17; // Вывод предупреждения об ограничении по возрасту
            p.Name = "Tom";
            //p.Family = "Valentine"; Family доступно только для чтения
            Console.WriteLine("Имя: {0} Отчество: {1} Фамилия {2}",p.Name,p.SecondName,p.Family); //Tom Jeff
        }
    }
    class Person
    {
        public string Name { get; set; } // Автоматическое свойство
        public string SecondName { get; set; } = "Jeff"; // Автоматическое свойство со значением по умолчанию
        public string Family => family ="Simpson"; // Сокращенная запись эквивалентно public string Family { get { return family; } } 
        /* Поле для свойства Age */
        private int age;
        private string family;
        /* Свойство Age с логикой    для проверки вводимого возраста в поле age */
        public int Age
        {
            get { return age; }
            set
            {
                if (value<18)
                    { Console.WriteLine("Возраст должен быть больше 18");}
                else { age = value; }
            }
        }
        
    }
}
