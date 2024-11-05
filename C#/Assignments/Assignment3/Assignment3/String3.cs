using System;


namespace Assignment3
{
/*    3.	Write a program in C# to accept two words from user and find out if they are same. 
*/
    class String3
    {
        static Boolean same(string s1,string s2)
        {
            return s1.Equals(s2);
        }
        static void Main()
        {
            Console.WriteLine("Enter word 1");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter word 2");
            string s2 = Console.ReadLine();
            Console.WriteLine(same(s1, s2));
            Console.ReadLine();

        }
    }
}
