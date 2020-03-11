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
        public MainWindow()
        {
            InitializeComponent();
            //code to get after startup here



        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogWindow dw = new DialogWindow();
            dw.textBox.Text = text;
        
            //if we left DialogWindow by pressing "OK" button
            if(dw.ShowDialog()==true)
            {
                text = dw.textBox.Text;

                //it will save the value until the next session
                Properties.Settings.Default.Text = text;
                Properties.Settings.Default.Save();
            }
        }

        private void addMailItem(Mail mail)
        {

            ListViewItem starredMailItem = new ListViewItem();
            starredMailItem.FontSize = 18;
            starredMailItem.Margin = new Thickness(5, 0, 0, 5);
            starredMailItem.Content = mail.Topic;
            messageList.Items.Add(starredMailItem);
        }


        private void starredMails1(object sender, MouseButtonEventArgs e)
        {
            messageList.Items.Clear();


            Mail starred1 = new Mail("Sender1", "Receiver1", "Starred 1", "StarredMessage1");
            Mail starred2 = new Mail("Sender2", "Receiver2", "Starred 2", "StarredMessage2");
            Mail starred3 = new Mail("Sender3", "Receiver3", "Starred 3", "StarredMessage3");
            Mail starred4 = new Mail("Sender4", "Receiver4", "Starred 4", "StarredMessage4");
            Mail starred5 = new Mail("Sender5", "Receiver5", "Starred 5", "StarredMessage5");


            addMailItem(starred1);
            addMailItem(starred2);
            addMailItem(starred3);
            addMailItem(starred4);
            addMailItem(starred5);


        }

        private void inboxMails1(object sender, MouseButtonEventArgs e)
        {

            messageList.Items.Clear();


            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
            Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
            Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");

            addMailItem(message1);
            addMailItem(message2);
            addMailItem(message3);
            addMailItem(message4);
        }
    }
}
