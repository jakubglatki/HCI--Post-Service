//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Input;

//namespace HCI__Post_Service
//{
//    public class MailShow
//    {

//        private Mail mail;
//        public String Sender { get; set; }
//        public String Receiver { get; set; }
//        public String CopyReceiver { get; set; }
//        public String Topic { get; set; }
//        public new String Content { get; set; }
//        public ObservableCollection<string> AttachmentList { get; set; }
//        public MailShow(Mail mail)
//        {
//            this.mail = mail;
//            this.Sender = mail.Sender;
//            this.Receiver = mail.Receiver;
//            this.CopyReceiver = mail.CopyReceiver;
//            this.Topic = mail.Topic;
//            this.Content = mail.MsgContent;
//            this.AttachmentList = mail.AttachmentList;
//        }


//        private void ShowMessage(object sender, System.Windows.Input.MouseButtonEventArgs e)
//        {
//            Manager manager = new Manager();
//            manager.SetCurrentMail(mail);

//            manager.EnableButtons();
//            manager.ShowMessage(mail);
//        }
//    }
//}
