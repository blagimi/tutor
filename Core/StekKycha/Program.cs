using MyLib;
using System;

namespace StekKycha
{
    class Program
    {
        static void Main()
        {
            /* Копирование значений */
            State state = new State();
            State state2 = new State();
            /* Структуре создаёт ссылку на поле country в куче */
            state2.country = new Country();
            state2.x = 1;
            state2.y = 1;
            /* Структура создаёт копию значений state2 и присваивает их state */
            state = state2;
            state2.x = 2;
            /* Значение state2.country.x работает с ссылкой в куче*/
            state2.country.x = 3;
            /* Вывод значений из стека */
            Console.WriteLine(state.x);     //1
            Console.WriteLine(state2.x);    //2
            /* Вывод значений из стека содержащего ссылки на кучу */
            Console.WriteLine(state.country.x); //3
            Console.WriteLine(state2.country.x);//3
            Country country = new Country();
            Country country2 = new Country();
            country2.x = 1;
            country2.y = 1;
            /* Класс создаёт ссылку на country2 */
            country = country2;
            country2.x = 2;
            Console.WriteLine(country.x);   //2
            Console.WriteLine(country2.x);  //2

            Console.WriteLine();
            Person2 p = new Person2 {name= "Tom", age = 30};
            Console.WriteLine("Name: {0} Age: {1}",p.name,p.age);
            ChangePerson(p);
            Console.WriteLine("Name: {0} Age: {1}", p.name, p.age);
            static void ChangePerson(Person2 p) //ref передаст ссылку и тогда нижная часть кода сработает тоже
            {
                p.name = "Alice"; // Сменит значение
                p = new Person2 { name = "bill", age = 17 }; //Создастся новая копия 
                Console.WriteLine("Name: {0} Age: {1}",p.name,p.age);//Выведет значения новой локальной копии
            }
            Person john = new Person { name = "John", age = 19 };
            Console.WriteLine($"Name: {john.name} Age: {john.age}");
        }
    }
    class Country
    {
        public int x;
        public int y;
    }
    struct State
    {
        public int x;
        public int y;
        public Country country; //ссылочный тип внутри типа значений
    }

    class Person2
    {
        public string name;
        public int age;
    }
}
