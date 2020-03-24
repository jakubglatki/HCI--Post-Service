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
        public bool starredListBool1 = false;
        public bool deletedListBool1 = false;
        public MailsList starredList1;
        public MailsList deletedList1;
        private MailManager mailManager;
        public MainWindow()
        {
            InitializeComponent();
            mailManager= new MailManager(this);
            //code to get after startup here

            starredList1 = new MailsList();
            deletedList1 = new MailsList();
            gridView1.Children.Add(starredList1);
            gridView1.Children.Add(deletedList1);
            messageList.listComponents(messageList);
            mailManager.setMessages();
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


        private void inboxMails1(object sender, MouseButtonEventArgs e)
        {
            mailManager.setVisibility();
            messageList.Visibility = Visibility.Visible;
        }

        private void starredMails1(object sender, MouseButtonEventArgs e)
        {
            if (starredListBool1 == false)
            {
                starredList1.listComponents(starredList1);

                Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
                Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
                Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
                Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
                Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");


                mailManager.addMailItem(starred1, starredList1);
                mailManager.addMailItem(starred2, starredList1);
                mailManager.addMailItem(starred3, starredList1);
                mailManager.addMailItem(starred4, starredList1);
                mailManager.addMailItem(starred5, starredList1);
            }
            starredListBool1 = true;

            mailManager.setVisibility();
            starredList1.Visibility = Visibility.Visible;

        }

        private void deletedMails1(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool1 == false)
            {
                deletedList1.listComponents(deletedList1);
            }
            deletedListBool1 = true;

            mailManager.setVisibility();
            deletedList1.Visibility = Visibility.Visible;
        }



        private void exitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            if (treeView1.SelectedItem == starredList1)
            {
                starredList1.Visibility = Visibility.Visible;
                messageList.Visibility = Visibility.Hidden;
            }
            else
            {
                starredList1.Visibility = Visibility.Hidden;
                messageList.Visibility = Visibility.Visible;
            }
            displayedMail.Visibility = Visibility.Hidden;
            bBack.Visibility = Visibility.Collapsed;
        }


        private void showMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            senderMail.Text = message1.Sender;
            receiverMail.Text = message1.Receiver;
            topicMail.Text = message1.Topic;
            contentMail.Text = message1.Content;

            mailManager.setVisibility();
            displayedMail.Visibility = Visibility.Visible;
            bBack.Visibility = Visibility.Visible;
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            //if (treeView1.SelectedItem == deleted1 || treeView1.SelectedItem == deleted2)
            //{
            //    mailManager.deletingMessage();
            //}
            //else
            //{
            //    if (messageList.SelectedItems.Contains(message1))
            //    {
            //        messageList.Items.Remove(message1);
            //        deletedList1.Items.Add(message1);
            //    }

            //}

        }

    }
}
