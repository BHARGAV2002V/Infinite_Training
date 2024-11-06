using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
/*    4. Create a program to count the no.of occurrences of a letter in a given string (eg: "OOPs Programming", o appears 3 times)
Hint : Accept a string and also the letter to be counted*/


    class Question4
    {
        public void occurences(String str,char ch)
        {
            int c = 0;
            foreach(char i in str)
            {
                if (i == ch)
                {
                    c++;
                }
            }
            Console.WriteLine("occurencs of {0} is {1}", ch, c);
        }
        
        static void Main()
        {
            Question4 q4 = new Question4();
            Console.WriteLine("Enter string");
            string str = Console.ReadLine();
            Console.WriteLine("Enter Character");
            char ch = Convert.ToChar(Console.ReadLine());

            q4.occurences(str, ch);
            Console.ReadLine();
        }
    }
    
}
