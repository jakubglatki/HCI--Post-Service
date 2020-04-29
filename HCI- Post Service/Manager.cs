using System;
using System.Collections.Generic;
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


        //Methods

        public void AddMailItem(Mail mail, MailsList list)
        {
            mailManager.AddMailItem(mail, list);
        }

        public void SetMessages()
        {
            SetVisibility();
            buttonManager.DisableButtons();
            mailManager.SetMessages();
        }

        public void SetVisibility()
        {
            window.sentList1.Visibility = Visibility.Hidden;
            window.deletedList1.Visibility = Visibility.Hidden;
            window.starredList1.Visibility = Visibility.Hidden;
            window.messageList1.Visibility = Visibility.Hidden;
            window.draftsList1.Visibility = Visibility.Hidden;


            window.sentList2.Visibility = Visibility.Hidden;
            window.deletedList2.Visibility = Visibility.Hidden;
            window.starredList2.Visibility = Visibility.Hidden;
            window.messageList2.Visibility = Visibility.Hidden;
            window.draftsList2.Visibility = Visibility.Hidden;

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

        public void DeletingMail()
        {
           buttonManager.DeletingMail();
        }
        public void MoveMailToDeleted()
        {
            buttonManager.MoveMailToDeleted();
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

        public void StarMessage()
        {
            mailManager.StarMessage();
        }
    }
}
