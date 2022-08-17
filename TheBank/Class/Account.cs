using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public Account (string name, int number)
        {
            Name = name;
            Balance = 0;
            AccountNumber = number;
        }
    }
}
