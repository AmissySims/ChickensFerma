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
using System.Windows.Shapes;
using Veterinar.Componentsvet;
using Veterinar.VetPages;

namespace Veterinar.WindowsVet
{
    /// <summary>
    /// Логика взаимодействия для AddOrderMeatWindow.xaml
    /// </summary>
    public partial class AddOrderMeatWindow : Window
    {

        public AddOrderMeatWindow()
        {
            InitializeComponent();
            //ListChicks.ItemSource App.db.Chicken.Where(x => x.HealthId == 3).ToList();
        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
