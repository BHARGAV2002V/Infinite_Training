using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Test
    {
        static void Main()
        {
            Console.WriteLine("Enter Length 1");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Breadth 1");
            int b = int.Parse(Console.ReadLine());
            Box box1 = new Box(l, b);

            Console.WriteLine("Enter Length 2");
            int l2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Breadth 2");
            int b2 = int.Parse(Console.ReadLine());
            Box box2 = new Box(l2, b2);

            Box box3 = box1.Add(box2);
            Console.WriteLine("");
            Console.WriteLine("======3rd box details (Sum of 2 boxes)======");
            box3.Display();
            Console.ReadLine();
        }
    }
}
