using System.Windows;
using System.Windows.Media;

namespace Veterinar.Componentsvet
{
    partial class Order
    {
        public SolidColorBrush ColorStatus
        {
            get
            {

                if (StatusId == 1)
                    return Brushes.Crimson;
                else
                    return Brushes.Green;
            }

        }
        public Visibility BtnVisible
        {
            get
            {
                if (StatusId == 1)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }
    }
}
