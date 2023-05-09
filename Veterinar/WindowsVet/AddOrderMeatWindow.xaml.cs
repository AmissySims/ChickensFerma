using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Veterinar.Componentsvet;
using Veterinar.VetPages;

namespace Veterinar.WindowsVet
{
    /// <summary>
    /// Логика взаимодействия для AddOrderMeatWindow.xaml
    /// </summary>
    public partial class AddOrderMeatWindow : Window
    {
        public IEnumerable<Chicken> Chickens { get; set; }
        public List<Chicken> ChikList { get; set; }
        public Order Order { get; set; }     
        public AddOrderMeatWindow(Order _order)
        {
            Order = _order;

            Chickens = App.db.Chicken.Local;

            InitializeComponent();
            ChikList = App.db.Chicken.Where(x => x.Health.Id == 2).ToList();


            ListChicks.ItemsSource = ChikList;

        }

        private void ListChicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
          DialogResult = true;

        private void RemoveBt_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ListChicks.SelectedItem as Chicken;

            var count = 0;
            try
            {
                //if (count > Order.Count)
                //{
                    for (count = 0; count < ChikList.Count; count++)
                    {
                   
                        var newOrder = new OrderChicken
                        {
                            OrderId = Order.Id,
                            ChickenId = ChikList[count].id,
                            Date = DateTime.Now
                        };

                        App.db.OrderChicken.Add(newOrder);

                        //var delChik = new Chicken
                        //{
                        //    id = ChikList[count].id,
                        //};

                        //var needDelete = App.db.OrderChicken.Where(oc => oc.ChickenId == delChik.id).FirstOrDefault();
                        //if (needDelete != null) { App.db.OrderChicken.Remove(needDelete); }

                        //App.db.Chicken.Remove(App.db.Chicken.Where(c => c.id == delChik.id).FirstOrDefault());
                        Order.StatusId = 2;
                        App.db.SaveChanges();
                        MessageBox.Show("Выполнено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        DialogResult = true;
                    }

                    
                //}
                //else
                //    MessageBox.Show("Недостаточно куриц", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);



            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
