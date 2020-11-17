using System;

namespace Delegati
{
    delegate void Message();                // Обьявляем делегат
    delegate int Operation(int x, int y);
    class Program
    {
        delegate int Operation2(int x, int y);
        delegate void MessageHandler(string message);
        static void Main()
        {
            /* Пример 1 */
            Console.WriteLine("Пример 1: ");

            Message message;                // Создаём переменную делегата
            if (DateTime.Now.Hour < 12)
            {
                message = GoodMorning;      // Присваиваем этой переменной адрес метода
            }
            else
            {
                message = GoodEvening;
            }
            message();                      // Вызываем метод

            /* Пример 2 */
            Console.WriteLine("Пример 2: ");

            Operation operation = Add;      // Указание на метода ADD
            int result = operation(4, 5);   // Add 4 5
            Console.WriteLine(result);
            operation = Multiply;           // Указание на метод Multiply
            result = operation(4, 5);       // Multiply 4 5
            Console.WriteLine(result);

            /* Пример 3 */
            Console.WriteLine("Пример 3: ");

            Math math = new Math();
            Operation2 operation2 = math.Sum;   // указание делегата на другой класс, где он не обьявлен 
            int result2 = operation2(4, 5);
            Console.WriteLine(result2);

            /* Пример 4 */
            Console.WriteLine("Пример 4: ");

            message = Hello;                // Указываем на метод hello
            message += HowAreYou;           // добавляем к нему метод howareyou
            message();                      // Hello How Are you? в 2 строчки т.к вызываеются оба метода
            message += Hello;
            message += Hello;
            message();                      // 3 раза вызывается Hello и один раз HowAreYou
            message -= HowAreYou;
            message();                      // 3 раза вызывается Hello

            Message message1 = Hello;
            Message message2 = HowAreYou;
            Message message3 = message1 + message2; // Объединение делегатов значит, что в список вызова делегата mes3 попадут все методы из делегатов mes1 и mes2.
            message3();

            /* Пример 5 */
            Console.WriteLine("Пример 5: ");

            Message message4 = Hello;
            message4.Invoke(); // Другой способ вызова делегатов
            Operation operation3 = Add;
            int result3 = operation3.Invoke(3, 4);
            Console.WriteLine(result3);
            Message message5 = null;
            message5?.Invoke(); // При вызове делегата лучше проверять не равен ли он null не то исключение 

            /* Пример 6
             * Анонимный метод */
            Console.WriteLine("Пример 6: ");

            MessageHandler handler = delegate (string mes) // Создание анонимного метода delegate ключевое слово
            {
                Console.WriteLine(mes);
            };
            handler("Hello World");

            ShowMessage("Hello",delegate(string mes)    // Другой пример анононимных методов - передача в качестве аргумента для параметра
                {
                Console.WriteLine(mes);
            });

            /* Если анонимный метод использует параметры, то они должны соответствовать параметрам делегата.
             *  Если для анонимного метода не требуется параметров, то скобки с параметрами можно опустить
             даже если делегет принимает несколько параметров исключение in out*/

            MessageHandler handler1 = delegate
            {
                Console.WriteLine("Анонимный метод");
            };
            handler1("Hello world");
            /* Так же как и обычное методы, анонимные могут возвращать результат */
            Operation operation1 = delegate (int x, int y)
            {
                return x + y;
            };
            int d = operation1(4, 5);
            Console.WriteLine(d);
            /* При этом анонимный метод имеет доступ ко всем переменным, определенным во внешнем коде*/
            int z = 8;
            Operation operation4 = delegate (int x, int y)
            {
                return x + y + z;
            };
            int j = operation4(4, 5);
            Console.WriteLine(j);   // 17

            /* Упражнение 1 */

            Console.WriteLine("Упражение 1: ");
            Account accout = new Account(200);
            Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);

            /* Добавляем в делегат ссылку на методы */

            accout.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            accout.RegisterHandler(colorDelegate);
            
            /* 2 раза снимаем деньги */

            accout.withdraw(100);                       
            accout.withdraw(150);

            /* Удаляем делегат */

            accout.UnregisterHandler(colorDelegate);   
            accout.withdraw(50);
        }

        /* Упражнение 1*/

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }

        private static void Color_Message (string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /* Пример 1 */

        private static void GoodMorning()
        {
            Console.WriteLine("Good morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }

        /* Пример 2 */

        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void HowAreYou()
        {
            Console.WriteLine("How Are You?");
        }

        /* Пример 6 */
        static void ShowMessage(string mes, MessageHandler handler)
        {
            handler(mes);
        }

        /* Упражнение */
        class Account
        {
            int _sum;
            public Account (int sum)
            {
                _sum = sum;
            }
            public int CurrentSum
            {
                get { return _sum; }
            }
            public void Put (int sum)
            {
                _sum += sum;
            }
            public void withdraw (int sum)
            {
                if (sum <= _sum)
                {
                    _sum -= sum;
                    if (_accountMessage != null)
                        _accountMessage($"Сумма {sum} снята со счёта");
                }
                else
                {
                    if (_accountMessage != null)
                        _accountMessage("Недостаточно денег на счёте");
                }
            }
            public delegate void AccountStateHandler(string message);   // Обьявление делегата
            AccountStateHandler _accountMessage;     // Создание переменной для делегата
            public void RegisterHandler(AccountStateHandler accountMessage)     // Добавление делегата
            {
                _accountMessage += accountMessage;
            }
            public void UnregisterHandler(AccountStateHandler accountMessage)   // Удаление делегата
            {
                _accountMessage -= accountMessage;
            }
        }
    }

    /* Пример 3 */

    class Math
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
