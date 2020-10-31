using System;

namespace PerechisleniyaEnum
{
    class Program
    {
        enum Operation
        {
            Add=1,
            Subract,
            Multiply,
            Divide
        }
        static void Main()
        {
            MathOp(10, 5, Operation.Add);
            MathOp(10, 5, Operation.Subract);
            MathOp(10, 5, Operation.Multiply);
            MathOp(10, 5, Operation.Divide);
            Console.WriteLine($"{Operation.Add}");
        }

        static void MathOp(double x, double y, Operation op)
        {
            double result = 0.0;

            switch (op)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            }
            Console.WriteLine($"Результат операции равен {result}");
        }
           
    }
}
