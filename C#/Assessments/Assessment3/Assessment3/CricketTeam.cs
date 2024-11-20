using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class CricketTeam
    {
        public void PointsCalculation(int no_of_matches)
        {
            int sum = 0;
            int[] scores = new int[no_of_matches];
            for(int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine($"Enter the score for match{i+1}");
                scores[i] = int.Parse(Console.ReadLine());
                sum += scores[i];
            }
            float avg = (float)sum / no_of_matches;
            Console.WriteLine($"Total matches played {no_of_matches}");
            Console.WriteLine($"Total runs scored {sum}");
            Console.WriteLine($"Average points scored {avg}");

        }
        static void Main()
        {
            CricketTeam ct = new CricketTeam();
            Console.WriteLine("Enter no of matches played");
            int n = int.Parse(Console.ReadLine());
            ct.PointsCalculation(n);
            Console.ReadLine();
        }
    }
}
