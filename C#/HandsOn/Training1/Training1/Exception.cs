using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training1
{
    class NameException : ApplicationException
    {
        public NameException(string msg) : base(msg) {}
    }
    class name
    {
        string str;
        public void getName()
        {
            Console.WriteLine("Enter your Name :");

            str = Console.ReadLine();
            foreach (char i in str)
            {
                if (char.IsDigit(i))
                {
                    throw (new NameException("Name should not contain Numbers"));

                }
            }
           

            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                throw (new NameException("Name should not be empty or null"));
            }
          
            else
                Console.WriteLine(str.ToUpper());
        }
    }

 
    class Exception
    {
        static void Main()
        {
            name n = new name();
            try
            {
                n.getName();
            }

            catch (NameException ne)
            {
                Console.WriteLine(ne.Message);
            }
            Console.Read();

        }
    }
}
