using Admin.ComponentsAdmin;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Type = Admin.ComponentsAdmin.Type;

namespace Admin.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public static byte[] image { get; set; }
        public InventoryPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            AddTypeCb.ItemsSource = null;
            NameCb.ItemsSource = null;
            AddTypeCb.ItemsSource = App.db.Type.ToList();
            NameCb.ItemsSource = App.db.Inventory.ToList();
            AddTitleTb.Text = "";
            AddCountTb.Text = "";
            AddPriceTb.Text = "";
            CountTb.Text = "";
            ImageInvent.Source = null;
        }

        private void EventOldInvent_Checked(object sender, RoutedEventArgs e)
        {
            OldStack.Visibility = Visibility.Visible;
            NewStack.Visibility = Visibility.Hidden;
            PhotoIm.Visibility = Visibility.Hidden;
        }

        private void EventNewInvent_Unchecked(object sender, RoutedEventArgs e)
        {
            OldStack.Visibility = Visibility.Hidden;
            NewStack.Visibility = Visibility.Visible;
            PhotoIm.Visibility = Visibility.Visible;
        }

        private void AddPhotoBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    image = File.ReadAllBytes(dialog.FileName);
                    ImageInvent.Source = new BitmapImage(new Uri(dialog.FileName));
                    MessageBox.Show("Добавление фото успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии диалога выбора файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AddNewSaveInventBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddTitleTb.Text != "" && AddTypeCb.SelectedIndex != -1 && AddCountTb.Text != "" && AddPriceTb.Text != "")
                {
                    Inventory inventory = new Inventory()
                    {
                        Title = AddTitleTb.Text.Trim(),
                        TypeId = (AddTypeCb.SelectedItem as Type).Id,
                        Count = Convert.ToInt32(AddCountTb.Text.Trim()),
                        Photo = image,
                        Price = Convert.ToInt32(AddPriceTb.Text.Trim())
                    };
                    App.db.Inventory.Add(inventory);
                    App.db.SaveChanges();
                    MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddSaveInventBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameCb.SelectedIndex != -1 && CountTb.Text != "")
                {
                    var SelInvent = (NameCb.SelectedItem as Inventory);
                    SelInvent.Count += Convert.ToInt32(CountTb.Text.Trim());
                    App.db.SaveChanges();
                    MessageBox.Show("Докуплено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("Заполните поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text.Trim(), 0))
            {
                e.Handled = true;
            }
        }

        private void AddCountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text.Trim(), 0))
            {
                e.Handled = true;
            }
        }

        private void AddPriceTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text.Trim(), 0))
            {
                e.Handled = true;
            }
        }
    }
}
