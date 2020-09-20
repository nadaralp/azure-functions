using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGridMailService
{
    public interface IMailService
    {
        public void SendMail(string sendToEmail);
    }
}
