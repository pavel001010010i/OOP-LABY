using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10] { 25, 24, 13, 41, 5, 62, 17, 21, 91, 10 };
            string hello = "hello world!";
            Console.WriteLine(Arr(arr, hello));
        }
        private static (int sum, int maxSize, int min, char ch) Arr(int[] numbers, string str)
        {
            var result = (sum: 0, minSize: numbers[0], maxSize: numbers[0], ch: str[0]);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > result.maxSize)
                {
                    result.maxSize = numbers[i];
                }
                if (numbers[i] < result.minSize)
                {
                    result.minSize = numbers[i];
                }
                result.sum += numbers[i];
            }
            return result;
        }
    }
}
