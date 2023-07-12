using HarpSimulasyonuWPF.Classes;
using System;
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
using System.Windows.Shapes;

namespace HarpSimulasyonuWPF.UCController
{
    /// <summary>
    /// Interaction logic for UCEnemyAddVehicle.xaml
    /// </summary>
    public partial class UCEnemyAddVehicle : Window
    {
        public bool EnemyAirVehicle     =false;
        public bool EnemyLandVehicle    =false;
        public bool EnemyNavalVehicle   =false;
               bool DirectionTop        = false;
               bool DirectionRight      = false;
               bool DirectionBottom     = false;
               bool DirectionLeft       = false;
               bool DirectionTopRight   = false;
               bool DirectionTopLeft    = false;
               bool DirectionBottomRight = false;
               bool DirectionBottomLeft  = false;
        public double GetLatValue;
        public double GetLongValue;

        MainWindow mainWindow = new MainWindow();
        Database dbProvider = new Database();
        public UCEnemyAddVehicle()
        {
            InitializeComponent();
            
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Hide();
            mainWindow.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnemyInstantLatitudeTextbox.Text    = GetLatValue.ToString();
            EnemyInstantLongitudeTextbox.Text   = GetLongValue.ToString();
            if (EnemyAirVehicle == true)
            {
                EnemyTopGrid1.Source    = new BitmapImage(new Uri("\\Images\\enemy_plane.png", UriKind.Relative));
                EnemyBottomGrid1.Source = new BitmapImage(new Uri("\\Images\\uav-left.png", UriKind.Relative));
                EnemyBottomGrid2.Source = new BitmapImage(new Uri("\\Images\\uav-top.png", UriKind.Relative));
                EnemyBottomGrid3.Source = new BitmapImage(new Uri("\\Images\\uav-right.png", UriKind.Relative));
                EnemyBottomGrid4.Source = new BitmapImage(new Uri("\\Images\\uav-bottom.png", UriKind.Relative));
                EnemyBottomGrid5.Source = new BitmapImage(new Uri("\\Images\\uav-top-left.png", UriKind.Relative));
                EnemyBottomGrid6.Source = new BitmapImage(new Uri("\\Images\\uav-top-right.png", UriKind.Relative));
                EnemyBottomGrid7.Source = new BitmapImage(new Uri("\\Images\\uav-bottom-left.png", UriKind.Relative));
                EnemyBottomGrid8.Source = new BitmapImage(new Uri("\\Images\\uav-bottom-right.png", UriKind.Relative));
                mainWindow.EnemyAirCount++;
                EnemyVehicleNameTextbox.Text = "ENEMY_SNL_AIR_"+ mainWindow.EnemyAirCount.ToString();
            }
            else if (EnemyLandVehicle == true)
            {
                EnemyTopGrid1.Source    = new BitmapImage(new Uri("\\Images\\enemy_tank.png", UriKind.Relative));
                EnemyBottomGrid1.Source = new BitmapImage(new Uri("\\Images\\tank-left.png", UriKind.Relative));
                EnemyBottomGrid2.Source = new BitmapImage(new Uri("\\Images\\tank-top.png", UriKind.Relative));
                EnemyBottomGrid3.Source = new BitmapImage(new Uri("\\Images\\tank-right.png", UriKind.Relative));
                EnemyBottomGrid4.Source = new BitmapImage(new Uri("\\Images\\tank-bottom.png", UriKind.Relative));
                EnemyBottomGrid5.Source = new BitmapImage(new Uri("\\Images\\tank-top-left.png", UriKind.Relative));
                EnemyBottomGrid6.Source = new BitmapImage(new Uri("\\Images\\tank-top-right.png", UriKind.Relative));
                EnemyBottomGrid7.Source = new BitmapImage(new Uri("\\Images\\tank-bottom-left.png", UriKind.Relative));
                EnemyBottomGrid8.Source = new BitmapImage(new Uri("\\Images\\tank-bottom-right.png", UriKind.Relative));
                mainWindow.EnemyLandCount++;
                EnemyVehicleNameTextbox.Text = "ENEMY_SNL_LAND_" + mainWindow.EnemyLandCount.ToString();
            }
            else if (EnemyNavalVehicle == true)
            {
                EnemyTopGrid1.Source    = new BitmapImage(new Uri("\\Images\\enemy_ship.png", UriKind.Relative));
                EnemyBottomGrid1.Source = new BitmapImage(new Uri("\\Images\\ship-left.png", UriKind.Relative));
                EnemyBottomGrid2.Source = new BitmapImage(new Uri("\\Images\\ship-top.png", UriKind.Relative));
                EnemyBottomGrid3.Source = new BitmapImage(new Uri("\\Images\\ship-right.png", UriKind.Relative));
                EnemyBottomGrid4.Source = new BitmapImage(new Uri("\\Images\\ship-bottom.png", UriKind.Relative));
                EnemyBottomGrid5.Source = new BitmapImage(new Uri("\\Images\\ship-top-left.png", UriKind.Relative));
                EnemyBottomGrid6.Source = new BitmapImage(new Uri("\\Images\\ship-top-right.png", UriKind.Relative));
                EnemyBottomGrid7.Source = new BitmapImage(new Uri("\\Images\\ship-bottom-left.png", UriKind.Relative));
                EnemyBottomGrid8.Source = new BitmapImage(new Uri("\\Images\\ship-bottom-right.png", UriKind.Relative));
                mainWindow.EnemyNavalCount++;
                EnemyVehicleNameTextbox.Text = "ENEMY_SNL_NAVAL_" + mainWindow.EnemyNavalCount.ToString();
            }

        }
        private void EnemyBottomGrid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility= Visibility.Visible;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = true;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;

        }
        private void EnemyBottomGrid2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Visible;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = true;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void EnemyBottomGrid3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Visible;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = true;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void EnemyBottomGrid4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Visible;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = true;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void EnemyAddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            VehicleAdd va   = new VehicleAdd();
            va.Vehicle_Name = EnemyVehicleNameTextbox.Text.ToString();
            if (EnemyAirVehicle == true)
            {
                va.Vehicle_Type = "Hava";
                va.Uri_Link = "\\Images\\enemy_plane.png"; 
            }
            else if (EnemyLandVehicle == true)
            {
                va.Vehicle_Type = "Kara";
                va.Uri_Link = "\\Images\\enemy_tank.png";
            }
            else
            {
                va.Vehicle_Type = "Deniz";
                va.Uri_Link = "\\Images\\enemy_ship.png";
            }
            va.Vehicle_Speed            = Convert.ToInt16(EnemyVehicleSpeedTextbox.Text);
            va.Target_Latitude          = Convert.ToDouble(EnemyLatitudeTextbox.Text);
            va.Target_Longitude         = Convert.ToDouble(EnemyLongtitudeTextbox.Text);
            va.Instant_Latitude         = Convert.ToDouble(EnemyInstantLatitudeTextbox.Text);
            va.Instant_Longitude        = Convert.ToDouble(EnemyInstantLongitudeTextbox.Text);
            if (DirectionTop == true)
            {
                va.Vehicle_Direction = "Top";
            }
            else if (DirectionRight == true)
            {
                va.Vehicle_Direction = "Right";

            }
            else if (DirectionLeft == true)
            {
                va.Vehicle_Direction = "Left";

            }
            else if (DirectionBottom == true)
            {
                va.Vehicle_Direction = "Bottom";

            }
            else if (DirectionTopLeft == true)
            {
                va.Vehicle_Direction = "Top-Left";

            }
            else if (DirectionTopRight == true)
            {
                va.Vehicle_Direction = "Top-Right";

            }
            else if (DirectionBottomRight == true)
            {
                va.Vehicle_Direction = "Bottom-Rig";

            }
            else if (DirectionBottomLeft == true)
            {
                va.Vehicle_Direction = "Bottom-Lef";

            }
            va.Ammo_List            = "Unknown";
            va.Friend_Or_Enemy      = "Enemy";
            va.Active_Or_Passive    = "Active";


            dbProvider.Add(va);
        }
        private void EnemyTakeTargetCoordinatesButton_Click(object sender, RoutedEventArgs e)
        {
            EnemyLatitudeTextbox.Text   = EnemyInstantLatitudeTextbox.Text;
            EnemyLongtitudeTextbox.Text = EnemyInstantLongitudeTextbox.Text;
        }

        private void EnemyBottomGrid5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Visible;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;

            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = true;
            DirectionTopRight       = false;
        }

        private void EnemyBottomGrid6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Visible;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;

            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = true;
        }

        private void EnemyBottomGrid7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Visible;
            EnemyBottomGrid8Border8.Visibility = Visibility.Hidden;

            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = true;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }

        private void EnemyBottomGrid8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnemyBottomGrid1Border1.Visibility = Visibility.Hidden;
            EnemyBottomGrid2Border2.Visibility = Visibility.Hidden;
            EnemyBottomGrid3Border3.Visibility = Visibility.Hidden;
            EnemyBottomGrid4Border4.Visibility = Visibility.Hidden;
            EnemyBottomGrid5Border5.Visibility = Visibility.Hidden;
            EnemyBottomGrid6Border6.Visibility = Visibility.Hidden;
            EnemyBottomGrid7Border7.Visibility = Visibility.Hidden;
            EnemyBottomGrid8Border8.Visibility = Visibility.Visible;

            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = true;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;

        }
    }
}
