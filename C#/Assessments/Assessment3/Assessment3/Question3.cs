using System;
using System.IO;

namespace Assessment3
{
    public class FileException : ApplicationException
    {
        public FileException(string message) : base(message) { }
    }
    class Question3
    {
        static void Main()
        {
            string path = @"C:\Infinite training\Training_Official\C#\Assessments\Assessment3\Assessment3\OUTPUT.txt";
            Console.WriteLine("Enter text");
          
            try
            {
                string txt = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(txt))
                {
                    throw (new FileException("Text cannot be empty"));
                }


                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(txt);
                        Console.WriteLine("Text appended successfully");
                    }
                }
            }
            catch(FileException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}
