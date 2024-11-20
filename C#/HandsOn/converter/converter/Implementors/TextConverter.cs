using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using converter.Factories;
namespace converter.Implementors
{
    public class TextConverter:IDocumentConverter
    {
        public void Convert(string data)
        {
            Console.WriteLine($"converting {data} to Text");
        }
    }
}
