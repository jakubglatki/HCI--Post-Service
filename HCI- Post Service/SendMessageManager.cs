using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI__Post_Service
{
    class SendMessageManager
    {
        static private SendMessageWindow messageWindow;

        public SendMessageManager(SendMessageWindow sendMessageWindow)
        {
            messageWindow = sendMessageWindow;
        }

        public void ViewMessage(Mail mail)
        {

            messageWindow.subject.IsReadOnly = true;
            messageWindow.receiverName.IsReadOnly = true;
            messageWindow.content.IsReadOnly = true;

            messageWindow.senderSelect.Visibility = Visibility.Hidden;
            messageWindow.buttonAttachment.Visibility = Visibility.Hidden;
            messageWindow.receiverName.Text = mail.Sender;
            messageWindow.subject.Text = mail.Topic;
            messageWindow.content.Text = mail.Content;
            messageWindow.buttonSend.Content = "Close";
        }

        public void ReplyMessage(Mail mail, Manager manager, MainWindow mWindow)
        {

            messageWindow.subject.IsReadOnly = false;
            messageWindow.receiverName.IsReadOnly = true;
            messageWindow.content.IsReadOnly = false;

            //if there are more than one receivers respond just to first one
            string sender = mail.Sender;
            int index = mail.Sender.IndexOf(",");
            if (index > 0)
                mail.Sender = mail.Sender.Substring(0, index);
            messageWindow.receiverName.Text = mail.Sender;
            messageWindow.subject.Text = ("Re: " + mail.Topic);
            messageWindow.buttonSend.Content = "Reply";
            AddOneComboBoxElement(manager, mWindow);
            mail.Sender = sender;
        }
        public void ReplyToAllMessage(Mail mail, Manager manager, MainWindow mWindow)
        {
            messageWindow.subject.IsReadOnly = false;
            messageWindow.receiverName.IsReadOnly = true;
            messageWindow.content.IsReadOnly = false;

            messageWindow.receiverName.Text = mail.Sender;
            messageWindow.subject.Text = ("Re: " + mail.Topic);
            messageWindow.buttonSend.Content = "Reply";
            AddOneComboBoxElement(manager, mWindow);
        }
        public void ForwardMessage(Mail mail, MainWindow mWindow, Manager manager)
        {
            messageWindow.subject.IsReadOnly = true;
            messageWindow.receiverName.IsReadOnly = false;
            messageWindow.content.IsReadOnly = true;

            messageWindow.buttonAttachment.Visibility = Visibility.Hidden;
            messageWindow.receiverName.Text = "Forward to";
            messageWindow.subject.Text = mail.Topic;
            messageWindow.content.Text = mail.Content;
            messageWindow.buttonSend.Content = "Close";
            AddOneComboBoxElement(manager, mWindow);
        }

        public void AddComboBoxElements(MainWindow mWindow)
        {
            messageWindow.senderSelect.Items.Add(mWindow.header1.Header);
            messageWindow.senderSelect.Items.Add(mWindow.header2.Header);
            messageWindow.senderSelect.SelectedItem = messageWindow.senderSelect.Items[0];
        }

        private void AddOneComboBoxElement(Manager manager, MainWindow mWindow)
        {

            if (manager.GetCurrentTreeViewItem().Header == mWindow.header1.Header)
            {
                messageWindow.senderSelect.Items.Add(mWindow.header1.Header);
            }
            else if (manager.GetCurrentTreeViewItem().Header == mWindow.header2.Header)
            {
                messageWindow.senderSelect.Items.Add(mWindow.header2.Header);
            }
            messageWindow.senderSelect.SelectedItem = messageWindow.senderSelect.Items[0];
        }

        public bool CheckIfMailIsCorrect()
        {

            if (string.IsNullOrWhiteSpace(messageWindow.receiverName.Text) && string.IsNullOrWhiteSpace(messageWindow.subject.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without receiver's address and subject", "Can't Send Message", MessageBoxButton.OK);
                return false;
            }

            else if (string.IsNullOrWhiteSpace(messageWindow.receiverName.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without receiver's address", "Can't Send Message", MessageBoxButton.OK);
                return false;
            }

            else if (string.IsNullOrWhiteSpace(messageWindow.subject.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without subject", "Can't Send Message", MessageBoxButton.OK);
                return false;
            }

            else return true;
        }

        public void AddMailToSent(Manager manager, MainWindow mWindow)
        {
            if (messageWindow.buttonSend.Content.ToString() == "Send" || messageWindow.buttonSend.Content.ToString() == "Reply" || messageWindow.buttonSend.Content.ToString() == "Reply to all" || messageWindow.buttonSend.Content.ToString() == "Forward")
            {
                Mail mail = new Mail(messageWindow.senderSelect.SelectedItem.ToString(), messageWindow.receiverName.Text, messageWindow.subject.Text, messageWindow.content.Text);
                if (messageWindow.senderSelect.SelectedItem == mWindow.header1.Header)
                    manager.AddMailItem(mail, mWindow.sentList1);
                else if (messageWindow.senderSelect.SelectedItem == mWindow.header2.Header)
                    manager.AddMailItem(mail, mWindow.sentList2);
            }
        }
    }
}
