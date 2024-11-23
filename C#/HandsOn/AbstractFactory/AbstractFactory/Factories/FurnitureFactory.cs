using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories
{
    public static class FurnitureFactory
    {
        public static IFurnitureFactory GetFactory(string type)
        {
            if (type.Equals("modern"))
            {
                return new ModernFactory();
            }
            else if (type.Equals("vintage"))
            {
                return new VintageFactory();
            }
            else
            {
                throw new ArgumentException("Invalid");
            }
        }
    }
}
