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

        public ButtonManager() { }
        public ButtonManager(MainWindow mainWindow, Mail cMail, MailsList cList)
        {
            window = mainWindow;
            currentList = cList;
            currentMail = cMail;
        }


        public void DeletingMail()
        {

            MessageBoxResult result = MessageBox.Show("Do you really wish to delete the message?", "Delete Message", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (currentList == window.deletedList1)
                    {
                        window.deletedList1.Items.Remove(currentMail);
                        DisableButtons();
                    }

                    else if (currentList == window.deletedList2)
                    {
                        window.deletedList2.Items.Remove(currentMail);
                        DisableButtons();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        public void MoveMailToDeleted()
        {
            currentList.Items.Remove(currentMail);
            if (GetCurrentList() == window.messageList1 || GetCurrentList() == window.sentList1
                || GetCurrentList() == window.starredList1 || GetCurrentList() == window.draftsList1)
            {
                window.deletedList1.Items.Add(currentMail);
                DisableButtons();
                currentMail = null;
            }

            else
            {
                window.deletedList2.Items.Add(currentMail);
                DisableButtons();
                currentMail = null;
            }

        }

        private MailsList GetCurrentList()
        {
            return currentList;
        }

        public void DisableButtons()
        {
            window.buttonDelete.IsEnabled = false;
            window.buttonForward.IsEnabled = false;
            window.buttonReply.IsEnabled = false;
            window.buttonReplyAll.IsEnabled = false;
        }
        public void EnableButtons()
        {
            window.buttonDelete.IsEnabled = true;
            window.buttonForward.IsEnabled = true;
            window.buttonReply.IsEnabled = true;
            window.buttonReplyAll.IsEnabled = true;
        }
    }
}
