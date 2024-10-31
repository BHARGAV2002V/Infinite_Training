using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    1. Write a C# Sharp program to swap two numbers.
*/
    class Program
    {
        public void swap(int a,int b)
        {
            Console.WriteLine($"Before swapping {a} and {b}");

            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"After swapping {a} and {b}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter 2 numbers");
            int a = Convert.ToInt32(Console.ReadLine());

            int b = Convert.ToInt32(Console.ReadLine());

            Program p = new Program();
            p.swap(a, b);
            Console.ReadLine();
        }
    }
}
