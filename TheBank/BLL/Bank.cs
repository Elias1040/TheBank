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
    public class Bank
    {
        public string BankName { get; }

        public readonly IBank _bank;
        public Bank(IBank bank)
        {
            BankName = "EUC Bank";
            _bank = bank;
        }
    }
}
