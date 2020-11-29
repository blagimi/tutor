using System;

namespace InterfaceRealization
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Явная реализация интерфейсов 
            При явной реализации интерфейса его методы и свойства не являются частью
            интерфейса класса. Поэтому напрямую через объект класса мы к ним 
            обратиться не сможем.*/

            BaseAction action = new BaseAction();
            ((IAction)action).Move();           //  Move in Base Class

            /* Пример 2 Класс реализующий 2 интерфейса */

            Person person = new Person();
            ((ISchool)person).Study();          //  Учёба в школе
            ((IUniversity)person).Study();      //  Учёба в университете

            /* Пример 3  РЕ-Реализация интерфейса в производном классе */

            HeroAction heroAction = new HeroAction();
            heroAction.Move();                  //  Move in BaseAction2
            ((IAction)heroAction).Move();       //  Move in HeroAction

            IAction heroAction2 = new HeroAction();
            heroAction2.Move();                 // Move in HeroAction
            ((HeroAction)heroAction2).Move();   // Move in BaseAction 2

            /* Пример 4 Модификаторы доступа */

            IMovable move = new Human();
            // Подписываемся на событие
            move.MoveEvent += () => Console.WriteLine("IMovable is moving");
            move.Move();
        }
    }

    /* Пример 1 Явная реализация интерфейсов 
    При явной реализации указывается название метода или свойства вместе 
    с названием интерфейса, при этом мы не можем использовать модификатор public, 
    то есть методы являются закрытыми.
    Используется когда класс применяет несколько интерфейсов, но они имеют один и тот
    же метод с одним и тем же возвращаемым результатом и одним и тем же набором 
    параметров.*/

    class BaseAction : IAction
    {
        void IAction.Move() // Явная реализация интерфейса
        {
            Console.WriteLine("Move in Base Class");
        }
    }

    /* Пример 2 Класс реализующий 2 интерфейса*/

    class Person: ISchool,IUniversity
    {
        void ISchool.Study()
        {
            Console.WriteLine("Учёба в школе");
        }
        void IUniversity.Study()
        {
            Console.WriteLine("Учёба в университете");
        }
    }

    /* Пример 3 РЕ-Реализация интерфейса в производном классе, уже реализованном в базовом классе */

    class BaseAction2: IAction
    {
        public void Move()
        {
            Console.WriteLine("Move in Base Action 2");
        }
    }
    class HeroAction: BaseAction2,IAction
    {
        void IAction.Move()
        {
            Console.WriteLine("Move in HeroAction");
        }
    }

    /* Пример 4 Модификаторы доступа
    Члены интерфейса могут иметь разные модификаторы доступа. Если модификатор 
    доступа не public, а какой-то другой, то для реализации метода, свойства или 
    события интерфейса в классах и структурах также необходимо использовать 
    явную реализацию интерфейса.*/

    class Human : IMovable
    {
        // явная реализация свойства - в виде автосвойства
        string IMovable.Name { get; set; }

        // явная реализация события - дополнительно создается переменная
        IMovable.MoveHandler _moveEvent;
        event IMovable.MoveHandler IMovable.MoveEvent
        {
            add => _moveEvent += value;
            remove => _moveEvent -= value;
        }
        // Явная реализация метода
        void IMovable.Move()
        {
            Console.WriteLine("Human is moving");
            _moveEvent();
        }
    }
}
