using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HCI__Post_Service
{

    public class Manager
    {

        static protected MainWindow window;
        static private ButtonManager buttonManager;
        static private MailManager mailManager;
        static private TreeViewItem treeViewItem;


        //Constructors
        public Manager() { }
        public Manager(MainWindow mainWindow)
        {
            window = mainWindow;
            buttonManager = new ButtonManager(mainWindow);
            mailManager = new MailManager(mainWindow);
        }

        //Getters and setters

        public void SetCurrentTreeViewItem(TreeViewItem treeView)
        {
            treeViewItem = treeView;
        }
        public void SetCurrentMail(Mail mail)
        {
            buttonManager.SetCurrentMail(mail);
        }
        public void SetCurrentMailsList(MailsList mailsList)
        {
            buttonManager.SetCurrentMailsList(mailsList);
        }

        public void SetCurrentMailBox(MailBox mail)
        {
            buttonManager.SetCurrentMailBox(mail);
        }
        public void SetCurrentFolder(MailFolder folder)
        {
            buttonManager.SetCurrentMailFolder(folder);
        }

        public TreeViewItem GetCurrentTreeViewItem()
        {
            return treeViewItem;
        }
        public MainWindow GetMainWindow()
        {
            return window;
        }

        public MailsList GetCurrentList()
        {
            return buttonManager.GetCurrentList();
        }

        public Mail GetCurrentMail()
        {
            return buttonManager.GetCurrentMail();
        }

        public MailBox GetCurrentMailBox(string name)
        {
            return buttonManager.GetCurrentMailBox(name);
        }

        public MailFolder GetCurrentFolder()
        {
            return buttonManager.GetCurrentFolder();
        }

        //Methods

        public void AddMailItem(Mail mail, MailsList list)
        {
            mailManager.AddMailItem(mail, list);
        }



        public void SetVisibility() { 

            window.displayedMail.Visibility = Visibility.Hidden;
            window.bBack.Visibility = Visibility.Collapsed;

            buttonManager.DisableButtons();
        }

        public void ShowMessage(Mail mail)
        {
            SetVisibility();
            buttonManager.DisableButtons();
            mailManager.ShowMessage(mail);
        }

        public void MakeNewMailsList(MailsList mailsList, params Mail[] mail)
        {
            mailManager.MakeNewMailsList(mailsList, mail);
        }

        public void DeletingMail(int index)
        {
           buttonManager.DeletingMail( index);
        }
        public void MoveMailToDeleted(int index)
        {
            buttonManager.MoveMailToDeleted( index);
        }
        public void DisableButtons()
        {
            buttonManager.DisableButtons();
        }
        public void EnableButtons()
        {
            buttonManager.EnableButtons();
        }

        public void ShowSendMessageWindow(Mail mail, MainWindow window, Manager manager, MailType mailType)
        {
            SendMessageWindow sendMessageWindow = new SendMessageWindow(mail, window, manager, mailType);
            sendMessageWindow.Show();
        }
        public void SendReply()
        {
            MailType mailType= MailType.reply;
            ShowSendMessageWindow(buttonManager.GetCurrentMail(), window, this, mailType);
        }

        public void ReplyToAllMessage()
        {
            MailType mailType = MailType.replyToAll;
            ShowSendMessageWindow(buttonManager.GetCurrentMail(), window, this, mailType);
        }

        public void ForwardMessage()
        {
            MailType mailType = MailType.forward;
            ShowSendMessageWindow(buttonManager.GetCurrentMail(), window, this, mailType);
        }

        public string MailboxNameString()
        {
            if (window.treeViewMailBox.SelectedItem != null)
            {
                StackPanel selectedFolder = (StackPanel)window.treeViewMailBox.SelectedItem;
                TreeViewItem selectedMailbox = (TreeViewItem)selectedFolder.Parent;
                return selectedMailbox.Header.ToString();
            }
            else return window.mailBoxes[0].name;
        }

        public void StarMessage()
        {
            mailManager.StarMessage();
        }

        public void Deserialize(string path)
        {
            mailManager.Deserialize(path);
        }
        public void ImportFile()
        {
            mailManager.ImportFile();
        }

        public void ExportFile()
        {
            mailManager.ExportFile();
        }

        public void TreeViewForMailBox(ObservableCollection<MailBox> mailboxes)
        {
            mailManager.TreeViewForMailBox(mailboxes);
        }
    }
}
