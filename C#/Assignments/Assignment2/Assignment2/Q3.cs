using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

        Test Data / input: 2

        Expected Output :
        Tuesday     */
    class Q3
    {
        public enum days { Monday=1,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday};
        static void Main()
        {
            Console.WriteLine("enter day number");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{(days)n}");
            Console.ReadLine();
        }
            }
}
