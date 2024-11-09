using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
/*    2. Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input.
If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
If the given mark is >90, then calculate scholarship amount as 50% of the fees.
In all the cases return the Scholarship amount*/
class marksException : ApplicationException
    {
        public marksException(String msg) : base(msg)
        {

        } 
    }
    class Scholarship
    {
        public delegate int MeritMarks(int marks, int fees);
        public static int Merit(int marks,int fees,MeritMarks mm)
        {
            return mm(marks, fees);
        }
        public static void getMarks(int marks)
        {
        
            if (marks > 100)
            {
                throw (new marksException("enter marks between 0 and 100"));
            }

        }
        public static int scholarship_amount(int marks,int fees)
        {
            if (marks >= 70 && marks<=80)
            {
                return (fees * 20) / 100;
            }
            else if(marks>80 && marks <= 90)
            {
                return (fees * 30) / 100;
            }
            else if (marks > 90)
            {
                return (fees * 50) / 100;
            }
            return 0;
        }
    }
    class Question2
    {
            static void Main()
        {
            Console.WriteLine("enter Marks");

            int marks = int.Parse(Console.ReadLine());
            try
            {
                Scholarship.getMarks(marks);
            }
            catch(marksException me)
            {
                Console.WriteLine(me.Message);
            }
            Console.WriteLine("Enter fees");
            int fees = int.Parse(Console.ReadLine());
            int amount = Scholarship.Merit(marks, fees, Scholarship.scholarship_amount);
            Console.WriteLine(amount);
            Console.ReadLine();
        }        
    }
}
