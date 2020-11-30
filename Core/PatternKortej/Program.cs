using System;
/* Паттерны кортежей позволяют сравнивать значения кортежей. Например, передадим конструкци switch 
 * кортеж с названием языка и времени дня и в зависимости от переданных данных возвратим
 * определенное сообщение.*/

namespace PatternKortej
{
    class Program
    {
        static void Main()
        {
            string message = GetWelcome("English", "Evening","User");
            Console.WriteLine(message); //  Good Morning
            message = GetWelcome("French", "Morning","User");
            Console.WriteLine(message); //  Здравствуйте
            message = GetWelcome("French", "Morning", "Admin");
            Console.WriteLine(message); //  Hello Admin
        }
        /* Нам не обязательно сравнивать все значения кортежа, мы можем использовать 
         * только некоторые элементы кортежа. В случае, если мы не хотим использовать 
         * элемент кортежа, то вместо него ставим прочерк */
        static string GetWelcome(string lang, string daytime, string status) => (lang, daytime,status) switch
        {
            ("English", "Morning", _) => "GoodMorning",
            ("English", "Evening", _) => "GoodEvening",
            ("German", "Morning", _) => "GutenMorgen",
            ("German", "Evening", _) => "GutenAbend",
            (_,_,"Admin")=>"Hello, Admin",
            _ => "Здраствуйте"
        };
    }
  
}
