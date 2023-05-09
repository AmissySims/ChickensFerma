using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Veterinar.Componentsvet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для ChickensHealth.xaml
    /// </summary>
    public partial class ChickensHealthPage : Page
    {
        ChickensEntities _context = new ChickensEntities();
        public ChickensHealthPage()
        {
            InitializeComponent();

            Chicklist.ItemsSource = App.db.Chicken.ToList();

            List<Health> listHealth = _context.Health.ToList();

            listHealth.Insert(3, new Health { Title = "Все" });

            HealthCb.ItemsSource = listHealth;
            HealthCb.SelectedIndex = 3;

            Sort();
        }
        public void Sort()
        {
            List<Chicken> listChick = _context.Chicken.ToList();

            if (HealthCb.SelectedIndex != 3)
            {
                Health selHealth = (Health)HealthCb.SelectedItem;
                listChick = listChick.Where(x => x.HealthId == selHealth.Id).ToList();
            }
            var searchString = FoundTb.Text;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listChick = listChick.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                Chicklist.ItemsSource = listChick;
            }

            Chicklist.ItemsSource = listChick;
        }

        private void FoundTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }

        private void HealthCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }


        private void EditHealthBt_Click(object sender, RoutedEventArgs e)
        {
            var selchick = (sender as Button).DataContext as Chicken;
            NavigationService.Navigate(new CreateChickensHealthPage(selchick));

        }

      
    }
}
