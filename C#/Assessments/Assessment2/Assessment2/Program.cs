using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
/*    1. Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.

Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 
Test the above by creating appropriate objects*/

    public abstract class Student
    {
        public string Name;
        public int StudentId;
        public double Grade;

        public abstract bool IsPassed(double Grade);
    }

    public class Undergraduate : Student
    {
        public override bool IsPassed(double Grade)
        {
            if (Grade >= 70.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
    }

    public class Graduate : Student
    {
        public override bool IsPassed(double Grade)
        {
            if(Grade >= 80.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter type of the student(Under graduate or graduate)");
            string type = Console.ReadLine();
            Console.WriteLine("Enter student Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student Id");
            int s_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Grade");
            double grade = Convert.ToDouble(Console.ReadLine());
            Student s;
            if (type == "undergraduate")
            {
                s = new Undergraduate();
            }
            else
            {
                s = new Graduate();
            }

            s.Name = name;
            s.StudentId = s_id;
            s.Grade = grade;
            Console.WriteLine("--------------Student details------------");
            Console.WriteLine($"Name       : {name}");
            Console.WriteLine($"student id : {s_id}");
            Console.WriteLine($"Grade      : {name}");
            Console.WriteLine($"Is Passed  : {s.IsPassed(grade)}");

            Console.ReadLine();
        }
    }
}
