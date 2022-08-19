using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank.Models;

namespace TheBank.Repository
{
    public interface IBank
    {
        public Account? CreateAccount(string name, ConsoleKey accType);
        public decimal? Deposit(int accountNumber, decimal amount);
        public decimal? Withdraw(int accountNumber, decimal amount);
        public decimal? Balance(int accountNumber);
        public decimal BankBalance();
        public void ChargeInterest();
        public string BankName { get; }
        public List<AccountListItem> GetAccountList();
    }
}
