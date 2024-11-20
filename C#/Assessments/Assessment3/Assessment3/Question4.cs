using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Question4
    {
        public delegate int CalculateDelegate(int n1, int n2);
        static int calculation(int n1,int n2,CalculateDelegate c)
        {
            return c(n1, n2);
        }
        static int Addition(int a,int b)
        {
            return a + b;
        }
        static int Subtraction(int a,int b)
        {
            return a - b;
        }
        static int Multiplication(int a,int b)
        {
            return a * b;
        }
        static void Main()
        {
            Console.WriteLine("Enter the first number");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second number");
            int n2 = int.Parse(Console.ReadLine());
            CalculateDelegate add =Addition;
            int res1 = calculation(n1, n2, add);
            Console.WriteLine($"Addition of {n1} and {n2}        :  {res1}");

            CalculateDelegate sub = Subtraction;
            int res2 = calculation(n1, n2, sub);
            Console.WriteLine($"Subtraction of {n1} and {n2}     :  {res2}");

            CalculateDelegate mul = Multiplication;
            int res3 = calculation(n1, n2, mul);
            Console.WriteLine($"Multiplication of {n1} and {n2}  :  {res3}");
            Console.ReadLine();
        }
    }
}
