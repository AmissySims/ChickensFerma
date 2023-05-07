using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
