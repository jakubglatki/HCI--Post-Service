using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI__Post_Service
{
    class ButtonManager 
    {

        static private MainWindow window;
        static private Mail currentMail;
        static private MailsList currentList;
        static private MailBox currentMailBox;
        static private MailFolder currentFolder;

        public ButtonManager() { }
        public ButtonManager(MainWindow mainWindow)
        {
            window = mainWindow;
        }


        public void DeletingMail(int index)
        {
            Manager manager = new Manager();
            MessageBoxResult result = MessageBox.Show("Do you really wish to delete the message?", "Delete Message", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (GetCurrentFolder().name == "Deleted")
                    {
                        GetCurrentMailBox(manager.MailboxNameString()).GetCurrentFolder().mailList.RemoveAt(index);
                        currentList.Items.Remove(currentMail);
                        DisableButtons();
                    }

                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        public void MoveMailToDeleted(int index)
        {
            Manager manager = new Manager();
            currentList.Items.Remove(currentMail);
            if (GetCurrentFolder().name!="Deleted" )
            {
                manager.GetCurrentFolder().mailList.RemoveAt(index);
                GetCurrentMailBox(manager.MailboxNameString()).deleted.mailList.Add(currentMail);
                DisableButtons();
                currentMail = null;
            }

        }


        public void SetCurrentMail(Mail mail)
        {
            currentMail = mail;
        }
        public void SetCurrentMailsList(MailsList mailsList)
        {
            currentList = mailsList;
        }

        public void SetCurrentMailBox(MailBox mail)
        {
            currentMailBox = mail;
        }
        public void SetCurrentMailFolder(MailFolder mailsFolder)
        {
            currentFolder = mailsFolder;
        }


        public Mail GetCurrentMail()
        {
            return currentMail;
        }

        public MailsList GetCurrentList()
        {
            return currentList;
        }

        public MailBox GetCurrentMailBox(string name)
        {
            foreach (MailBox m in window.mailBoxes)
            {
                if (m.name == name)
                {
                    return m;
                }
            }
            return null;
        }

        public MailFolder GetCurrentFolder()
        {
            return currentFolder;
        }

        public void DisableButtons()
        {
            window.buttonDelete.IsEnabled = false;
            window.buttonForward.IsEnabled = false;
            window.buttonReply.IsEnabled = false;
            window.buttonReplyAll.IsEnabled = false;
            window.buttonStar.IsEnabled = false;
        }
        public void EnableButtons()
        {
            window.buttonDelete.IsEnabled = true;
            window.buttonForward.IsEnabled = true;
            window.buttonReply.IsEnabled = true;
            window.buttonReplyAll.IsEnabled = true;
            window.buttonStar.IsEnabled = true;
        }


    }
}
