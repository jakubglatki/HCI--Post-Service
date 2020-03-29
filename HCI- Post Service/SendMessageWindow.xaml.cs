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
        //constructor resposnsible for showing email
        public SendMessageWindow(Mail mail)
        {
            InitializeComponent();
            receiverName.IsReadOnly = true;
            subject.IsReadOnly = true;
            this.content.IsReadOnly = true;
            senderSelect.Visibility = Visibility.Hidden;
            buttonAttachment.Visibility = Visibility.Hidden;
            buttonSend.Content = "Close";

            receiverName.Text = mail.Sender;
            subject.Text = mail.Topic;
            content.Text = mail.Content;

        }

        //constructor responsible for sending email
        public SendMessageWindow(MainWindow mainWindow, MailManager mManager)
        {
            mWindow = mainWindow;
            mailManager = mManager;
            InitializeComponent();

            AddComboBoxElements();
        }

        private void AddComboBoxElements()
        {
            senderSelect.Items.Add(mWindow.header1.Header);
            senderSelect.Items.Add(mWindow.header2.Header);
            senderSelect.SelectedItem = senderSelect.Items[0];
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
                if (buttonSend.Content.ToString() == "Send")
                {
                    //Sender is a placeholder, as well as not selecting proper sender
                    Mail mail = new Mail(senderSelect.SelectedItem.ToString(), receiverName.Text, subject.Text, content.Text);
                    if (senderSelect.SelectedItem == senderSelect.Items[0])
                        mailManager.AddMailItem(mail, mWindow.sentList1);
                    else if (senderSelect.SelectedItem == senderSelect.Items[1])
                        mailManager.AddMailItem(mail, mWindow.sentList2);
                }
                this.Close();
            }
        }
    }
}
