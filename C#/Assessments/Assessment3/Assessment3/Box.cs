using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Box
    {
        public int length;
        public int breadth;
        public Box(int length,int breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public Box Add(Box b)
        {
            int length2 = this.length + b.length;
            int breadth2 = this.breadth + b.breadth;
            return new Box(length2, breadth2);
        }

        public void Display()
        {
            Console.WriteLine($"Length is {length} , Breadth is {breadth}");
        }
    }
}
