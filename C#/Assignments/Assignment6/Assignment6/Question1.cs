using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Question1
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();
            Console.WriteLine("enter no of elements");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter element {i+1}");
                l.Add(int.Parse(Console.ReadLine()));
            }
            var res = from i in l
                      where i * i > 20
                      select i;
            foreach(var x in res)
            {
                Console.WriteLine($"{x} -> {x * x}");
            }
            Console.ReadLine();

        }
    }
}
