using System;


namespace Training1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* --------------------Basics-------------------*/

            Console.WriteLine("enter name");
            String name = Console.ReadLine();
            Console.WriteLine("Enter number");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(name+" "+num);


            /* -----------------Data Conversion and Type Casting---------------*/
            int i = 10;
            float f = i;
            Console.WriteLine(f);
            int t = (int)f;
            Console.WriteLine(t);

            /* ----------------Parse and TryParse-----------------*/
            String str = "3141";
            int n = int.Parse(str);
            Console.WriteLine(n);

            String s = "bhargav";
            int res = 0;
            bool b = int.TryParse(s, out res);
            Console.WriteLine(b);
            Console.ReadLine();

            /*-----------------------Boxing and Unboxing---------------*/


        }
    }
}
