using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    class Mail
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
    }
}
