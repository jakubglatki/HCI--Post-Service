using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCI__Post_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text = Properties.Settings.Default.Text;
        private Manager manager;
        private MailBox currentMailBox;

        public List<MailBox> mailBoxes;
        public MainWindow()
        {
            InitializeComponent();
            //code to get after startup here
            manager = new Manager(this);

            currentMailBox = new MailBox();
            mailBoxes = new List<MailBox>();
            manager.Deserialize("D:\\Users\\Jakub Głatki\\GitHub\\HCI-post-service\\HCI- Post Service\\HCI- Post Service\\initializationData.xml");
            TreeViewForMailBox(mailBoxes);
            foreach(Mail mail in mailBoxes[0].inbox.mailList)
            {
                manager.AddMailItem(mail, mailsListXAML);
            }
            mailsListXAML.ListComponents(mailsListXAML);

            manager.SetCurrentFolder(mailBoxes[0].inbox);
        }

        private void TreeViewForMailBox(List<MailBox> mailboxes)
        {
            treeViewMailBox.Items.Clear();
            foreach(MailBox mail in mailboxes)
            {
                TreeViewItemForMailBox(mail.name);
            }
        }

        private void TreeViewItemForMailBox(string name)
        {
            TreeViewItem mailbox = new TreeViewItem();
            mailbox.Header = name;
            mailbox.FontSize = 15;


            CreateSubfolderStackPanelForMailbox("Inbox", "Resources/mailInbox.png", mailbox);
            CreateSubfolderStackPanelForMailbox("Sent", "Resources/mailSent.png", mailbox);
            CreateSubfolderStackPanelForMailbox("Starred", "Resources/mailStarred.png", mailbox);
            CreateSubfolderStackPanelForMailbox("Drafts", "Resources/mailDrafts.png", mailbox);
            CreateSubfolderStackPanelForMailbox("Deleted", "Resources/mailDeleted.png", mailbox);

            treeViewMailBox.Items.Add(mailbox);
        }

        private void CreateSubfolderStackPanelForMailbox(string subfolderName, string iconPath, TreeViewItem parentMailbox)
        {
           // MailsList mailsList = new MailsList();
            //mailsList.ListComponents(mailsList);
            StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            stackPanel.MouseLeftButtonUp += FolderSetCurrentFolder;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(iconPath, UriKind.Relative));
            img.Width = 25;
            img.Height = 25;
            TextBlock label = new TextBlock() { Text = subfolderName };
            label.Margin = new Thickness(10, 10, 0, 0);
            stackPanel.Children.Add(img);
            stackPanel.Children.Add(label);
            // adding ready subfolder stackpanel into mailbox treeviewitem
            parentMailbox.Items.Add(stackPanel);
        }


        private void FolderSetCurrentFolder(object sender, MouseButtonEventArgs e)
        {
             currentMailBox= manager.GetCurrentMailBox(manager.MailboxNameString());

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
            mailsListXAML.Items.Clear();
            foreach (Mail mail in manager.GetCurrentMailBox(manager.MailboxNameString()).GetCurrentFolder().mailList)
            {
                manager.AddMailItem(mail, mailsListXAML);
            }

        }
        private void NewMessage(object sender, RoutedEventArgs e)
        {
            SendMessageWindow sendMessage = new SendMessageWindow(this, manager);
            sendMessage.Show();

        }

      
        public void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
            textBox.GotFocus -= SearchGotFocus;
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            manager.SetVisibility();
            manager.GetCurrentList().Visibility = Visibility.Visible;
        }


      
        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (manager.GetCurrentFolder().name=="Deleted")
            {
                manager.DeletingMail();
            }
            else
            {
                manager.MoveMailToDeleted();
            }

        }

        private void ReplyMessage(object sender, RoutedEventArgs e)
        {
            manager.SendReply();
        }

        private void ReplyToAllMessage(object sender, RoutedEventArgs e)
        {
            manager.ReplyToAllMessage();
        }

        private void ForwardMessage(object sender, RoutedEventArgs e)
        {
            manager.ForwardMessage();
        }

        private void StarMessage(object sender, RoutedEventArgs e)
        {
            manager.StarMessage();
        }

        private void ExportFile(object sender, RoutedEventArgs e)
        {
            manager.ExportFile();
        }

        private void ImportFile(object sender, RoutedEventArgs e)
        {
            manager.ImportFile();
        }
    }
}
