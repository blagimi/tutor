using System;
using System.ComponentModel.DataAnnotations;

namespace Indeksatori
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people[0] = new Person { Name = "Tom" };
            people[1] = new Person { Name = "Bob" };
            Person tom = people[0];
            Console.WriteLine(tom?.Name);

            Matrix matrix = new Matrix();
            Console.WriteLine(matrix[0,0]); //Обращение к элементу массива используя 2 индекса
            matrix[0, 0] = 111;
            Console.WriteLine(matrix[0,0]);

            Console.WriteLine("Упражнение 1");

            FootbalTeam dreamTeam = new FootbalTeam(); // Создание новой команды с названиемteam
            dreamTeam[0] = new FootbalPlayer { name = "Tom", playerNumber = 11 }; // Добавление в команду нового игрока с индексом [0]
            dreamTeam[1] = new FootbalPlayer { name = "John", playerNumber = 10 }; // Добавление в команду нового игрока с индексом [1]
            dreamTeam[2] = new FootbalPlayer { name = "Ronadldo", playerNumber = 9 };
            Console.WriteLine(dreamTeam[2].name); // Вывод на экран имени футболиста с индексом 1 команды team

            Console.WriteLine("Упражнение 2");

            Dictionary dictionary = new Dictionary();
            Console.WriteLine(dictionary["blue"]);
            dictionary["blue"] = "голубой";
            Console.WriteLine(dictionary["blue"]);
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
    class People
    {
        Person[] data;
        public People()
        {
            data = new Person[5];
        }
        /* Индексатор. Создаётся в том месте где нужен, без привязки к конкретному классу */
        public Person this [int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
    class Matrix
    {
        private int[,] numbers = new int[,] { { 1, 2, 4 }, { 2, 3, 6 }, { 3, 4, 8 } };
        public int this [int i, int j]
        {
            get
            {
                return numbers[i, j];
            }
            set
            {
                numbers[i, j] = value;
            }
        }
    }
    /* Упражнение 1 */
    /* Класс футболист Имя и номер */
    class FootbalPlayer
    {
        public string name { get; set; }
        public int playerNumber { get; set; }
    }
    /* Класс команды содержащий массив из 11 игроков в футбол */
    class FootbalTeam
    {
        FootbalPlayer[] team; // Создание пустого массива

        public FootbalTeam()    // Конструктор
        {
            team = new FootbalPlayer[11]; // Заполнение массива 11 пустными полями
        }

        public FootbalPlayer this [int index]  // Индексатор принимающий массив футболистов
        {
            get
            {
                if (index >= 0 && index < team.Length)  // Проверка что индекс больше\равен 0 и не превышает индекс массива
                {
                    return team[index];

                }
                else
                {
                    Console.WriteLine("Превышен индекс");
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < team.Length)
                    team[index] = value;
                else team[index] = null;
            }
        }
    }
    /* Упражнение 2 */
    /* Переводчик */
    class Word                  // Класс Слово
    {
        public string Source { get; }               // Значение слова на исходном языке
        public string Target { get; set; }          // Значение слово после перевода
        public Word(string source, string target)   // Конструктор Слово принимающий слово и его переведенный вариант
        {
            Source = source;
            Target = target;
        }
    }
    class Dictionary            // Класс Словарь
    {
        Word[] words;           // Создание пустого массива words из слов
        public Dictionary()     // Конструктор словаря
        {
            words = new Word[]  // Заполнение массива words словами и их переводом
            {
               new Word("red", "красный"),
               new Word("blue", "синий"),
               new Word("green", "зелённый")
            };
        }
        public string this[string source] // Получение значений по имени и их замена
        {
            get
            {
                Word word = null;
                foreach (Word w in words)
                {
                    if (w.Source == source)
                    {
                        word = w;
                        break;
                    }
                }
                return word?.Target;
            }
            set
            {
               foreach (Word w in words)
                {
                    if (w.Source == source)
                    {
                        w.Target = value;
                        break;
                    }
                }
            }
        }
    }
}
