using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using Veterinar.WindowsVet;

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
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    image = File.ReadAllBytes(dialog.FileName);
                    ImInvent.Source = new BitmapImage(new Uri(dialog.FileName));
                    MessageBox.Show("Добавление фото успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (image == null && ImInvent.Source != null) { MessageBox.Show("Фото не может быть пустым" + "\n", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);}

                App.db.Inventory.Where(z=>z.Id == invent.Id).First().Photo = image;
                App.db.SaveChanges();
                MessageBox.Show("Изменено");
                NavigationService.Navigate(new UseInventoryPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
