using System;
using System.Collections.Generic;

namespace InterfaceIComparable
{
    class Program
    {
        static void Main()
        {
            /* Пример 1 Обычная сортировка
             С помощью одного метода, который, как правило, называется Sort() можно 
            сразу отсортировать по возрастанию весь набор данных.Однако метод Sort по 
            умолчанию работает только для наборов примитивных типов, как int или string. 
            Для сортировки наборов сложных объектов применяется интерфейс IComparable*/

            int[] numbers = new int[] { 97, 45, 32, 65, 83, 23, 15 };
            Array.Sort(numbers);
            foreach (int n in numbers)
                Console.WriteLine(n);
            /* Пример2  Сортировка по алфавиту */

            Person person1 = new Person { Name = "Bill", Age = 34 };
            Person person2 = new Person { Name = "Tom", Age = 23 };
            Person person3 = new Person { Name = "Alice", Age = 21 };
            Person[] people = new Person[] { person1, person2, person3 };
            Array.Sort(people);
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            /* Пример 3 Сортировка по колличеству символов в имени*/

            Array.Sort(people, new PeopleComparer());
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }

    /* Пример 2 Интерфейс IComparable */

    class Person: IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        /* Метод CompareTo предназначен для сравнения текущего объекта с объектом, 
         * который передается в качестве параметра object o. На выходе он возвращает целое 
         * число, которое может иметь одно из трех значений:
            - Меньше нуля. Значит, текущий объект должен находиться перед объектом, 
                который передается в качестве параметра
            - Равен нулю. Значит, оба объекта равны
            - Больше нуля. Значит, текущий объект должен находиться после объекта,
                передаваемого в качестве параметра */

        public int CompareTo(Person person)
        {
            return this.Name.CompareTo(person.Name);
        }

    }

    /* Пример 3 Interface Comparer 
    Метод Compare предназначен для сравнения двух объектов o1 и o2. 
    Он также возвращает три значения, в зависимости от результата сравнения: 
    если первый объект больше второго, то возвращается число больше 0, 
    если меньше - то число меньше нуля; если оба объекта равны, возвращается ноль.*/

    class PeopleComparer : IComparer<Person>
    {
        public int Compare (Person p1, Person p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}
