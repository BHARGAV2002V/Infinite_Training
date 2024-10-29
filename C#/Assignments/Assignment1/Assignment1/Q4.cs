using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
/*    4. Write a C# Sharp program that prints the multiplication table of a number as input.

        Test Data:
        Enter the number: 5
        Expected Output:
        5 * 0 = 0
        5 * 1 = 5
        5 * 2 = 10
        5 * 3 = 15
        ....
        5 * 10 = 50    */
    class Q4
    {
        public void multiplication(int n)
        {
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine(n + " * " + i + " = " + (n * i));
            }
        }
        static void Main()
        {
            Q4 q = new Q4();
            Console.WriteLine("Enter a number");
            int n = Convert.ToInt32(Console.ReadLine());
            q.multiplication(n);
            Console.ReadLine();
        }

       
    }
}
