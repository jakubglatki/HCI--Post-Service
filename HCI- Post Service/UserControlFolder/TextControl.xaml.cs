using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI__Post_Service.UserControlFolder
{
    /// <summary>
    /// Interaction logic for TextControl.xaml
    /// </summary>
    public partial class TextControl : UserControl
    {
        public TextControl()
        {
            InitializeComponent();
            LoadFontSizes();
            LoadFontFamilies();
        }

        private void LoadFontSizes()
        {
            cbSize.Items.Add(8);
            cbSize.Items.Add(9);
            cbSize.Items.Add(10);
            cbSize.Items.Add(11);
            cbSize.Items.Add(12);
            cbSize.Items.Add(14);
            cbSize.Items.Add(16);
            cbSize.Items.Add(18);

            //font 11 as default
            cbSize.SelectedItem = cbSize.Items[3];
        }

        private void LoadFontFamilies()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (System.Drawing.FontFamily font in installedFonts.Families)
            {
                cbFontFamily.Items.Add(font.Name);
            }

            cbFontFamily.SelectedItem = cbFontFamily.Items[2];
        }

        private void BoldButton(object sender, RoutedEventArgs e)
        {

            var fontWeight = richTextBox.Selection.GetPropertyValue(RichTextBox.FontWeightProperty);
            if (fontWeight.Equals(FontWeights.Bold)) 
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Normal);
            }
            else // bold text
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Bold);
            }
            
        }

        private void ItalicButton(object sender, RoutedEventArgs e)
        {
            var fontStyle = richTextBox.Selection.GetPropertyValue(RichTextBox.FontStyleProperty);
            if (fontStyle.Equals(FontStyles.Italic)) 
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Normal);
            }
            else // bold text
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Italic);
            }
        }

        private void UnderlineButton(object sender, RoutedEventArgs e)
        {
            var fontUnderlined = richTextBox.Selection.GetPropertyValue(Run.TextDecorationsProperty);
            if (fontUnderlined.Equals(TextDecorations.Underline)) 
            {
                richTextBox.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, null);
            }
            else // bold text
            {
                richTextBox.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        private void FontSizeChanged(object sender, SelectionChangedEventArgs e)
        {
            String sSize = cbSize.SelectedItem.ToString();
            double size = (double)Int32.Parse(sSize);
            richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontSizeProperty, size);
            
        }
    }
}
