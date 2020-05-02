using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    public class MailBox
    {
        public string name;
        public MailFolder inbox { get; set; }
        public MailFolder sent { get; set; }
        public MailFolder starred { get; set; }
        public MailFolder drafts { get; set; }
        public MailFolder deleted { get; set; }

        public MailBox() { }
       public MailBox(string name)
        {
            this.name = name;
        }

        public MailFolder GetCurrentFolder()
        {
            Manager manager = new Manager();
            return manager.GetCurrentFolder();
        }
    }
}
