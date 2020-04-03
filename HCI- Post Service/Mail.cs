using System.Collections.Generic;
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
        public List<string> AttachmentList { get; set; }

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

        public Mail(string Sender, string Receiver, string Topic, string Content, List<string> list)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Topic = Topic;
            this.Content = Content;
            this.AttachmentList=list;

            this.MouseDoubleClick += ShowMessage;
            this.MouseLeftButtonUp += MailSetCurrentMail;
            this.MouseDoubleClick += ShowMessageInSendMessageWindow;
        }

        private void ShowMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            manager.SetCurrentMail(this);

            manager.EnableButtons();
            manager.ShowMessage(this);
        }
        private void ShowMessageInSendMessageWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            MailType mailType = MailType.view;
            manager.ShowSendMessageWindow(manager.GetCurrentMail(), manager.GetMainWindow(), manager, mailType);

        }
        private void MailSetCurrentMail(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            if (manager.GetCurrentList() != manager.GetMainWindow().draftsList1 && manager.GetCurrentList() != manager.GetMainWindow().draftsList2)
            {
                manager.EnableButtons();
            }
            else manager.GetMainWindow().buttonDelete.IsEnabled = true;
            manager.SetCurrentMail(this);
        }

    }
}
