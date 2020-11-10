using System;

namespace AbstractClass
{
    class Program
    {
        static void Main()
        {
            Client client1 = new Client("Tom","Ellis", 500);
            Employee employee1 = new Employee("Bob","Harris","Manager");
            client1.Display();
            employee1.Display();
        }
    }

    /* Создание абстактного класса хранящего общие свойтва для классов наследников, обьект абстрактного класса создать нельзя*/

    abstract class Person                               
    {
        public string Name { get; set; }
        public abstract string SecondName {get;set;}
        public Person (string name, string secondName)
        {
            Name = name;
            SecondName = secondName;
        }
        public abstract void Display();
    }
    /* Создание класса наследника от класа Person с унаследоваными свойствами и методами которые НЕОБХОДИМО переопределить. 
       Поскольку в отличии от виртуальных методов от обстрактных классов, свойств и методов наследуется интерфейс а не реализация.
       Всё абстрактное должно быть реализовано в классе наследнике*/
    class Client : Person   
    {
        public int Sum { get; set; }    // Сумма на счету
        private string secondName;
        public override string SecondName
        {
            get { return "Mr/Ms. " + secondName; }
            set { secondName = value; }
        }
        public Client (string name, string secondName, int sum) :base(name,secondName)
        {
            Sum = sum;
        }
        public override void Display()
        {
            Console.WriteLine($"{SecondName} {Name} имеет на счету {Sum}");
        }
    }
    class Employee : Person
    {

        public string Position { get; set; }    // Должность
        private string secondName;
        public override string SecondName
        {
            get { return "Mr/Ms. " + secondName; }
            set { secondName = value; }
        }
        public Employee(string name, string secondName, string position) : base(name,secondName)
        {
            Position = position;
        }
        public override void Display()
        {
            Console.WriteLine($"{Position} {SecondName} {Name}");
        }
    }

    abstract class Figure
    {
        public abstract float Perimetr();
        public abstract float Area();
    }
    class Rectangle : Figure
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public Rectangle (float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override float Perimetr()
        {
            return Width * 2 + Height * 2;
        }
        public override float Area()
        {
            return Width * Height;
        }
    }
}
