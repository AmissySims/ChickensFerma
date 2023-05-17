using Admin.ComponentsAdmin;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

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
            UserList = new List<User>(App.db.User.Where(z => z.Id == PartialClasses.ClassCorrUser.CorrUser.Id).ToList());
            ListDataFoView.ItemsSource = UserList;
        }
    }
}
