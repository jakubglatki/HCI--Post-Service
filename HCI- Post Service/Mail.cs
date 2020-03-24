namespace HCI__Post_Service
{
    public class Mail
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public Mail() { }

        public Mail(string Sender, string Receiver, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = "";
            this.Content = Content;
        }
        public Mail(string Sender, string Receiver, string Topic, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = Content;
        }

        //private void showMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
        //    senderMail.Text = message1.Sender;
        //    receiverMail.Text = message1.Receiver;
        //    topicMail.Text = message1.Topic;
        //    contentMail.Text = message1.Content;

        //    setVisibility();
        //    displayedMail.Visibility = Visibility.Visible;
        //    bBack.Visibility = Visibility.Visible;
        //}
    }
}
