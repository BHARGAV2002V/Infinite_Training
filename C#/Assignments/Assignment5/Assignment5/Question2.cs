using System;
using System.IO;

namespace Assignment5
{
/*    2. Write a program in C# Sharp to create a file and write an array of strings to the file.
*/
    class Question2
    {

        static void Main()
        {
            Console.WriteLine("Enter size of array");
            int n = int.Parse(Console.ReadLine());
            string[] str = new string[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter string {i+1}");
                str[i] = Console.ReadLine();
            }


            string path = "OUTPUT5.txt";
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach(string s in str)
            {
                sw.WriteLine(s);
            }
            Console.WriteLine("Written to the file Successfully");
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.ReadLine();

        }
    }
}
