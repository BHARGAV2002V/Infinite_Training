using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
/*    2.	Write a program in C# to accept a word from the user and display the reverse of it. 
*/
    class String2
    {
        public string reverse(String str)
        {
            int l= str.Length-1;
            string s="";
            for(int i = l; i >= 0; i--)
            {
                s = s + str[i];
            }
            return s;

        }
        static void Main()
        {
            String2 s = new String2();
            Console.WriteLine("Enter a word");
            string str= Console.ReadLine();
            Console.WriteLine(s.reverse(str));
            Console.ReadLine();
        }
    }
}
