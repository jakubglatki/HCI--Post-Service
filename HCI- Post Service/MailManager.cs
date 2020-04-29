using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HCI__Post_Service
{
    public class MailManager
    {

        static protected MainWindow window;
        static protected Mail currentMail;
        protected MailsList currentList;

        public MailManager() { }
        public MailManager(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public void AddMailItem(Mail mail, MailsList list)
        {
            ListViewItem newMailItem = new Mail(mail.Sender, mail.Receiver, mail.Topic, mail.Content, mail.AttachmentList);
            newMailItem.FontSize = 18;
            newMailItem.Margin = new Thickness(5, 0, 0, 5);
            newMailItem.Content = mail.Topic;
            list.Items.Insert(0, newMailItem);
        }

        //List when something might be added are made at the beggining, the rest when given button is clicked
        public void SetMessages()
        {
            List<string> list = new List<string>();
            list.Add("olo.jpg");
            list.Add("dsafas.mpeg");
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            message1.AttachmentList = list;
            Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
            Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
            Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");

            window.messageList1.ListComponents(window.messageList1);
            MakeNewMailsList(window.messageList1, message1, message2, message3, message4);

            window.sentList1.ListComponents(window.sentList1);

            Mail sent1 = new Mail("Sender1", "Receiver1", "Sent 1", "sentMessage1");
            Mail sent2 = new Mail("Sender2", "Receiver2", "Sent 2", "sentMessage2");

            MakeNewMailsList(window.sentList1, sent1, sent2);
            window.gridView1.Children.Add(window.sentList1);

            window.sentList2.ListComponents(window.sentList2);

            Mail sent1b = new Mail("Sender1b", "Receiver1b", "Sent 1b", "sentMessage1b");
            Mail sent2b = new Mail("Sender2b", "Receiver2b", "Sent 2b", "sentMessage2b");
            Mail sent3b = new Mail("Sender3b", "Receiver3b", "Sent 3b", "sentMessage3b");

            MakeNewMailsList(window.sentList2, sent1b, sent2b, sent3b);
            window.gridView1.Children.Add(window.sentList2);


            window.starredList1.ListComponents(window.starredList1);

            Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
            Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
            Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
            Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
            Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");

            MakeNewMailsList(window.starredList1, starred1, starred2, starred3, starred4, starred5);
            window.gridView1.Children.Add(window.starredList1);

            window.starredList2.ListComponents(window.starredList2);

            Mail starred1b = new Mail("Sender1b", "Receiver1b", "Starred 1b", "StarredMessage1b");
            Mail starred2b = new Mail("Sender2b", "Receiver2b", "Starred 2b", "StarredMessage2b");
            Mail starred3b = new Mail("Sender3b", "Receiver3b", "Starred 3b", "StarredMessage3b");

            MakeNewMailsList(window.starredList2, starred1b, starred2b, starred3b);
            window.gridView1.Children.Add(window.starredList2);

            window.messageList1.Visibility = Visibility.Visible;
        }

        public void ShowMessage(Mail mail)
        {
            window.senderMail.Text = mail.Sender;
            window.receiverMail.Text = mail.Receiver;
            window.topicMail.Text = mail.Topic;
            window.contentMail.Text = mail.Content;

            window.displayedMail.Visibility = Visibility.Visible;
            window.bBack.Visibility = Visibility.Visible;
        }

        public void MakeNewMailsList(MailsList mailsList, params Mail[] mail)
        {
            foreach(Mail mailParam in mail)
            {
                AddMailItem(mailParam, mailsList);
            }
        }

        public void StarMessage()
        {
            Manager manager = new Manager(window);
            if(manager.GetCurrentList()==window.sentList1 || manager.GetCurrentList() == window.messageList1)
            {
                AddMailItem(manager.GetCurrentMail(), window.starredList1);
            }
            else if (manager.GetCurrentList() == window.sentList2 || manager.GetCurrentList() == window.messageList2)
            {
                AddMailItem(manager.GetCurrentMail(), window.starredList2);
            }
        }

    }
}
