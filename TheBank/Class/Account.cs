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

        public Account (string name)
        {
            Name = name;
            Balance = 0;
        }
    }
}
