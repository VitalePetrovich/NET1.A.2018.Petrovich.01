using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArraySortInt.Sort;

namespace ConsoleUI
{
    class ConsoleUI
    {
        static void Main(string[] args)
        {
            const int N = 15;
            int[] arr = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }

            MergeSort(arr);

            foreach (var value in arr)
            {
                Console.Write("{0} ", value);
            }
            Console.ReadKey();
        }
    }
}
