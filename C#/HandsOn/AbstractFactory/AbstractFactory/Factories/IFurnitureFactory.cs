using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;
using AbstractFactory.Concrete;
namespace AbstractFactory.Factories
{
    public interface IFurnitureFactory
    {
        IChair createChair();
        ISofa createSofa();
    }
}
