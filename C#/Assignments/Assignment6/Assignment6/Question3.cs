using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Employee
    {
        public int EmpId;
        public string EmpName;
        public string EmpCity;
        public float EmpSalary;
         
    }
    class Question3
    {
        static void Main()
        {
            List<Employee> emp = new List<Employee>();
            Console.WriteLine("Enter the number of employees");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter Employee {i+1} details");
                int EmpId = int.Parse(Console.ReadLine());

                string EmpName = Console.ReadLine();
                string EmpCity = Console.ReadLine();
                float EmpSalary = Convert.ToSingle(Console.ReadLine());
                emp.Add(new Employee
                {
                EmpId = EmpId,
                EmpName = EmpName,
                EmpCity = EmpCity,
                EmpSalary = EmpSalary
                }
                  );
            }
            Console.WriteLine("=============Display all employees=============");
           foreach(var e in emp)
            {
                Console.WriteLine($"Emp Id  :   {e.EmpId}, Emp Name  :   {e.EmpName}, Emp City  :   {e.EmpCity}, Emp Salary  :   {e.EmpSalary}");
            }

            Console.WriteLine("=============Display all employees salary greater than 4500=============");

            var empb = emp.Where(e => e.EmpSalary > 4500).ToList();
            foreach (var e in empb)
            {
                Console.WriteLine($"Emp Id  :   {e.EmpId}, Emp Name  :   {e.EmpName}, Emp City  :   {e.EmpCity}, Emp Salary  :   {e.EmpSalary}");
            }
            Console.WriteLine("=============Display all employees belong to banglore region=============");

            var empc = emp.Where(e => e.EmpCity == "banglore").ToList();
            foreach (var e in empc)
            {
                Console.WriteLine($"Emp Id  :   {e.EmpId}, Emp Name  :   {e.EmpName}, Emp City  :   {e.EmpCity}, Emp Salary  :   {e.EmpSalary}");
            }
            Console.WriteLine("=============Display all employees in Ascending order=============");

            var empd = emp.OrderBy(e=>e.EmpName).ToList();
            foreach (var e in empd)
            {
                Console.WriteLine($"Emp Id  :   {e.EmpId}, Emp Name  :   {e.EmpName}, Emp City  :   {e.EmpCity}, Emp Salary  :   {e.EmpSalary}");
            }


            Console.ReadLine();
           
        }
        
    }
}
