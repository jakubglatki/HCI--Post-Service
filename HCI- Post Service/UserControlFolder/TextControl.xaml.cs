using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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

            if (richTextBox.Selection.GetPropertyValue(RichTextBox.FontWeightProperty).Equals(FontWeights.Bold)) 
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Normal);

            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Bold);
            }
            
        }

        private void ItalicButton(object sender, RoutedEventArgs e)
        {
            if (richTextBox.Selection.GetPropertyValue(RichTextBox.FontStyleProperty).Equals(FontStyles.Italic)) 
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Italic);
            }
        }

        private void UnderlineButton(object sender, RoutedEventArgs e)
        {
            if (richTextBox.Selection.GetPropertyValue(Run.TextDecorationsProperty).Equals(TextDecorations.Underline)) 
            {
                richTextBox.Selection.ApplyPropertyValue(Run.TextDecorationsProperty, null);
            }
            else 
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

        private void FontFamilyChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in cbFontFamily.Items)
            {
                System.Windows.Media.FontFamily font = new System.Windows.Media.FontFamily(item.ToString());
                if (font.ToString()==cbFontFamily.SelectedItem.ToString())
                {
                    richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontFamilyProperty, font);
                    break;
                }
            }
        }

        private void SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            if (richTextBox != null)
            {
                if (colorPicker.SelectedColor.HasValue)
                {
                    BrushConverter brushConverter = new BrushConverter();
                    string color = colorPicker.SelectedColor.ToString();

                    richTextBox.Selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, brushConverter.ConvertFrom(color));
                }
            }
        }

        private void ClearAllFormating(object sender, RoutedEventArgs e)
        {
            richTextBox.Selection.ClearAllProperties();
        }


    }
}
