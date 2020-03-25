using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HCI__Post_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text = Properties.Settings.Default.Text;
        public bool messageListBool2 = false;
        public bool starredListBool1 = false;
        public bool starredListBool2 = false;
        public bool deletedListBool1 = false;
        public bool deletedListBool2 = false;
        public bool sentListBool1 = false;
        public bool sentListBool2 = false;
        public bool draftsListBool1 = false;
        public bool draftsListBool2 = false;
        public MailsList messageList2;
        public MailsList starredList1;
        public MailsList starredList2;
        public MailsList deletedList1;
        public MailsList deletedList2;
        public MailsList sentList1;
        public MailsList sentList2;
        public MailsList draftsList1;
        public MailsList draftsList2;
        private MailManager mailManager;
        public MainWindow()
        {
            InitializeComponent();
            mailManager= new MailManager(this);
            //code to get after startup here

            starredList1 = new MailsList();
            starredList2 = new MailsList();
            deletedList1 = new MailsList();
            deletedList2 = new MailsList();
            sentList1 = new MailsList();
            sentList2 = new MailsList();
            draftsList1 = new MailsList();
            draftsList2 = new MailsList();
            messageList2 = new MailsList();
            gridView1.Children.Add(starredList1);
            gridView1.Children.Add(starredList2);
            gridView1.Children.Add(deletedList1);
            gridView1.Children.Add(deletedList2);
            gridView1.Children.Add(sentList1);
            gridView1.Children.Add(sentList2);
            gridView1.Children.Add(draftsList1);
            gridView1.Children.Add(draftsList2);
            gridView1.Children.Add(messageList2);
            mailManager.SetMessages();
            mailManager.SetCurrentMailsList(messageList1);
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    DialogWindow dw = new DialogWindow();
        //    dw.textBox.Text = text;

        //    //if we left DialogWindow by pressing "OK" button
        //    if(dw.ShowDialog()==true)
        //    {
        //        text = dw.textBox.Text;

        //        //it will save the value until the next session
        //        Properties.Settings.Default.Text = text;
        //        Properties.Settings.Default.Save();
        //    }
        //}


        private void InboxMails1(object sender, MouseButtonEventArgs e)
        {
            mailManager.SetVisibility();
            messageList1.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(messageList1);
        }


        private void InboxMails2(object sender, MouseButtonEventArgs e)
        {
            if (messageListBool2 == false)
            {
                messageList2.ListComponents(messageList2);

                Mail message1b = new Mail("Sender1b", "Receiver1b", "Message 1b", "messageMessage1b");
                Mail message2b = new Mail("Sender2b", "Receiver2b", "Message 2b", "messageMessage2b");
                Mail message3b = new Mail("Sender3b", "Receiver3b", "Message 3b", "messageMessage3b");
                Mail message4b = new Mail("Sender4b", "Receiver4b", "Message 4b", "messageMessage4b");
                Mail message5b = new Mail("Sender5b", "Receiver5b", "Message 5b", "messageMessage5b");
                Mail message6b = new Mail("Sender6b", "Receiver6b", "Message 6b", "messageMessage6b");

                mailManager.MakeNewMailsList(messageList2, message1b, message2b, message3b, message4b, message5b, message6b);
            }
            messageListBool2 = true;

            mailManager.SetVisibility();
            messageList2.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(messageList2);
        }

        private void SentMails1(object sender, MouseButtonEventArgs e)
        {
            if (sentListBool1 == false)
            {
                sentList1.ListComponents(sentList1);

                Mail sent1 = new Mail("Sender1", "Receiver1", "Sent 1", "sentMessage1");
                Mail sent2 = new Mail("Sender2", "Receiver2", "Sent 2", "sentMessage2");

                mailManager.MakeNewMailsList(sentList1, sent1, sent2);
            }
            sentListBool1 = true;

            mailManager.SetVisibility();
            sentList1.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(sentList1);
        }

        private void SentMails2(object sender, MouseButtonEventArgs e)
        {
            if (sentListBool2 == false)
            {
                sentList2.ListComponents(sentList2);

                Mail sent1b = new Mail("Sender1b", "Receiver1b", "Sent 1b", "sentMessage1b");
                Mail sent2b = new Mail("Sender2b", "Receiver2b", "Sent 2b", "sentMessage2b");
                Mail sent3b = new Mail("Sender3b", "Receiver3b", "Sent 3b", "sentMessage3b");

                mailManager.MakeNewMailsList(sentList2, sent1b, sent2b, sent3b);
            }
            sentListBool2 = true;

            mailManager.SetVisibility();
            sentList2.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(sentList2);
        }

        private void StarredMails1(object sender, MouseButtonEventArgs e)
        {
            if (starredListBool1 == false)
            {
                starredList1.ListComponents(starredList1);

                Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
                Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
                Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
                Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
                Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");

                mailManager.MakeNewMailsList(starredList1, starred1, starred2, starred3, starred4, starred5);
            }
            starredListBool1 = true;

            mailManager.SetVisibility();
            starredList1.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(starredList1);
        }

        private void StarredMails2(object sender, MouseButtonEventArgs e)
        {
            if (starredListBool2 == false)
            {
                starredList2.ListComponents(starredList2);
                
                Mail starred1b = new Mail("Sender1b", "Receiver1b", "Starred 1b", "StarredMessage1b");
                Mail starred2b = new Mail("Sender2b", "Receiver2b", "Starred 2b", "StarredMessage2b");
                Mail starred3b = new Mail("Sender3b", "Receiver3b", "Starred 3b", "StarredMessage3b");

                mailManager.MakeNewMailsList(starredList2, starred1b, starred2b, starred3b);
            }
            starredListBool2 = true;

            mailManager.SetVisibility();
            starredList2.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(starredList2);
        }

        private void DraftsMails1(object sender, MouseButtonEventArgs e)
        {
            if (draftsListBool1 == false)
            {
                draftsList1.ListComponents(draftsList1);

                Mail drafts1 = new Mail("Sender1", "Receiver1", "Drafts 1", "draftsMessage1");

                mailManager.MakeNewMailsList(draftsList1, drafts1);
            }
            draftsListBool1 = true;

            mailManager.SetVisibility();
            draftsList1.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(draftsList1);
        }

        private void DraftsMails2(object sender, MouseButtonEventArgs e)
        {
            if (draftsListBool2 == false)
            {
                draftsList2.ListComponents(draftsList2);

                Mail drafts1b = new Mail("Sender1b", "Receiver1b", "Drafts 1b", "draftsMessage1b");
                Mail drafts2b = new Mail("Sender2b", "Receiver2b", "Drafts 2b", "draftsMessage2b");
                Mail drafts3b = new Mail("Sender3b", "Receiver3b", "Drafts 3b", "draftsMessage3b");

                mailManager.MakeNewMailsList(draftsList2, drafts1b, drafts2b, drafts3b);
            }
            draftsListBool2 = true;

            mailManager.SetVisibility();
            draftsList2.Visibility = Visibility.Visible;
            mailManager.SetCurrentMailsList(draftsList2);
        }
        private void DeletedMails1(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool1 == false)
            {
                deletedList1.ListComponents(deletedList1);
            }
            deletedListBool1 = true;

            mailManager.SetVisibility();
            mailManager.SetCurrentMailsList(deletedList1);
            deletedList1.Visibility = Visibility.Visible;
        }

        private void DeletedMails2(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool2 == false)
            {
                deletedList2.ListComponents(deletedList2);
            }
            deletedListBool2 = true;

            mailManager.SetVisibility();
            mailManager.SetCurrentMailsList(deletedList2);
            deletedList2.Visibility = Visibility.Visible;
        }


        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mailManager.SetVisibility();
            mailManager.GetCurrentList().Visibility = Visibility.Visible;
        }


      
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            //if (treeView1.SelectedItem == deleted1 || treeView1.SelectedItem == deleted2)
            //{
            //    mailManager.deletingMessage();
            //}
            //else
            //{
            //    if (messageList1.SelectedItems.Contains(message1))
            //    {
            //        messageList1.Items.Remove(message1);
            //        deletedList1.Items.Add(message1);
            //    }

            //}

        }

    }
}
