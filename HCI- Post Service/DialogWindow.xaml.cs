using System.Windows;
using System.Windows.Controls;

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
