using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    2.	Write a program in C# to accept ten marks and display the following
	a.Total
	b.Average
	c.	Minimum marks
	d.Maximum marks
	e.Display marks in ascending order
	f.Display marks in descending order        */

	class Array2
    {
		static float Total(int[] arr)
        {
			float sum = 0;
			for(int i = 0; i < arr.Length; i++)
            {
				sum += arr[i];
            }
			return sum;
        }
		static float average(int[] arr)
        {
			return Total(arr) / arr.Length;
        }
		static int minimum(int[] arr)
        {
			//return arr.Min();
			int min = arr[0];
			for(int i = 0; i < arr.Length; i++)
            {
				if (arr[i] < min){
					min = arr[i];
                }
            }
			return min;
        }
		static int maximum(int[] arr)
		{
			//return arr.Max();
			int max = arr[0];
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] > max)
				{
					max = arr[i];
				}
			}
			return max;
		}
		static void Main()
        {

			int[] arr = new int[10];
			for(int i = 0; i < 10; i++)
            {
				Console.WriteLine($"Enter marks {i}");
				arr[i]= Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine($"Total is {Total(arr)}");

			Console.WriteLine($"Average is {average(arr)}");

			Console.WriteLine($"Minimum is {minimum(arr)}");

			Console.WriteLine($"Maximum is {maximum(arr)}");
			Console.ReadLine();
        }
    }
}
