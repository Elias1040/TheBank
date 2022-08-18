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
        public decimal? Deposit(int accountNumber, decimal amount)
        {
            Account? _account = accounts.Find(x => x.AccountNumber == accountNumber);
            return _account != null ? _account.Balance += amount : null;
        }

        /// <summary>
        /// withdraws from account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>balance after withdrawal</returns>
        public decimal? Withdraw(int accountNumber, decimal amount)
        {
            Account? _account = accounts.Find(x => x.AccountNumber == accountNumber);
            return _account != null ? _account.Balance -= amount : null;
        }

        /// <summary>
        /// Gets balance from account
        /// </summary>
        /// <returns></returns>
        public decimal? Balance(int accountNumber)
        {
            Account? _account = accounts.Find(x => x.AccountNumber == accountNumber);
            return _account != null ? _account.Balance : null;
        }

        /// <summary>
        /// Adds all balances
        /// </summary>
        /// <returns>sum of all</returns>
        public decimal BankBalance()
        {
            return accounts.AsEnumerable().Sum(x => x.Balance);
        }
    }
}
