using Microsoft.Win32.SafeHandles;
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
using Veterinar.Componentsvet;
using Veterinar.VetPages;
using Veterinar.WindowsVet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для AddEggsPage.xaml
    /// </summary>
    public partial class AddEggsPage : Page
    {
        public AddEggsPage()
        {
            InitializeComponent();
            EggsList.ItemsSource = App.db.Eggs.ToList();
            Refresh();
            
        }
        public void Refresh()
        {
            EggsList.ItemsSource = App.db.Eggs.ToList();
            StandartCb.ItemsSource = null;

            StandartCb.ItemsSource = App.db.TypeStandart.ToList();
            CountTb.Text = "";
        }
        private void AddEggBt_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (StandartCb.SelectedItem != null && CountTb.Text != "")
                {
                  
                    var SellEg = (StandartCb.SelectedItem as TypeStandart);
                    var SelEggs = App.db.Eggs.Where(z => z.TypeStandartId == SellEg.Id).FirstOrDefault();
                    SelEggs.Count += Convert.ToInt32(CountTb.Text);

                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                    
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
