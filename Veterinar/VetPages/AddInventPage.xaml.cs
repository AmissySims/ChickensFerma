using Microsoft.Win32;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Veterinar.Componentsvet;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для AddInventPage.xaml
    /// </summary>
    public partial class AddInventPage : Page
    {
        public static byte[] image { get; set; }
        public static Inventory invent { get; set; }
        public AddInventPage(Inventory _inv)
        {
            App.db.Inventory.Load();
            invent = _inv ?? new Inventory();
            InitializeComponent();

            invent = _inv;
            DataContext = _inv;
        }

        private void PhotoBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    image = File.ReadAllBytes(dialog.FileName);
                    ImInvent.Source = new BitmapImage(new Uri(dialog.FileName));
                    MessageBox.Show("Добавление фото успешно", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии диалога выбора файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //invent.Photo = image;
                App.db.Inventory.Where(z => z.Id == invent.Id).FirstOrDefault().Photo = image;
                App.db.SaveChanges();
                MessageBox.Show("Изменено", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information); MessageBox.Show("Измене");
                NavigationService.Navigate(new UseInventoryPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
