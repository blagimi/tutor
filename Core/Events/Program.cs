using System;

namespace Events
{
    class Program
    {
        static void Main()
        {
            Account account = new Account(100);
            account.Notify2 += DisplayMessage;

            /* Установка в качестве обработчика анонимного метода 
            account.Notify += delegate (string message)
            {
                Console.WriteLine(message);
            };
            */
            /* Установка в качестве обработчика лямбда выражение
            account.Notify += message => Console.WriteLine(message);
            */

            //account.Notify2 += DisplayRedMessage;    // Добавление обработчика события
            account.Put(20);
            //account.Notify2 -= DisplayRedMessage;    // Удаление обработчика события
            account.Take(70);
            account.Take(180);                      // Вывод сообщения об ошибке
        }
        private static void DisplayMessage(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
        }
        private static void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    /* Создаём класс Аккаунт*/
    class Account
    {
        public delegate void AccountHandler(object sender, AccountEventArgs e);    // Создаём делегат
        public event AccountHandler Notify;                     // Создаём событие представляющее делегат
        
        /* Добавление и удаление обработчиков с помощью акссесоров add/remove */
        
        private event AccountHandler notify2;
        public event AccountHandler Notify2
        {
            add     // Вызывается при добавление обработчика +=
            {

                /* Определение логики при добавлении */
                
                notify2 += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove  // Вызывается при удалении обработчика -=
            {
                notify2 -= value;
                Console.WriteLine($"{value.Method.Name} удалён");
            }
        }

        public int Sum { get; set; }    // Аккаунт хранит сумму средств на счёте
        public Account (int sum)        // Описываем конструктор класса аккаунт
        {
            Sum = sum;
        }
        public void Put (int sum)       // Метод добавления средств на счёт
        {
            Sum += sum;
            Notify?.Invoke(this, new AccountEventArgs ($"На счёт поступило: {sum}, текущий баланс счёта {Sum}",sum));
            notify2?.Invoke(this, new AccountEventArgs($"На счёт поступило: {sum}, текущий баланс счёта {Sum}",sum));
        }
        public void Take(int sum)       // Метод снятия средст со счёта
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke(this, new AccountEventArgs($"Со счёта снято: {sum}, текущий остаток на счёте {Sum}", sum));
                notify2?.Invoke(this, new AccountEventArgs($"Со счёта снято: {sum}, текущий остаток на счёте {Sum}", sum));
            }
            else                        // Вывод сообщения об ошибке при недостатке средств на счёте
            {
                Notify?.Invoke(this, new AccountEventArgs($"Недостаточно денег на счете для снятия. Текущий баланс: {Sum}", sum));
                notify2?.Invoke(this, new AccountEventArgs($"Недостаточно денег на счете для снятия. Текущий баланс: {Sum}", sum));
            }
        }
    }

    /* Класс данных событий */

    class AccountEventArgs
    {
        public string Message { get; }
        public int Sum { get; }
        public AccountEventArgs (string message, int sum)
        {
            Message = message;  // Хранение выводимого сообщения
            Sum = sum;          // Хранение суммы транзакции
        }
    }
}
