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
        }

        public Mail(string Sender, string Receiver, string Topic)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = "";

            MouseLeftButtonUp += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
        }

        public Mail(string Sender, string Receiver, string Topic, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = Content;

            this.MouseDoubleClick += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
        }


        private void ShowMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MailManager mailManager = new MailManager();
            mailManager.SetCurrentMail(this);
            mailManager.EnableDeleteButton();
            mailManager.ShowMessage(this);
        }
        private void MailSetCurrentMail(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MailManager mailManager = new MailManager();
            mailManager.EnableDeleteButton();
            mailManager.SetCurrentMail(this);
        }

    }
}
