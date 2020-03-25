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
        }

        public Mail(string Sender, string Receiver, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = "";
            this.Content = Content;

            MouseLeftButtonUp += ShowMessage;
        }
        public Mail(string Sender, string Receiver, string Topic, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = Content;

            this.MouseDoubleClick += ShowMessage;
        }


        private void ShowMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            

            MailManager mailManager = new MailManager();
            mailManager.SetCurrentMail(this);
            mailManager.ShowMessage(this);
        }
    }
}
