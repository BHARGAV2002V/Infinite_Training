using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /*    1.
    •	You have a class which has methods for transaction for a banking system. (created earlier)
    •	Define your own methods for deposit money, withdraw money and balance in the account.
    •	Write your own new application Exception class called InsuffientBalanceException.
    •	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
    •	Identify and categorize all possible checked and unchecked exception.*/

    class InsuffientBalanceException : ApplicationException
    {
        public InsuffientBalanceException(string msg) : base(msg)
        {

        }
    }
    class Accounts
    {
        public int Accno, amount;
        public float bal;
        public string cust_name;
        public string acc_type, transaction_type;
        public Accounts(int Accno, String cust_name, String acc_type, String transaction_type, float bal)
        {
            this.Accno = Accno;
            this.cust_name = cust_name;
            this.acc_type = acc_type;
            this.transaction_type = transaction_type;
            this.bal = bal;
        }
        public void deposit(int n)
        {
            if (n > 0)
            {
                bal += n;
                Console.WriteLine("Amount credited successfully");
            }
            else
            {
                throw (new InsuffientBalanceException("Enter amount greater than Zero"));
            }

        }
        public void withdraw(int n)
        {
            if (n > 0 && n < bal)
            {
                bal -= n;
                Console.WriteLine("Amount debited successfully");
            }
            else if (n > bal)
            {
                throw (new InsuffientBalanceException("Insufficient balance"));
            }
        }

        public void balance(string transaction_type, int amount)
        {
            if (transaction_type == "d")
            {
                deposit(amount);
            }
            else
            {
                withdraw(amount);
            }
        }

        public void showdata()
        {
            Console.WriteLine("Account number is   {0} ", Accno);
            Console.WriteLine("Customer name is    {0} ", cust_name);
            Console.WriteLine("Account Type is     {0} ", acc_type);
            Console.WriteLine("Transaction Type is {0} ", transaction_type);
            Console.WriteLine("Balance is          {0} ", bal);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Account number");
            int accno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter  Customer Name");
           
            string cust_name = Console.ReadLine();
            
            Console.WriteLine("Enter Account Type(current/savings)");
            string acc_type = Console.ReadLine();
            Console.WriteLine("Enter  Transaction Type (D/W)");
            string Transaction_type = Console.ReadLine();
            Console.WriteLine("Enter Amount");
            int amount = Convert.ToInt32(Console.ReadLine());
      
            Accounts a = new Accounts(accno, cust_name, acc_type, Transaction_type, amount);
         
            a.showdata();
                while (true)
                {
                    Console.WriteLine("Enter Transaction Type(D/W)");
                    string t_t = Console.ReadLine();
                    if (t_t == "q")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Amount");
                        int amt = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        a.balance(t_t, amt);
                    }
                    catch(InsuffientBalanceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch(Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                    } 
                    a.showdata();
                
             
            }
            Console.ReadLine();

        }
    }
}
