using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace HCI__Post_Service
{
    public class MailManager
    {

        static protected MainWindow window;
        static protected Mail currentMail;
        protected MailsList currentList;
        protected MailBox currentMailBox;
        protected MailFolder currentFolder;
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


            if (manager.GetCurrentFolder().name== "Inbox" || manager.GetCurrentFolder().name == "Sent")
            {
                manager.GetCurrentMailBox(manager.MailboxNameString()).starred.mailList.Add(manager.GetCurrentMail());
            }

        }

        public void ImportFile()
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Import file";

            string XML = "XML(*.xml)| *.xml";
            fileDialog.Filter = XML;


            if (fileDialog.ShowDialog() == true)
            {
                string filePath = fileDialog.FileName;
                Deserialize(filePath);
            }
        }

        public void Deserialize(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<MailBox>));

            using (FileStream fs = File.OpenRead(filePath))
            {
                window.mailBoxes = (List<MailBox>)deserializer.Deserialize(fs);
            }
        }
        public void ExportFile()
        {

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Title = "Export file";
            string XML = "XML(*.xml)| *.xml";

            fileDialog.Filter = XML;

            if (fileDialog.ShowDialog() == true)
            {
                string file = fileDialog.FileName;
                this.Serialize(file);
            }
        }

        private void Serialize(String file)
        {
            using (Stream fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                XmlSerializer xml = new XmlSerializer(typeof(List<MailBox>));
                xml.Serialize(fs, window.mailBoxes);
            }
        }



        public void TreeViewForMailBox(List<MailBox> mailboxes)
        {
            window.treeViewMailBox.Items.Clear();
            foreach (MailBox mail in mailboxes)
            {
                TreeViewItemForMailBox(mail.name);
            }
        }

        private void TreeViewItemForMailBox(string name)
        {
            TreeViewItem mailbox = new TreeViewItem();
            mailbox.Header = name;
            mailbox.FontSize = 15;

            CreateFolder(mailbox, "Inbox", "Resources/mailInbox.png");
            CreateFolder(mailbox, "Sent", "Resources/mailSent.png");
            CreateFolder(mailbox, "Starred", "Resources/mailStarred.png");
            CreateFolder(mailbox, "Drafts", "Resources/mailDrafts.png");
            CreateFolder(mailbox, "Deleted", "Resources/mailDeleted.png");

            window.treeViewMailBox.Items.Add(mailbox);
        }

        private void CreateFolder(TreeViewItem mailbox, string name, string path)
        {
            StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            stackPanel.MouseLeftButtonUp += FolderSetCurrentFolder;
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            image.Width = 25;
            image.Height = 25;
            TextBlock label = new TextBlock() { Text = name };
            label.Margin = new Thickness(10, 10, 0, 0);
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(label);
            mailbox.Items.Add(stackPanel);
        }


        private void FolderSetCurrentFolder(object sender, MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            currentMailBox = manager.GetCurrentMailBox(manager.MailboxNameString());

            if (sender is StackPanel)
            {
                string folderName = "";

                StackPanel folder = (StackPanel)sender;

                TextBlock text = (TextBlock)folder.Children[1];
                folderName = text.Text;

                if (folderName == "Inbox")
                {
                    manager.SetCurrentFolder(currentMailBox.inbox);
                }
                else if (folderName == "Sent")
                {
                    manager.SetCurrentFolder(currentMailBox.sent);
                }

                else if (folderName == "Starred")
                {
                    manager.SetCurrentFolder(currentMailBox.starred);
                }

                else if (folderName == "Drafts")
                {
                    manager.SetCurrentFolder(currentMailBox.drafts);
                }

                else if (folderName == "Deleted")
                {
                    manager.SetCurrentFolder(currentMailBox.deleted);
                }

            }
            manager.DisableButtons();
            LoadMails(manager.GetCurrentFolder().mailList);
        }

        private void LoadMails(List<Mail> mails)
        {
            Manager manager = new Manager();
            window.mailsListXAML.Items.Clear();
            foreach (Mail mail in manager.GetCurrentMailBox(manager.MailboxNameString()).GetCurrentFolder().mailList)
            {
                manager.AddMailItem(mail, window.mailsListXAML);
            }

        }
    }
}
