using System;
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
        private StatusLife statusLifeDeath { get; set; }
        public Order Order { get; set; }
        public AddOrderMeatWindow(Order _order)
        {
            Order = _order;

            statusLifeDeath = App.db.StatusLife.Where(sl => sl.Id == 2).FirstOrDefault();

            Chickens = App.db.Chicken.Local;

            InitializeComponent();

            ListChicks.ItemsSource = App.db.Chicken.Where(x => x.Health.Id == 2 && x.StatusLife.Id != statusLifeDeath.Id).ToList(); ;

        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTb.Text = ListChicks.SelectedItems.Count.ToString();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
          DialogResult = true;

        private void RemoveBt_Click(object sender, RoutedEventArgs e)
        {
            string ending = GetEnding((int)Order.Count);
            var selectedChick = ListChicks.SelectedItems;

            switch (selectedChick.Count)
            {
                case 0:
                    MessageBox.Show("Нужно выбрать хотя бы одну", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                case var count when count < Order.Count:
                    MessageBox.Show($"Для заказа необходимо {Order.Count} куриц{ending}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                case var count when count > Order.Count:
                    MessageBox.Show("Выберите то количество которое указано в заказе", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                default:
                    break;
            }

            try
            {
                for (var count = 0; count < selectedChick.Count; count++)
                {
                    var newOrder = new OrderChicken
                    {
                        OrderId = Order.Id,
                        ChickenId = ((Chicken)selectedChick[count]).id,
                        Date = DateTime.Now,
                    };

                    App.db.OrderChicken.Add(newOrder);

                    var choiceChik = App.db.Chicken.Where(oc => oc.id == newOrder.ChickenId).FirstOrDefault();

                    if (choiceChik != null) { choiceChik.StatusLife = statusLifeDeath; }

                }

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

        private string GetEnding(int count)
        {
            switch (Order.Count % 10)
            {
                case 1:
                    return "а";
                case 2:
                case 3:
                case 4:
                    return "ы";
                default:
                    return "";
            }
        }

    }
}
