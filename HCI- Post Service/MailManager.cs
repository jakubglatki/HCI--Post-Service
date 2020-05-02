using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace HCI__Post_Service
{
    public class MailManager
    {

        static protected MainWindow window;
        static protected Mail currentMail;
        protected MailsList currentList;
        protected MailBox currentMailBox;
        protected MailFolder currentFolder;
        public MailManager() { }
        public MailManager(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public void AddMailItem(Mail mail, MailsList list)
        {
            ListViewItem newMailItem = new Mail(mail.Sender, mail.Receiver, mail.Topic, mail.Content, mail.AttachmentList);
            newMailItem.FontSize = 18;
            newMailItem.Margin = new Thickness(5, 0, 0, 5);
            newMailItem.Content = mail.Topic;
            list.Items.Insert(0, newMailItem);
        }


        public void ShowMessage(Mail mail)
        {
            window.senderMail.Text = mail.Sender;
            window.receiverMail.Text = mail.Receiver;
            window.topicMail.Text = mail.Topic;
            window.contentMail.Text = mail.Content;

            window.displayedMail.Visibility = Visibility.Visible;
            window.bBack.Visibility = Visibility.Visible;
        }

        public void MakeNewMailsList(MailsList mailsList, params Mail[] mail)
        {
            foreach(Mail mailParam in mail)
            {
                AddMailItem(mailParam, mailsList);
            }
        }

        public void StarMessage()
        {
            Manager manager = new Manager(window);


            if (manager.GetCurrentFolder().name== "Inbox" || manager.GetCurrentFolder().name == "Sent")
            {
                manager.GetCurrentMailBox(manager.MailboxNameString()).starred.mailList.Add(manager.GetCurrentMail());
            }

        }

        public void ImportFile()
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Import file";

            string XML = "XML(*.xml)| *.xml";
            fileDialog.Filter = XML;


            if (fileDialog.ShowDialog() == true)
            {
                string filePath = fileDialog.FileName;
                Deserialize(filePath);
            }
        }

        public void Deserialize(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<MailBox>));

            using (FileStream fs = File.OpenRead(filePath))
            {
                window.mailBoxes = (List<MailBox>)deserializer.Deserialize(fs);
            }
        }
        public void ExportFile()
        {

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Title = "Export file";
            string XML = "XML(*.xml)| *.xml";

            fileDialog.Filter = XML;

            if (fileDialog.ShowDialog() == true)
            {
                string file = fileDialog.FileName;
                this.Serialize(file);
            }
        }

        private void Serialize(String file)
        {
            using (Stream fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                XmlSerializer xml = new XmlSerializer(typeof(List<MailBox>));
                xml.Serialize(fs, window.mailBoxes);
            }
        }
    }
}
