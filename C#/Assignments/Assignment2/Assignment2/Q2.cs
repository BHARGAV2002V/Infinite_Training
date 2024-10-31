using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
/*    2. Write a C# program that takes a number as input and displays it four times in a row
 *    (separated by blank spaces), and then four times in the next row, with no separation. 
 *    You should do it twice: Use the console. Write and use {0}.

        Test Data:
        Enter a digit: 25

        Expected Output:
        25 25 25 25
        25252525
        25 25 25 25
        25252525*/

    class Q2
    {
        public void pattern(int n)
        {
            for(int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("{0} {0} {0} {0}", n);
                }
                else
                {
                    Console.Write("{0}{0}{0}{0}", n);

                }
                Console.WriteLine();

            }
        }

        static void Main()
        {
            Q2 q = new Q2();
            q.pattern(Convert.ToInt32(Console.ReadLine()));
            Console.ReadLine();
        }
    }
}
