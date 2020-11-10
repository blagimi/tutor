using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GenericsObobsheniya
{
    class Program
    {
        static void Main()
        {
            Account<int> account1 = new Account<int> { Sum = 5000 };
            Account<string> account2 = new Account<string> { Sum = 4000 };
            Account<int> account3 = new Account<int> { Sum = 2000 };
            account1.Id = 2;                    // Принимает значение типа int в id
            account2.Id = "4567";               // Принимает значение типа string в id
            int id1 = account1.Id;
            string id2 = account2.Id;
            Account<int>.session = 5436;        // Присваивание статических значений
            Account<string>.session = "4577";   //
            Console.WriteLine(id1);             // Вывод для проверки
            Console.WriteLine(id2);             // Вывод для проверки   
            Console.WriteLine(Account<int>.session);
            Console.WriteLine(Account<string>.session);

            Transaction<Account<int>, string> transaction1 = new Transaction<Account<int>, string>
            {
                FromAccount = account1,
                ToAccount = account3,
                Code = "01",
                Sum = 900
            };

            Account2 account21 = new Account2(1743) { Sum = 4500 };
            Account2 account22 = new Account2(1144) { Sum = 5000 };
            Transaction2<Account2> transaction2 = new Transaction2<Account2>
            {
                FromAccount = account21,
                ToAccout = account22,
                Sum = 500
            };
            transaction2.Execute();
            

            int x = 7;
            int y = 25;
            Swap.Swaping<int>(ref x, ref y);
            Console.WriteLine($"x={x} y={y}");
            string s1 = "Hello";
            string s2 = "Bye";
            Swap.Swaping<string>(ref s1, ref s2);
            Console.WriteLine($"s1={s1} s2={s2}");


            int[] mas1 = { 1, 2, 3, 3, 5, 6 };
            MassiveBuilder<int> massive = new MassiveBuilder<int>();

            Collection<int> numbers = new Collection<int>();
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);

            numbers.Remove(2); // попытка удалить элемента, которого нет в коллекции
            numbers.Remove(3);

        }
    }
    /* Generics, обобщенный тип, универсальный шаблон/тип */

    class Account <Gen>             // Параметр в угловых скобках считается универсальным, наименование любое
    {
        // Gen id = default(Gen);   // Присваивание ссылочным тимпам в качестве зачения null, типам значений 0
        public Gen Id { get; set; } // Присваиваемый тип становится универсальным
        public int Sum { get; set; }
        public static Gen session;  // Определение статических полей
    }
    /* Использование несколько униварельных параметров */

    class Transaction <Unv1,Unv2>
    {
        public Unv1 FromAccount { get; set; }
        public Unv1 ToAccount { get; set; }
        public Unv2 Code { get; set; }
        public int Sum { get; set; }
    }
    /* Использование обобщеного метода */
    class Swap
    {
        /* метод Swap, который принимает параметры по ссылке и меняет их значения. 
         * При этом в данном случае не важно, какой тип представляют эти параметры.*/
        public static void Swaping <Unv> (ref Unv x, ref Unv y)
        {
            Unv temp = x;
            x = y;
            y = temp;
        }
    }
    class Instantiator<Unv>
    {
        public Unv instance;
        public Instantiator()
        {
            instance = default(Unv);
        }
    }

    class Account2
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public Account2 (int _id)
        {
            Id = _id;
        }
    }
    class Transaction2<Unv> where Unv: Account2     // where Ограничение обобщеного класса
    {
        public Unv FromAccount { get; set; }
        public Unv ToAccout { get; set; }
        public int Sum { get; set; }
        public void Execute()
        {
            if (FromAccount.Sum>Sum)
            {
                FromAccount.Sum -= Sum;
                ToAccout.Sum += Sum;
                Console.WriteLine($"Счёт {FromAccount.Id}: {FromAccount.Sum}$ 'n Счёт {ToAccout.Id}: {ToAccout.Sum}$");
            }
            else
                Console.WriteLine($"Недостаточно денег на счёте {FromAccount.Id}");
        }
    }

    class MassiveBuilder<Unv>
    {
        Unv[] MyMassive;

        public MassiveBuilder()
        {
            MyMassive = new Unv[0];
        }

        public void Add (Unv item)
        {
            Unv[] newMassive = new Unv[MyMassive.Length + 1];
            for (int i = 0; i < MyMassive.Length; i++)
            {
                newMassive[i] = MyMassive[i];
            }
            newMassive[MyMassive.Length] = item;
            MyMassive = newMassive;
        }
        public void Remove (Unv item)
        {
            int index = -1;
            for (int i = 0; i < MyMassive.Length; i++)
            {
                if (MyMassive[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index > -1)
            {
                Unv[] newMassive = new Unv[MyMassive.Length - 1];
                for (int i = 0, j = 0; i < MyMassive.Length; i++)
                {
                    if (i == index) continue;
                    newMassive[j] = MyMassive[i];
                    j++;
                }
                MyMassive = newMassive;
            }
        }
        public Unv GetItem(int index)
        {
            if (index > -1 && index < MyMassive.Length)
            {
                return MyMassive[index];
            }
            else
                throw new IndexOutOfRangeException();
        }
        public int Count()
        {
            return MyMassive.Length;
        }

    }
}
