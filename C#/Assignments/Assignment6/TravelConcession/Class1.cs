using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcession
{
    public class Class1
    {
        public void CalculateConcession(int age,double Total)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double concession = (Total * 30) / 100;
                Console.WriteLine($"Senior Citizen - Fare : {concession}");
            }

            else
            {
                Console.WriteLine($"Ticket Booked - Fare : {Total}");
            }
        }
    }
}
