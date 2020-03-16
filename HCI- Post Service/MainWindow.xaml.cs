using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI__Post_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text = Properties.Settings.Default.Text;
        private bool starredListBool1 = false;
        private bool deletedListBool1 = false;
        private ListView starredList1;
        private ListView deletedList1;

        public MainWindow()
        {
            InitializeComponent();
            //code to get after startup here
            
            starredList1 = new ListView();
            deletedList1 = new ListView();
            gridView1.Children.Add(starredList1);
            gridView1.Children.Add(deletedList1);
        }

        
        private void setVisibility()
        {
            deletedList1.Visibility = Visibility.Hidden;
            starredList1.Visibility = Visibility.Hidden;
            messageList.Visibility = Visibility.Hidden;
            displayedMail.Visibility = Visibility.Hidden;
            bBack.Visibility = Visibility.Collapsed;
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


          //it is used only for starred items for now on
        private void addMailItem(Mail mail, ListView list)
        {
            ListViewItem starredMailItem = new ListViewItem();
            starredMailItem.FontSize = 18;
            starredMailItem.Margin = new Thickness(5, 0, 0, 5);
            starredMailItem.Content = mail.Topic;
            list.Items.Add(starredMailItem);

        }

        private void listComponents(ListView list)
        {
            //it's the same as Height=auto
            list.Height = Double.NaN;
            list.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(list, 1);
            Grid.SetColumnSpan(list, 2);
            Grid.SetRow(list, 2);
            list.Background = Brushes.Ivory;
            list.Margin = new Thickness(0, 0, 10, 10);
        }

        private void starredMails1(object sender, MouseButtonEventArgs e)
        {
            if (starredListBool1 == false)
            {
                listComponents(starredList1);

                Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
                Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
                Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
                Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
                Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");


                addMailItem(starred1, starredList1);
                addMailItem(starred2, starredList1);
                addMailItem(starred3, starredList1);
                addMailItem(starred4, starredList1);
                addMailItem(starred5, starredList1);
            }
            starredListBool1 = true;

            setVisibility();
            starredList1.Visibility = Visibility.Visible;

        }

        private void deletedMails1(object sender, MouseButtonEventArgs e)
        {

            if (deletedListBool1 == false)
            {
                listComponents(deletedList1);
            }

            setVisibility();
            deletedList1.Visibility = Visibility.Visible;
        }


            private void inboxMails1(object sender, MouseButtonEventArgs e)
        {

            //messageList.Items.Clear();

            //Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            //Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
            //Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
            //Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");

            //addMailItem(message1);
            //addMailItem(message2);
            //addMailItem(message3);
            //addMailItem(message4);

            setVisibility();
            messageList.Visibility = Visibility.Visible;
        }

        private void exitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void showMessage(object sender, MouseButtonEventArgs e)
        {
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            senderMail.Text = message1.Sender;
            receiverMail.Text = message1.Receiver;
            topicMail.Text = message1.Topic;
            contentMail.Text = message1.Content;

            setVisibility();
            displayedMail.Visibility = Visibility.Visible;
            bBack.Visibility = Visibility.Visible;
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

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (treeView1.SelectedItem == deleted1 || treeView1.SelectedItem == deleted2)
            {
                if (deletedList1.SelectedItems.Contains(message1))
                {
                    MessageBoxResult result = MessageBox.Show("“Do you really wish to delete the message?", "Delete Message", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            deletedList1.Items.Remove(message1);

                            break;
                        case MessageBoxResult.No:
                            break;
                    }

                }
            }
            else
            {
                if(messageList.SelectedItems.Contains(message1))
                {
                    messageList.Items.Remove(message1);
                    deletedList1.Items.Add(message1);
                }

            }

        }

    }
}
