using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank;
using TheBank.Models;
using TheBank.Repository;

namespace Repository.Bank
{
    public class Bank : IBank
    {
        public string BankName { get; }
        public List<Account> accounts = new List<Account>();
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
        public Account? CreateAccount(string name, ConsoleKey accType)
        {
            Console.Clear();
            switch (accType)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    CheckingAccount cAcc = new CheckingAccount(name, AccountCounter);
                    accounts.Add(cAcc);
                    AccountCounter++;
                    return cAcc;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    SavingsAccount sAcc = new SavingsAccount(name, AccountCounter);
                    accounts.Add(sAcc);
                    AccountCounter++;
                    return sAcc;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    MasterCardAccount mcAcc = new MasterCardAccount(name, AccountCounter);
                    accounts.Add(mcAcc);
                    AccountCounter++;
                    return mcAcc;
                default:
                    Console.ReadKey(true);
                    return null;
            }
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
            if ((_account.Balance - amount) < 0 && _account.AccountType == "MasterCard konto")
            {
                throw new OverdraftException("Du kan ikke overtrække");
            }
            else
            {
                return _account != null ? _account.Balance -= amount : null;
            }
            
        }

        /// <summary>
        /// Gets balance from account
        /// </summary>
        /// <param name="accountNumber"></param>
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
            return accounts.Sum(x => x.Balance);
        }

        /// <summary>
        /// Adds interest to all accounts
        /// </summary>
        public void ChargeInterest()
        {
            foreach (Account acc in accounts)
            {
                acc.ChargeInterest();
            }
        }
        public List<AccountListItem> GetAccountList()
        {
            List<AccountListItem> accountList = new List<AccountListItem>();
            foreach (Account acc in accounts)
            {
                accountList.Add(new AccountListItem(acc));
            }
            return accountList;
        }
    }
}
