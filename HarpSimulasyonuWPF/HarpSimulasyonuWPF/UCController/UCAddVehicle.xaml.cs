using HarpSimulasyonuWPF.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace HarpSimulasyonuWPF.UCController
{
    /// <summary>
    /// Interaction logic for UCAddVehicle.xaml
    /// </summary>
    public partial class UCAddVehicle : Window
    {
        public bool     FrAirVehicle            = false;
        public bool     FrLandVehicle           = false;
        public bool     FrNavalVehicle          = false;
               int      TempIndex               = 0;
               bool     DirectionTop            = false;
               bool     DirectionRight          = false;
               bool     DirectionBottom         = false;
               bool     DirectionLeft           = false;
               bool     DirectionTopRight       = false;
               bool     DirectionTopLeft        = false;
               bool     DirectionBottomRight    = false;
               bool     DirectionBottomLeft     = false;
               bool     Akinci                  = false;
               bool     Aksungur                = false;   
               bool     Anka                    = false;
               bool     Aslan                   = false;
               bool     Barkan                  = false;
               bool     Bogac                   = false;
               bool     Fedai                   = false;
               bool     GolgeSuvari             = false;
               bool     Hancer                  = false;
               bool     Karayel                 = false;
               bool     Mius                    = false;
               bool     tb2                     = false;
               bool     ukap                    = false;
               bool     ulaq                    = false;
               string   AmmoList;
        public string   SetUri;
        public double   GetLatValue;
        public double   GetLongValue;

        List<Vehicles> Vehicle_List = new List<Vehicles>();
        MainWindow mainWindow = new MainWindow();
        Database   dbProvider               = new Database();
        public UCAddVehicle()
        {
            InitializeComponent();
        }
        private void BtnClose(object sender, RoutedEventArgs e)
        {
            mainWindow.Hide();
            mainWindow.Show();
            this.Close();
        }
        private void AllFalse()
        {
            Akinci      = false;
            Aksungur    = false;
            Anka        = false;
            Aslan       = false;
            Barkan      = false;
            Bogac       = false;
            Fedai       = false;
            GolgeSuvari = false;
            Hancer      = false;
            Karayel     = false;
            Mius        = false;
            tb2         = false;
            ukap        = false;
            ulaq        = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InstantLatitudeTextbox.Text    = GetLatValue.ToString();
            InstantLongitudeTextbox.Text  = GetLongValue.ToString();
            if (FrAirVehicle == true)
            {
                TopGrid1.Source    = new BitmapImage(new Uri("\\Images\\tb2.jpg", UriKind.Relative));
                TopGrid2.Source    = new BitmapImage(new Uri("\\Images\\akinci.jpg", UriKind.Relative));
                TopGrid3.Source    = new BitmapImage(new Uri("\\Images\\mius.jpg", UriKind.Relative));
                TopGrid4.Source    = new BitmapImage(new Uri("\\Images\\anka.jpg", UriKind.Relative));
                TopGrid5.Source    = new BitmapImage(new Uri("\\Images\\aksungur.jpg", UriKind.Relative));
                TopGrid6.Source    = new BitmapImage(new Uri("\\Images\\karayel.jpg", UriKind.Relative));
                BottomGrid1.Source = new BitmapImage(new Uri("\\Images\\uav-left.png", UriKind.Relative));
                BottomGrid2.Source = new BitmapImage(new Uri("\\Images\\uav-top.png", UriKind.Relative));
                BottomGrid3.Source = new BitmapImage(new Uri("\\Images\\uav-right.png", UriKind.Relative));
                BottomGrid4.Source = new BitmapImage(new Uri("\\Images\\uav-bottom.png", UriKind.Relative));
                BottomGrid5.Source = new BitmapImage(new Uri("\\Images\\uav-top-left.png", UriKind.Relative));
                BottomGrid6.Source = new BitmapImage(new Uri("\\Images\\uav-top-right.png", UriKind.Relative));
                BottomGrid7.Source = new BitmapImage(new Uri("\\Images\\uav-bottom-left.png", UriKind.Relative));
                BottomGrid8.Source = new BitmapImage(new Uri("\\Images\\uav-bottom-right.png", UriKind.Relative));
                //FrAirVehicle    = false;
                FrLandVehicle   = false;
                FrNavalVehicle  = false;

            }
            else if (FrLandVehicle == true)
            {
                TopGrid1.Source    = new BitmapImage(new Uri("\\Images\\aslan.jpg", UriKind.Relative));
                TopGrid2.Source    = new BitmapImage(new Uri("\\Images\\barkan.jpg", UriKind.Relative));
                TopGrid3.Source    = new BitmapImage(new Uri("\\Images\\bogac.jpg", UriKind.Relative));
                TopGrid4.Source    = new BitmapImage(new Uri("\\Images\\fedai.jpg", UriKind.Relative));
                TopGrid5.Source    = new BitmapImage(new Uri("\\Images\\golge_suvari.jpg", UriKind.Relative));
                TopGrid6.Source    = new BitmapImage(new Uri("\\Images\\hancer.jpg", UriKind.Relative));
                TopGrid7.Source    = new BitmapImage(new Uri("\\Images\\ukap.jpg", UriKind.Relative));
                BottomGrid1.Source = new BitmapImage(new Uri("\\Images\\tank-left.png", UriKind.Relative));
                BottomGrid2.Source = new BitmapImage(new Uri("\\Images\\tank-top.png", UriKind.Relative));
                BottomGrid3.Source = new BitmapImage(new Uri("\\Images\\tank-right.png", UriKind.Relative));
                BottomGrid4.Source = new BitmapImage(new Uri("\\Images\\tank-bottom.png", UriKind.Relative));
                BottomGrid5.Source = new BitmapImage(new Uri("\\Images\\tank-top-left.png", UriKind.Relative));
                BottomGrid6.Source = new BitmapImage(new Uri("\\Images\\tank-top-right.png", UriKind.Relative));
                BottomGrid7.Source = new BitmapImage(new Uri("\\Images\\tank-bottom-left.png", UriKind.Relative));
                BottomGrid8.Source = new BitmapImage(new Uri("\\Images\\tank-bottom-right.png", UriKind.Relative));
                //FrLandVehicle   = false;
                FrAirVehicle    = false;
                FrNavalVehicle  = false;

            }
            else if (FrNavalVehicle == true)
            {
                TopGrid1.Source    = new BitmapImage(new Uri("\\Images\\ulaq.jpg", UriKind.Relative));
                BottomGrid1.Source = new BitmapImage(new Uri("\\Images\\ship-left.png", UriKind.Relative));
                BottomGrid2.Source = new BitmapImage(new Uri("\\Images\\ship-top.png", UriKind.Relative));
                BottomGrid3.Source = new BitmapImage(new Uri("\\Images\\ship-right.png", UriKind.Relative));
                BottomGrid4.Source = new BitmapImage(new Uri("\\Images\\ship-bottom.png", UriKind.Relative));
                BottomGrid5.Source = new BitmapImage(new Uri("\\Images\\ship-top-left.png", UriKind.Relative));
                BottomGrid6.Source = new BitmapImage(new Uri("\\Images\\ship-top-right.png", UriKind.Relative));
                BottomGrid7.Source = new BitmapImage(new Uri("\\Images\\ship-bottom-left.png", UriKind.Relative));
                BottomGrid8.Source = new BitmapImage(new Uri("\\Images\\ship-bottom-right.png", UriKind.Relative));
                //FrNavalVehicle  = false;
                FrAirVehicle    = false;
                FrLandVehicle   = false;

            }
        }
        private void AmmoCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AmmoCountCombobox.Items.Clear();

            if (AmmoCombobox.SelectedItem == "MAM-L + MAM-C" || AmmoCombobox.SelectedItem == "L-UMTAS")
            {
                AmmoCountCombobox.Items.Add("1");
                AmmoCountCombobox.Items.Add("2");
            }
            else if (AmmoCombobox.SelectedItem == "7,62mm MAG58 Makinalı Tüfek")
            {
                AmmoCountCombobox.Items.Add("500");
            }
            else if (AmmoCombobox.SelectedItem == "5,56mm M249 Makinalı Tüfek")
            {
                AmmoCountCombobox.Items.Add("800");
            }
            else if (AmmoCombobox.SelectedItem == "7,62mm Makinalı Tüfek")
            {
                AmmoCountCombobox.Items.Add("500");
            }
            else if (AmmoCombobox.SelectedItem == "12,7mm Makinalı Tüfek")
            {
                AmmoCountCombobox.Items.Add("250");
            }
            else if (AmmoCombobox.SelectedItem == "40mm Otomatik Bomba Atar")
            {
                AmmoCountCombobox.Items.Add("50");
            }
            else if (AmmoCombobox.SelectedItem == "Bozok" || AmmoCombobox.SelectedItem == "CİRİT" || AmmoCombobox.SelectedItem == "MAM-L" || AmmoCombobox.SelectedItem == "MAM-C"
                || AmmoCombobox.SelectedItem == "GÖKTUĞ" || AmmoCombobox.SelectedItem == "Bozdoğan")
            {
                AmmoCountCombobox.Items.Add("1");
                AmmoCountCombobox.Items.Add("2");
                AmmoCountCombobox.Items.Add("3");
                AmmoCountCombobox.Items.Add("4");
            }
            else if (AmmoCombobox.SelectedItem == "Lazer Güdüm Kiti (LGK)" || AmmoCombobox.SelectedItem == "Hassas Güdüm Kiti (HGK)" || AmmoCombobox.SelectedItem == "Mk81"
                || AmmoCombobox.SelectedItem == "Mk82" || AmmoCombobox.SelectedItem == "Mk83" || AmmoCombobox.SelectedItem == "SOM-A")
            {
                AmmoCountCombobox.Items.Add("1");
            }
            AmmoCountCombobox.SelectedIndex = 0;

        }
        private void Grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Visible;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrTb2Count++;
                VehicleNameTextbox.Text = "TC_SNL_TB2_" + mainWindow.FrTb2Count.ToString();
                VehicleSpeedTextbox.Text = "Max 120 knot";
                AmmoCombobox.Items.Add("MAM-L");
                AmmoCombobox.Items.Add("MAM-C");
                AmmoCombobox.Items.Add("MAM-L + MAM-C");
                SetUri = "\\Images\\tb2_icon.png";
                AllFalse();
                tb2 = true;

            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrAslanCount++;
                VehicleNameTextbox.Text = "TC_SNL_Aslan_" + mainWindow.FrAslanCount.ToString();
                VehicleSpeedTextbox.Text = "Max 10km/h";
                AmmoCountCombobox.IsEnabled = false;
                AmmoCombobox.Items.Add("7,62mm MAG58 Makinalı Tüfek");
                AmmoCombobox.Items.Add("5,56mm M249 Makinalı Tüfek");
                SetUri = "\\Images\\aslan_icon.png";

                AllFalse();
                Aslan = true;

            }
            else if (FrNavalVehicle == true)
            {
                mainWindow.FrUlaqCount++;
                VehicleNameTextbox.Text = "TC_SNL_Ulaq_" + mainWindow.FrUlaqCount.ToString();
                VehicleSpeedTextbox.Text = "Max 65km/h";
                AmmoCombobox.Items.Add("CİRİT");
                AmmoCombobox.Items.Add("L-UMTAS");
                SetUri = "\\Images\\ulaq_icon.png";

                AllFalse();
                ulaq = true;
            }
        }
        private void Grid2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Visible;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrAkinciCount++;
                VehicleNameTextbox.Text = "TC_SNL_Akinci_" + mainWindow.FrAkinciCount.ToString();
                VehicleSpeedTextbox.Text = "Max 190 knot";
                AmmoCombobox.Items.Add("MAM-L");
                AmmoCombobox.Items.Add("MAM-C");
                AmmoCombobox.Items.Add("CİRİT");
                AmmoCombobox.Items.Add("L-UMTAS");
                AmmoCombobox.Items.Add("Bozok");
                AmmoCombobox.Items.Add("Mk81");
                AmmoCombobox.Items.Add("Mk82");
                AmmoCombobox.Items.Add("Mk83");
                AmmoCombobox.Items.Add("SOM-A");
                AmmoCombobox.Items.Add("Hassas Güdüm Kiti (HGK)");
                AmmoCombobox.Items.Add("Lazer Güdüm Kiti (LGK)");
                SetUri = "\\Images\\akinci_icon.png";

                AllFalse();
                Akinci = true;

            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrBarkanCount++;
                VehicleNameTextbox.Text = "TC_SNL_Barkan_" + mainWindow.FrBarkanCount.ToString();
                VehicleSpeedTextbox.Text = "Max 13km/h";
                AmmoCombobox.Items.Add("7,62mm Makinalı Tüfek");
                SetUri = "\\Images\\barkan_icon.png";

                AllFalse();
                Barkan=true;
            }
        }
        private void Grid3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Visible;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrMiusCount++;
                VehicleNameTextbox.Text = "TC_SNL_Mius_" + mainWindow.FrMiusCount.ToString();
                VehicleSpeedTextbox.Text = "Max 590 knot";
                AmmoCombobox.Items.Add("GÖKTUĞ");
                AmmoCombobox.Items.Add("Bozdoğan");
                AmmoCombobox.Items.Add("Bozok");
                AmmoCombobox.Items.Add("Mk81");
                AmmoCombobox.Items.Add("Mk82");
                AmmoCombobox.Items.Add("Mk83");
                AmmoCombobox.Items.Add("SOM-A");
                SetUri = "\\Images\\mius_icon.png";

                AllFalse();
                Mius = true;
            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrBogacCount++;
                VehicleNameTextbox.Text = "TC_SNL_Bogac_" + mainWindow.FrBogacCount.ToString();
                VehicleSpeedTextbox.Text = "Max 12km/h";
                AmmoCombobox.Items.Add("7,62mm MAG58 Makinalı Tüfek");
                AmmoCombobox.Items.Add("5,56mm M249 Makinalı Tüfek");
                SetUri = "\\Images\\bogac_icon.png";

                AllFalse();
                Bogac=true;
            }
        }
        private void Grid4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Visible;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrAnkaCount++;
                VehicleNameTextbox.Text = "TC_SNL_Anka_" + mainWindow.FrAnkaCount.ToString();
                VehicleSpeedTextbox.Text = "Max 170 knot";
                AmmoCombobox.Items.Add("MAM-L");
                AmmoCombobox.Items.Add("CİRİT");
                AmmoCombobox.Items.Add("L-UMTAS");
                SetUri = "\\Images\\anka_icon.png";

                AllFalse();
                Anka= true;
            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrFedaiCount++;
                VehicleNameTextbox.Text = "TC_SNL_Fedai_" + mainWindow.FrFedaiCount.ToString();
                VehicleSpeedTextbox.Text = "Max 10km/h";
                AmmoCombobox.Items.Add("7,62mm MAG58 Makinalı Tüfek");
                SetUri = "\\Images\\fedai_icon.png";

                AllFalse();
                Fedai= true;    
            }
        }
        private void Grid5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Visible;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrAksungurCount++;
                VehicleNameTextbox.Text = "TC_SNL_Aksungur_" + mainWindow.FrAksungurCount.ToString();
                VehicleSpeedTextbox.Text = "Max 130 knot";
                AmmoCombobox.Items.Add("MAM-L");
                AmmoCombobox.Items.Add("MAM-C");
                AmmoCombobox.Items.Add("CİRİT");
                AmmoCombobox.Items.Add("L-UMTAS");
                AmmoCombobox.Items.Add("Mk81");
                AmmoCombobox.Items.Add("Mk82");
                AmmoCombobox.Items.Add("Hassas Güdüm Kiti (HGK)");
                AmmoCombobox.Items.Add("Lazer Güdüm Kiti (LGK)");
                SetUri = "\\Images\\aksungur_icon.png";

                AllFalse();
                Aksungur = true;

            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrGolgeSuvariCount++;
                VehicleNameTextbox.Text = "TC_SNL_GolgeSuvari_" + mainWindow.FrGolgeSuvariCount.ToString();
                VehicleSpeedTextbox.Text = "Max 50km/h";
                AmmoCombobox.Items.Add("7,62mm Makinalı Tüfek");
                SetUri = "\\Images\\golge_suvari_icon.png";

                AllFalse();
                GolgeSuvari = true;
            }
        }
        private void Grid6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Visible;
            TopGrid7Border7.Visibility = Visibility.Hidden;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrAirVehicle == true)
            {
                mainWindow.FrKarayelCount++;
                VehicleNameTextbox.Text = "TC_SNL_Karayel_" + mainWindow.FrKarayelCount.ToString();
                VehicleSpeedTextbox.Text = "Max 80 knot";
                AmmoCombobox.Items.Add("MAM-L");
                AmmoCombobox.Items.Add("MAM-C");
                SetUri = "\\Images\\karayel_icon.png";

                AllFalse();
                Karayel = true;
            }
            else if (FrLandVehicle == true)
            {
                mainWindow.FrHancerCount++;
                VehicleNameTextbox.Text = "TC_SNL_Hancer_" + mainWindow.FrHancerCount.ToString();
                VehicleSpeedTextbox.Text = "Max 12km/h";
                AmmoCombobox.Items.Add("5,56mm M249 Makinalı Tüfek");
                SetUri = "\\Images\\hancer_icon.png";

                AllFalse();
                Hancer = true;
            }
        }
        private void Grid7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TopGrid1Border1.Visibility = Visibility.Hidden;
            TopGrid2Border2.Visibility = Visibility.Hidden;
            TopGrid3Border3.Visibility = Visibility.Hidden;
            TopGrid4Border4.Visibility = Visibility.Hidden;
            TopGrid5Border5.Visibility = Visibility.Hidden;
            TopGrid6Border6.Visibility = Visibility.Hidden;
            TopGrid7Border7.Visibility = Visibility.Visible;
            TopGrid8Border8.Visibility = Visibility.Hidden;
            AmmoListListView.Items.Clear();
            TempIndex = 0;
            AmmoCombobox.Items.Clear();
            if (FrLandVehicle == true)
            {
                mainWindow.FrUkapCount++;
                VehicleNameTextbox.Text = "TC_SNL_Ukap_" + mainWindow.FrUkapCount.ToString();
                VehicleSpeedTextbox.Text = "Max 25km/h";
                AmmoCombobox.Items.Add("7,62mm Makinalı Tüfek");
                AmmoCombobox.Items.Add("12,7mm Makinalı Tüfek");
                AmmoCombobox.Items.Add("40mm Otomatik Bomba Atar");
                SetUri = "\\Images\\ukap_icon.png";

                AllFalse();
                ukap = true;
            }
        }
        private void VehicleNameTextbox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VehicleNameTextbox.Clear();
        }
        private void VehicleSpeedTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TopGrid1Border1.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle==true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 120)
                    {
                        MessageBox.Show("TB2 insansız hava aracı maksimum 120 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 70)
                    {
                        MessageBox.Show("TB2 insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 10 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Aslan insansız kara aracı maksimum 10km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrNavalVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 65 )
                    {
                        MessageBox.Show("Ulaq insansız deniz aracı maksimum 65km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid2Border2.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 190)
                    {
                        MessageBox.Show("Akıncı insansız hava aracı maksimum 190 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 50)
                    {
                        MessageBox.Show("Akıncı insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 13 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Barkan insansız kara aracı maksimum 13km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid3Border3.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 590)
                    {
                        MessageBox.Show("Mius insansız hava aracı maksimum 590 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 50)
                    {
                        MessageBox.Show("Mius insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 12 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Boğaç insansız kara aracı maksimum 12km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid4Border4.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 170)
                    {
                        MessageBox.Show("Anka insansız hava aracı maksimum 170 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 50)
                    {
                        MessageBox.Show("Anka insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 10 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Fedai insansız kara aracı maksimum 10km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid5Border5.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 130)
                    {
                        MessageBox.Show("Aksungur insansız hava aracı maksimum 130 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 50)
                    {
                        MessageBox.Show("Aksungur insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 50 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Gölge Fedai insansız kara aracı maksimum 50km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid6Border6.Visibility == Visibility.Visible)
            {
                if (FrAirVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 80)
                    {
                        MessageBox.Show("Karayel insansız hava aracı maksimum 80 knot hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                    else if (Convert.ToInt16(VehicleSpeedTextbox.Text) < 40)
                    {
                        MessageBox.Show("Karayel insansız hava aracı hızı çok düşük...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
                else if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 12 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Hançer insansız kara aracı maksimum 12km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
            else if (TopGrid7Border7.Visibility == Visibility.Visible)
            {
                if (FrLandVehicle == true)
                {
                    if (Convert.ToInt16(VehicleSpeedTextbox.Text) > 25 || Convert.ToInt16(VehicleSpeedTextbox.Text) < 0)
                    {
                        MessageBox.Show("Hançer insansız kara aracı maksimum 25km/h hıza ulaşabilir...", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        VehicleSpeedTextbox.Clear();
                    }
                }
            }
        }
        private void AmmoAddButton_Click(object sender, RoutedEventArgs e)
        {
            AmmoListListView.Items.Add(new Vehicles{AmmoCount = Convert.ToInt16(AmmoCountCombobox.SelectedItem), AmmoName = AmmoCombobox.SelectedItem.ToString()});
            AmmoList += AmmoCombobox.SelectedItem.ToString()+"("+ Convert.ToInt16(AmmoCountCombobox.SelectedItem)+")"+" ";
            TempIndex++;
        }
        private void BottomGrid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Visible;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = true;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void BottomGrid2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Visible;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft               = false;
            DirectionTop                = true;
            DirectionRight              = false;
            DirectionBottom             = false;
            DirectionBottomLeft         = false;
            DirectionBottomRight        = false;
            DirectionTopLeft            = false;
            DirectionTopRight           = false;
        }
        private void BottomGrid3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Visible;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft               = false;
            DirectionTop                = false;
            DirectionRight              = true;
            DirectionBottom             = false;
            DirectionBottomLeft         = false;
            DirectionBottomRight        = false;
            DirectionTopLeft            = false;
            DirectionTopRight           = false;

        }
        private void BottomGrid4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Visible;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = true;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void BottomGrid5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Visible;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;


            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = true;
            DirectionTopRight       = false;

        }
        private void BottomGrid6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Visible;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = true;
        }
        private void BottomGrid7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Visible;
            BottomGrid8Border8.Visibility = Visibility.Hidden;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = true;
            DirectionBottomRight    = false;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void BottomGrid8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomGrid1Border1.Visibility = Visibility.Hidden;
            BottomGrid2Border2.Visibility = Visibility.Hidden;
            BottomGrid3Border3.Visibility = Visibility.Hidden;
            BottomGrid4Border4.Visibility = Visibility.Hidden;
            BottomGrid5Border5.Visibility = Visibility.Hidden;
            BottomGrid6Border6.Visibility = Visibility.Hidden;
            BottomGrid7Border7.Visibility = Visibility.Hidden;
            BottomGrid8Border8.Visibility = Visibility.Visible;
            DirectionLeft           = false;
            DirectionTop            = false;
            DirectionRight          = false;
            DirectionBottom         = false;
            DirectionBottomLeft     = false;
            DirectionBottomRight    = true;
            DirectionTopLeft        = false;
            DirectionTopRight       = false;
        }
        private void AmmoClearListButton_Click(object sender, RoutedEventArgs e)
        {
            AmmoListListView.Items.Clear();
            AmmoList = "";
        }
        private void VehicleSpeedTextbox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VehicleSpeedTextbox.Clear();
        }
        private void FrAddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            VehicleAdd va   = new VehicleAdd();

            va.Vehicle_Name = VehicleNameTextbox.Text.ToString();
            if (FrAirVehicle == true)
            {
                va.Vehicle_Type = "Hava";
            }
            else if (FrLandVehicle == true)
            {
                va.Vehicle_Type = "Kara";
            }
            else
            {
                va.Vehicle_Type = "Deniz";
            }
            va.Vehicle_Speed        = Convert.ToInt16(VehicleSpeedTextbox.Text);
            va.Target_Latitude      = Convert.ToDouble(TargetLatitudeTextbox.Text);
            va.Target_Longitude     = Convert.ToDouble(TargetLongitudeTextbox.Text);
            va.Instant_Latitude     = Convert.ToDouble(InstantLatitudeTextbox.Text);
            va.Instant_Longitude    = Convert.ToDouble(InstantLongitudeTextbox.Text);
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
            va.Ammo_List            = AmmoList;
            va.Friend_Or_Enemy      = "Friend";
            va.Active_Or_Passive    = "Active";
            va.Uri_Link = SetUri;
            dbProvider.Add(va);
            mainWindow.GetLatValue  = Convert.ToDouble(TargetLatitudeTextbox.Text);
            mainWindow.GetLongValue = Convert.ToDouble(TargetLongitudeTextbox.Text);
            #region Uri If
            if (Akinci == true)
            {
                SetUri = "\\Images\\akinci.jpg";
            }
            else if (Aksungur == true)
            {
                SetUri = "\\Images\\aksungur.jpg";

            }
            else if (Anka == true)
            {
                SetUri = "\\Images\\anka.jpg";

            }
            else if (Aslan == true)
            {
                SetUri = "\\Images\\aslan.jpg";

            }
            else if (Barkan == true)
            {
                SetUri = "\\Images\\barkan.jpg";

            }
            else if (Bogac == true)
            {
                SetUri = "\\Images\\bogac.jpg";

            }
            else if (Fedai == true)
            {
                SetUri = "\\Images\\fedai.jpg";

            }
            else if (GolgeSuvari == true)
            {
                SetUri = "\\Images\\golge_suvari.jpg";

            }
            else if (Hancer == true)
            {
                SetUri = "\\Images\\hancer.jpg";

            }
            else if (Karayel == true)
            {
                SetUri = "\\Images\\karayel.jpg";

            }
            else if (Mius == true)
            {
                SetUri = "\\Images\\mius.jpg";

            }
            else if (tb2 == true)
            {
                SetUri = "\\Images\\tb2.jpg";

            }
            else if (ukap == true)
            {
                SetUri = "\\Images\\ukap.jpg";

            }
            else if (ulaq == true)
            {
                SetUri = "\\Images\\ulaq.jpg";

            }
            #endregion
            #region Direction If
            if (DirectionTop == true)
            {
                mainWindow.VehicleDirection = "Top";
            }
            else if (DirectionLeft == true)
            {
                mainWindow.VehicleDirection = "Left";

            }
            else if (DirectionRight == true)
            {
                mainWindow.VehicleDirection = "Right";

            }
            else if (DirectionBottom == true)
            {
                mainWindow.VehicleDirection = "Bottom";

            }
            #endregion
            mainWindow.GetUri = SetUri;
            mainWindow.GetVehicleName = va.Vehicle_Name;
            mainWindow.Vehicle_Speed = va.Vehicle_Speed;
            mainWindow.Target_Latitude = va.Target_Latitude;
            mainWindow.Target_Longitude = va.Target_Longitude;
            mainWindow.Instant_Latitude = va.Instant_Latitude;
            mainWindow.Instant_Longitude = va.Instant_Longitude;
            mainWindow.VehicleDirection = va.Vehicle_Direction;
            mainWindow.Ammo_List = va.Ammo_List;
            mainWindow.Friend_Or_Enemy = va.Friend_Or_Enemy;
            mainWindow.Active_Or_Passive = va.Active_Or_Passive;

        }
        private void TakeTargetCoordinatesButton_Click(object sender, RoutedEventArgs e)
        {
            TargetLatitudeTextbox.Text  = InstantLatitudeTextbox.Text;
            TargetLongitudeTextbox.Text = InstantLongitudeTextbox.Text;
        }

        
    }
}
