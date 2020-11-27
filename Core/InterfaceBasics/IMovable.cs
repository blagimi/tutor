using System;

namespace InterfaceBasics
{
    interface IMovable
    {
        void Move()
        {
            Console.WriteLine("В движении");
        }
        void Turbo()
        {
            Console.WriteLine("Ускоряется");
        }
    }
}
