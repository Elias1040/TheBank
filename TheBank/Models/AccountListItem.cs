using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public class AccountListItem
    {
        public Account Account { get; set; }
        public AccountListItem(Account acc)
        {
            Account = acc;
        }
    }
}
