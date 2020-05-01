using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    class MailFolder
    {
        private string name;
        private MailsList mailList;

        public MailFolder(string name)
        {
            this.name = name;
        }

        public MailFolder(string name, MailsList mails)
        {
            this.name = name;
            this.mailList = mails;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
    }
}
