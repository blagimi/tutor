using System;

/* Реализация интерфейсов в базовых и производных классах */

namespace InterfaceInChildClass
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Реализация метода интрефейса через унаследование от абстрактного класса */
            
            Driver driver = new Driver();
            driver.Move();          //  Шофёр ведет машину

            /* Пример 2 Реализация метода интерфейса унаследованная от базового класса */

            HeroAction heroAction = new HeroAction();
            heroAction.Move();      //  Move in BaseAction

            /* Пример 3 Изменение реализации интерфейсов в производных классах */

            BaseAction2 baseAction2 = new HeroAction2();
            baseAction2.Move();     //  Move In HeroAction2

            IAction action2 = new HeroAction2();
            action2.Move();         //  Move In HeroAction2

            HeroAction2 heroAction2 = new HeroAction2();
            heroAction2.Move();     //  Move In HeroAction2

            /* Пример 4 Повторная реализация интерфейса в классе-наследнике */

            BaseAction3 action3 = new HeroAction3();
            action3.Move();            // Move in BaseAction3

            IAction action4 = new HeroAction3();
            action4.Move();             // Move in HeroAction3

            HeroAction3 action5 = new HeroAction3();
            action5.Move();             // Move in HeroAction3

            /* Пример 5  Явная реализация интерфейса */
            
            BaseAction4 action6 = new HeroAction4();
            action6.Move();            // Move in BaseAction4

            IAction action7 = new HeroAction4();
            action7.Move();             // Move in IAction4

            HeroAction4 action8 = new HeroAction4();
            action8.Move();             // Move in HeroAction4
        }
    }

    /* Пример 1 Реализация метода интрефейса через унаследование от абстрактного класса */

    abstract class Person: IMovable
    {
        public abstract void Move();
    }
    class Driver: Person
    {
        public override void Move()
        {
            Console.WriteLine("Шофёр ведет машину");
        }
    }

    /* Пример 2 Реализация метода интерфейса унаследованная от базового класса */

    class BaseAction
    {
        public void Move()
        {
            Console.WriteLine("Move in BaseAction");
        }
    }
    class HeroAction: BaseAction,IAction
    {

    }

    /* Пример 3 Изменение реализации интерфейсов в производных классах */

    class BaseAction2: IAction
    {
        public virtual void Move()
        {
            Console.WriteLine("Move in BaseAction2");
        }
    }
    class HeroAction2: BaseAction2
    {
        public override void Move()
        {
            Console.WriteLine("Move in HeroAction2");
        }
    }

    /* Пример 4  Повторная реализация интерфейса в классе-наследнике*/

    class BaseAction3: IAction
    {
        public void Move()
        {
            Console.WriteLine("Move In BaseAction3");
        }
    } 
    class HeroAction3: BaseAction3, IAction
    {
        public new void Move()
        {
            Console.WriteLine("Move In HeroAction3");
        }
    }

    /* Пример 5  Явная реализация интерфейса*/

    class BaseAction4 : IAction
    {
        public void Move()
        {
            Console.WriteLine("Move In BaseAction4");
        }
    }
    class HeroAction4 : BaseAction4, IAction
    {
        public new void Move()
        {
            Console.WriteLine("Move In HeroAction4");
        }
        void IAction.Move()
        {
            Console.WriteLine("Move in Iaction4");
        }
    }
}
