using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    /*    2. Create a Class called Products with Productid, 
            Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products*/
    class Question2
    {
        static void Main(string[] args)
        {
            List<Products> p_list = new List<Products>();
            Console.WriteLine("Enter Details of products");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter product {i + 1}");
                Console.WriteLine("Enter product Id");
                int prodid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter product Name");
                string prodname = Console.ReadLine();
                Console.WriteLine("Enter product price");
                float price = Convert.ToSingle(Console.ReadLine());
                p_list.Add(new Products(prodid, prodname, price));

            }




            p_list.Sort();

            Console.WriteLine("---------After sorting by price----------");
            foreach (Products p in p_list)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();
        }
        public class Products : IComparable<Products>
        {
            public int prodid;
            public string prodname;
            public float price;

            public Products(int prodid, string prodname, float price)
            {
                this.prodid = prodid;
                this.prodname = prodname;
                this.price = price;
            }

            public override string ToString()
            {
                return $"Product Name : {prodname}, product Id : {prodid} , product price : {price}";
            }

            public int CompareTo(Products p)
            {
                return this.price.CompareTo(p.price);
            }

        }
    }
}

  
    

  

