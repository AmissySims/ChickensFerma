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
using Veterinar.WindowsVet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для CloseEggsOrderPage.xaml
    /// </summary>
    public partial class CloseEggsOrderPage : Page
    {
        public static Order order {  get; set; }
        public CloseEggsOrderPage()
        {
            InitializeComponent();
            ListEggsOrders.ItemsSource = App.db.Order.Where(x => x.TypeProdId == 1).ToList();
            //var Orders = App.db.Order.Where(x => x.TypeProdId == 1);
            //if (Orders.Status.Id = 2)
            //{
            //    CloseOrderEggBt.Visibility = Visibility.Collapsed;
            //}
        }

        private void CloseOrderEggBt_Click(object sender, RoutedEventArgs e)
        {
            
            AddOrderEggsWindow selectEggs = new AddOrderEggsWindow((sender as Button).DataContext as Order);
            selectEggs.ShowDialog();
        }
    }
}
