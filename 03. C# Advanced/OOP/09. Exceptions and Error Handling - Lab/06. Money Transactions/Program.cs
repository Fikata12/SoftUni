using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Money_Transactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputBankAccounts = Console.ReadLine().Split(',');
            List<BankAccount> bankAccounts = new List<BankAccount>();
            foreach (var bankAccount in inputBankAccounts)
            {
                int accountNumber = int.Parse(bankAccount.Split('-')[0]);
                decimal accountBalance = decimal.Parse(bankAccount.Split('-')[1]);
                bankAccounts.Add(new BankAccount(accountNumber, accountBalance));
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputToArray = input.Split();
                string cmd = inputToArray[0];
                int accountNumber = int.Parse(inputToArray[1]);
                decimal sum = decimal.Parse(inputToArray[2]);
                try
                {
                    BankAccount bankAccount = bankAccounts.FirstOrDefault(ba => ba.AccountNumber == accountNumber);
                    switch (cmd)
                    {
                        case "Deposit":
                            bankAccount.Deposit(sum);
                            break;
                        case "Withdraw":
                            bankAccount.Withdraw(sum);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    Console.WriteLine($"Account {bankAccount.AccountNumber} has new balance: {bankAccount.AccountBalance:F2}");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid command!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                input = Console.ReadLine();
            }
        }
    }
    public class BankAccount
    {
        public int AccountNumber { get; }
        public decimal AccountBalance { get; private set; }
        public BankAccount(int accountNumber, decimal accountBalance)
        {
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
        }
        public void Deposit(decimal sum)
        {
            AccountBalance += sum;
        }
        public void Withdraw(decimal sum)
        {
            if (sum > AccountBalance)
            {
                throw new ArgumentException();
            }
            else
            {
                AccountBalance -= sum;
            }
        }
    }
}
