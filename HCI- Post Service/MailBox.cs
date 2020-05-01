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
        public MailFolder inbox;
        public MailFolder sent;
        public MailFolder starred;
        public MailFolder drafts;
        public MailFolder deleted;

        public MailBox() { }
       public MailBox(string name)
        {
            this.name = name;
            if (name == "bobby@firmino.br")
            {
                Mail message1b = new Mail("Sender1b, Receiver1c", "Receiver1b", "Message 1b", "messageMessage1b");
                Mail message2b = new Mail("Sender2b", "Receiver2b", "Message 2b", "messageMessage2b");
                Mail message3b = new Mail("Sender3b", "Receiver3b", "Message 3b", "messageMessage3b");
                Mail message4b = new Mail("Sender4b", "Receiver4b", "Message 4b", "messageMessage4b");
                Mail message5b = new Mail("Sender5b", "Receiver5b", "Message 5b", "messageMessage5b");
                Mail message6b = new Mail("Sender6b", "Receiver6b", "Message 6b", "messageMessage6b");
                List<Mail> messageB = new List<Mail>();
                messageB.Add(message1b);
                messageB.Add(message2b);
                messageB.Add(message3b);
                messageB.Add(message4b);
                messageB.Add(message5b);
                messageB.Add(message6b);
                this.inbox = new MailFolder("Inbox", messageB);
                List<Mail> messageB1 = new List<Mail>();

                Mail sent1b = new Mail("Sender1b", "Receiver1b", "Sent 1b", "sentMessage1b");
                Mail sent2b = new Mail("Sender2b", "Receiver2b", "Sent 2b", "sentMessage2b");
                Mail sent3b = new Mail("Sender3b", "Receiver3b", "Sent 3b", "sentMessage3b");

                messageB1.Add(sent1b);
                messageB1.Add(sent2b);
                messageB1.Add(sent3b);
                this.sent = new MailFolder("Sent", messageB1);


                List<Mail> messageB2 = new List<Mail>();

                Mail starred1b = new Mail("Sender1b", "Receiver1b", "Starred 1b", "StarredMessage1b");
                Mail starred2b = new Mail("Sender2b", "Receiver2b", "Starred 2b", "StarredMessage2b");
                Mail starred3b = new Mail("Sender3b", "Receiver3b", "Starred 3b", "StarredMessage3b");
                messageB2.Add(starred1b);
                messageB2.Add(starred2b);
                messageB2.Add(starred3b);
                this.starred = new MailFolder("Starred", messageB2);

                List<Mail> messageB3 = new List<Mail>();

                Mail drafts1b = new Mail("Sender1b", "Receiver1b", "Drafts 1b", "draftsMessage1b");
                Mail drafts2b = new Mail("Sender2b", "Receiver2b", "Drafts 2b", "draftsMessage2b");
                Mail drafts3b = new Mail("Sender3b", "Receiver3b", "Drafts 3b", "draftsMessage3b");
                messageB3.Add(drafts1b);
                messageB3.Add(drafts2b);
                messageB3.Add(drafts3b);
                this.drafts = new MailFolder("Drafts", messageB3);
                this.deleted = new MailFolder("Deleted");
            }

            else
            {
                List<string> list = new List<string>();
                list.Add("olo.jpg");
                list.Add("dsafas.mpeg");
                Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
                message1.AttachmentList = list;
                Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
                Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
                Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");
                List<Mail> messageA = new List<Mail>();
                messageA.Add(message1);
                messageA.Add(message2);
                messageA.Add(message3);
                messageA.Add(message4);
                this.inbox = new MailFolder("Inbox", messageA);


                List<Mail> messageA1 = new List<Mail>();
                Mail sent1 = new Mail("Sender1", "Receiver1", "Sent 1", "sentMessage1");
                Mail sent2 = new Mail("Sender2", "Receiver2", "Sent 2", "sentMessage2");
                messageA1.Add(sent1);
                messageA1.Add(sent2);
                this.sent = new MailFolder("Sent", messageA1);
                List<Mail> messageA2 = new List<Mail>();


                Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
                Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
                Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
                Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
                Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");

                messageA2.Add(starred1);
                messageA2.Add(starred2);
                messageA2.Add(starred3);
                messageA2.Add(starred4);
                messageA2.Add(starred5);
                this.starred = new MailFolder("Starred", messageA2);

                List<Mail> messageA3 = new List<Mail>();

                Mail drafts1 = new Mail("Sender1", "Receiver1", "Drafts 1", "draftsMessage1");
                messageA3.Add(drafts1);
                this.drafts = new MailFolder("Drafts", messageA3);
                this.deleted = new MailFolder("Deleted");

            }
        }

        //public MailBox(string name, MailsList inboxMails, MailsList sentMails, MailsList starredMails, MailsList draftsMails, MailsList deletedMails)
        //{
        //    this.name = name;
        //    this.inbox = new MailFolder("Inbox", inboxMails);
        //    this.sent = new MailFolder("Sent", sentMails);
        //    this.starred = new MailFolder("Starred", starredMails);
        //    this.drafts = new MailFolder("Drafts", draftsMails);
        //    this.deleted = new MailFolder("Deleted", deletedMails);
        //}
    }
}
