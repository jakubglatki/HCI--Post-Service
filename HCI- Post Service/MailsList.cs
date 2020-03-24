using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HCI__Post_Service
{
    public class MailsList : ListView
    {
        public MailsList()
        {

        }
        public void listComponents(MailsList list)
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
    }
}
