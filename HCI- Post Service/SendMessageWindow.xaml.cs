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
        static private SendMessageManager messageManager;
        private bool isSendMessageManagerInitialized = false;

        //constructor resposnsible for showing email
        public SendMessageWindow(Mail mail, MainWindow mainWindow, Manager mManager, MailType mailType)
        {
            if (isSendMessageManagerInitialized==false)
            {
                messageManager = new SendMessageManager(this);
                isSendMessageManagerInitialized = true;
            }
            mWindow = mainWindow;
            manager = mManager;
            InitializeComponent();

            if (mailType.ToString()=="view")
            {
                messageManager.ViewMessage(mail, manager);
            }
            else if (mailType.ToString() == "reply")
            {
                messageManager.ReplyMessage(mail, manager, mWindow);
            }
            else if (mailType.ToString() == "replyToAll")
            {
                //if there were no other receivers than do just normal reply 
                if (!mail.Sender.Contains(","))
                {
                    messageManager.ReplyMessage(mail, manager, mWindow);
                }
                //TO DO:
                else
                {
                    messageManager.ReplyToAllMessage(mail, manager, mWindow);
                }
            }
            else if (mailType.ToString() == "forward")
            {
                messageManager.ForwardMessage(mail, mWindow, manager);
            }
        }

        //constructor responsible for sending email
        public SendMessageWindow(MainWindow mainWindow, Manager mManager)
        {
            if (isSendMessageManagerInitialized == false)
            {
                messageManager = new SendMessageManager(this);
                isSendMessageManagerInitialized = true;
            }
            mWindow = mainWindow;
            manager = mManager;
            InitializeComponent();

            AddComboBoxElements();
        }

        private void AddComboBoxElements()
        {
            messageManager.AddComboBoxElements(mWindow);
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            if (messageManager.CheckIfMailIsCorrect() == true)
            {
                messageManager.AddMailToSent(manager, mWindow);
                boxAttachments.Items.Clear();
                this.Close();
            }
        }

        private void TextGotFocus(object sender, RoutedEventArgs e)
        {
            
            TextBox textBox = (TextBox)sender;
            if (!textBox.IsReadOnly)
            {
                textBox.Text = string.Empty;
                textBox.GotFocus -= TextGotFocus;
            }
        }

        private void AddAttachment(object sender, RoutedEventArgs e)
        {
            messageManager.AddAttachment(manager);
        }
    }
}
