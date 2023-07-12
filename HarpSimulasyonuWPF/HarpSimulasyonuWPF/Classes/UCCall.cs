using HarpSimulasyonuWPF.UCController;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HarpSimulasyonuWPF.Classes
{
    public class UCCall
    {
        public static void UC_Add(Grid grd, UserControl uc)
        {
            if (grd is null)
            {
                throw new ArgumentNullException(nameof(grd));
            }
            grd.Children.Add(uc);

        }



    }
}
