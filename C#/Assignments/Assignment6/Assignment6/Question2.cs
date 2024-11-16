using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter number of elements");
            int n = int.Parse(Console.ReadLine());
            List<string> str = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enetr string {i+1}");
                str.Add(Console.ReadLine());

            }

            var res = from i in str
                      where i.StartsWith("a") & i.EndsWith("m")
                      select i;
            Console.WriteLine("Words starts with A and ends with M are :");
            foreach (var x in res)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }

       
    }
}
