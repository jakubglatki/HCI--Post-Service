using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HCI__Post_Service
{
    class SendMessageManager
    {
        static private SendMessageWindow messageWindow;

        public SendMessageManager(SendMessageWindow sendMessageWindow)
        {
            messageWindow = sendMessageWindow;
        }

        public void ViewMessage(Mail mail, Manager manager)
        {
            messageWindow.Title = "View message";
            messageWindow.subject.IsReadOnly = true;
            messageWindow.receiverName.IsReadOnly = true;
            messageWindow.content.IsReadOnly = true;

            messageWindow.senderSelect.Visibility = Visibility.Hidden;
            messageWindow.buttonAttachment.Visibility = Visibility.Hidden;
            messageWindow.receiverName.Text = mail.Sender;
            messageWindow.subject.Text = mail.Topic;
            messageWindow.content.Text = mail.MsgContent;
            if (mail.AttachmentList != null)
            {
                foreach (String attachement in mail.AttachmentList)
                {
                    messageWindow.boxAttachments.Items.Add(attachement);
                }
            }
            messageWindow.buttonSend.Content = "Close";
        }

        public void ReplyMessage(Mail mail, Manager manager, MainWindow mWindow)
        {

            messageWindow.Title = "Send reply";
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

            messageWindow.Title = "Send reply to all";
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
            messageWindow.Title = "Send message forward";
            messageWindow.subject.IsReadOnly = true;
            messageWindow.receiverName.IsReadOnly = false;
            messageWindow.content.IsReadOnly = true;

            messageWindow.buttonAttachment.Visibility = Visibility.Hidden;
            messageWindow.receiverName.Text = "Forward to";
            messageWindow.subject.Text = ("Fwd: " + mail.Topic);
            messageWindow.content.Text = mail.MsgContent;
            messageWindow.buttonSend.Content = "Forward";
            AddOneComboBoxElement(manager, mWindow);
        }



        public void AddComboBoxElements(MainWindow mWindow)
        {
            foreach(TreeViewItem header in mWindow.treeViewMailBox.Items)
            {
                messageWindow.senderSelect.Items.Add(header.Header);
            }
            messageWindow.senderSelect.SelectedItem = messageWindow.senderSelect.Items[0];
        }

        private void AddOneComboBoxElement(Manager manager, MainWindow mWindow)
        {

            foreach (TreeViewItem header in mWindow.treeViewMailBox.Items)
            {
                if(manager.GetCurrentMailBox(manager.MailboxNameString()).name== header.Header.ToString())
                messageWindow.senderSelect.Items.Add(header.Header);
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
                List<string> list = messageWindow.boxAttachments.Items.OfType<string>().ToList();
                ObservableCollection<string> collection = new ObservableCollection<string>(list);
                Mail mail = new Mail(messageWindow.senderSelect.SelectedItem.ToString(), messageWindow.receiverName.Text, messageWindow.subject.Text, messageWindow.content.Text, collection);
                manager.GetCurrentMailBox(manager.MailboxNameString()).sent.mailList.Add(mail);
            }
        }

          public void AddAttachment(Manager manager)
        {
            
                Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
                fileDialog.Multiselect = true;
                fileDialog.Title = "Select Attachments";

                string images = "Image(*.JPG; *.PNG; *.BMP; *.GIF)| *.JPG; *.PNG; *.BMP; *.GIF |";
                string videos = "Video(*.WMV;*.MPG;*.MPEG)| *.WMV;*.MPG;*.MPEG |";
                string audios = "Audio(*.MP3)| *.MP3 |";
                fileDialog.Filter = images + videos + audios + "All files (*.*)|*.*";

                if (fileDialog.ShowDialog() == true)
                {
                    foreach (String attachement in fileDialog.FileNames)
                    {
                        string fileName = System.IO.Path.GetFileName(attachement);
                        messageWindow.boxAttachments.Items.Add(fileName);
                    }
                }
            
        }
    }
}
