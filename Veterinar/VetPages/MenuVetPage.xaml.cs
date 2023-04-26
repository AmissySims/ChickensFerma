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
using Veterinar.Componentsvet;
using Veterinar.VetPages;



namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для MenuVetPage.xaml
    /// </summary>
    public partial class MenuVetPage : Page
    {
        public MenuVetPage()
        {
            InitializeComponent();
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void CloseChickOrderBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new CloseChickOrderPage()); 
        }

        private void CloseEggsOrderBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new CloseEggsOrderPage());
        }

        private void AddEggsBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new AddEggsPage());
        }

        private void UseInventBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new UseInventoryPage());
        }

        private void ChickHealBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new ChickensHealthPage());
        }
    }
}
