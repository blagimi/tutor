using System;

namespace InterfaceBasics
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 */

            Console.WriteLine(IMove.MaxSpeed);
            IMove.MaxSpeed = 65;
            Console.WriteLine(IMove.MaxSpeed);
            double time = IMove.GetTime(100, 10);
            Console.WriteLine(time);

            /* Пример 2*/

            Person person = new Person();
            Car car = new Car();
            Action(person);                     // Человек идёт
            Action(car);                        // Машина едет

            /* Пример 3 Значения по умолчанию
             * В данном случае интерфейс IMovable определяет реализацию по умолчанию для метода Move.
            Класс Person в отличии от Car не реазизует метод Turbo интрефейса IMovable 
            поэтому при вызове используется значение по умолчанию которое 
            определенно в самом интерфейсе.
            Если мы добавим в этот интерфейс новый метод, 
            то мы будем обязаны реализовать этот метод во всех классах, 
            применяющих данный интерфейс. Иначе подобные классы просто не будут 
            компилироваться. Теперь вместо реализации метода во всех классах нам 
            достаточно определить его реализацию по умолчанию в интерфейсе. 
            Если класс не реализует метод, будет применяться реализация по умолчанию.*/


            IMovable tom = new Person();        // Интерфейс опеределяет реализацию
            Car tesla = new Car();
            tom.Turbo();                        // Ускоряется
            tesla.Turbo();                      // Машина ускоряется

            /* Код приведённый ниже вызовет ошибку, поскольку опеределение для метода Turbo
             * в классе Person нет и поскольку не было указано напрямую что интерфейс определяет 
             реализацию этот метод недоступен.
            *Person jack = new Person();         
            *jack.Turbo();                       // Ошибка
            */

            /* Пример 3 Множественная реализация интерфейсов*/

            Client client = new Client("Tom", 200);
            client.Put(30);
            Console.WriteLine(client.CurrentSum);   // 230
            client.Withdraw(250);
            client.Withdraw(100);
            Console.WriteLine(client.CurrentSum);   // 130

            /* Пример 4 Преобразование типов 
            Преобразование от класса к его интерфейсу, как и преобразование от производного 
            типа к базовому, выполняется автоматически. Так как любой объект Client реализует 
            интерфейс IAccount. 
            Обратное преобразование - от интерфейса к реализующему его классу 
            будет аналогично преобразованию от базового класса к производному. 
            Так как не каждый объект IAccount является объектом Client 
            (ведь интерфейс IAccount могут реализовать и другие классы), то для подобного 
            преобразования необходима операция приведения типов. И если мы хотим 
            обратиться к методам класса Client, которые не определены в интерфейсе 
            IAccount, но являются частью класса Client, то нам надо явным образом 
            выполнить преобразование типов*/

            IAccount account = new Client("Jack", 200);
            account.Put(200);
            Console.WriteLine(account.CurrentSum);  // 400
            // Не все объекты IAccount являются объектами Client, необходимо явное привидение
            Client client1 = (Client)account;
            // Интерфейс IAccount не имеет свойста Name, необхомо явное приведение
            string clientName = ((Client)account).Name;
            Console.WriteLine(clientName);          // Jack
        }

        /* Пример 2 */

        static void Action(IMovable movable)    // Метод принимающий интерфейс
        {
            movable.Move();         // Вызов реализация метода Move интерфейса IMovable
        }
    }

    /* Пример 2*/

    class Person : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Человек идёт");
        }
    }

    /* Пример 2*/

    struct Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Машина едет");
        }
        public void Turbo()
        {
            Console.WriteLine("Машина ускоряется");
        }
    }

    /* Пример 3 */
    
    class Client :  IAccount,IClient
    {
        int _sum;   // Переменная для хранения суммы
        public string Name { get; set; }
        public Client (string name,int sum)
        {
            Name = name;
            _sum = sum;
        }
        public int CurrentSum { get { return _sum; } }
        public void Put(int sum) { _sum += sum; }
        public void Withdraw (int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
            else
            {
                Console.WriteLine("На счету недостаточно средств для снятия");
            }
        }
    }
}
