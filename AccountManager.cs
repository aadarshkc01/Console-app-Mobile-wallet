using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Based_Mobile_Wallet
{
    internal class AccountManager
    {
        public static string AccountHolderName;
        public static int AccountNumber;
        public static double Balance;
        public static string FilePath = @$"C:\\Users\\Lenovo\\Desktop\\Records\";

        public AccountManager(string acName, int acNo, int balance)
        {
            AccountHolderName = acName;
            AccountNumber = acNo;
            Balance = balance;
            StreamWriter sw = new StreamWriter($"{FilePath}{AccountHolderName}_{AccountNumber}.txt",false);
            sw.WriteLine($"Account Holder Name: {AccountHolderName}");
            sw.WriteLine($"Account Number: {AccountNumber}");
            sw.WriteLine($"Initial Deposit Amount: RS. {Balance}");
            sw.Flush();
            sw.Close();
        }

        public static void WriteToFile(string action)
        {
            StreamWriter sw = new StreamWriter($"{FilePath}{AccountHolderName}_{AccountNumber}.txt", true);
            sw.WriteLine($"\nTransaction Date and Time: {DateTime.Now}");
            sw.WriteLine(action);
            sw.Flush();
            sw.Close();
        }

        public static bool isAccountExist()
        {
            try
            {
                StreamReader rw = new StreamReader($"{FilePath}{AccountHolderName}_{AccountNumber}.txt");
                string accHolderName = rw.ReadLine().ToLower();
                string accNumber = rw.ReadLine();

                string name = $"Account Holder Name: {AccountHolderName}".ToLower();
                string number = $"Account Number: {AccountNumber}";

                if (name == accHolderName && number == accNumber)
                {
                    return true;
                }

            }
            catch (FileNotFoundException)
            {
                return false;
            }
            return false;
        }

        public static void CheckTransactionDetails()
        {
            StreamReader sr = new StreamReader($"{FilePath}{AccountHolderName}_{AccountNumber}.txt");
            string data = sr.ReadToEnd();
            Console.WriteLine();
            Console.WriteLine("\n--- Transaction History ---");
            Console.WriteLine($"\n{data}");
            sr.Close();
        }

        public static void AccountDetails()
        {
            Console.WriteLine();
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account Holder Name: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: RS. {Balance}");
            Console.WriteLine();
        }

        public static void DepositAmount(double amount)
        {
            Balance += amount;
            Console.WriteLine($"\nSuccessfully deposited RS. {amount}. New balance is RS. {Balance}.");
            WriteToFile($"Deposited Amount: RS. {amount}\nNew Balance: RS. {Balance}");
        }

        public static void WithdrawAmount(double amount)
        {
            if(amount > Balance)
            {
                Console.WriteLine("\nInsufficient balance. Withdrawal failed.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"\nSuccessfully withdraw RS. {amount}. New balance is RS. {Balance}.");
                WriteToFile($"Withdrawn Amount: RS. {amount}\nNew Balance: RS. {Balance}");
            }
        }
    }
}
