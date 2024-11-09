using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /*    4. Create an Employee class with Empid int, Empname string, Salary float. 
     *    Pass values to the members through Constructor.
            Create a derived class called ParttimeEmployee with Wages as a data member.
            Instantiate the base class through the derived class constructor*/

    class Employee
    {
        private int Empid;
        private string Empname;
        private float Salary;

        public int Employeid{
            get { return Empid; }
            set { Empid = value; }
        }
        public string Employeename
        {
            get { return Empname; }
            set { Empname = value; }
        }
        public float Employeesalary
        {
            get { return Salary; }
            set { Salary = value; }
        }
        public Employee(int Empid,String Empname,float Salary)
        {
            this.Empid = Empid;
            this.Empname = Empname;
            this.Salary = Salary;
        }
        public void display()
        {
            Console.WriteLine($"Employee id   : {Empid}");
            Console.WriteLine($"Employee name : {Empname}");
            Console.WriteLine($"Salary        : {Salary}");
        }
    }
    class ParttimeEmployee : Employee
    {
        private float wages;
        public float empwages
        {
            get { return wages; }
            set { wages = value; }
        }
        public ParttimeEmployee(int Empid, string Empname, float Salary, float wages) : base(Empid,Empname,Salary)
        {
            this.wages = wages;
        }
        public void displaywages()
        {
            base.display();
            Console.WriteLine($"wages         : {wages}");
        }
    }
    class Question4
    {
        static void Main()
        {
            Console.WriteLine("enter employee id");
            int empid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter employee name");

            string empname = Console.ReadLine();
            Console.WriteLine("enter employee salary");

            float salary = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("enter employee wages");

            float wages = Convert.ToSingle(Console.ReadLine());
            ParttimeEmployee pe = new ParttimeEmployee(empid, empname, salary,wages);
            Console.WriteLine("==========employee details===========");
            pe.displaywages();
            Console.Read();
        }
    }
}
