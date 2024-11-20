using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using converter.Factories;
namespace converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input folder");
            String input = Console.ReadLine();
            Console.WriteLine("Enter the format to be converted");
            string format = Console.ReadLine();
            try
            {
                var converter = DocumentConverterFactory.GetConverter(format);
                converter.Convert(input);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
