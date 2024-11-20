using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;
using AbstractFactory.Concrete;

namespace AbstractFactory.Factories
{
    public class ModernFactory : IFurnitureFactory
    {
        public IChair createChair()
        {
            return new ModernChair();
        }
        public ISofa createSofa()
        {
            return new ModernSofa();
        }
    }
}
