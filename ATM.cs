using System;



namespace Assignment1

{
    class ATM
    {
        static Account[] acctArray = new Account[3];
        static bool acctscreated = false;

        public static void Main(string[] args)
        {
            ATM ATM = new ATM();
            ATM.topMenu();
        }

        public static void populateArray()
        {
            if (acctscreated == false)
            {
                for (int i = 0; i <= 2; i++)
                {
                    string accountname;
                    Console.WriteLine("Write the name of account " + i + ".");
                    accountname = Console.ReadLine();
                    acctArray[i] = new Account(accountname, 100);
                    Console.WriteLine("Account " + i + " created successfully!");
                }

                acctscreated = true;
            }
            else Console.WriteLine("Error: Accounts have already been created.");
        }

        public static void topMenu()
        {

            //RunAccount ra = new RunAccount();
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("Please choose one of the following:");
                Console.WriteLine("1) Populate Accounts");
                Console.WriteLine("2) Load Accounts from file");
                Console.WriteLine("3) Select Account");
                Console.WriteLine("4) Exit");


                input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    populateArray();
                }

                else if (input == 2 && acctscreated == true)
                {
                    //loadAccountFromFile();
                }

                else if (input == 3 && acctscreated == true)
                {
                    selectAccount();
                }

                else if (input == 3 && acctscreated == false)
                {
                    Console.WriteLine("Error: Accounts have not yet been created.");
                }

                else if (input == 4)
                {
                    int exitCode = 0;
                    Environment.Exit(exitCode);
                }

                else if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }

        public static void selectAccount()
        {

            Console.WriteLine("Please enter account 0, 1, or 2");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());
            acctArray[selectedIndex].menu();

        }
    }
}