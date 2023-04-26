using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Veterinar.Componentsvet;
using Veterinar.VetPages;

namespace Veterinar
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ChickensEntities db = new ChickensEntities();
    }
}
