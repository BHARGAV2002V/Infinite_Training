using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assessment3_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter product name");
            string productname = Console.ReadLine();
            Console.WriteLine("Enter product price");
            int price = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(@"Data Source=ICS-LT-D244D678\SQLEXPRESS;Initial Catalog=Assessment;" +
                "Integrated Security=true;"))
            {
                conn.Open();
                using(SqlCommand cmd=new SqlCommand("procproduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@price", price);
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@productId";
                    param1.DbType = DbType.Int32;
                    param1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param1);
                    cmd.ExecuteNonQuery();
                    int productid = (int)param1.Value;
                    int discprice = (int)(price - ((price) * 10 / 100));
                    Console.WriteLine();
                    Console.WriteLine($"-------------product added successfully-----------");
                    Console.WriteLine($"Generated product Id : {productid}");
                    Console.WriteLine($"Discounted price : {discprice}");
                }
               
            }

            Console.ReadLine();
        }
    }
}
