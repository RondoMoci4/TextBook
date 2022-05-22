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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextBook.Data;
using TextBook.Pages;

namespace TextBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListThemePage.xaml
    /// </summary>
    public partial class ListThemePage : Page
    {
        public ListThemePage()
        {
            InitializeComponent();
            // ConnectionClass.connection = new DBTextBookEntities();
            ConnectionClass.connect = new TextBookEntities();
        }

        private void txbSearchTheme_LostFocus(object sender, RoutedEventArgs e) { LostFocusAnimation(txbVisibleSearch); }

        private void txbSearchTheme_GotFocus(object sender, RoutedEventArgs e) { GotFocusAnimation(txbVisibleSearch); }

        private void txbSearchTheme_TextChanged(object sender, TextChangedEventArgs e) { Search(); }

        private void Search()
        {
            //ConnectionClass.connection = new DBTextBookEntities();
            //var themeSearch = ConnectionClass.connection.Test.ToList();
            //themeSearch = themeSearch.Where(x => x.Title.ToLower().Contains(txbSearchTheme.Text.ToLower())).ToList();
            //lvTheme.ItemsSource = themeSearch.ToList();
        }

        private void lvTheme_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAddTheme_Click(object sender, RoutedEventArgs e) { FrameClass.mainFrame.Navigate(new AddContentPage()); }

        private void GotFocusAnimation(TextBlock textblock)
        {
            TranslateTransform transform = new TranslateTransform();
            textblock.RenderTransform = transform;
            DoubleAnimation animationY = new DoubleAnimation(0, -20, TimeSpan.FromSeconds(0.3));
            transform.BeginAnimation(TranslateTransform.YProperty, animationY);
            textblock.FontSize = 14;
        }

        private void LostFocusAnimation(TextBlock textblock)
        {
            TranslateTransform transform = new TranslateTransform();
            textblock.RenderTransform = transform;
            DoubleAnimation animationY = new DoubleAnimation(-20, 0, TimeSpan.FromSeconds(0.3));
            transform.BeginAnimation(TranslateTransform.YProperty, animationY);
            textblock.FontSize = 18;
        }
    }
}
