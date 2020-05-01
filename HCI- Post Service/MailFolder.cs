using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    public class MailFolder
    {
        public string name;
        public List<Mail> mailList;

        public MailFolder() { }
        public MailFolder(string name)
        {
            this.name = name;
        }

        public MailFolder(string name, List<Mail> mails)
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
