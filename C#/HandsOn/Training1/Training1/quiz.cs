using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training1
{
    class quiz
    {
        static void Main()
        {
            /*  int num = 2147483647;
              object b = num;
              ++num;
              int unb = (int)b;
              Console.WriteLine(num+++unb+1);
              Console.ReadLine();*/


            /*      int x = 8, X = 20;
                  int _val = 5, @val = 13;
                  Console.WriteLine(++x+X+_val+@val++);
                  Console.ReadLine();*/

            //int x = 10, y = 0;
            //object bx = x;
            //x = x + 5;
            //y++;
            //Console.WriteLine((int)bx/y);
            //x++;
            //bx = x;
            //Console.WriteLine((int)bx/y);

            int[] nums = { 1, -2, 3, 0, -4, 5 };
            var posNums = from n in nums where n >= 0 select n;
            foreach (int i in posNums)
            {
                Console.Write(i + " "); Console.WriteLine(); Console.ReadLine();
                Console.ReadLine();


            }


        }
    }
}
