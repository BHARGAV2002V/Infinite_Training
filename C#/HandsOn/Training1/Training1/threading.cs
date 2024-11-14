using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Training1
{
    class threading
    {
        public  static int counter = 0;
        public static object o = new object();
        public static void IncCounter(string tname)
        {
            for (int i = 0; i < 5000; i++)
            {
                lock(o)
                {
                    counter++;
                }
                Console.WriteLine($"{tname} incremented {i} times");
            }
        }


        static void Main()
        {
            Thread t1 = new Thread( () =>IncCounter("thread 1"));
            Thread t2 = new Thread( () => IncCounter("thread 2"));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
