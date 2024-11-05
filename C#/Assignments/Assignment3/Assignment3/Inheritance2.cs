using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
/*    2. Create a class called student which has data members like rollno, name, class, Semester, branch, 
 *    int[] marks = new int marks[5] (marks of 5 subjects )
-Pass the details of student like rollno, name, class, SEM, branch in constructor
-For marks write a method called GetMarks() and give marks for all 5 subjects
-Write a method called displayresult, which should calculate the average marks
-If marks of any one subject is less than 35 print result as failed
-If marks of all subject is >35,but average is < 50 then also print result as failed
-If avg > 50 then print result as passed.
-Write a DisplayData() method to display all object members values.*/

    class student
    {
        public int rollno, semester;
        public string name,classs,branch;
        public int[] marks;

        public student(int rollno,string name,string classs,int semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.classs = classs;
            this.semester = semester;
            this.branch = branch;
            marks = new int[5];
        }
        public void getMarks()
        {
            Console.WriteLine("Enter Marks of 5 subjects");
            for(int i = 0; i < marks.Length; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void display_result()
        {
            int sum = 0;
            Boolean fail = false;
            foreach(int i in marks)
            {
                sum += i;
                if (i < 35)
                {
                    fail=true;
                }
            }
            int avg = sum / marks.Length;
            if (fail)
            {
                Console.WriteLine("Failed");
            }
            else if (avg < 50)
            {
                Console.WriteLine("failed...avg is < 50");
            }
            else if(avg > 50)
            {
                Console.WriteLine("Passed");
            }

            

        }
        public void display_data()
        {
            Console.WriteLine("Roll no : {0}",rollno);
            Console.WriteLine("Name    : {0}", name);
            Console.WriteLine("Class   : {0}", classs);
            Console.WriteLine("semester: {0}", semester);
            Console.WriteLine("Branch  : {0}", branch);
        }
        
    }
    class Inheritance2
    {
        static void Main()
        {
            Console.WriteLine("enter rollno");
            int rollno = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("enter Class");

            string classs = Console.ReadLine();
            Console.WriteLine("enter Semester");

            int semester = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Branch");

            string branch = Console.ReadLine();
            student st = new student(rollno,name,classs,semester,branch);
            st.getMarks();
            st.display_result();
            st.display_data();
            Console.ReadLine();

        }
    }
}
