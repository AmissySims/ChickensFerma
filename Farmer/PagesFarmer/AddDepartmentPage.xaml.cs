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

namespace Farmer.PagesFarmer
{
    /// <summary>
    /// Логика взаимодействия для AddDepartmentPage.xaml
    /// </summary>
    public partial class AddDepartmentPage : Page
    {
        public AddDepartmentPage()
        {
            InitializeComponent();
            DepartmentList.ItemsSource = App.db.Department.ToList();
            Refresh();
        }
        public void Refresh()
        {
            AddTitleTb.Text = "";
            AddCountCageTb.Text = "";
            AddAdressTb.Text = "";
        }

        private void AddDepartmentBt_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if(AddTitleTb.Text != "" && AddCountCageTb.Text != "" && AddAdressTb.Text != "")
                {

                    Department NewDep = new Department()
                    {
                        Title = AddTitleTb.Text,
                        CountCage = Convert.ToInt32(AddCountCageTb.Text),
                        Adress = AddAdressTb.Text,
                        IsPauzz = false
                    };
                    App.db.Department.Add(NewDep);
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                DepartmentList.ItemsSource = App.db.Department.ToList();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddCountCageTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
