using System;


namespace Assignment1
{
    class Program
    {
 /*       1. Write a C# Sharp program to accept two integers and check whether they are equal or not. 

            Test Data :
            Input 1st number: 5
            Input 2nd number: 5
            Expected Output :
            5 and 5 are equal      */

        static void equal(int n1,int n2)
        {
            if (n1 == n2)
            {
                Console.WriteLine(n1 + " and " + n2 + " are equal");
            }
            else
            {
                Console.WriteLine(n1 + " and " + n2 + " are not equal");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());
            equal(n1, n2);
            Console.ReadLine();


        }
    }
}
