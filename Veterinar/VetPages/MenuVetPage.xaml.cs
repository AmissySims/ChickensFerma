using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;



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

        private void ChickBreedBt_Click(object sender, RoutedEventArgs e)
        {
            MenuVetFrame.NavigationService.Navigate(new BreedInfoPage());
        }
    }
}
