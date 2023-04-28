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
using System.Windows.Media.Effects;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((LoginTb.Text != "") && (PasswordTb.Password != ""))
                {

                    var datalogin = App.db.User.Where(x => x.Login == LoginTb.Text && x.Password == PasswordTb.Password).FirstOrDefault();
                    if (datalogin != null)
                    {
                        if (datalogin.RoleId == 1)
                        {
                            NavigationService.Navigate(new MenuPage());
                        }
                        else
                            MessageBox.Show("Недостаточно прав для входа", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                        MessageBox.Show("Неверные данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        

    
    }
}
