using Farmer.Components;
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
                //MessageBox.Show(DateTime.Now.ToString());
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
