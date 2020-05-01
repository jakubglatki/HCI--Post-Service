using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    class MailBox
    {
        private string name;
        private MailFolder inbox;
        private MailFolder sent;
        private MailFolder starred;
        private MailFolder drafts;
        private MailFolder deleted;

       public MailBox(string name)
        {
            this.name = name;
            this.inbox = new MailFolder("Inbox");
            this.sent = new MailFolder("Sent");
            this.starred = new MailFolder("Starred");
            this.drafts = new MailFolder("Drafts");
            this.deleted = new MailFolder("Deleted");
        }

        public MailBox(string name, MailsList inboxMails, MailsList sentMails, MailsList starredMails, MailsList draftsMails, MailsList deletedMails)
        {
            this.name = name;
            this.inbox = new MailFolder("Inbox", inboxMails);
            this.sent = new MailFolder("Sent", sentMails);
            this.starred = new MailFolder("Starred", starredMails);
            this.drafts = new MailFolder("Drafts", draftsMails);
            this.deleted = new MailFolder("Deleted", deletedMails);
        }
    }
}
