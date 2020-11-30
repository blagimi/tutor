using System;
/* Паттерн свойств позволяет сравнивать со значениями определенных свойств объекта */

namespace PatternSvoistva
{
    class Program
    {
        static void Main()
        {
            Person pierre = new Person { Language = "French", Status = "User", Name = "Pierre" };
            string message = GetMessage(pierre);
            Console.WriteLine(message);             //  Salut!

            Person tomas = new Person { Language = "German", Status = "Admin", Name = "Tomas" };
            Console.WriteLine(GetMessage(tomas));   //  Hello admin!

            Person pablo = new Person { Language = "Spanish", Status = "User", Name = "Pablo" };
            Console.WriteLine(GetMessage(pablo));   //  Unknown language Spanish

            Person bob = null;
            Console.WriteLine(GetMessage(bob));     //  Null
        }
        /* Теперь в методе в зависимости от статуса и языка пользователя выведем ему определенное 
         * сообщене, применив паттерн свойств */
        static string GetMessage(Person person) => person switch
        {
            { Language: "English" } => "Hello!",
            { Language: "German", Status: "Admin" } => "Hallo, Admin!",
            /* Так, подвыражение Name: var name говорит, что надо передать в переменную name значение 
             * свойства Name. Затем ее можно применить при генерации выходного 
             * значения: => $"Salut, {name}!"*/
            { Language: "French", Name: var name } => $"Salut!, {name}",
            /* Кроме того, мы можем определять в паттерных свойств переменные, передавать этим 
             * переменным значения объекта и использовать при возвращении значения. */
            { Language: var lang } => $"Unknown language: {lang}",
            null => "null"
        };
    }
    class Person
    {
        public string Name { get; set; }            //  Имя пользователя
        public string Status { get; set; }          //  Статус пользователя
        public string Language { get; set; }        //  Язык пользователя
    }
}
