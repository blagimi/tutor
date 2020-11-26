using System;

namespace DelegateKovariativnost
{
    delegate Person Persons(string name);

    class Program
    {
        static void Main()
        {
            Persons persons;
            persons = BuildClient;
            Person person = persons("Tom");
            Console.WriteLine(person.Name);
            
        }
        private static Client BuildClient (string name)
        {
            return new Client { Name = name };
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
    class Client : Person
    {

    }
}
