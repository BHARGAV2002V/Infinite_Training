using System;


namespace Assignment3
{
/*    3. Create a class called Saledetails which has data members like 
 *       Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
        - Create a method called Sales() that takes qty, Price details of the object 
        and updates the TotalAmount as  Qty* Price
        - Pass the other information like SalesNo, Productno, Price, Qty and Dateof sale through constructor
        - call the show data method to display the values without an object.*/
       class Saledetails
    {
        public int salesno,productno,price,qty,totalamount;
        public DateTime dateofsale;

        public Saledetails(int salesno,int productno,int price,int qty,DateTime dateofsale)
        {
            this.salesno = salesno;
            this.productno = productno;
            this.price = price;
            this.qty = qty;
            this.dateofsale = dateofsale;
            Sales(qty, price);
        }

        public void Sales(int qty,int price)
        {
            totalamount = qty * price;
        }

        public static void showdata(Saledetails s)
        {
            Console.WriteLine("Sales number   : {0}",s.salesno);
            Console.WriteLine("Product number : {0}", s.productno);
            Console.WriteLine("Price          : {0}", s.price);
            Console.WriteLine("Quantity       : {0}", s.qty);
            Console.WriteLine("Date of Sale   : {0}", s.dateofsale);
            Console.WriteLine("Total Amount   : {0}", s.totalamount);

        }

    }
    class Inheritance3
    {
        static void Main()
        {
            Console.WriteLine("Enter sales no");

            int salesno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product no");
            int productno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of sale");
            DateTime dateofsale = Convert.ToDateTime(Console.ReadLine());
            Saledetails s = new Saledetails(salesno,productno,price,qty,dateofsale);
            Console.WriteLine(" ================ ");

            Saledetails.showdata(s);
            Console.ReadLine();
        }
    }
}
