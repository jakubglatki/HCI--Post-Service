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
        private Manager manager;
        public MainWindow()
        {
            InitializeComponent();
            //code to get after startup here
            manager = new Manager(this);

            starredList1 = new MailsList();
            starredList2 = new MailsList();
            deletedList1 = new MailsList();
            deletedList2 = new MailsList();
            sentList1 = new MailsList();
            sentList2 = new MailsList();
            draftsList1 = new MailsList();
            draftsList2 = new MailsList();
            messageList2 = new MailsList();


            manager.SetMessages();
            manager.SetCurrentMailsList(messageList1);
            header1.IsSelected = true;
        }



        private void NewMessage(object sender, RoutedEventArgs e)
        {
            SendMessageWindow sendMessage = new SendMessageWindow(this, manager);
            sendMessage.Show();

        }

        private void InboxMails1(object sender, MouseButtonEventArgs e)
        {
            manager.SetVisibility();
            messageList1.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(messageList1);
            header1.IsSelected = true;
            header2.IsSelected = false;
        }


        private void InboxMails2(object sender, MouseButtonEventArgs e)
        {
            if (messageListBool2  == false)
            {
                messageList2.ListComponents(messageList2);

                Mail message1b = new Mail("Sender1b", "Receiver1b", "Message 1b", "messageMessage1b");
                Mail message2b = new Mail("Sender2b", "Receiver2b", "Message 2b", "messageMessage2b");
                Mail message3b = new Mail("Sender3b", "Receiver3b", "Message 3b", "messageMessage3b");
                Mail message4b = new Mail("Sender4b", "Receiver4b", "Message 4b", "messageMessage4b");
                Mail message5b = new Mail("Sender5b", "Receiver5b", "Message 5b", "messageMessage5b");
                Mail message6b = new Mail("Sender6b", "Receiver6b", "Message 6b", "messageMessage6b");

                manager.MakeNewMailsList(messageList2, message1b, message2b, message3b, message4b, message5b, message6b);

                gridView1.Children.Add(messageList2);
            }
            messageListBool2 = true;

            manager.SetVisibility();
            messageList2.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(messageList2);
            header1.IsSelected = false;
            header2.IsSelected = true;
        }

        private void SentMails1(object sender, MouseButtonEventArgs e)
        {
            manager.SetVisibility();
            sentList1.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(sentList1);
            header1.IsSelected = true;
            header2.IsSelected = false;
        }

        private void SentMails2(object sender, MouseButtonEventArgs e)
        { 
            manager.SetVisibility();
            sentList2.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(sentList2);
            header1.IsSelected = false;
            header2.IsSelected = true;
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

                manager.MakeNewMailsList(starredList1, starred1, starred2, starred3, starred4, starred5);
                gridView1.Children.Add(starredList1);
            }
            starredListBool1 = true;

            manager.SetVisibility();
            starredList1.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(starredList1);
            header1.IsSelected = true;
            header2.IsSelected = false;
        }

        private void StarredMails2(object sender, MouseButtonEventArgs e)
        {
            if (starredListBool2 == false)
            {
                starredList2.ListComponents(starredList2);
                
                Mail starred1b = new Mail("Sender1b", "Receiver1b", "Starred 1b", "StarredMessage1b");
                Mail starred2b = new Mail("Sender2b", "Receiver2b", "Starred 2b", "StarredMessage2b");
                Mail starred3b = new Mail("Sender3b", "Receiver3b", "Starred 3b", "StarredMessage3b");

                manager.MakeNewMailsList(starredList2, starred1b, starred2b, starred3b);
                gridView1.Children.Add(starredList2);
            }
            starredListBool2 = true;

            manager.SetVisibility();
            starredList2.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(starredList2);
            header1.IsSelected = false;
            header2.IsSelected = true;
        }

        private void DraftsMails1(object sender, MouseButtonEventArgs e)
        {
            if (draftsListBool1 == false)
            {
                draftsList1.ListComponents(draftsList1);

                Mail drafts1 = new Mail("Sender1", "Receiver1", "Drafts 1", "draftsMessage1");

                manager.MakeNewMailsList(draftsList1, drafts1);
                gridView1.Children.Add(draftsList1);
            }
            draftsListBool1 = true;

            manager.SetVisibility();
            draftsList1.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(draftsList1);
            header1.IsSelected = true;
            header2.IsSelected = false;
        }

        private void DraftsMails2(object sender, MouseButtonEventArgs e)
        {
            if (draftsListBool2 == false)
            {
                draftsList2.ListComponents(draftsList2);

                Mail drafts1b = new Mail("Sender1b", "Receiver1b", "Drafts 1b", "draftsMessage1b");
                Mail drafts2b = new Mail("Sender2b", "Receiver2b", "Drafts 2b", "draftsMessage2b");
                Mail drafts3b = new Mail("Sender3b", "Receiver3b", "Drafts 3b", "draftsMessage3b");

                manager.MakeNewMailsList(draftsList2, drafts1b, drafts2b, drafts3b);
                gridView1.Children.Add(draftsList2);
            }
            draftsListBool2 = true;

            manager.SetVisibility();
            draftsList2.Visibility = Visibility.Visible;
            manager.SetCurrentMailsList(draftsList2);
            header1.IsSelected = false;
            header2.IsSelected = true;
        }
        private void DeletedMails1(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool1 == false)
            {
                deletedList1.ListComponents(deletedList1);
                gridView1.Children.Add(deletedList1);
            }
            deletedListBool1 = true;

            manager.SetVisibility();
            manager.SetCurrentMailsList(deletedList1);
            deletedList1.Visibility = Visibility.Visible;
            header1.IsSelected = true;
            header2.IsSelected = false;
        }

        private void DeletedMails2(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool2 == false)
            {
                deletedList2.ListComponents(deletedList2);
                gridView1.Children.Add(deletedList2);
            }
            deletedListBool2 = true;

            manager.SetVisibility();
            manager.SetCurrentMailsList(deletedList2);
            deletedList2.Visibility = Visibility.Visible;
            header1.IsSelected = false;
            header2.IsSelected = true;
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
            if (manager.GetCurrentList()==deletedList1 || manager.GetCurrentList()==deletedList2)
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
    }
}
