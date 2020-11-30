using System;
/* Проверка с помощью ключевого слова is, приведение через оператор as и отлов исключения 
 * при прямом преобразовании. */

namespace PatternMatching
{
    class Program
    {
        static void Main()
        {
            Employee employee1 = new Manager();
            Manager manager1 = new Manager();
            Employee employee2 = new Employee();
            manager1.isOnVacation = true;
            UseEmployee(employee1);             //  Отлично работаем дальше
            UseEmployee(manager1);              //  Сотрудник в отпуске
            EmployeeNotNull(manager1);          //  Олично, работаем дальше
            UseEmployeeSwitch(manager1);        //  Олично, работаем дальше
            UseEmployeeSwitchWhen(manager1);    //  Объект в отпуске
            UseEmployeeSwitchWhen(employee2);   //  Объект не менеджер
        }

        /* Пример 1 Pattern Matching 
        Pattern matching фактически выполняет сопоставление с некоторым шаблоном. Здесь 
        выполняется сопоставление с типом Manager. То есть в данном случае речь идет о 
        type pattern - в качестве шаблона выступает тип Manager. Если сопоставление прошло 
        успешно, в переменной manager оказывается объект emp. И далее мы можем вызвать у него 
        методы и свойства.*/

        static void UseEmployee(Employee emp)
        {
            if (emp is Manager manager && manager.isOnVacation==false)
            {
                manager.Work();
            }
            else
            {
                Console.WriteLine("Сотрудник в отпуске");
            }
        }

        /* Пример 2 Constant Pattern 
        Сопоставление с некоторой константой. Например, можно проверить, 
        имеет ли ссылка значение:*/

        static void EmployeeNotNull(Employee emp)
        {
            if (!(emp is null))
            {
                emp.Work();
            }
        }

        /* Пример 3  Pattern Matching (Switch)*/

        static void UseEmployeeSwitch(Employee emp)
        {
            switch (emp)
            {
                case Manager manager:
                    manager.Work();
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                default:
                    Console.WriteLine("объект не менеджер");
                    break;
            }
        }

        /* Пример 4 Pattern Matching (Switch) + дополнительные условия when
         * В этом случае опять же преобразуем объект emp в объект типа Manager 
         * и в случае удачного преобразования смотрим на значение свойства 
         * IsOnVacation: если оно равно false, то выполняется данный блок case. */
        static void UseEmployeeSwitchWhen(Employee emp)
        {
            switch(emp)
            {
                case Manager manager when manager.isOnVacation == false:
                    manager.Work();
                    break;
                case Manager manager when manager.isOnVacation == true:
                    Console.WriteLine("Менеджер в отпуске");
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                default:
                    Console.WriteLine("Объект не менеджер");
                    break;
            }
        }
    }
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Да работаю я, работаю");
        }
    }
    class Manager: Employee
    {
        public override void Work()
        {
            Console.WriteLine("Отлично, работаем дальше");
        }
        public bool isOnVacation { get; set; }
    }
}
