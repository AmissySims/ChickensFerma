using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Veterinar.VetPages
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
                        if (datalogin.RoleId == 3)
                        {

                            NavigationService.Navigate(new MenuVetPage());

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
