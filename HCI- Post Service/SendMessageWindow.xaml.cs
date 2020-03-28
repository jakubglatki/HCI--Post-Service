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
using System.Windows.Shapes;

namespace HCI__Post_Service
{
    /// <summary>
    /// Interaction logic for SendMessageWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window
    {
        static private MainWindow mWindow;
        static private MailManager mailManager;


        public SendMessageWindow(MainWindow mainWindow, MailManager mManager)
        {
            mWindow = mainWindow;
            mailManager = mManager;
            InitializeComponent();
            
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(receiverName.Text) && string.IsNullOrWhiteSpace(subject.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without receiver's address and subject", "Can't Send Message", MessageBoxButton.OK);
            }

            else if (string.IsNullOrWhiteSpace(receiverName.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without receiver's address", "Can't Send Message", MessageBoxButton.OK);
            }

            else if (string.IsNullOrWhiteSpace(subject.Text))
            {
                MessageBoxResult result = MessageBox.Show("You can't send an email without subject", "Can't Send Message", MessageBoxButton.OK);
            }

            else
            {
                //Sender is a placeholder, as well as not selecting proper sender
                Mail mail = new Mail("Sender", receiverName.Text, subject.Text, content.Text);
                mailManager.AddMailItem(mail, mWindow.sentList1);
                this.Close();
            }
        }
    }
}
