using Farmer.Components;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            AddDepCb.ItemsSource = App.db.Department.Where(x => x.IsPauzz == false).ToList();
            AddSizeCb.ItemsSource = App.db.Size.ToList();
            NumberTb.Text = "";
        }

        private void AddCageBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((AddSizeCb.SelectedIndex != -1) && (AddDepCb.SelectedIndex != -1))
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
                            DepartmentId = (AddDepCb.SelectedItem as Department).Id,
                            NumberCage = Convert.ToInt32(NumberTb.Text),
                            IsPaus = false
                        };
                        App.db.Cage.Add(NewCage);

                    }

                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);   
                }
                CageList.ItemsSource = App.db.Cage.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
