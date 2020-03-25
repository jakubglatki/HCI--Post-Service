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
        static private MainWindow window;
        private Mail currentMail;
        private MailsList currentList;

        public MailManager() { }
        public MailManager(MainWindow mainWindow)
        {
            window = mainWindow;
           // window.menu = 
        }
        public void SetVisibility()
        {
            window.sentList1.Visibility = Visibility.Hidden;
            window.deletedList1.Visibility = Visibility.Hidden;
            window.starredList1.Visibility = Visibility.Hidden;
            window.messageList1.Visibility = Visibility.Hidden;
            window.draftsList1.Visibility = Visibility.Hidden;


            window.sentList2.Visibility = Visibility.Hidden;
            window.deletedList2.Visibility = Visibility.Hidden;
            window.starredList2.Visibility = Visibility.Hidden;
            window.messageList2.Visibility = Visibility.Hidden;
            window.draftsList2.Visibility = Visibility.Hidden;

            window.displayedMail.Visibility = Visibility.Hidden;
            window.bBack.Visibility = Visibility.Collapsed;
        }


        public void AddMailItem(Mail mail, MailsList list)
        {
            ListViewItem newMailItem = new Mail(mail.Sender, mail.Receiver, mail.Topic, mail.Content);
            newMailItem.FontSize = 18;
            newMailItem.Margin = new Thickness(5, 0, 0, 5);
            newMailItem.Content = mail.Topic;
            list.Items.Add(newMailItem);

        }

        public void SetMessages()
        {
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
            Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
            Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");

            window.messageList1.ListComponents(window.messageList1);
            MakeNewMailsList(window.messageList1, message1, message2, message3, message4);
        }

        public void SetCurrentMail(Mail mail)
        {
            currentMail = mail;
        }
        public void SetCurrentMailsList(MailsList mailsList)
        {
            currentList=mailsList;
        }

        public MailsList GetCurrentList()
        {
            return this.currentList;
        }

        public void ShowMessage(Mail mail)
        {
            window.senderMail.Text = mail.Sender;
            window.receiverMail.Text = mail.Receiver;
            window.topicMail.Text = mail.Topic;
            window.contentMail.Text = mail.Content;

            SetVisibility();
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

    }
}
