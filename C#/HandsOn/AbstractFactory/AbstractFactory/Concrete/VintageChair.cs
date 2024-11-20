using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete
{
    class VintageChair : IChair
    {
        public void Sitting()
        {
            Console.WriteLine("Sitting On a Vintage Chair");
        }
    }
}
