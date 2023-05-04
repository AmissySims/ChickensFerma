using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Veterinar.Componentsvet;

namespace Veterinar.WindowsVet
{
    /// <summary>
    /// Логика взаимодействия для AddOrderMeatWindow.xaml
    /// </summary>
    public partial class AddOrderMeatWindow : Window
    {
        public IEnumerable<Chicken> Chickens { get; set; }
        public Order Order { get; set; }
        public IEnumerable<Chicken> SelectedChicken => ListChicks.SelectedItems.Cast<Chicken>();

        public AddOrderMeatWindow(Order _order)
        {
            Order = _order;

            Chickens = App.db.Chicken.Local.Where(x => x.HealthId == 3).Except(Order.Id);

            InitializeComponent();

            ListChicks.ItemsSource = App.db.Chicken.Where(x => x.HealthId == 3).ToList();
        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListChicks.ItemsSource != null)
            {

            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
          DialogResult = true;
    }
}
