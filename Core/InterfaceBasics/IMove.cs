using System;

namespace InterfaceBasics
{
    /* Интерфейс 
     По умолчанию иммет уровень доступа internal, public делает общедоступным*/
    interface IMove
    {
        /* По умолчанию функционал у интерфейсов имеет модификатор доступа public  */
        // Константа
        public const int minSpeed = 0;     // Минимальная скорость

        /* Eсли интерфейс имеет приватные методы и свойства (с модификатором private), 
         * то они должны иметь реализацию по умолчанию */
        // Статическая переменная
        private static int maxSpeed = 60;   // Максимальная скорость
        static double GetTime(double distance, double speed) => distance / speed;
        static int MaxSpeed
        {
            get { return maxSpeed; }
            set { if (value > 0) maxSpeed = value; }
        }

        /* Метод 
         Интерфейсы поддерживают реализацию методов и свойств по умолчанию*/
        public void Move()                // Движение
        {
            Console.WriteLine("Walking");
        }
        // Свойство
        protected internal string Name { get; set; }   // Название
        // Делегат
        public delegate void MoveHandler(string message);  // Определение делегата для события
        // Событие
        public event MoveHandler MoveEvent;    // Событие движения
    }
}
