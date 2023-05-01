﻿using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UseInventoryPage.xaml
    /// </summary>
    public partial class UseInventoryPage : Page
    {
        ChickensEntities _context = new ChickensEntities();
        public UseInventoryPage()
        {
            
            InitializeComponent();
            Inventlist.ItemsSource = App.db.Inventory.ToList();
            List<Componentsvet.Type> listType = _context.Type.ToList();
            listType.Insert(0, new Componentsvet.Type { Title = "Все" });
            TypeCb.ItemsSource = listType;
            TypeCb.SelectedIndex = 0;
            Sort();
            
        }
       
        public void Sort()
        {
            List<Inventory> listInvent = _context.Inventory.ToList();

            if (TypeCb.SelectedIndex != 0)
            {
                Componentsvet.Type selType = (Componentsvet.Type)TypeCb.SelectedItem;
                listInvent = listInvent.Where(x => x.TypeId == selType.Id).ToList();
            }
            var searchString = FoundTb.Text;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listInvent = listInvent.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
                Inventlist.ItemsSource = listInvent;
            }
            
            Inventlist.ItemsSource = listInvent;
        }
        private void AvialibleTb_Checked(object sender, RoutedEventArgs e)
        {
            List<Inventory> listInvent = _context.Inventory.ToList();
            listInvent = listInvent.Where(x => x.Count == 0).ToList();  
            Inventlist.ItemsSource = listInvent;
        }

        private void TypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void FoundTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }

        private void AvialibleTb_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Inventory> listInvent = _context.Inventory.ToList();
            Inventlist.ItemsSource = listInvent;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var selinvent = (sender as Button).DataContext as Inventory;
            NavigationService.Navigate(new AddInventPage(selinvent));
        }

        private void UseBt_Click(object sender, RoutedEventArgs e)
        {
            if(Inventlist.SelectedItem != null)
            {
                var dataInvent = Inventlist.SelectedItem as Inventory;
                if(dataInvent.TypeId == 1)
                { 
                    if((dataInvent.Count -1) <= 1)
                    {
                        MessageBox.Show("Инвентарь закончился", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        dataInvent.Count--;
                        MessageBox.Show("Инвентарь использован", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        App.db.SaveChanges();
                        Inventlist.ItemsSource = App.db.Inventory.ToList();
                        
                        
                    }
                }
                else
                {
                    MessageBox.Show("Инвентарь использовaн", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.db.SaveChanges();
                    Inventlist.ItemsSource = App.db.Inventory.ToList();
                }
               
            }
            
        }
    }
}
