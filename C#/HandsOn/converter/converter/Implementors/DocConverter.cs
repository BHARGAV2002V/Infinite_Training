using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using converter.Factories;
namespace converter.Implementors
{
    public class DocConverter:IDocumentConverter
    {
        public void Convert(string data)
        {
            Console.WriteLine($"Converting {data} to Document");
        }
    }
}
