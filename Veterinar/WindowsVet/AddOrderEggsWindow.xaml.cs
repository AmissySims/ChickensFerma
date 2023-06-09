﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Veterinar.Componentsvet;

namespace Veterinar.WindowsVet
{
    /// <summary>
    /// Логика взаимодействия для AddOrderEggsWindow.xaml
    /// </summary>
    public partial class AddOrderEggsWindow : Window
    {
        public IEnumerable<Eggs> Egg { get; set; }
        public Order Order { get; set; }


        public AddOrderEggsWindow(Order _order)
        {
            Order = _order;
            Egg = App.db.Eggs.Local;
            InitializeComponent();
            EggsList.ItemsSource = App.db.Eggs.ToList();
            StandartCb.ItemsSource = null;

            StandartCb.ItemsSource = App.db.TypeStandart.ToList();

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
        DialogResult = true;
        private void AddOrderEggBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StandartCb.SelectedItem != null)
                {

                    var SellEg = (StandartCb.SelectedItem as TypeStandart);
                    var SelEggs = App.db.Eggs.Where(z => z.TypeStandartId == SellEg.Id).FirstOrDefault();
                    if (SelEggs.Count >= Order.Count)
                    {
                        SelEggs.Count -= Convert.ToInt32(CountTb.Text);
                        OrderEggs NewOrder = new OrderEggs()
                        {

                            TypeStandartId = (StandartCb.SelectedItem as TypeStandart).Id,
                            Count = Convert.ToInt32(CountTb.Text),
                            OrderId = Order.Id

                        };
                        App.db.OrderEggs.Add(NewOrder);

                        Order.StatusId = 2;
                        App.db.SaveChanges();
                        MessageBox.Show("Выполнено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        DialogResult = true;
                    }
                    else
                        MessageBox.Show("Недостаточно яиц", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);




                }
                else
                    MessageBox.Show("Выберите стандарт", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
