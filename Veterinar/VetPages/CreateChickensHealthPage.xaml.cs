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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии диалога выбора файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (Convert.ToDouble(WeightTb.Text) <= 7 && Convert.ToDouble(AgeTb.Text) <= 8 && Convert.ToInt32(AddeggsTb.Text) <= 400)
                {
                    var SelCell = CageCb.SelectedItem == null ? throw new Exception("Клетка не выбрана") : (CageCb.SelectedItem as Cage);

                    var ListChick = App.db.Chicken.Where(x => x.Cage.Id == SelCell.Id).ToList();

                    SelCell.IsPaus = SelCell.Size.Count <= ListChick.Count + 1;

                    Cage pastChikenCell = App.db.Cage.FirstOrDefault(x => x.Id == Chickens.CageId);
                    pastChikenCell.IsPaus = pastChikenCell.IsPaus == true ? false : pastChikenCell.IsPaus;

                    var Ch = App.db.Chicken.First(z => z.id == Chickens.id);

                    if (Ch == null) { throw new InvalidOperationException($"Курица с id={Chickens.id} не найдена в базе данных"); }

                    Ch.PhotoChic = image ?? Ch.PhotoChic;
                    Ch.CageId = (CageCb.SelectedItem as Cage).Id;
                    Ch.HealthId = (HealthCb.SelectedItem as Health).Id;
                    Ch.Age = AgeTb.Text.Trim();
                    Ch.EggsInMonth = Convert.ToInt32(AddeggsTb.Text.Trim());
                    Ch.Weight = WeightTb.Text.Trim();


                    App.db.SaveChanges();

                    MessageBox.Show("Изменено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new ChickensHealthPage());
                }
                else
                {
                    MessageBox.Show("Слишком высокие показатели", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidatyData() =>
            AgeTb.Text != "" && AddeggsTb.Text != "" && WeightTb.Text != "" && CageCb.SelectedIndex != -1 && HealthCb.SelectedIndex != -1;

        private void WeightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (e.Text != ",") )
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
            if (!Char.IsDigit(e.Text, 0) && (e.Text != ",") )
            {
                e.Handled = true;
            }
        }

        private void CageCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
