using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank.Models;

namespace TheBank
{
    abstract public record Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }

        public abstract decimal ChargeInterest();
    }
}
