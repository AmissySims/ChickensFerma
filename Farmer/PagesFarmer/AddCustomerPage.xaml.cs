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
using Farmer.PagesFarmer;
using Farmer.PagesFarmer.OrdersPages;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerPage.xaml
    /// </summary>
    public partial class AddCustomerPage : Page
    {
        public AddCustomerPage()
        {
            InitializeComponent();
            CustomerList.ItemsSource = App.db.Customer.ToList();
            Refresh();
        }
        public void Refresh()
        {
            AddDescriptionTb.Text = "";
        }

        private void AddCustBt_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if(AddDescriptionTb.Text != "")
                {
                    Customer NewCust = new Customer()
                    {
                        Description = AddDescriptionTb.Text,

                    };
                    App.db.Customer.Add(NewCust);
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
               else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                CustomerList.ItemsSource = App.db.Customer.ToList();
             
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
