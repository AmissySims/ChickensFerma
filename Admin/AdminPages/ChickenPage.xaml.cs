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
using Admin.AdminPages;
using Admin.ComponentsAdmin;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace Admin.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ChickenPage.xaml
    /// </summary>
    public partial class ChickenPage : Page
    {
        public static byte[] image { get; set; }
        public static Chicken Chickens { get; set; }
        public List<Cage> Cages { get; set; }
        public List<Health> Healths { get; set; }
        public List<Breed> Breeds { get; set; }
        public ChickenPage()
        {
            
            InitializeComponent();
            Refresh();

        }
        public void Refresh()
        {
            CageCb.ItemsSource = null;
            BreedCb.ItemsSource = null;
            HealthCb.ItemsSource = null;


            Breeds = App.db.Breed.ToList();

            Healths = App.db.Health.ToList();

            Cages = App.db.Cage.Where(x => x.IsPaus == false).ToList();
            CageCb.ItemsSource = Cages;
            BreedCb.ItemsSource = Breeds;
            HealthCb.ItemsSource = Healths;
            AddNameTb.Text = "";
            AddWeightTb.Text = "";
            AddAgeTb.Text = "";
            AddeggsTb.Text = "";
            ImageChick.Source = null;
        }

        private void AddWeightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text.Trim(), 0) || (AddWeightTb.Text.Length >= 3) )
            {
                e.Handled = true;
            }
        }

        private void AddPhotoBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    image = File.ReadAllBytes(dialog.FileName);
                    ImageChick.Source = new BitmapImage(new Uri(dialog.FileName));
                    MessageBox.Show("Добавление фото успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите необходимое фото", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void AddSaveChickBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddNameTb.Text != "" && BreedCb.SelectedIndex != -1 && AddWeightTb.Text != "" && AddAgeTb.Text != "" && AddeggsTb.Text != "" && CageCb.SelectedIndex != -1 && HealthCb.SelectedIndex != -1)
                {
                   
                    if(Convert.ToDouble(AddWeightTb.Text) <= 7 && Convert.ToDouble(AddAgeTb.Text) <= 8 && Convert.ToInt32(AddeggsTb.Text) <= 400)
                    {
                        var SelCell = (CageCb.SelectedItem as Cage);
                        var ListChick = App.db.Chicken.ToList().Where(x => x.Cage == SelCell).ToList();

                        if (SelCell.Size.Count <= ListChick.Count)
                        {
                            SelCell.IsPaus = true;
                            MessageBox.Show("error");
                        }
                        else
                        {

                            Chicken chicken = new Chicken()
                            {
                                Name = AddNameTb.Text,
                                BreedId = (BreedCb.SelectedItem as Breed).Id,
                                Weight = AddWeightTb.Text.Trim(),
                                Age = AddAgeTb.Text.Trim(),
                                EggsInMonth = Convert.ToInt32(AddeggsTb.Text.Trim()),
                                CageId = (CageCb.SelectedItem as Cage).Id,
                                HealthId = (HealthCb.SelectedItem as Health).Id,
                                PhotoChic = image


                            };
                            App.db.Chicken.Add(chicken);
                        }
                        App.db.SaveChanges();
                        MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Refresh();
                    }
                    else
                        MessageBox.Show("Слишком высокие показатели", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddAgeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text.Trim(), 0)  || AddAgeTb.Text.Length >= 3 )
            {
                e.Handled = true;
            }
        }

        private void AddeggsTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text.Trim(), 0) || AddeggsTb.Text.Length >= 3  )
            {
                e.Handled = true;
            }
        }

        private void AddNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
