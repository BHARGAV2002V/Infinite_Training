using System;
using TravelConcession;

namespace Assignment6
{
    class Question4
    {
        public const double Total = 500;
        static void Main()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age");
            int age = int.Parse(Console.ReadLine());

            Class1 c = new Class1();
            Console.WriteLine($"Hello {name}");
            c.CalculateConcession(age, Total);
            Console.ReadLine();
        }
    }
}
