using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract;
namespace AbstractFactory.Concrete
{
    public class ModernChair : IChair
    {
        public void Sitting()
        {
            Console.WriteLine("Sitting on a modern Chair");
        }
    }
}
