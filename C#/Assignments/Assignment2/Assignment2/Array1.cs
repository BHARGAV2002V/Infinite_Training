using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    1.    Write a  Program to assign integer values to an array  and then print the following
    a.Average value of Array elements

    b.Minimum and Maximum value in an array     */
    class Array1
    {
        public void Min(int[] arr)
        {
            int min = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine($"Minimum value is {min}");
        }
        public void Max(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine($"Maximum value is {max}");
        }
        public void average(int[] arr)
        {
            float sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"Average value is {sum / arr.Length}");
        }
        static void Main()
        {
            Console.WriteLine("Enter number of elements in array");

            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"enter array element {i}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array1 ar = new Array1();
            ar.Min(arr);
            ar.Max(arr);
            ar.average(arr);
            Console.ReadLine();
        }
    }
}
