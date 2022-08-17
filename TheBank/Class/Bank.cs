using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank;

namespace TheBank
{
    public class Bank
    {
        public string BankName { get; }
        public Account account { get; set; }
        List<Account> accounts = new List<Account>();
        int AccountCounter;


        public Bank()
        {
            BankName = "EUC Bank";
        }

        /// <summary>
        /// Creates account
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The account created</returns>
        public Account CreateAccount(string name)
        {
            AccountCounter++;
            account = new Account(name, AccountCounter);
            accounts.Add(account);
            return account;
        }

        /// <summary>
        /// Deposits to account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Balance after deposit</returns>
        public bool Deposit(int accountNumber, decimal amount)
        {
            if (validation.ValidateAccount(accountNumber, accounts) != null)
            {
                validation.ValidateAccount(accountNumber, accounts).Balance += amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// withdraws from account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>balance after withdrawal</returns>
        public bool Withdraw(int accountNumber, decimal amount)
        {
            if (validation.ValidateAccount(accountNumber, accounts) != null)
            {
                validation.ValidateAccount(accountNumber, accounts).Balance -= amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets balance from account
        /// </summary>
        /// <returns></returns>
        public string Balance(int accountNumber)
        {
            if (validation.ValidateAccount(accountNumber, accounts) != null)
            {
                return ("Saldo: {0:c}", validation.ValidateAccount(accountNumber, accounts).Balance);
            }
            return "Konto findes ikke";
        }

        
    }

    public static class validation
    {
        public static Account ValidateAccount(int accountNumber, List<Account> accounts)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accountNumber == accounts[i].AccountNumber)
                {
                    return accounts[i];
                }
            }
            return null;
        }
    }
}
