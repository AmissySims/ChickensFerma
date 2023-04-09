using System;
using System.Collections.Generic;
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
            AddDepCb.Items.Clear();
            AddDepCb.ItemsSource = App.db.Department.ToList();
            AddDepCb.DisplayMemberPath = "Title";
            AddSizeCb.Items.Clear();
            AddSizeCb.ItemsSource = App.db.Size.ToList();
            AddSizeCb.DisplayMemberPath = "Title";
        }

        private void AddCageBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cage NewCage = new Cage()
                {
                    
                    SizeId = (AddSizeCb.SelectedItem as Size).Id,
                    DepartmentId = (AddDepCb.SelectedItem as Department).Id,
                };
                App.db.Cage.Add(NewCage);
                App.db.SaveChanges();
                MessageBox.Show("Добавлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                CageList.ItemsSource = App.db.Cage.ToList();
                AddSizeCb.Items.Clear();
                AddSizeCb.Items.Clear();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
