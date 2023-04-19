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
using Admin.ComponentsAdmin;
using Admin.AdminPages;

namespace Admin.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public static List<User> UserList { get; set; }
        public InfoPage()
        {
            InitializeComponent();
            UserList = new List<User>(App.db.User.Where(z=> z.Id == PartialClasses.ClassCorrUser.CorrUser.Id).ToList());
            ListDataFoView.ItemsSource = UserList;
            
            
        }
    }
}
