using Farmer.Components;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                if (AddDescriptionTb.Text != "")
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
                {
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                CustomerList.ItemsSource = App.db.Customer.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
