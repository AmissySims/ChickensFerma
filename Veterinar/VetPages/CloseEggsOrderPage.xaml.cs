using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Veterinar.Componentsvet;
using Veterinar.WindowsVet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для CloseEggsOrderPage.xaml
    /// </summary>
    public partial class CloseEggsOrderPage : Page
    {
        public static Order order { get; set; }
        public CloseEggsOrderPage()
        {
            InitializeComponent();
            ListEggsOrders.ItemsSource = App.db.Order.Where(x => x.TypeProdId == 1).ToList();


        }

        private void CloseOrderEggBt_Click(object sender, RoutedEventArgs e)
        {

            AddOrderEggsWindow selectEggs = new AddOrderEggsWindow((sender as Button).DataContext as Order);
            selectEggs.ShowDialog();
            ListEggsOrders.ItemsSource = App.db.Order.Where(x => x.TypeProdId == 1).ToList();
        }
    }
}
