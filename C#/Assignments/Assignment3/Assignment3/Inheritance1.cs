using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    
/*1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type(d/w), amount, balance
D->Deposit
W->Withdrawal
-write a function that updates the balance depending upon the transaction type
	-If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance
  function Credit(int amount)
	-If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance
  Debit(int amt) function 
-Pass the other information like Acount no, customer name, acc type through constructor
-write and call the show data method to display the values.
*/
    class Accounts
    {
        public int Accno,amount;
        public float bal;
        public string cust_name;
        public string acc_type,transaction_type;
        public Accounts(int Accno,String cust_name,String acc_type,String transaction_type,float bal)
        {
            this.Accno = Accno;
            this.cust_name = cust_name;
            this.acc_type = acc_type;
            this.transaction_type = transaction_type;
            this.bal = bal;
        }
        public void credit(int n)
        {
            if (n > 0)
            {
                bal += n;
                Console.WriteLine("Amount credited successfully");
            }
            else
            {
                Console.WriteLine("Not credited");
            }

        }
        public void debit(int n)
        {
            if(n>0 && n < bal)
            {
                bal -= n;
                Console.WriteLine("Amount debited successfully");
            }
        }

        public void balance(string transaction_type,int amount)
        {
            if (transaction_type == "d")
            {
                credit(amount);
            }
            else
            {
                debit(amount);
            }
        }

        public void showdata()
        {
            Console.WriteLine("Account number is {0} ",Accno);
            Console.WriteLine(" Customer name is {0} ", cust_name);
            Console.WriteLine("Account Type is {0} ", acc_type);
            Console.WriteLine("Transaction Type is {0} ", transaction_type);
            Console.WriteLine("Balance is {0} ", bal);

        }

    }
    class Inheritance1
    {
        static void Main()
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

            Accounts a = new Accounts(accno,cust_name,acc_type,Transaction_type,amount);
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
                    a.balance(t_t, amt);
                }
                a.showdata();
            }
            Console.ReadLine();
        }
    }
}
