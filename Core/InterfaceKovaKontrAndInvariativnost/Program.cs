using System;
/* Понятия ковариантности и контравариантности связаны с возможностью 
 * использовать в приложении вместо некоторого типа другой тип, 
 * который находится ниже или выше в иерархии наследования.
 * Имеется три возможных варианта поведения:
 *   -Ковариантность: позволяет использовать более конкретный тип, чем заданный изначально
 *   -Контравариантность: позволяет использовать более универсальный тип, чем заданный изначально
 *   -Инвариантность: позволяет использовать только заданный тип */

namespace InterfaceKovaKontrAndInvariativnost
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Ковариативные интерфейсы 
            То есть мы можем присвоить более общему типу IBank<Account> объект более 
            конкретного типа IBank<DepositAccount> или Bank<DepositAccount>.*/

            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            Account account1 = depositBank.CreateAccount(34);
            //Клиент положил на депозитный счёт 34 доллара 

            IBank<Account> ordinaryBank = new Bank<DepositAccount>();
            Account account2 = ordinaryBank.CreateAccount(45);
            // Клиент положил на депозитный счёт 45 долларов

            /* Контрвариативные интерфейсы 
            Так как интерфейс ITransaction использует универсальный параметр с ключевым 
            словом in, то он является контравариантным, поэтому в коде мы можем объект 
            Transaction<Account> привести к типу ITransaction<DepositAccount>*/

            ITransaction<Account> accountTransaction1 = new Transaction<Account>();
            accountTransaction1.DoOperation(new Account(), 400);
            // Клиент положил на счёт 400 долларов

            ITransaction<DepositAccount> depositeAccountTransaction1 = new Transaction<Account>();
            depositeAccountTransaction1.DoOperation(new DepositAccount(), 450);
            // Клиент положил на депозитный счёт 450 долларов
        }
    }
    class Account
    {
        public virtual void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на счёт {sum} долларов");
        }
    }
    class DepositAccount: Account
    {
        public override void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на депозитный счёт {sum} долларов");
        }
    }

    /* Пример 1 Ковариативный интерфейс 
    Обобщенный интерфейс IBank определяет метод CreateAccount для создания счета.
    Класс Bank, который представляет условный банк, реализует этот интерфейс 
    и возвращает из метода CreateAccount объект, который представляет либо 
    класс Account, либо один из его наследников.*/

    class Bank<T>: IBank<T> where T: Account, new()
    {
        public T CreateAccount (int sum)
        {
            T account = new T();
            account.DoTransfer(sum);
            return account;
        }
    }

    /* Пример 2 Контрвариативные интерфейсы */

    class Transaction<T>: ITransaction<T> where T: Account
    {
        public void DoOperation(T account, int sum)
        {
            account.DoTransfer(sum);
        }
    }
}
