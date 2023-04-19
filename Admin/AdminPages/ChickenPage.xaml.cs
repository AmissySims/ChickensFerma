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
        public ChickenPage()
        {

            InitializeComponent();
            BreedCb.Items.Clear();
            BreedCb.ItemsSource = App.db.Breed.ToList();
            BreedCb.DisplayMemberPath = "Title";
            HealthCb.Items.Clear();
            HealthCb.ItemsSource = App.db.Health.ToList();
            HealthCb.DisplayMemberPath = "Title";
            CageCb.Items.Clear();
            CageCb.ItemsSource = App.db.Cage.ToList();
            CageCb.DisplayMemberPath = "Id";
        }

        private void AddWeightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddPhotoBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
                ImageChick.Source = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Добавление фото успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void AddSaveChickBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddNameTb.Text != "" && BreedCb.SelectedIndex != null && AddWeightTb.Text != "" && AddAgeTb.Text != "" && AddeggsTb.Text != "" && CageCb.SelectedIndex != null && HealthCb.SelectedIndex != null)
                {
                    Chicken chicken = new Chicken()
                    {
                        Name = AddNameTb.Text,
                        BreedId = (BreedCb.SelectedItem as Breed).Id,
                        Weight = AddWeightTb.Text,
                        Age = AddAgeTb.Text,
                        EggsInMonth = Convert.ToInt32(AddeggsTb.Text),
                        CageId = (CageCb.SelectedItem as Cage).Id,
                        HealthId = (HealthCb.SelectedItem as Health).Id,
                        PhotoChic = image


                    };
                    App.db.Chicken.Add(chicken);
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
