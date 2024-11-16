using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training1
{
    class lambda2
    {
        static void Main()
        {
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(8);
            List<int> li = l.Where(x => x % 2 == 0).ToList();

            foreach (int i in li)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
