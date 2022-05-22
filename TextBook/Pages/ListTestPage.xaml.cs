﻿using System;
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
    /// Логика взаимодействия для ListTestPage.xaml
    /// </summary>
    public partial class ListTestPage : Page
    {
        public ListTestPage()
        {
            InitializeComponent();
           // ConnectionClass.connection = new DBTextBookEntities();
            ConnectionClass.connect = new TextBookEntities();
            lvTest.ItemsSource = ConnectionClass.connect.Test.ToList();
        }

        private void txbSearchTest_LostFocus(object sender, RoutedEventArgs e) { LostFocusAnimation(txbVisibleSearch); }

        private void txbSearchTest_GotFocus(object sender, RoutedEventArgs e) { GotFocusAnimation(txbVisibleSearch); }

        private void txbSearchTest_TextChanged(object sender, TextChangedEventArgs e) { Search(); }

        private void Search()
        {
            ConnectionClass.connect = new TextBookEntities();
            var testSearch = ConnectionClass.connect.Test.ToList();
            testSearch = testSearch.Where(x => x.Title.ToLower().Contains(txbSearchTest.Text.ToLower())).ToList();
            lvTest.ItemsSource = testSearch.ToList();
        }

        private void lvTest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.TitleTest = labelTitle.Text;
            MessageBox.Show(labelTitle.Text);
            FrameClass.mainFrame.Navigate(new RegistrationPage());
        }

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

        private void btnUpdateTest_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.TitleTest = labelTitle.Text;
            var testId = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == labelTitle.Text);
            Properties.Settings.Default.IdExistingTest = testId.IdTest;
            FrameClass.mainFrame.Navigate(new CreateTestPage());
        }

        private void btnAddTest_Click(object sender, RoutedEventArgs e) { FrameClass.mainFrame.Navigate(new CreateTestPage()); }
    }
}
