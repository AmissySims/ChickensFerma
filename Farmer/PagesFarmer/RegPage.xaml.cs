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
using System.Xml.Linq;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void ClearBt_Click(object sender, RoutedEventArgs e)
        {
            NameTb.Text = "";
            LoginTb.Text = "";
            PasswordTb.Password = "";
        }

        private void RegBt_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                User NewUser = new User()
                {
                    FullName = NameTb.Text,
                    RoleId = 2,
                    Login = LoginTb.Text.Trim(),
                    Password = PasswordTb.Password.Trim()
                };
                App.db.User.Add(NewUser); 
                App.db.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
