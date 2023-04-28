using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using Size = Farmer.Components.Size;

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для AddCagePage.xaml
    /// </summary>
    public partial class AddCagePage : Page
    {
        public AddCagePage()
        {
            InitializeComponent();
            CageList.ItemsSource = App.db.Cage.ToList();
            Refresh();
            
        }
        public void Refresh()
        {
            
            AddDepCb.ItemsSource = null;
            AddSizeCb.ItemsSource = null;
            AddDepCb.ItemsSource = App.db.Department.ToList();
            AddSizeCb.ItemsSource = App.db.Size.ToList();
        }

        private void AddCageBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((AddSizeCb.SelectedIndex != null) && (AddDepCb.SelectedIndex != null))
                {
                   
                    var SelCell = (AddDepCb.SelectedItem as Department);
                    var ListCage = App.db.Cage.ToList().Where(x => x.Department == SelCell).ToList();
                    if ((SelCell.CountCage) < ListCage.Count)
                    {
                        SelCell.IsPauzz = true;
                        MessageBox.Show("error");
                    }
                    else
                    {
                        Cage NewCage = new Cage()
                        {

                            SizeId = (AddSizeCb.SelectedItem as Size).Id,
                            DepartmentId = (AddDepCb.SelectedItem as Department).Id
                        };
                        App.db.Cage.Add(NewCage);

                    }
                   
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                CageList.ItemsSource = App.db.Cage.ToList();
                Refresh();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
