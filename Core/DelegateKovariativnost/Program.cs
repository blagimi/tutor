using System;

namespace DelegateKovariativnost
{
    delegate Person PersonFactory(string name); // Пример 1
    delegate void ClientInfo(Client client);    // Пример 2 Делегат принимает объект
    delegate T Builder<out T>(string name);     // Пример 3
    delegate void GetInfo<in T>(T Item);        // Пример 4

    class Program
    {
        static void Main()
        {
            /* Пример 1 Ковариативность
             * Здесь делегат возвращает объект Person. Однако благодаря ковариантности 
             * данный делегат может указывать на метод, который возвращает объект 
             * производного типа, например, Client. */

            PersonFactory personDel;    
            personDel = BuildClient;               // Ковариативность
            Person p = personDel("Tom");
            Console.WriteLine(p.Name);

            /* Пример 2 Контрвариативность 
             Несмотря на то, что делегат в качестве параметра принимает объект Client, 
            ему можно присвоить метод, принимающий в качестве параметра объект базового 
            типа Person.*/

            ClientInfo clientInfo = GetPersonInfo;  // Контрвариативность
            Client client = new Client { Name = "Alice" };
            clientInfo(client);

            /* Пример 3 
             Благодаря использованию out мы можем присвоить делегату типа Builder<Person>
            делегат типа Builder<Client> или ссылку на метод, который возвращает значение
            Client.*/

            Builder<Client2> clientBuilder = GetClient;
            Builder<Person2> personBuilder1 = clientBuilder;  // Ковариативность
            Builder<Person2> personBuilder2 = GetClient;      // Ковариативность

            Person2 person2 = personBuilder1("Tom");         // Вызов делегата
            person2.Display();                               // Client: Tom

            /* Пример 4 
             Использование ключевого слова in позволяет присвоить делегат с более 
            универсальным типом (GetInfo<Person>) делегату с производным типом 
            (GetInfo<Client>).*/

            GetInfo<Person2> personInfo2 = PersonInfo;
            GetInfo<Client2> clientInfo2 = personInfo2;      // Контрвариативность

            Client2 client2 = new Client2 { Name = "Jack" };
            clientInfo2(client2);                            // Client: Jack
        }

        /* Пример 1 */

        private static Client BuildClient (string name)
        {
            return new Client { Name = name };
        }

        /* Пример 2 */

        private static void GetPersonInfo( Person p)
        {
            Console.WriteLine(p.Name);
        }

        /* Пример 3 */

        private static Person2 GetPerson(string name)
        {
            return new Person2 { Name = name };
        }
        private static Client2 GetClient(string name)
        {
            return new Client2 { Name = name };
        }

        /* Пример 4 */

        private static void PersonInfo(Person2 p)
        {
            p.Display();
        }
        private static void ClientInfo (Client2 cl)
        {
            cl.Display();
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
    class Client : Person
    {

    }

    /* Пример 3 */

    class Person2
    {
        public string Name { get; set; }
        public virtual void Display()
        {
            Console.WriteLine($"Person {Name}");
        }
    }
    class Client2 : Person2
    {
        public override void Display()
        {
            Console.WriteLine($"Client {Name}");
        }
    }
}
