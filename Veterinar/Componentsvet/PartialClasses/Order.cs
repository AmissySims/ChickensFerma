﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
