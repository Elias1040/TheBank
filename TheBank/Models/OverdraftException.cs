using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public class OverdraftException : Exception
    {
        public OverdraftException(string s) : base(s)
        {

        }

    }
}
