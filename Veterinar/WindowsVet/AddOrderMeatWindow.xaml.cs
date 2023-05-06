using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Veterinar.Componentsvet;
using Veterinar.VetPages;

namespace Veterinar.WindowsVet
{
    /// <summary>
    /// Логика взаимодействия для AddOrderMeatWindow.xaml
    /// </summary>
    public partial class AddOrderMeatWindow : Window
    {
        public IEnumerable<Chicken> Chickens { get; set; }
        public Order Order { get; set; }
        

        public AddOrderMeatWindow(Order _order)
        {
            Order = _order;

            Chickens = App.db.Chicken.Local.Where(x => x.HealthId == 3).ToList();

            InitializeComponent();

            //ListChicks.ItemsSource = Chickens.Where(x => x.HealthId == 3).ToList();
        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListChicks.ItemsSource != null)
            {

            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
          DialogResult = true;

        private void RemoveBt_Click(object sender, RoutedEventArgs e)
        {
            Order.StatusId = 2;
            App.db.SaveChanges();
            MessageBox.Show("Закрыто", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;

        }
    }
}
