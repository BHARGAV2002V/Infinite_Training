using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
/*    3. Write a C# Sharp program to check the largest number among three given integers.
 
Sample Input:
1,2,3
1,3,2
1,1,1
1,2,2
Expected Output:
3
3
1
2*/
class largest
    {
        public void large_number(int[] n)
        {
            int max = n[0];
            for(int i = 0; i < n.Length; i++)
            {
                if (n[i] > max)
                {
                    max = n[i];
                }
            }
            Console.WriteLine("Maximum is {0}", max);
        }
    }
    class Question3
    {
        static void Main()
        {
            largest l = new largest();
            int[] n = new int[3];
            Console.WriteLine("Enter 3 numbers");
            for(int i = 0; i < n.Length; i++)
            {
                n[i] = Convert.ToInt32(Console.ReadLine());
            }
            l.large_number(n);
            Console.ReadLine();
        }
    }
}
