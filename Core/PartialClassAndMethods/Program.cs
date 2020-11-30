using System;
/* Классы могут быть частичными. То есть мы можем иметь несколько файлов с определением 
 * одного и того же класса, и при компиляции все эти определения будут скомпилированы 
 * в одно. */

namespace PartialClassAndMethods
{
    class Program
    {
        static void Main()
        {
            Person tom = new Person();
            tom.Eat();
            tom.Move();
            tom.DoSomething();
        }
    }
}
