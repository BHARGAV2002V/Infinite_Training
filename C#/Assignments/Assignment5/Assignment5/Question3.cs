using System;
using System.IO;

namespace Assignment5
{
/*    3. Write a program in C# Sharp to count the number of lines in a file.
*/
    class Question3
    {
        static void Main()
        {
            string path = @"C:\Infinite training\Training_Official\C#\C#.txt";
            if (File.Exists(path))
            {
                int count = File.ReadAllLines(path).Length;
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine("File does not Exist");
            }
            Console.Read();
        }
    }
}
