using System;


namespace Assignment1
{
/*    5.  Write a C# program to compute the sum of two given integers. 
         If two values are the same, return the triple of their sum.
*/
    class Q5
    {
        public int sum_triple(int n1,int n2)
        {
            int sum = n1 + n2;
            return n1 == n2 ? (3 * sum) : sum; 
        }
        static void Main()
        {
            Console.WriteLine("Enter n1");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter n2");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Q5 q = new Q5();
            int res=q.sum_triple(n1, n2);
            Console.WriteLine("Result is "+res);
            Console.ReadLine();
        }
    }
}
