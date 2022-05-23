using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddContentPage.xaml
    /// </summary>
    public partial class AddContentPage : Page
    {
        public AddContentPage()
        {
            InitializeComponent();
        }

        private void btnLoadTheme_Click(object sender, RoutedEventArgs e)
        {
            rtbTheme.Document.Blocks.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(rtbTheme.Document.ContentStart, rtbTheme.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".docx")
                        doc.Load(fs, DataFormats.Xaml);
                }
            }

        }

        private void btnSaveTheme_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txbTitleTheme_LostFocus(object sender, RoutedEventArgs e) { LostFocusAnimation(txbVisibleTheme,txbTitleTheme); }


        private void txbTitleTheme_GotFocus(object sender, RoutedEventArgs e) { GotFocusAnimation(txbVisibleTheme); }


        private void GotFocusAnimation(TextBlock textblock)
        {
            TranslateTransform transform = new TranslateTransform();
            textblock.RenderTransform = transform;
            DoubleAnimation animationY = new DoubleAnimation(0, -20, TimeSpan.FromSeconds(0.3));
            transform.BeginAnimation(TranslateTransform.YProperty, animationY);
            textblock.FontSize = 14;
        }

        private void LostFocusAnimation(TextBlock textVisible, TextBox textBox)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                TranslateTransform transform = new TranslateTransform();
                textVisible.RenderTransform = transform;
                DoubleAnimation animationY = new DoubleAnimation(-20, 0, TimeSpan.FromSeconds(0.3));
                transform.BeginAnimation(TranslateTransform.YProperty, animationY);
                textVisible.FontSize = 18;
                textBox.Text = null;
            }
        }
    }
}
