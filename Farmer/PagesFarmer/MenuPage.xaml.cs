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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Farmer.PagesFarmer.OrdersPages;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
          
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void AddUserBt_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new AddUserPage());
        }

        private void AddCageBt_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new AddCagePage());
        }

        private void AddDepartmentBt_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new AddDepartmentPage());
        }

        private void AddOrderBt_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new AllOrdersPage());
        }

        private void AddCustomerBt_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new AddCustomerPage());
        }
    }
}
