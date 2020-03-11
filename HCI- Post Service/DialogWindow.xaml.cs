using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI__Post_Service
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //closing the window and is saying to the main window that we want to keep the changes
            DialogResult = true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //it allows as to mirror the text from textBox to textBlock
            textBlock.Text = textBox.Text;
        }
    }
}
