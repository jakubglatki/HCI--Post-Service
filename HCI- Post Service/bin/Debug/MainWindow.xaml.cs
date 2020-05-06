using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public ObservableCollection<MailShow> mailsSource = new ObservableCollection<MailShow>();

        public ObservableCollection<MailBox> mailBoxes;
        public MainWindow()
        {
            InitializeComponent();
            //code to get after startup here
            manager = new Manager(this);

            currentMailBox = new MailBox();
            mailBoxes = new ObservableCollection<MailBox>();
            manager.Deserialize("initializationData.xml");
            manager.TreeViewForMailBox(mailBoxes);
            foreach (Mail mail in mailBoxes[0].inbox.mailList)
            {
                manager.AddMailItem(mail, mailsListXAML);
            }
            mailsListXAML.ListComponents(mailsListXAML);

            manager.SetCurrentFolder(mailBoxes[0].inbox);
            //mailsListXAML.ItemsSource = manager.GetCurrentFolder().mailList;
            //for (int i = 0; i < manager.GetCurrentFolder().mailList.Count; i++)
            //{
            //    mailsSource.Add(new MailShow(manager.GetCurrentFolder().mailList[i]));
            //}
            //mailsListXAML.ItemsSource = mailsSource;
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
            int index = this.mailsListXAML.SelectedIndex;
            if (index >= 0)
            {
                if (manager.GetCurrentFolder().name == "Deleted")
                {
                    manager.DeletingMail(index);
                }
                else
                {
                    manager.MoveMailToDeleted(index);
                }
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
