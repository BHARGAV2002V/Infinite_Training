using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training1
{
    class lambda
    {
        static void Main(string[] args)
        {                                    //List initilaization
            List<int> numbers = new List<int>() { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

            foreach (var value in numbers)
            {
                Console.WriteLine("{0} ", value);
            }

            //using lambda expressions to find the square of all numbers in the List
        

            //find all the numbers divisible by 3 in the list

            var div = numbers.Where(x => x % 3==0);
            Console.WriteLine("-----Numbers divisible by 3------");
            foreach (var i in div)
            {
                Console.Write("{0} ", i);
              
            }
            Console.Read();

        }
    }
}
