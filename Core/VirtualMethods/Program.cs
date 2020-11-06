using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Bill");
            Employee p2 = new Employee("Tom", "Microsoft");
            p1.Display();
            p2.Display();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public virtual void Display()                  //  Виртуальный метод
        {
            Console.WriteLine(Name);
        }
    }
    class Employee : Person
    {
        public string Company { get; set; }
        public Employee (string name, string company) : base(name)
        {
            Company = company;
        }
        public override sealed void Display()          // Переопределение метода "override" для другой реализации
        {                                              // "sealed" запрещает дальнейшее переопределение метода в классах наследниках
            base.Display();                            // Вызов метода базового класса 
            Console.WriteLine($"{Name} работает в {Company}");
        }
    }

    class Credit
    {
        public virtual decimal Sum { get; set; }
    }
    class LongCredit : Credit
    {
        private decimal sum;
        public override decimal Sum                     // Переопределение свойств
        {
            get { return sum; }
            set { if (value > 1000) { sum = value; } }
        }
    }
}

