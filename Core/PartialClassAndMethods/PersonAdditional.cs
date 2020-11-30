using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassAndMethods
{
    public partial class Person
    {
        partial void DoSomethingElse()
        {
            Console.WriteLine("I'm reading a book");
        }
        public void Eat()
        {
            Console.WriteLine("I'm eating");
        }
    }
}
