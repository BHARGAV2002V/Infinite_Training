using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    3.  Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)*/
   class Array3
    {
        static void Main()
        {
            Console.WriteLine("Enter no of elements");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"enter array element {i}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] arr2 = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i];
            }

            Console.WriteLine("copied elements of array are");

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine($"{arr[i]}");
            }

            Console.ReadLine();

        }
    }
}
