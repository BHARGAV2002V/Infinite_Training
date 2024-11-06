using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
/*    2. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
Sample Input:
"abcd"
"a"
"xy"
Expected Output:
 
dbca
a
yx*/
   
    class Question2
    {
        public void exchange(string str)
        {
            string s="";
            int l = str.Length;
            string fp = Convert.ToString( str[0]);
            string lp = Convert.ToString( str[l - 1]);
            s += lp;
            for(int i = 1; i < str.Length-1; i++)
            {
                s = s + str[i];
            }
            s += fp;
            Console.WriteLine("the result is {0}",s);
        }

        static void Main()
        {
            Question2 q2 = new Question2();
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            q2.exchange(str);
            Console.ReadLine();
        }

    }
}
