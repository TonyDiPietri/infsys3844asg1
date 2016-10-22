using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Assignment1

{

    class Account
    {
        protected double balance;
        protected string name;
        //protected int firstdate;
        //protected int seconddate;
        DateTime firstDate;
        DateTime secondDate;
        protected bool dateflag = false;
        protected double rate = .05;

        public Account(string arg_name, double arg_bal)
        {
            name = arg_name;
            balance = arg_bal;
        }

        public void withdraw()
        {
            calcint();
            Console.WriteLine("Currently in " + name + "'s account");
            Console.WriteLine("Enter the amount you wish to withdraw");
            int input = Convert.ToInt32(Console.ReadLine());
            //Check to make sure that the withdraw amount is not more than the balance
            if (input <= balance)
            {
                balance = balance - input;
                //Console.WriteLine("Your new balance is $" + balance + "; don't spend it all in one place.");
            }
            else Console.WriteLine("INSUFFICIENT FUNDS. DEADBEAT DETECTED.");
        }

        public void deposit()
        {
            calcint();
            Console.WriteLine("Currently in " + name + "'s account");
            Console.WriteLine("Enter the amount you wish to deposit:");
            int input = Convert.ToInt32(Console.ReadLine());
            //TODO: need to calculate interest and add it FIRST, call the calcInt() method
            balance = balance + input;
            //Console.WriteLine("Your new balance is $" + balance);
        }

        public void calcint()
        {
            if (dateflag == true)
            {
                getDate2();
                double datediff = (secondDate - firstDate).TotalDays;
                rate = rate / 365;
                double ratetime = Math.Pow(1 + rate, datediff);
                balance = balance * ratetime;
                string balstring = string.Format("{0:#.00}", Convert.ToDecimal(balance));
                Console.WriteLine("Your updated balance including interest is: $" + balstring);
                firstDate = secondDate;
            }
            else getDate1();
            //Console.ReadLine();
        }

        public void getInterest()
        {

        }

        public void getDate1()
        {
            Console.WriteLine("Please enter the current date in MM/DD/YYYY format.");    //enter the date
            try
            {
                firstDate = Convert.ToDateTime(Console.ReadLine());     //take input, convert to date
            }
            catch
            {
                Console.WriteLine("Incorrect format, please try again");
                getDate1();
            }

            dateflag = true;
        }

        public void getDate2()
        {
            Console.WriteLine("Please enter the current date in MM/DD/YYYY format.");    //enter the date
            try
            {
                secondDate = Convert.ToDateTime(Console.ReadLine());     //take input, convert to date
            }
            catch
            {
                Console.WriteLine("Incorrect format, please try again");
                getDate2();
            }

            if (firstDate > secondDate)
            {
                Console.WriteLine("Error: you cannot specify a date that is earlier than the last transaction.");
            }
        }

        public void getbalance()
        {
            string balstring = string.Format("{0:#.00}", Convert.ToDecimal(balance));
            Console.WriteLine("Currently in " + name + "'s account");
            //TODO: check and add interest
            Console.WriteLine("Your current balance is $" + balstring);
        }

        public void menu()
        {
            int input = 0;
            while (input != 5)
            {
                string balstring = string.Format("{0:#.00}", Convert.ToDecimal(balance));
                Console.WriteLine("Currently in " + name + "'s account. Balance is: $" + balstring);
                Console.WriteLine("Please choose one of the following:");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3) Calculate Interest");
                Console.WriteLine("4) Check Balance");
                Console.WriteLine("5) Exit");

                input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    deposit();
                }

                else if (input == 2)
                {
                    withdraw();
                }

                else if (input == 3)
                {
                    calcint();
                }

                else if (input == 4)
                {
                    getbalance();
                }

                else if (input == 5)
                {
                    //int exitCode = 0;
                    //Environment.Exit(exitCode);

                }

                else if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }
    }
}