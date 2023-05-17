using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Veterinar.Componentsvet;
using Veterinar.WindowsVet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для CloseChickOrderPage.xaml
    /// </summary>
    public partial class CloseChickOrderPage : Page
    {

        public CloseChickOrderPage()
        {
            InitializeComponent();
            ListChickOrders.ItemsSource = App.db.Order.Where(x => x.TypeProdId == 2).ToList();
        }

        private void CloseOrderMeatBt_Click(object sender, RoutedEventArgs e)
        {
            AddOrderMeatWindow selectChicken = new AddOrderMeatWindow((sender as Button).DataContext as Order);
            selectChicken.ShowDialog();
            ListChickOrders.ItemsSource = App.db.Order.Where(x => x.TypeProdId == 2).ToList();
        }


    }
}
