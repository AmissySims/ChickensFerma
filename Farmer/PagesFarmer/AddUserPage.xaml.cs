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
using Farmer.Components;
using Farmer.PagesFarmer;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            UserList.ItemsSource = App.db.User.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User NewUser = new User()
                {
                    FullName = AddNameTb.Text,
                    RoleId = 2,
                    Login = AddLoginTb.Text.Trim(),
                    Password = AddPasswordTb.Text.Trim()
                };
                App.db.User.Add(NewUser);
                App.db.SaveChanges();
                MessageBox.Show("Добавлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                UserList.ItemsSource = App.db.User.ToList();
                AddNameTb.Text = "";
                AddLoginTb.Text = "";
                AddPasswordTb.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var seluser = (sender as Button).DataContext as User;
            if( MessageBox.Show("Хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                App.db.User.Remove(seluser);
            }
            App.db.SaveChanges();
            UserList.ItemsSource = App.db.User.ToList();
        }
    }
}
