using System;

namespace OperatorReload
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c1 = new Counter { Value = 23 };
            Counter c2 = new Counter { Value = 45 };
            bool result = c1 > c2;
            Console.WriteLine(result); // false

            Counter c3 = c1 + c2;
            Console.WriteLine(c3.Value);  // 23 + 45 = 68

            Counter counter = new Counter() { Value = 0 };
            if (counter)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);

            Counter counter2 = new Counter() { Value = 10 };
            Console.WriteLine($"{counter2.Value}");      // 10
            Console.WriteLine($"{(++counter2).Value}");  // 20
            Console.WriteLine($"{counter2.Value}");      // 20

            Console.ReadKey();

            Counter2 counter3 = new Counter2() { Number = 45 };
            int x = counter3 + 6;
            Console.WriteLine(x);

            Console.WriteLine("Упражнение 1");
            
            State Chelyabinsk = new State() { Population = 100, Area = 1000 };
            State Ekaterinburg = new State() { Population = 200, Area = 2000 };
            bool isGreater = Chelyabinsk.Area > Ekaterinburg.Area; // Сравнение только с явным указанием полей Area или Population
            Console.WriteLine(isGreater);
            State CheKabe = Chelyabinsk + Ekaterinburg;
            Console.WriteLine(CheKabe.Population);  // 300
            Console.WriteLine(CheKabe.Area);        // 3000
            if (CheKabe.Area > Chelyabinsk.Area)
            { Console.WriteLine("ЧЕкабе больше Челябинска"); }
            else { Console.WriteLine("Чекабе меньше Челябинска"); }
            
            Console.WriteLine("Упражнение 2");
            Bread bread = new Bread() { Weight = 80 };
            Butter butter = new Butter() { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight);     // 100
        }
    }
    class Counter
    /* Для того что бы проводить операции сложение\сравнения и других для классов и структур. 
     * для этого нам надо выполнить перегрузку нужных нам операторов. */
    {
        public int Value { get; set; }

        public static Counter operator +(Counter c1, Counter c2)
        {
            return new Counter { Value = c1.Value + c2.Value };
        }
        public static bool operator >(Counter c1, Counter c2)
        {
            return c1.Value > c2.Value;
        }
        public static bool operator <(Counter c1, Counter c2)
        {
            return c1.Value < c2.Value;
        }
        public static bool operator true(Counter c1)
        {
            return c1.Value != 0;
        }
        public static bool operator false(Counter c1)
        {
            return c1.Value == 0;
        }
        public static Counter operator ++(Counter c1)
        {
            return new Counter { Value = c1.Value + 10 };
        }
    }
    class Counter2
    {
        public int Number { get; set; }
        public static int operator +(Counter2 counter2, int val)
        {
            return counter2.Number + val;
        }
    }
    /* Упражнение 1 */
    class State // Регион
    {
        public decimal Population { get; set; }         // Население
        public decimal Area { get; set; }               // Размер территории

        public static State operator +(State state1, State state2)
        {
            return new State { Area = state1.Area + state2.Area, Population=state1.Population+state2.Population };
        }
        public static bool operator >(State state1, State state2)
        {
            return (state1 > state2);

        }
        public static bool operator <(State state1, State state2)
        {
            return (state1 < state2);
        }
    }
    class Bread
    {
        public int Weight { get; set; }
        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich { Weight = bread.Weight + butter.Weight };
        }
    }
    class Butter
    {
        public int Weight { get; set; }
    }
    class Sandwich
    {
        public int Weight { get; set; }
    }
}
