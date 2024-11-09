using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training1
{
    class comparer
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>
            {
                new Employee(200, "Bhargav", 50000, "Infinite"),
                new Employee(130, "Mahesh Babu", 52000, "Infinite"),
                new Employee(250, "Virat kohli", 48000, "Infinite")
            };

          

            emplist.Sort();

            Console.WriteLine("---------After sorting by EmpId----------");
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e.ToString());
            }

            emplist.Sort(new EmpComparison());
            Console.WriteLine("---------After sorting by EmpName----------");

            foreach (Employee e in emplist)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
        
    }

    public class Employee : IComparable<Employee>
    {
        public int EmpId;
        public string EmpName;
        public float Salary;
        string Company;

        public Employee(int id, string name, float sal, string comp)
        {
            EmpId = id;
            EmpName = name;
            Salary = sal;
            Company = comp;
        }

        public override string ToString()
        {
            return $"Employee Named : {EmpName} with Id : {EmpId} Works for {Company} and Earns Rs. : {Salary}";
        }

        public int CompareTo(Employee e)
        {
            return this.EmpId.CompareTo(e.EmpId); 
        }

    }
    
    public class EmpComparison : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.EmpName.CompareTo(y.EmpName); 
        }
    }
}
