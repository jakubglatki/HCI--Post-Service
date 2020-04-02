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
        static private Manager manager;
        //constructor resposnsible for showing email
        public SendMessageWindow(Mail mail, bool isReplying, MainWindow mainWindow, Manager mManager)
        {
            mWindow = mainWindow;
            manager = mManager;
            InitializeComponent();
            receiverName.IsReadOnly = true;
            subject.IsReadOnly = true;

            if (isReplying == false)
            {
                senderSelect.Visibility = Visibility.Hidden;
                buttonAttachment.Visibility = Visibility.Hidden;
                this.content.IsReadOnly = true;
                receiverName.Text = mail.Sender;
                subject.Text = mail.Topic;
                content.Text = mail.Content;
                buttonSend.Content = "Close";
            }
            else
            {
                receiverName.Text = mail.Sender;
                subject.Text = ("Re: " + mail.Topic);
                buttonSend.Content = "Reply";
                if(mWindow.header1.IsSelected)
                {
                    senderSelect.Items.Add(mWindow.header1.Header);
                }
                else if (mWindow.header2.IsSelected)
                {
                    senderSelect.Items.Add(mWindow.header2.Header);
                }
                senderSelect.SelectedItem = senderSelect.Items[0];
            }
        }

        //constructor responsible for sending email
        public SendMessageWindow(MainWindow mainWindow, Manager mManager)
        {
            mWindow = mainWindow;
            manager = mManager;
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
                if (buttonSend.Content.ToString() == "Send" || buttonSend.Content.ToString() == "Reply")
                {
                    //Sender is a placeholder, as well as not selecting proper sender
                    Mail mail = new Mail(senderSelect.SelectedItem.ToString(), receiverName.Text, subject.Text, content.Text);
                    if (senderSelect.SelectedItem == mWindow.header1.Header)
                        manager.AddMailItem(mail, mWindow.sentList1);
                    else if (senderSelect.SelectedItem == mWindow.header2.Header)
                        manager.AddMailItem(mail, mWindow.sentList2);
                }
                this.Close();
            }
        }
    }
}
