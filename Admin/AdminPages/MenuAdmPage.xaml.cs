﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Admin.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmPage.xaml
    /// </summary>
    public partial class MenuAdmPage : Page
    {
        public MenuAdmPage()
        {
            InitializeComponent();
        }

        private void AddChickensBt_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmFrame.NavigationService.Navigate(new ChickenPage());
        }

        private void AddInventoryBt_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmFrame.NavigationService.Navigate(new InventoryPage());
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void AddDepartmentBt_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmFrame.NavigationService.Navigate(new InfoPage());
        }
    }
}
