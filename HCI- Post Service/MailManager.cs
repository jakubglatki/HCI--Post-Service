using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HCI__Post_Service
{
    public class MailManager
    {
        private MainWindow window;

        public MailManager(MainWindow window)
        {
            this.window = window;
           // window.menu = 
        }
        public void setVisibility()
        {
            window.deletedList1.Visibility = Visibility.Hidden;
            window.starredList1.Visibility = Visibility.Hidden;
            window.messageList.Visibility = Visibility.Hidden;
            window.displayedMail.Visibility = Visibility.Hidden;
            window.bBack.Visibility = Visibility.Collapsed;
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    DialogWindow dw = new DialogWindow();
        //    dw.textBox.Text = text;

        //    //if we left DialogWindow by pressing "OK" button
        //    if(dw.ShowDialog()==true)
        //    {
        //        text = dw.textBox.Text;

        //        //it will save the value until the next session
        //        Properties.Settings.Default.Text = text;
        //        Properties.Settings.Default.Save();
        //    }
        //}


        public void addMailItem(Mail mail, ListView list)
        {
            ListViewItem newMailItem = new ListViewItem();
            newMailItem.FontSize = 18;
            newMailItem.Margin = new Thickness(5, 0, 0, 5);
            newMailItem.Content = mail.Topic;
            list.Items.Add(newMailItem);

        }

        public void listComponents(ListView list)
        {
            //it's the same as Height=auto
            list.Height = Double.NaN;
            list.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(list, 1);
            Grid.SetColumnSpan(list, 2);
            Grid.SetRow(list, 2);
            list.Background = Brushes.Ivory;
            list.Margin = new Thickness(0, 0, 10, 10);
        }

        public void setMessages()
        {
            listComponents(window.messageList);
            Mail message1 = new Mail("Sender1", "Receiver1", "Message 1", "messageMessage1");
            Mail message2 = new Mail("Sender2", "Receiver2", "Message 2", "messageMessage2");
            Mail message3 = new Mail("Sender3", "Receiver3", "Message 3", "messageMessage3");
            Mail message4 = new Mail("Sender4", "Receiver4", "Message 4", "messageMessage4");

            addMailItem(message1, window.messageList);
            addMailItem(message2, window.messageList);
            addMailItem(message3, window.messageList);
            addMailItem(message4, window.messageList);
        }

    }
}
