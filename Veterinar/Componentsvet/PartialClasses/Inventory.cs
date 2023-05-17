using System.Windows.Media;

namespace Veterinar.Componentsvet
{
    partial class Inventory
    {
        public SolidColorBrush ColorCount
        {
            get
            {

                if (Count == 0)
                    return Brushes.Crimson;
                else
                    return Brushes.Black;
            }

        }

    }
}

