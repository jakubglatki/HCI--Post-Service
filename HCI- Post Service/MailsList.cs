using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HCI__Post_Service
{
    [Serializable]
    public class MailsList : ListView, ISerializable
    {
        public List<Mail> mails;
        public MailsList()
        {
            this.MouseLeftButtonUp += SetCurrentMailList;
        }
        public MailsList(List<Mail> mails)
        {
            this.mails = mails;
           this.MouseLeftButtonUp += SetCurrentMailList;
        }

        protected MailsList(SerializationInfo info, StreamingContext context)
        {
            //Clear out the current items in the ListViewItems if there are any
            base.Items.Clear();

            //Retrieve the List of ListViewItems you created on Serialization
            List<ListViewItem> items = (List<ListViewItem>)info.GetValue("ListViewItems", typeof(List<ListViewItem>));

            //Add each ListViewItem back into the collection
            foreach (ListViewItem item in items)
            {
                base.Items.Add(item);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {           
            //Create a List of ListViewItems for serialization
            List<ListViewItem> items = new List<ListViewItem>();

            //Add each ListViewItem to the collection
            foreach (ListViewItem item in base.Items)
            {
                items.Add(item);
            }

            //Add the collection to the SerializationInfo object
            info.AddValue("ListViewItems", items);
        }

        public void ListComponents(MailsList list)
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
        private void SetCurrentMailList(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            manager.SetCurrentMailsList(this);
        }

    }
}
