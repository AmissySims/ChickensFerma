using Farmer.PagesFarmer.OrdersPages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
