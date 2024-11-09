using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{

/*    5. Create an Interface IStudent with StudentId and Name as Properties, void ShowDetails() as its method.
 *    Create 2 classes Dayscholar and Resident that implements the interface Properties and Methods.
*/   
    public interface IStudent
    {
         int studentid { get; set; }
         string name{ get; set; }

         void ShowDetails();
    }
    public class Dayscholar : IStudent
    {
       
        public int studentid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public Dayscholar(int studentid, string name)
        {
            this.studentid = studentid;
            this.name = name;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Day scholar Student id is    : {studentid}");

            Console.WriteLine($"Day scholar student Name is  : {name}");
        }
    }
    public class Resident : IStudent
    {

        public int studentid
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public Resident(int studentid, string name)
        {
            this.studentid = studentid;
            this.name = name;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Resident Student id is    : {studentid}");

            Console.WriteLine($"Resident student Name is  : {name}");
        }
    }
    class Question5
    {
        static void Main()
        {
            Console.WriteLine("Enter dayscholar student Id");
            int stuid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter dayscholar student Name");
            string name = Console.ReadLine();
            IStudent ds = new Dayscholar(stuid,name);
            Console.WriteLine("==========Dayscholar details============");
            ds.ShowDetails();
            Console.WriteLine("=========================================");
            Console.WriteLine("Enter Resident student Id");
            int resid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Resident student Name");
            string resname = Console.ReadLine();
            IStudent res = new Resident(resid,resname);
            Console.WriteLine("===============resident details==========");
            res.ShowDetails();
            Console.ReadLine();
        }
    }
}
