using System;
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

            Chickens = App.db.Chicken.Local;

            InitializeComponent();

            ListChicks.ItemsSource = App.db.Chicken.Where(x => x.Health.Id == 2).ToList();

        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
          DialogResult = true;

        private void RemoveBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ListChicks.SelectedItem as Chicken;

            try
            {
                var newOrder = new OrderChicken
                {
                    OrderId = Order.Id,
                    ChickenId = selectedItem.id,
                    Date = DateTime.Now
                };

                App.db.OrderChicken.Add(newOrder);
                Order.StatusId = 2;
                App.db.SaveChanges();
                MessageBox.Show("Выполнено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
