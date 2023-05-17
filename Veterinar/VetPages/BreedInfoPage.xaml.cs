using System.Linq;
using System.Windows.Controls;

namespace Veterinar.VetPages
{
    /// <summary>
    /// Логика взаимодействия для BreedInfoPage.xaml
    /// </summary>
    public partial class BreedInfoPage : Page
    {
        public BreedInfoPage()
        {
            InitializeComponent();
            ListBreed.ItemsSource = App.db.Breed.ToList();
        }
    }
}
