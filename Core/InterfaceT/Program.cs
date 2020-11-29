using System;

namespace InterfaceT
{
    class Program
    {
        static void Main()
        {

            /* Пример 1 */

            Client account1 = new Client("Tom", 200);
            Client account2 = new Client("Bob", 300);
            Transaction<Client> transaction1 = new Transaction<Client>();
            transaction1.Operate(account1, account2, 150);

            /* Пример 2 */

            IClientAccount account3 = new ClientAccount("Alice", 400);
            IClientAccount account4 = new ClientAccount("Kate", 500);
            Transaction<IClientAccount> transaction2 = new Transaction<IClientAccount>();
            transaction2.Operate(account3, account4, 200);

            /* Пример 3 */

            IUser<int> user1 = new User<int>(6789);
            Console.WriteLine(user1.Id);
            IUser<string> user2 = new User<string>("12345");
            Console.WriteLine(user2.Id);
        }
    }

    class Client: IAccount,IClient
    {
        int _sum;
        public string Name { get; set; }
        public Client (string name, int sum)
        {
            Name = name;
            _sum = sum;
        }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Put(int sum)
        {
            _sum += sum;
        }
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
            }
        }
    }

    /* Пример 1 Интрефейсы и обобщения
     * параметр T представляет тип, который который реализует сразу два интерфейса 
     * IAccount и IClient. Например, выше определен класс Client, который реализует 
     * оба интерфейса, поэтому мы можем данным типом типизировать объекты Transaction */
    
    class Transaction <T> where T: IAccount,IClient
    {
        public void Operate (T acc1, T acc2, int sum)
        {
            if (acc1.CurrentSum>=sum)
            {
                acc1.Withdraw(sum);
                acc2.Put(sum);
                Console.WriteLine($"{acc1.Name}:{acc1.CurrentSum} \n{acc2.Name}:{acc2.CurrentSum}");
            }
        }
    }

    /* Пример 2 
    Также параметр класса Transaction T может представлять интерфейс, 
    который наследуется от обоих интерфейсов:*/

    class ClientAccount : IClientAccount
    {
        int _sum;
        public ClientAccount (string name, int sum)
        {
            _sum = sum; Name = name;
        }
        public string Name { get; set; }
        public int CurrentSum { get { return _sum; } }
        public void Put (int sum)
        {
            _sum += sum;
        }
        public void Withdraw (int sum)
        {
            if (sum <= _sum) _sum -= sum;
        }
    }

    /* Пример 3 обобщённые интерфейсы */

    class User<T>: IUser<T>
    {
        T _id;
        public User(T id)
        {
            _id = id;
        }
        public T Id { get { return _id; } }
    }
}
