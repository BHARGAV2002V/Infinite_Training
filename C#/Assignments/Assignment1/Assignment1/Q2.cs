using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
/*    2. Write a C# Sharp program to check whether a given number is positive or negative. 
         Test Data : 14
         Expected Output :
         14 is a positive number    */

    class Q2
    {
        public void pos_neg(int n)
        {
            if (n < 0)
            {
                Console.WriteLine(n + " is a negative number");
            }
            else if (n > 0)
            {
                Console.WriteLine(n + " is a Positive number");

            }
        }
        static void Main()
        {
            Q2 q = new Q2();
            Console.WriteLine("Enter a number");
            int n = Convert.ToInt32(Console.ReadLine());
            q.pos_neg(n);
            Console.ReadLine();
        }
    }
}
