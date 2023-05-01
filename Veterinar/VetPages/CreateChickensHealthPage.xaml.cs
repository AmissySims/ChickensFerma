using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для CreateChickensHealthPage.xaml
    /// </summary>
    public partial class CreateChickensHealthPage : Page
    {
        public static byte[] image { get; set; }
        public Chicken Chickens { get; set; }
        public List<Cage> Cages { get; set; }
        public List<Health> Healths { get; set; }
        public CreateChickensHealthPage(Chicken _chick)
        {
            Chickens = _chick ?? new Chicken();
            InitializeComponent();
            Chickens = _chick;
            DataContext = _chick;
           
            HealthCb.ItemsSource = App.db.Health.ToList();
            CageCb.ItemsSource = App.db.Cage.Where(x => x.IsPaus == null).ToList();
           
        }

        private void PhotoBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
                ImageChick.Source = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Добавление фото успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void SaveChickBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( AgeTb.Text != "" && AddeggsTb.Text != "" && WeightTb.Text != "" && CageCb.SelectedIndex != null && HealthCb.SelectedIndex != null)
                {

                    var SelCell = (CageCb.SelectedItem as Cage);
                    var ListChick = App.db.Chicken.ToList().Where(x => x.Cage == SelCell).ToList();
                    if ((SelCell.Size.Count) < ListChick.Count)
                    {
                        SelCell.IsPaus = true;
                        MessageBox.Show("error");
                    }
                    else
                    {
                        if(Chickens.id == 0)
                        {
                            Chickens.Weight = WeightTb.Text;
                            Chickens.Age = AgeTb.Text;
                            Chickens.EggsInMonth = Convert.ToInt32(AddeggsTb.Text);
                            Chickens.CageId = (CageCb.SelectedItem as Cage).Id;
                            Chickens.HealthId = (HealthCb.SelectedItem as Health).Id;
                            Chickens.PhotoChic = image;
                            App.db.Chicken.Add(Chickens);
                        }
                        //Chicken chicken = new Chicken()
                        //{

                        //    Weight = WeightTb.Text,
                        //    Age = AgeTb.Text,
                        //    EggsInMonth = Convert.ToInt32(AddeggsTb.Text),
                        //    CageId = (CageCb.SelectedItem as Cage).Id,
                        //    HealthId = (HealthCb.SelectedItem as Health).Id,
                        //    PhotoChic = image


                        //};
                        //App.db.Chicken.Add(chicken);
                    }
                    App.db.SaveChanges();
                    MessageBox.Show("Изменено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new ChickensHealthPage());
                   
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void WeightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddeggsTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AgeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
