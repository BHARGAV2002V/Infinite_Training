using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
/*    3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

        Test Data
        Input first number: 20
        Input operation: -
        Input second number: 12
        Expected Output :
        20 - 12 = 8     */
    class Q3
    {
        public void ArithmeticOp(int n1, char ch, int n2)
        {
            switch (ch)
            {
                case '+':
                    Console.WriteLine(n1 + " " + ch + " " + n2 + " = " + (n1 + n2));
                    break;
                case '-':
                    Console.WriteLine(n1 + " " + ch + " " + n2 + " = " + (n1 - n2));
                    break;
                case '*':
                    Console.WriteLine(n1 + " " + ch + " " + n2 + " = " + (n1 * n2));
                    break;
                case '/':
                    Console.WriteLine(n1 + " " + ch + " " + n2 + " = " + (n1 / n2));
                    break;
                default:
                    Console.WriteLine("Enter Valid numbers");
                    break;
            }

        }
        static void Main()
        {
            Q3 q = new Q3();
            Console.WriteLine("Enter n1");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operator");
            char ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter n2");
            int n2 = Convert.ToInt32(Console.ReadLine());

            q.ArithmeticOp(n1, ch, n2);
            Console.ReadLine();
        }
    }
}
