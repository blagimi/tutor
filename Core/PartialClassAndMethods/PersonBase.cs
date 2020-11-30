using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassAndMethods
{
    public partial class Person
    {
        partial void DoSomethingElse();
        public void Move()
        {
            Console.WriteLine("I'm moving");
        }
        public void DoSomething()
        {
            Console.WriteLine("Start");
            DoSomethingElse();
            Console.WriteLine("Finish");
        }
    }
}
