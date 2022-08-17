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
            return account = new Account(name);
        }

        /// <summary>
        /// Deposits to account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Balance after deposit</returns>
        public decimal Deposit(decimal amount)
        {
            return account.Balance += amount;
        }

        /// <summary>
        /// withdraws from account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>balance after withdrawal</returns>
        public decimal Withdraw(decimal amount)
        {
            return account.Balance -= amount;
        }

        /// <summary>
        /// Gets balance from account
        /// </summary>
        /// <returns></returns>
        public decimal Balance()
        {
            return account.Balance;
        }
    }
}
