using System;
using System.Globalization;

namespace MassTest
{
    class Program
    {
        static void Main()
        {
            //Пузырь
            // Ввод числе в массив
            int[] nums = new int[7];
            Console.WriteLine("Введите 7 чисел");
            for (int i=0; i < nums.GetLength(0); i++)
            {
                Console.Write("{0}-e число: ", i + 1);
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            //Сортировка
            int temp;
            for (int i=0; i < nums.Length-1; i++)
            {
                for (int j = i+1; j<nums.Length; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            //Вывод
            Console.WriteLine("Вывод массива");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }
    }
}
