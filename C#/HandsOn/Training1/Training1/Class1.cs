using System;

namespace Training1
{
    class Class1
    {

        public static int Calculator(int a, int b, out int sum, out int product, out float division)

        {

            sum = a + b;  //addition

            product = a * b;  //multiplication

            division = a / b;  //Division

            

            return a - b;


        }
        static void Main()
        {
            int Total, Prod, Difference;

            float div;
           

            Difference = Class1.Calculator(12, 6, out Total, out Prod, out div);

            Console.WriteLine("Sum = {0} Product = {1}, Difference = {2}, and Division = {3}", Total, Prod, Difference,div);

            var x = 10;
            var y = "abc";
            Console.WriteLine(x+" "+y);
            Console.WriteLine(x.GetType() + " " + y.GetType());
            dynamic d;
            d = 10;
            d = "abc";
            Console.WriteLine(d.GetType() + " " + d.GetType());

            Console.Read();
        }

    }
}
