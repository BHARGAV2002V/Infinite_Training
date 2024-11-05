using System;


namespace Assignment3
{
/*    1.	Write a program in C# to accept a word from the user and display the length of it.
*/
    class String1
    {
        static int stringlength(string str)
        {
            return str.Length;
           

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word");
            string str = Console.ReadLine();
            Console.WriteLine(stringlength(str));
            Console.ReadLine();
        }
    }
}
