using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Veterinar.Componentsvet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для CreateChickensHealthPage.xaml
    /// </summary>
    public partial class CreateChickensHealthPage : Page
    {
        public byte[] image { get; set; }
        public Chicken Chickens { get; set; }
        public List<Cage> Cages { get; set; }
        public List<Health> Healths { get; set; }
        public byte Chang { get; set; } = 0;
        public int? IdCageChicken { get; set; }

        public CreateChickensHealthPage(Chicken _chick)
        {
            Chickens = _chick ?? new Chicken();
            Healths = App.db.Health.ToList();
            Cages = App.db.Cage.Where(x => x.IsPaus == false || x.Id == Chickens.CageId).ToList();
            IdCageChicken = Chickens.Cage.IsPaus == null ? 0 : Cages.Select(x => x.Id).ToList().IndexOf(Chickens.Cage.Id);

            InitializeComponent();
        }

        private void PhotoBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
                ImageChick.Source = new BitmapImage(new Uri(dialog.FileName));
                App.db.SaveChanges();
                MessageBox.Show("Добавление фото успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void SaveChickBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidatyData() == false)
                {
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var SelCell = CageCb.SelectedItem == null ? throw new Exception("Клетка не выбрана") : (CageCb.SelectedItem as Cage);

                var ListChick = App.db.Chicken.Where(x => x.Cage.Id == SelCell.Id).ToList();


                SelCell.IsPaus = SelCell.Size.Count <= ListChick.Count + 1;

                Cage pastChikenCell = App.db.Cage.FirstOrDefault(x => x.Id == Chickens.CageId);
                pastChikenCell.IsPaus = pastChikenCell.IsPaus == true ? false : pastChikenCell.IsPaus;

                var Ch = App.db.Chicken.First(z => z.id == Chickens.id);

                Ch.PhotoChic = image ?? Ch.PhotoChic;
                Ch.CageId = (CageCb.SelectedItem as Cage).Id;
                Ch.HealthId = (HealthCb.SelectedItem as Health).Id;

                App.db.SaveChanges();

                MessageBox.Show("Изменено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ChickensHealthPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidatyData() =>
            AgeTb.Text != "" && AddeggsTb.Text != "" && WeightTb.Text != "" && CageCb.SelectedIndex != null && HealthCb.SelectedIndex != null;

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

        private void CageCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
