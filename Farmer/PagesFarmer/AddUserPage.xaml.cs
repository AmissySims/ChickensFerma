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
            Refresh();
        }
        public void Refresh()
        {
            AddNameTb.Text = "";
            AddLoginTb.Text = "";
            AddPasswordTb.Text = "";
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(AddNameTb.Text != "" && AddLoginTb.Text != "" && AddPasswordTb.Text != "")
                {
                    User NewUser = new User()
                    {
                        FullName = AddNameTb.Text,
                        RoleId = 3,
                        Login = AddLoginTb.Text.Trim(),
                        Password = AddPasswordTb.Text.Trim()
                    };
                    App.db.User.Add(NewUser);
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                UserList.ItemsSource = App.db.User.ToList();
              
               

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

       

       
        private void AddNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
