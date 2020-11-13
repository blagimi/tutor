using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace TryCatchFinally
{
    class Program
    {
        static void Main()
        {
            /* Пример использования try catch конструкции */

            int f = 1;
            int j = 0;
            try
            {
                Console.WriteLine("Введите строку");
                string message = Console.ReadLine();
                if (message.Length >6)
                {
                    throw new Exception("Длина строки больше 6 символов");  // оператор throw позволяет создавать свои исключения 
                }
                Person p = new Person { Name = "Tom", Age = 17 };
                int result = f / j;
                int x = 5;
                int y = x / 0;
                Console.WriteLine($"Результат: {y}");
            }
            catch (DivideByZeroException) when (f == 0 && j == 0)   // Фильтр исключений с добавлением условия
            {
                Console.WriteLine("f j не должны быть равны 0");
            }
            catch(DivideByZeroException ex)  // catch без указания исключения обрабатывает все
            {
                Console.WriteLine("Возникло исключение: " +ex.Message);   // Но можно указать конкретные и вывести их на экран
                Console.WriteLine("В методе: " +ex.TargetSite);
                Console.WriteLine("Трассировка стека: " +ex.StackTrace);
            }
            catch (PersonException ex)  // Искользование своего класса исключений
            {
                Console.WriteLine("Ошибка "+ex.Message);
            }
            catch (Exception globalEx)
            {
                Console.WriteLine("Ошибка: " +globalEx);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            Console.WriteLine("Конец программы");

            /* Условная конструкция для обработки исключений */

            Console.WriteLine("Введите число");
            int z;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out z))
            {
                z *= z;
                Console.WriteLine("Квадрат числа: "+z);
            }
            else
            {
                Console.WriteLine("Некоректный ввод");
            }

        }
    }
    class Person
    {
        private int age;
        public string Name { get; set; }
        public int Age {
            get { return age; }
            set { 
                if (value < 18) 
                    { 
                        throw new PersonException("Лицам до 18 регистрация запрещена"); 
                    }
                else { age = value; } }
        }
    }

    /* На тот случай если вдруг за чем-то хочется исключениям дать имена */
    class PersonException : Exception
    {
        public PersonException (string message) :base(message)
        { }
    }
}
