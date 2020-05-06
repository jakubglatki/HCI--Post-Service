using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HCI__Post_Service
{
 
    public class MailsList : ListView { 
        public MailsList()
        {
            this.MouseLeftButtonUp += SetCurrentMailList;
        }

        public MailsList(SerializationInfo info, StreamingContext context)
        {
            //Clear out the current items in the ListViewItems if there are any
            base.Items.Clear();

            //Retrieve the List of ListViewItems you created on Serialization
            ObservableCollection<ListViewItem> items = (ObservableCollection<ListViewItem>)info.GetValue("ListViewItems", typeof(ObservableCollection<ListViewItem>));

            //Add each ListViewItem back into the collection
            foreach (ListViewItem item in items)
            {
                base.Items.Add(item);
            }
        }


        public void ListComponents(MailsList list)
        {
            ////it's the same as Height=auto
            //list.Height = Double.NaN;
            //list.HorizontalAlignment = HorizontalAlignment.Stretch;
            //Grid.SetColumn(list, 1);
            //Grid.SetColumnSpan(list, 2);
            //Grid.SetRow(list, 2);
            //list.Background = Brushes.Ivory;
            //list.Margin = new Thickness(0, 0, 10, 10);
        }
        public void SetCurrentMailList(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            manager.SetCurrentMailsList(this);
        }


    }
}
