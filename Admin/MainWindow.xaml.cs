using Admin.AdminPages;
using System.Windows;

namespace Admin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrameAdmin.NavigationService.Navigate(new AuthPage());
        }
    }
}
