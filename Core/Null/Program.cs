using System;

namespace Null
{
    class Program
    {
        static void Main(string[] args)
        {
            object x = null;
            object y = x ?? 100;  // равно 100, так как x равен null

            object z = 200;
            object t = z ?? 44; // равно 200, так как z не равен null

            // int x = 44; Переменные значений не могут быть null
            // int y = x ?? 100;
            User user = new User();
            // Console.WriteLine(user.Phone.Company.Name); Значения в классах по умолчанию null, их не вывести
            /* Предварительная проверка не является ли передаваемое значение null */
            if (user!=null)
            {
                if (user.Phone != null)
                {
                    if (user.Phone.Company != null)
                    {
                            string companyName = user.Phone.Company.Name;
                            Console.WriteLine(companyName);
                    }
                }
            }
            /* Сокращённая конструкция */
            User user1 = new User();
            if (user1 != null && user1.Phone != null && user1.Phone.Company != null)
            {
                string companyName1 = user1.Phone.Company.Name;
                Console.WriteLine(companyName1);
            }
            /* Конструкция с условным null */
            User user2 = new User();
            string companyName2 = user2?.Phone?.Company?.Name;
            Console.WriteLine(companyName2);
            /* Добавление значения по умолчанию если выводится null*/
            User user3 = new User();
            string companyName3 = user3?.Phone?.Company?.Name ?? "Не установленно";
            Console.WriteLine(companyName3);
        }
    }
    class User
    {
        public Phone Phone { get; set; }
    }

    class Phone
    {
        public Company Company { get; set; }
    }

    class Company
    {
        public string Name { get; set; }
    }
}
