using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Email
    {
        public void SendEmail(string message)
        {
            // Code here
        }
    }
    public class Sms
    {
        public void SendSms(string number)
        {
            // Code here
        }
    }
}
