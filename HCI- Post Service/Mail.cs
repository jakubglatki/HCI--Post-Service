using System.Windows;
using System.Windows.Controls;

namespace HCI__Post_Service
{
    public class Mail : ListViewItem
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }


        public Mail() {

            MouseLeftButtonUp += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
            this.MouseDoubleClick += ShowMessageInSendMessageWindow;
        }

        public Mail(string Sender, string Receiver, string Topic)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = "";

            MouseDoubleClick += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
            this.MouseDoubleClick += ShowMessageInSendMessageWindow;
        }

        public Mail(string Sender, string Receiver, string Topic, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = Content;

            this.MouseDoubleClick += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
            this.MouseDoubleClick += ShowMessageInSendMessageWindow;
        }


        private void ShowMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MailManager mailManager = new MailManager();
            mailManager.SetCurrentMail(this);
            mailManager.EnebaleButtons();
            mailManager.ShowMessage(this);
        }
        private void ShowMessageInSendMessageWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SendMessageWindow sendMessage = new SendMessageWindow(this);
            sendMessage.Show();

        }
        private void MailSetCurrentMail(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MailManager mailManager = new MailManager();
            mailManager.EnebaleButtons();
            mailManager.SetCurrentMail(this);
        }



    }
}
