using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Concrete;
using AbstractFactory.Abstract;
using AbstractFactory.Factories;
namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter furniture Type (modern or vintage)");
            string furnituretype = Console.ReadLine();
            IFurnitureFactory factory=FurnitureFactory.GetFactory(furnituretype);
            Console.WriteLine("Enter furniture product(chair or sofa)");
            string str = Console.ReadLine();
            if (str.Equals("chair"))
            {
                IChair chair = factory.createChair();
                chair.Sitting();

            }
            else if (str.Equals("sofa"))
            {
                ISofa sofa = factory.createSofa();
                sofa.LayOn();
            }
            
            Console.ReadLine();
        }
    }
}
