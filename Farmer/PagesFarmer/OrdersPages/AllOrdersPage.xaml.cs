using Farmer.Components;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Farmer.PagesFarmer.OrdersPages
{
    /// <summary>
    /// Логика взаимодействия для AllOrdersPage.xaml
    /// </summary>
    public partial class AllOrdersPage : Page
    {
        public AllOrdersPage()
        {
            InitializeComponent();
            Refresf();

        }
        public void Refresf()
        {
            ChoiceComponentCb.ItemsSource = null;
            ChoiceCustCb.ItemsSource = null;
            ChoiceComponentCb.ItemsSource = App.db.TypeProd.ToList();
            ChoiceCustCb.ItemsSource = App.db.Customer.ToList();
            CountaddTb.Text = "";
            PriceTb.Text = "";
        }


        private void AddOrderBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ChoiceCustCb.SelectedIndex != -1 && ChoiceComponentCb.SelectedIndex != -1 && CountaddTb.Text != "" && PriceTb.Text != "")
                {
                    Order NewOrder = new Order()
                    {
                        Date = DateTime.Now,
                        TypeProdId = (ChoiceComponentCb.SelectedItem as TypeProd).Id,
                        CustomerId = (ChoiceCustCb.SelectedItem as Customer).Id,
                        Count = Convert.ToInt32(CountaddTb.Text),
                        Price = Convert.ToInt32(PriceTb.Text),
                        StatusId = 1

                    };
                    App.db.Order.Add(NewOrder);
                    App.db.SaveChanges();
                    MessageBox.Show(DateTime.Now.ToString(), "Дата заказа", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show("Создано", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresf();

                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PriceTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void CountaddTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
