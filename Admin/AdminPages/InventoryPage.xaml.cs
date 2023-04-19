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
            AddTypeCb.Items.Clear();
            AddTypeCb.ItemsSource = App.db.Type.ToList();
            AddTypeCb.DisplayMemberPath = "Title";
            NameCb.Items.Clear();
            NameCb.ItemsSource = App.db.Inventory.ToList();
            NameCb.DisplayMemberPath = "Title";
        }

        private void EventOldInvent_Checked(object sender, RoutedEventArgs e)
        {
            OldStack.Visibility = Visibility.Visible;
            NewStack.Visibility = Visibility.Hidden;
        }

        private void EventNewInvent_Unchecked(object sender, RoutedEventArgs e)
        {
            OldStack.Visibility = Visibility.Hidden;
            NewStack.Visibility = Visibility.Visible;
        }

        private void AddPhotoBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != null)
            {
                image = File.ReadAllBytes(dialog.FileName);
                ImageInvent.Source = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Добавление фото успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void AddNewSaveInventBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(AddTitleTb.Text != "" && AddTypeCb.SelectedIndex != null && AddCountTb.Text != "" && AddPriceTb.Text != "")
                {
                    Inventory inventory = new Inventory()
                    {
                        Title = AddTitleTb.Text,
                        TypeId = (AddTypeCb.SelectedItem as Type).Id,
                        Count = Convert.ToInt32(AddCountTb.Text),
                        Photo = image,
                        Price = Convert.ToInt32(AddPriceTb.Text)
                        


                    };
                    App.db.Inventory.Add(inventory);
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

        private void AddSaveInventBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameCb.SelectedIndex != null && CountTb.Text != "")
                {
                    var SelInvent = (NameCb.SelectedItem as Inventory);
                    SelInvent.Count += Convert.ToInt32(CountTb.Text);
                    App.db.SaveChanges();
                    MessageBox.Show("Докуплено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddCountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddPriceTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
