using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Based_Mobile_Wallet
{
    internal class MenuManager
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("\nEnter your account details to proceed..........");

            Console.Write("Account Holder Name: ");
            string accountHolderName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(accountHolderName))
            {
                Console.WriteLine("\nAccount Holder Name cannot be empty. Please enter a valid name.");
                DisplayMenu();
                return;
            }
          
            bool flag = true;
            while (flag)
            {
                Console.Write("Account Number: ");
                string input1 = Console.ReadLine();
                int accountNumber;

                if (int.TryParse(input1, out accountNumber))
                {
                    AccountManager.AccountHolderName = accountHolderName;
                    AccountManager.AccountNumber = accountNumber;

                    // check account already existed or not
                    bool isNotValidAccount = AccountManager.isAccountExist();
                    if (isNotValidAccount)
                    {
                        Console.WriteLine("Invalid!! Account already existed. You cannot open multiple account.");
                        return;
                    }

                    while (flag)
                    {
                        Console.Write("Initial Deposit Amount: RS. ");
                        string input2 = Console.ReadLine();
                        int initialDeposit;

                        if (int.TryParse(input2, out initialDeposit))
                        {
                            AccountManager account = new AccountManager(accountHolderName, accountNumber, initialDeposit);
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number for the deposit amount.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for the account number.");
                }
            }

                while (true)
                {
                    Console.WriteLine("\n--- Mobile Wallet Menu ---");
                    Console.WriteLine("1. Check Account Details");
                    Console.WriteLine("2. Deposit Funds");
                    Console.WriteLine("3. Withdraw Funds");
                    Console.WriteLine("4. Check all transaction history");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option (1-5): ");
                    string choice = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();

                    if (choice == "1")
                    {
                        AccountManager.AccountDetails();
                    }
                    else if (choice == "2")
                    {
                        //DepositFunds;
                        Console.Write("\nEnter deposit amount: RS. ");
                        string input = Console.ReadLine();

                        if (double.TryParse(input, out double amount) && amount > 0)
                        {
                            AccountManager.DepositAmount(amount);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Please enter a valid positive number for the deposit amount.");
                        }
                    }
                    else if (choice == "3")
                    {
                        //AccountManager.WithdrawFunds();
                        Console.Write("\nEnter withdrawal amount: RS. ");
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out double amount) && amount > 0)
                        {
                            AccountManager.WithdrawAmount(amount);
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Please enter a valid positive number for the withdrawal amount.");
                        }
                    }
                    else if (choice == "4")
                    {
                        //AccountManager.ViewTransactionHistory();
                        AccountManager.CheckTransactionDetails();
                    }
                    else if (choice == "5")
                    {
                        Console.WriteLine("\n\nExiting the application. GoodBye!, have a nice day.... ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice. Please select a valid option.");
                    }
                }
            }
        }
}
