using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HCI__Post_Service
{
    [Serializable]
    public class Mail : ListViewItem, IXmlSerializable
    {
        [XmlAttribute("Sender")]
        public string Sender { get; set; }
        [XmlAttribute("Receiver")]
        public string Receiver { get; set; }
        [XmlAttribute("CopyReceiver")]
        public string CopyReceiver { get; set; }
        [XmlAttribute("Topic")]
        public string Topic { get; set; }
        [XmlAttribute("Content")]
        public string Content { get; set; }
        [XmlAttribute("AttachmentList")]
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

        public Mail(SerializationInfo info, StreamingContext context)
        {
            Sender = (string)info.GetValue("Sender", typeof(string));
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
            if (manager.GetCurrentFolder().name != "Deleted")
            {
                manager.EnableButtons();
            }
            
            if (manager.GetCurrentFolder().name !="Inbox" && manager.GetCurrentFolder().name != "Sent")
            {
                manager.GetMainWindow().buttonStar.IsEnabled = false;
            }
            else manager.GetMainWindow().buttonDelete.IsEnabled = true;
            manager.SetCurrentMail(this);
        }


        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();


            this.Sender = (string)new
                          XmlSerializer(typeof(string)).Deserialize(reader);
            this.Receiver = (string)new
                          XmlSerializer(typeof(string)).Deserialize(reader);
            this.Topic = (string)new
                          XmlSerializer(typeof(string)).Deserialize(reader);
            this.Content = (string)new
                          XmlSerializer(typeof(string)).Deserialize(reader);
            this.AttachmentList = (List<string>)new
                          XmlSerializer(typeof(List<string>)).Deserialize(reader);
            this.CopyReceiver = (string)new
                          XmlSerializer(typeof(string)).Deserialize(reader);
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            new XmlSerializer(Sender.GetType()).Serialize(writer, Sender);
            new XmlSerializer(Receiver.GetType()).Serialize(writer, Receiver);
            new XmlSerializer(Topic.GetType()).Serialize(writer, Topic);
            new XmlSerializer(Content.GetType()).Serialize(writer, Content);
            if(AttachmentList!=null)
            new XmlSerializer(AttachmentList.GetType()).Serialize(writer, AttachmentList);
            if(CopyReceiver != null)
            new XmlSerializer(CopyReceiver.GetType()).Serialize(writer, CopyReceiver);
        }
    }
}
