using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
/*    3. Write a C# program to implement a method that takes an integer as 
        input and throws an exception if the number is negative. Handle the exception in the calling code.*/
   class Negative_exception : ApplicationException
    {
        public Negative_exception(string message) : base(message) { }
    }
    class Question3
    {
        public static void checknumber(int n)
        {
            if (n < 0)
            {
                throw (new Negative_exception("Exception : Number is negative"));
            }
            else
            {
                Console.WriteLine("Number is Positive");
            }
        }
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a number");
                int n = int.Parse(Console.ReadLine());
                checknumber(n);
            }
            catch(Negative_exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
