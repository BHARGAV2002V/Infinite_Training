using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;
using AbstractFactory.Concrete;
namespace AbstractFactory.Factories
{
    public class VintageFactory : IFurnitureFactory
    {
        public IChair createChair()
        {
            return new VintageChair();
        }

        public ISofa createSofa()
        {
            return new VintageSofa();
        }
    }
}
