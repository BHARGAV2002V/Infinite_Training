using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
/*    1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
Sample Input:
"Python", 1
"Python", 0
"Python", 4
Expected Output:
Pthon
ython
Pythn*/
    class rem_pos{
    public void rem_position(String str, int n)
        {
            string s = "";
            if (n < 0 || n >= str.Length)
            {
                Console.WriteLine("Please enter the number in range");
            }
            else
            {


                for (int i = 0; i < str.Length; i++)
                {
                    if (i == n)
                    {
                        continue;
                    }
                    else
                    {
                        s = s + str[i];
                    }
                }
                Console.WriteLine(s);
            }
        }
       
    }

    class Question1
    {

        static void Main(string[] args)
        {
            rem_pos rp = new rem_pos();
            Console.WriteLine("Enter String");
            string str = Console.ReadLine();
            Console.WriteLine("Enter number");
            
            int n=int.Parse(Console.ReadLine());
            rp.rem_position(str, n);
            Console.ReadLine();
        }
    }
}
