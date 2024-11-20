using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;

namespace AbstractFactory.Concrete
{
    public class VintageSofa: ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("Lay on Vintage Sofa");
        }

    }
}
