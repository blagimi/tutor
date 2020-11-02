using System;

namespace ConstReadOnly
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(MathLib.PI);
            //MathLib.E = 3.8; Значение константы изменить нельзя
            MathLib mathLib = new MathLib(6.6); // Изменение ридонли поля через конструктор
            Console.WriteLine(mathLib.K); // 6.6
            // mathLib.K = 7.7; вне конструктора изменять ридонли поля нельзя
        }
    }
    class MathLib
    {
        public const double PI = 3.14;  // Константа определяется во время компиляции
        public const double E = 2.81;
        // public const double K; константа должна содержать значение
        public readonly double K = 23;  // Ридонли определяется во время выполнения программы 
        public MathLib (double _k)
        {
            K = _k; // Ридонли поле может быть изменено в конструкторе
        }
        public void ChangeField()
        {
            //K = 25; // Изменять за пределами конструктора нельзя
        }
    }
    /* Ридонли структура, все её поля должны быть ридонли тоже */
    readonly struct User
    {
        public readonly string name;
        public readonly int Age { get;} // Свойства тоже определяются только для чтения метод set недопустим
        public User (string name,int age)
        {
            this.name = name;
            this.Age = age;
        }
    }
}
