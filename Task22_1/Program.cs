using System;
using System.Threading.Tasks;

namespace Task22_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Task<int[]> task = new Task<int[]>(() => GetArray(n));

            Task printTask = task.ContinueWith(t => PrintArray(task.Result));
            Task sumTask = printTask.ContinueWith(t => SumArray(task.Result));
            Task maxTask = sumTask.ContinueWith(t => MaxArray(task.Result));
            task.Start();
            Console.ReadKey();
        }

        static int[] GetArray(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }
        static void SumArray(int[] array) 
        { 
            Console.WriteLine($"сумма всех элементов: {array.Sum()}");
        }

        static void MaxArray(int[] array)
        {
            Console.WriteLine($"максимальный элемент: {array.Max()}");
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}