using GMap.NET.MapProviders;
using GMap.NET;
using HarpSimulasyonuWPF.Classes;
using HarpSimulasyonuWPF.UCController;

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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
using GMapMarker = GMap.NET.WindowsPresentation.GMapMarker;
using System.Windows.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace HarpSimulasyonuWPF
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        bool StateClosed                = false;
        bool StateClosed2               = true;
        bool StateClosed3               = true;
        public short FrTb2Count         = 0;
        public short FrAkinciCount      = 0;
        public short FrMiusCount        = 0;
        public short FrAksungurCount    = 0;
        public short FrAnkaCount        = 0;
        public short FrKarayelCount     = 0;
        public short FrAslanCount       = 0;
        public short FrBarkanCount      = 0;
        public short FrBogacCount       = 0;
        public short FrFedaiCount       = 0;
        public short FrGolgeSuvariCount = 0;
        public short FrHancerCount      = 0;
        public short FrUkapCount        = 0;
        public short FrUlaqCount        = 0;
        public short EnemyAirCount      = 0;
        public short EnemyLandCount     = 0;
        public short EnemyNavalCount    = 0;

        double LatValue                 = 39.9602803542957;
        double LongValue                = 34.47509765625;
        double TempLatValue             = 39.9602803542957;
        double TempLongValue            = 34.47509765625;
        double MouseLat                 = 0.0;
        double MouseLong                = 0.0;
        public double GetLatValue       = 0.0;
        public double GetLongValue      = 0.0;
        public string GetVehicleName;
        public string GetUri;
        public string VehicleDirection;
        public string Vehicle_Type;
        public int Vehicle_Speed;
        public double Target_Latitude;
        public double Target_Longitude;
        public double Instant_Latitude;
        public double Instant_Longitude;
        public string Ammo_List;
        public string Friend_Or_Enemy;
        public string Active_Or_Passive;
        int temp                        = 0;
        int tempTimerCount              = 0;
        int tempLoop                    = 0;
        double speedForCoordinates;
        string idList;



        ArrayList IdArray = new ArrayList();
        ArrayList VehicleNameArray = new ArrayList();
        ArrayList InstantLatitudeArray = new ArrayList();
        ArrayList InstantLongitudeArray = new ArrayList();
        ArrayList VehicleDirectionArray = new ArrayList();
        ArrayList VehicleSpeedArray = new ArrayList();





        DispatcherTimer timer = new DispatcherTimer();
        GMapMarker marker;
        Database dbProvider = new Database();
        List<VehicleAdd> Markerlist = new List<VehicleAdd>();
        VehicleAdd va = new VehicleAdd();
        SqlConnection con;
        SqlCommand cmd;


        public MainWindow()
        {
            InitializeComponent();
            VehiclesRefresh.IsEnabled = true;
            RegisteredStrategies.ItemsSource = dbProvider.StrategyList();

        }

        public void AddMarker(string getvehiclename, double gettargetlatitude, double gettargetlongitude, int getid,string getvehicletype,int getspeed)
        {
            if (temp == 0)
            {
                int angle = 0;
                #region Vehicle Direction If
                if (VehicleDirection == "Top" && getvehicletype=="Hava")
                {
                    angle = 0;
                }
                else if (VehicleDirection == "Right" && getvehicletype == "Hava")
                {
                    angle = 90;
                }
                else if (VehicleDirection == "Left" && getvehicletype == "Hava")
                {
                    angle = 270;
                }
                else if (VehicleDirection == "Bottom" && getvehicletype == "Hava")
                {
                    angle = 180;
                }
                else if (VehicleDirection == "Top-Right" && getvehicletype == "Hava")
                {
                    angle = 45;
                }
                else if (VehicleDirection == "Top-Left" && getvehicletype == "Hava")
                {
                    angle = 315;
                }
                else if (VehicleDirection == "Bottom-Lef" && getvehicletype == "Hava")
                {
                    angle = 225;
                }
                else if (VehicleDirection == "Bottom-Rig" && getvehicletype == "Hava")
                {
                    angle = 135;
                }
                else if (VehicleDirection == "Top" && (getvehicletype == "Kara" || getvehicletype == "Deniz") )
                {
                    angle = 90;
                }
                else if (VehicleDirection == "Right" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 180;
                }
                else if (VehicleDirection == "Left" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 0;
                }
                else if (VehicleDirection == "Bottom" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 270;
                }
                else if (VehicleDirection == "Top-Left" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 45;
                }
                else if (VehicleDirection == "Top-Right" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 135;
                }
                else if (VehicleDirection == "Bottom-Lef" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 315;
                }
                else if (VehicleDirection == "Bottom-Rig" && (getvehicletype == "Kara" || getvehicletype == "Deniz"))
                {
                    angle = 225;
                }

                #endregion
                BitmapImage bitmapImage = new BitmapImage();
                TransformedBitmap convertBitmap = new TransformedBitmap();
                bitmapImage.BeginInit();
                UriLink(getvehiclename);


                bitmapImage.UriSource = new Uri(Environment.CurrentDirectory + GetUri);
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                marker = new GMapMarker(new PointLatLng(gettargetlatitude, gettargetlongitude));

                convertBitmap.Source = bitmapImage;
                double ratio_f64 = bitmapImage.Width / bitmapImage.Height;

                double min_marker_height = 60;
                double max_marker_height = 120;

                double width_f64 = Scale(map.Zoom, 7, 20, min_marker_height, max_marker_height);
                double height_f64 = width_f64 / ratio_f64;
                marker.Shape = new Image
                {
                    Height = height_f64,
                    Width = width_f64,
                    Source = bitmapImage,
                    Uid = getvehiclename

                };
                RotateTransform dondurme = new RotateTransform(angle);

                dondurme.CenterX = 0.5 * ((System.Windows.FrameworkElement)marker.Shape).Width;
                dondurme.CenterY = 0.5 * ((System.Windows.FrameworkElement)marker.Shape).Height;

                marker.Shape.RenderTransform = dondurme;
                marker.Tag = (getvehiclename + "_" + getid).ToString();
                marker.Offset = new Point(-0.5 * ((System.Windows.FrameworkElement)marker.Shape).Width,
                                           -0.5 * ((System.Windows.FrameworkElement)marker.Shape).Height);
                InstantLatitudeArray.Add(gettargetlatitude);
                InstantLongitudeArray.Add(gettargetlongitude);
                map.Markers.Add(marker);
                marker.Shape.MouseLeftButtonDown += Marker_MouseLeftButtonDown;



                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(0.001);
                timer.Tick += Timer_Tick;
            }
           


        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            if (tempTimerCount == 1)
            {
                foreach (GMapMarker marker in map.Markers)
                {
                    if (tempLoop ==IdArray.Count)
                    {
                        tempLoop = 0;
                        break;
                    }
                    else
                    {
                        for (int a= tempLoop; a < IdArray.Count; a++)
                        {
                            if (VehicleDirectionArray[tempLoop].ToString() == "Top")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat + speedForCoordinates, marker.Position.Lng);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Bottom")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat - speedForCoordinates, marker.Position.Lng);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Right")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat, marker.Position.Lng + speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Left")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat, marker.Position.Lng - speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Top-Left")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat + speedForCoordinates, marker.Position.Lng - speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Top-Right")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat + speedForCoordinates, marker.Position.Lng + speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Bottom-Lef")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat - speedForCoordinates, marker.Position.Lng - speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                            else if (VehicleDirectionArray[tempLoop].ToString() == "Bottom-Rig")
                            {
                                SpeedCal();
                                marker.Position = new PointLatLng(marker.Position.Lat - speedForCoordinates, marker.Position.Lng + speedForCoordinates);
                                tempLoop++;
                                break;
                            }
                        }
                        map.InvalidateVisual();
                    }
                }
            }
        }
        private void SpeedCal()
        {
            if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 10)
            {
                speedForCoordinates = 0.000001;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 50)
            {
                speedForCoordinates = 0.000005;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 75)
            {
                speedForCoordinates = 0.0000075;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 120)
            {
                speedForCoordinates = 0.000012;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 200)
            {
                speedForCoordinates = 0.00002;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 300)
            {
                speedForCoordinates = 0.00003;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 400)
            {
                speedForCoordinates = 0.00004;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 500)
            {
                speedForCoordinates = 0.00005;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) < 600)
            {
                speedForCoordinates = 0.00006;
            }
            else if (Convert.ToInt16(VehicleSpeedArray[tempLoop]) > 600)
            {
                speedForCoordinates = 0.000065;
            }
        }
        private void Marker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LatValue = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lat;
            LongValue = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lng;

            if (temp > 2)
            {
                TopInformation.Children.RemoveAt(1);
                temp = 1;
            }
            else
            {
                if (temp > 1)
                {
                    TopDockPanel.Visibility = Visibility.Hidden;
                    temp = 1;
                }
                else
                {
                    for (int i = 0; i < IdArray.Count; i++)
                    {
                        if (LatValue == Convert.ToDouble(InstantLatitudeArray[i]))
                        {
                            UCCall.UC_Add(TopInformation, new UCVehicleInformation(Convert.ToInt16(IdArray[i])));
                        }
                    }
                }
            }
        }
        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            //Mouse haritanın üstüne geldiğinde enlem ve boylam değerlerini al
            MouseLat = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lat;
            MouseLong = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lng;
            LatitudeTextBox.Text = MouseLat.ToString();
            LongitudeTextBox.Text = MouseLong.ToString();
        }
        private void Map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Mouse tekerleği ile yakınlaştırıldığında farenin olduğu noktaya doğru yakınlaştır
            Zoom_With_Maker();
            Setting_Map_Zoom(e);
        }
        private void Setting_Map_Zoom(MouseWheelEventArgs e)
        {
            if (0 < e.Delta)
            {
                if (map.MaxZoom > (map.Zoom + 0.1))
                {
                    map.Zoom += 0.1;
                }
            }
            else
            {
                if (map.MinZoom < (map.Zoom - 0.1))
                {
                    map.Zoom -= 0.1;
                }
            }

            map.Position = new PointLatLng(map.Position.Lat + (map.Position.Lat - MouseLat) / 7, map.Position.Lng + (map.Position.Lng - MouseLong) / 7);
        }
        private void Zoom_With_Maker()
        {
            var marker_list = map.Markers.Where(a => a != null && a.Shape != null && a.Shape.Uid.Contains("_")).ToList();

            if (0 < marker_list.Count)
            {
                foreach (GMapMarker duzenlenecek_marker in marker_list)
                {
                    double oran_f64 = ((FrameworkElement)duzenlenecek_marker.Shape).ActualWidth / ((FrameworkElement)duzenlenecek_marker.Shape).ActualHeight;

                    double min_marker_height = 40;
                    double max_marker_height = 100;

                    ((FrameworkElement)duzenlenecek_marker.Shape).Width = Scale(map.Zoom, 7, 20, min_marker_height, max_marker_height);
                    ((FrameworkElement)duzenlenecek_marker.Shape).Height = ((FrameworkElement)duzenlenecek_marker.Shape).Width / oran_f64;
                }
            }
        }
        double Scale(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }
        private void Map_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (temp != 0)
            {
                if (TopInformation.Children.Count == 2 && temp > 1)
                {

                    TopInformation.Children.RemoveAt(1);
                    TopDockPanel.Visibility = Visibility.Visible;
                    temp--;

                }
                else if (TopInformation.Children.Count == 2 && temp == 1)
                {
                    TopInformation.Children.RemoveAt(1);
                    TopDockPanel.Visibility = Visibility.Visible;

                }

                else if (TopInformation.Children.Count == 2)
                {

                    TopDockPanel.Visibility = Visibility.Hidden;
                    temp++;
                }
                else if (TopInformation.Children.Count == 1 && temp == 1)
                {
                    temp = 0;
                    map.MouseLeftButtonDown += Map_MouseLeftButtonDown;
                }
                
                else
                {
                    TopInformation.Children.RemoveAt(1);
                    TopDockPanel.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (TopInformation.Children.Count==1)
                {
                    temp++;
                    TopDockPanel.Visibility = Visibility.Visible;
                    //Mouse sol butonu aşağıya indiğinde tıklanılan konumun koordinatlarını al
                    LatValue = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lat;
                    LongValue = map.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(map).X), Convert.ToInt32(e.GetPosition(map).Y)).Lng;
                    TempLatValue = LatValue;
                    TempLongValue = LongValue;
                    LatitudeTextBox.Text = LatValue.ToString();
                    LongitudeTextBox.Text = LongValue.ToString();
                    GetLatValue = LatValue;
                    GetLongValue = LongValue;
                    ProcessedLatitude.Text = GetLatValue.ToString();
                    ProcessedLongitude.Text = GetLongValue.ToString();
                }
                else
                {
                    TopInformation.Children.RemoveAt(1);

                }

            }
        }
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            //Sol hamburger menu
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
            }
            StateClosed = !StateClosed;

        }
        private void BtnFrAddAirVehicle(object sender, RoutedEventArgs e)
        {
            if (ProcessedLatitude.Text != "")
            {
                GetLatValue = Convert.ToDouble(ProcessedLatitude.Text);
                GetLongValue = Convert.ToDouble(ProcessedLongitude.Text);
                UCAddVehicle VehicleScreen = new UCAddVehicle();
                VehicleScreen.FrAirVehicle = true;
                VehicleScreen.GetLatValue = TempLatValue;
                VehicleScreen.GetLongValue = TempLongValue;
                VehicleScreen.Show();
            }
        }
        private void BtnFrAddLandVehicle(object sender, RoutedEventArgs e)
        {
            if (ProcessedLatitude.Text != "")
            {
                GetLatValue = Convert.ToDouble(ProcessedLatitude.Text);
                GetLongValue = Convert.ToDouble(ProcessedLongitude.Text);
                UCAddVehicle VehicleScreen = new UCAddVehicle();
                VehicleScreen.FrLandVehicle = true;
                VehicleScreen.GetLatValue = TempLatValue;
                VehicleScreen.GetLongValue = TempLongValue;
                VehicleScreen.Show();
            } 
        }
        private void BtnFrAddNavalVehicle(object sender, RoutedEventArgs e)
        {
            if (ProcessedLatitude.Text != "")
            {
                GetLatValue = Convert.ToDouble(ProcessedLatitude.Text);
                GetLongValue = Convert.ToDouble(ProcessedLongitude.Text);
                UCAddVehicle VehicleScreen = new UCAddVehicle();
                VehicleScreen.FrNavalVehicle = true;
                VehicleScreen.GetLatValue = TempLatValue;
                VehicleScreen.GetLongValue = TempLongValue;
                VehicleScreen.Show();
            }
            
        }
        private void ButtonMenu2_Click(object sender, RoutedEventArgs e)
        {
            //Sağ hamburger menu
            if (StateClosed2)
            {
                Storyboard sb = this.FindResource("RightOpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("RightCloseMenu") as Storyboard;
                sb.Begin();
            }

            StateClosed2 = !StateClosed2;
        }
        private void ButtonMenu3_Click(object sender, RoutedEventArgs e)
        {
            //Orta hamburger menu
            if (StateClosed3)
            {
                Storyboard sb = this.FindResource("MiddleOpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("MiddleCloseMenu") as Storyboard;
                sb.Begin();
            }
            StateClosed3 = !StateClosed3;
        }
        private void BtnEnemyAddAirVehicle(object sender, RoutedEventArgs e)
        {
            UCEnemyAddVehicle VehicleScreen = new UCEnemyAddVehicle();
            VehicleScreen.EnemyAirVehicle = true;
            VehicleScreen.GetLatValue = TempLatValue;
            VehicleScreen.GetLongValue = TempLongValue;
            VehicleScreen.Show();
        }
        private void BtnEnemyAddLandVehicle(object sender, RoutedEventArgs e)
        {
            UCEnemyAddVehicle VehicleScreen = new UCEnemyAddVehicle();
            VehicleScreen.EnemyLandVehicle = true;
            VehicleScreen.GetLatValue = TempLatValue;
            VehicleScreen.GetLongValue = TempLongValue;
            VehicleScreen.Show();
        }
        private void BtnEnemyAddNavalVehicle(object sender, RoutedEventArgs e)
        {
            UCEnemyAddVehicle VehicleScreen = new UCEnemyAddVehicle();
            VehicleScreen.EnemyNavalVehicle = true;
            VehicleScreen.GetLatValue = TempLatValue;
            VehicleScreen.GetLongValue = TempLongValue;
            VehicleScreen.Show();
        }
        public void VehiclesRefresh_Click(object sender, RoutedEventArgs e)
        {
            map.Markers.Clear();
            //VehiclesRefresh.IsEnabled=false;
            map.InvalidateVisual();

            if (GetUri != "")
            {
                UriLink(GetUri);

                VehiclesOnTheMap.ItemsSource = dbProvider.List();
                MarkerList(false,false,false,true);
                timer.Start();

                tempTimerCount = 1;
            }
            map.InvalidateVisual();
        }
        private void UriLink(string getVehicleName)
        {
            if (getVehicleName != null)
            {
                if (getVehicleName.Contains("tb2"))
                {
                    GetUri = "\\Images\\tb2_icon.png";
                }
                else if (getVehicleName.Contains("akinci"))
                {
                    GetUri = "\\Images\\akinci_icon.png";
                }
                else if (getVehicleName.Contains("aksungur"))
                {
                    GetUri = "\\Images\\aksungur_icon.png";
                }
                else if (getVehicleName.Contains("anka"))
                {
                    GetUri = "\\Images\\anka_icon.png";
                }
                else if (getVehicleName.Contains("karayel"))
                {
                    GetUri = "\\Images\\karayel_icon.png";
                }
                else if (getVehicleName.Contains("mius"))
                {
                    GetUri = "\\Images\\mius_icon.png";
                }
                else if (getVehicleName.Contains("aslan"))
                {
                    GetUri = "\\Images\\aslan_icon.png";
                }
                else if (getVehicleName.Contains("bar"))
                {
                    GetUri = "\\Images\\barkan_icon.png";
                }
                else if (getVehicleName.Contains("bogac"))
                {
                    GetUri = "\\Images\\bogac_icon.png";
                }
                else if (getVehicleName.Contains("fedai"))
                {
                    GetUri = "\\Images\\fedai_icon.png";
                }
                else if (getVehicleName.Contains("golge_suvari"))
                {
                    GetUri = "\\Images\\golge_suvari_icon.png";
                }
                else if (getVehicleName.Contains("hancer"))
                {
                    GetUri = "\\Images\\hancer_icon.png";
                }
                else if (getVehicleName.Contains("ukap"))
                {
                    GetUri = "\\Images\\ukap_icon.png";
                }
                else if (getVehicleName.Contains("ulaq"))
                {
                    GetUri = "\\Images\\ulaq_icon.png";
                }
                else if (getVehicleName.Contains("enemy_plane"))
                {
                    GetUri = "\\Images\\enemy_plane.png";
                }
                else if (getVehicleName.Contains("enemy_tank"))
                {
                    GetUri = "\\Images\\enemy_tank.png";
                }
                else if (getVehicleName.Contains("enemy_ship"))
                {
                    GetUri = "\\Images\\enemy_ship.png";
                }
                else
                {

                }
            }

        }
        public void RemoveArrayId(int getId)
        {
            for (int i = 0; i < IdArray.Count; i++)
            {
                if (Convert.ToInt16(IdArray[i]) == getId)
                {
                    IdArray.RemoveAt(i);
                    VehicleNameArray.RemoveAt(i);
                    InstantLatitudeArray.RemoveAt(i);
                    InstantLongitudeArray.RemoveAt(i);
                    map.Markers.RemoveAt(i);
                    TopInformation.Children.RemoveAt(1);
                    TopDockPanel.Visibility = Visibility.Visible;
                }
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            map.MapProvider = GoogleSatelliteMapProvider.Instance;
            map.Manager.Mode = AccessMode.ServerAndCache;
            map.Manager.BoostCacheEngine = true;

            map.ShowCenter = true;
            map.DragButton = MouseButton.Right;
            map.SetPositionByKeywords("Country_Name");

            map.MinZoom = 3;
            map.MaxZoom = 24;
            map.Zoom = 6;
            map.Position = new PointLatLng(39.9602803542957, 34.47509765625);
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            map.MouseLeftButtonDown += Map_MouseLeftButtonDown;
            map.MouseWheel += Map_MouseWheel;
            map.MouseMove += Map_MouseMove;


            VehiclesOnTheMap.ItemsSource = dbProvider.List();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //dbProvider.ActivePassiveUpdate();
        }

        private void VehiclesOnTheMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = VehiclesOnTheMap.SelectedItem; 
            if ((VehiclesOnTheMap.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text==null) { }
            else
            {
                string ID = (VehiclesOnTheMap.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                int scaleId = Convert.ToInt32(ID);
                for (int i = 0; i < IdArray.Count; i++)
                {
                    if (Convert.ToInt32(IdArray[i]) == scaleId)
                    {
                        if (temp != 0)
                        {
                            if (TopInformation.Children.Count == 2 && temp > 1)
                            {
                                MessageBox.Show("a");

                                TopInformation.Children.RemoveAt(1);
                                TopDockPanel.Visibility = Visibility.Visible;
                                temp--;

                            }
                            else if (TopInformation.Children.Count == 2)
                            {

                                UCCall.UC_Add(TopInformation, new UCVehicleInformation(Convert.ToInt16(IdArray[i])));

                            }
                            else if (TopInformation.Children.Count == 1)
                            {

                                TopDockPanel.Visibility = Visibility.Hidden;
                                UCCall.UC_Add(TopInformation, new UCVehicleInformation(Convert.ToInt16(IdArray[i])));

                            }
                            else
                            {

                                TopInformation.Children.RemoveAt(1);
                                TopDockPanel.Visibility = Visibility.Hidden;
                            }
                        }
                        else

                        {
                            TopDockPanel.Visibility = Visibility.Hidden;
                            UCCall.UC_Add(TopInformation, new UCVehicleInformation(Convert.ToInt16(IdArray[i])));
                            temp++;
                        }

                    }
                }
            }
        }
        private void VehiclesOnTheMap_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            VehiclesOnTheMap.SelectionChanged += VehiclesOnTheMap_SelectionChanged;
        }
        private void ShowAirVehicle_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (GetUri != "" && ProcessedLatitude.Text!="" && ProcessedLongitude.Text != "")
            {
                map.Markers.Clear();
                tempTimerCount = 1;
                tempLoop = 0;
                UriLink(GetUri);
                VehiclesOnTheMap.ItemsSource = dbProvider.ListMarker(true,false,false);
                MarkerList(true, false, false, false);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Lütfen referans olarak işlem yapılacak herhangi bir koordinatı seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            map.InvalidateVisual();
        }
        private void ShowLandVehicle_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (GetUri != "" && ProcessedLatitude.Text != "" && ProcessedLongitude.Text != "")
            {
                map.Markers.Clear();
                tempTimerCount = 1;
                tempLoop = 0;
                UriLink(GetUri);
                VehiclesOnTheMap.ItemsSource = dbProvider.ListMarker(false, true, false);
                MarkerList(false, true, false, false);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Lütfen referans olarak işlem yapılacak herhangi bir koordinatı seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            map.InvalidateVisual();
        }
        private void ShowNavalVehicle_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (GetUri != "" && ProcessedLatitude.Text != "" && ProcessedLongitude.Text != "")
            {
                map.Markers.Clear();
                tempTimerCount = 1;
                tempLoop = 0;
                UriLink(GetUri);
                VehiclesOnTheMap.ItemsSource = dbProvider.ListMarker(false, false,true);
                MarkerList(false, false, true, false);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Lütfen referans olarak işlem yapılacak herhangi bir koordinatı seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            map.InvalidateVisual();
        }
        private void ShowAllVehicle_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (GetUri != "" && ProcessedLatitude.Text != "" && ProcessedLongitude.Text != "")
            {
                map.Markers.Clear();
                tempTimerCount = 1;
                tempLoop = 0;
                UriLink(GetUri);
                VehiclesOnTheMap.ItemsSource = dbProvider.List();
                MarkerList(false, false, false, true);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Lütfen referans olarak işlem yapılacak herhangi bir koordinatı seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            map.InvalidateVisual();
        }
        private void DeleteVehiclesOnTheMap_Click(object sender, RoutedEventArgs e)
        {
            if (GetUri != "" && ProcessedLatitude.Text != "" && ProcessedLongitude.Text != "")
            {
                map.Markers.Clear();
                ProcessedLatitude.Text = "";
                ProcessedLongitude.Text = "";
                VehiclesOnTheMap.ItemsSource = dbProvider.SpaceList(); ;
                VehiclesRefresh.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen referans olarak işlem yapılacak herhangi bir koordinatı seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
      
        public void StrategyMarkerList(int getId)
        {
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
            IdArray.Clear();

            try
            {
                List<VehicleAdd> Markerlist = new List<VehicleAdd>();

                cmd.Parameters.Clear();
                
                cmd.CommandText = "Select * from Vehicle_Information where ID=@id";

                cmd.Parameters.AddWithValue("@id", getId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    IdArray.Add(Convert.ToInt16(rdr[0]));
                    MessageBox.Show("count"+IdArray.Count);
                    GetVehicleName = rdr[1].ToString();
                    VehicleNameArray.Add(GetVehicleName);
                    Vehicle_Type = rdr[2].ToString();
                    Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    VehicleSpeedArray.Add(Vehicle_Speed);
                    Target_Latitude = Convert.ToDouble(rdr[4]);
                    Target_Longitude = Convert.ToDouble(rdr[5]);
                    Instant_Latitude = Convert.ToDouble(rdr[6]);
                    Instant_Longitude = Convert.ToDouble(rdr[7]);
                    VehicleDirection = rdr[8].ToString();
                    VehicleDirectionArray.Add(VehicleDirection);
                    Ammo_List = rdr[9].ToString();
                    Friend_Or_Enemy = rdr[10].ToString();
                    Active_Or_Passive = rdr[11].ToString();
                    GetUri = rdr[12].ToString();
                    AddMarker(GetVehicleName, Instant_Latitude, Instant_Longitude, Convert.ToInt16(rdr[0]), Vehicle_Type, Vehicle_Speed);
                }
                temp = 1;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void SaveTheStrategy_Click(object sender, RoutedEventArgs e)
        {
            string[] _Split;
            AddStrategy();
            RegisteredStrategies.ItemsSource = dbProvider.StrategyList();



            for (int i = 0; i < IdArray.Count-1; i++)
            {
                 _Split = idList.Split(',');
                IdArray.Add(Convert.ToInt16(_Split[i]));
                StrategyMarkerList(Convert.ToInt16(_Split[i]));
            }
            timer.Start();
            

            tempTimerCount = 1;
            map.InvalidateVisual();
        }
       public void StrategyidList(int getId)
        {
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                List<VehicleAdd> Markerlist = new List<VehicleAdd>();

                cmd.Parameters.Clear();

                cmd.CommandText = "Select * from Vehicle_Information where ID=@id";

                cmd.Parameters.AddWithValue("@id", getId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    IdArray.Add(Convert.ToInt16(rdr[0]));
                    GetVehicleName = rdr[1].ToString();
                    VehicleNameArray.Add(GetVehicleName);
                    Vehicle_Type = rdr[2].ToString();
                    Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    VehicleSpeedArray.Add(Vehicle_Speed);
                    Target_Latitude = Convert.ToDouble(rdr[4]);
                    Target_Longitude = Convert.ToDouble(rdr[5]);
                    Instant_Latitude = Convert.ToDouble(rdr[6]);
                    Instant_Longitude = Convert.ToDouble(rdr[7]);
                    VehicleDirection = rdr[8].ToString();
                    VehicleDirectionArray.Add(VehicleDirection);
                    Ammo_List = rdr[9].ToString();
                    Friend_Or_Enemy = rdr[10].ToString();
                    Active_Or_Passive = rdr[11].ToString();
                    GetUri = rdr[12].ToString();
                    AddMarker(GetVehicleName, Instant_Latitude, Instant_Longitude, Convert.ToInt16(rdr[0]), Vehicle_Type, Vehicle_Speed);
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void RegisteredStrategies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] _Split;
            IdArray.Clear();
            VehicleDirectionArray.Clear();
            InstantLatitudeArray.Clear();
            InstantLongitudeArray.Clear();
            VehicleDirectionArray.Clear();
            VehicleSpeedArray.Clear();
            map.Markers.Clear();
            object item = RegisteredStrategies.SelectedItem; //probably you find this object
            idList = "";
            string ID = (RegisteredStrategies.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            _Split = ID.Split(',');
            for (int i = 0; i <_Split.Length ; i++)
            {
                idList += _Split[i]+",";

            }
            for (int i = 0; i < _Split.Length; i++)
            {
                if (i!=_Split.Length-1)
                {
                    _Split = idList.Split(',');
                    StrategyidList(Convert.ToInt16(_Split[i]));
                    ActivePassiveUpdate(Convert.ToInt16(_Split[i]));
                }                
            }
            timer.Start();

            VehiclesOnTheMap.ItemsSource = dbProvider.List();

            tempTimerCount = 1;
            map.InvalidateVisual();
            
        }
        private void RegisteredStrategies_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            RegisteredStrategies.SelectionChanged += RegisteredStrategies_SelectionChanged;
            dbProvider.ActivePassiveUpdate();
        }
        public void ActivePassiveUpdate(int getid)
        {

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandText = "Update Vehicle_Information set Active_Or_Passive=@active_or_passive where ID=@id";
                cmd.Parameters.AddWithValue("@id", getid);
                cmd.Parameters.AddWithValue("@active_or_passive", "Active");
                cmd.CommandType = CommandType.Text;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void MarkerList(bool getAir, bool getLand, bool getNaval, bool getAll)
        {
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
            IdArray.Clear();
            VehicleDirectionArray.Clear();
            InstantLatitudeArray.Clear();
            InstantLongitudeArray.Clear();
            VehicleDirectionArray.Clear();
            VehicleSpeedArray.Clear();
            try
            {
                List<VehicleAdd> Markerlist = new List<VehicleAdd>();

                cmd.Parameters.Clear();
                if (getAir == true)
                {
                    cmd.CommandText = "Select * from Vehicle_Information where Active_Or_Passive=@active_or_passive and Vehicle_Type=@vehicle_type";
                    cmd.Parameters.AddWithValue("@vehicle_type", "Hava");

                }
                else if (getLand == true)
                {
                    cmd.CommandText = "Select * from Vehicle_Information where Active_Or_Passive=@active_or_passive and Vehicle_Type=@vehicle_type";
                    cmd.Parameters.AddWithValue("@vehicle_type", "Kara");
                }
                else if (getNaval == true)
                {
                    cmd.CommandText = "Select * from Vehicle_Information where Active_Or_Passive=@active_or_passive and Vehicle_Type=@vehicle_type";
                    cmd.Parameters.AddWithValue("@vehicle_type", "Deniz");
                }
                else if (getAll == true)
                {
                    cmd.CommandText = "Select * from Vehicle_Information where Active_Or_Passive=@active_or_passive";

                }
                cmd.Parameters.AddWithValue("@active_or_passive", "Active");
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VehicleAdd va = new VehicleAdd();

                    IdArray.Add(Convert.ToInt16(rdr[0]));
                    GetVehicleName = rdr[1].ToString();
                    VehicleNameArray.Add(GetVehicleName);
                    Vehicle_Type = rdr[2].ToString();
                    Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    VehicleSpeedArray.Add(Vehicle_Speed);
                    Target_Latitude = Convert.ToDouble(rdr[4]);
                    Target_Longitude = Convert.ToDouble(rdr[5]);
                    Instant_Latitude = Convert.ToDouble(rdr[6]);
                    Instant_Longitude = Convert.ToDouble(rdr[7]);
                    VehicleDirection = rdr[8].ToString();
                    VehicleDirectionArray.Add(VehicleDirection);
                    Ammo_List = rdr[9].ToString();
                    Friend_Or_Enemy = rdr[10].ToString();
                    Active_Or_Passive = rdr[11].ToString();
                    GetUri = rdr[12].ToString();
                    AddMarker(GetVehicleName, Instant_Latitude, Instant_Longitude, Convert.ToInt16(rdr[0]), Vehicle_Type, Vehicle_Speed);
                }
                temp = 1;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void AddStrategy()
        {
            for (int i = 0; i < IdArray.Count; i++)
            {
                idList += IdArray[i].ToString() + ",";
            }
            idList = idList.Remove(idList.Length - 1);
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                List<VehicleAdd> Markerlist = new List<VehicleAdd>();

                cmd.Parameters.Clear();

                cmd.CommandText = "Insert Into Strategies(Strategy_With_Ids) Values (@strategy_with_ids)";
                cmd.Parameters.AddWithValue("@strategy_with_ids", idList);
                cmd.CommandType = CommandType.Text;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Araçlar simülasyona kaydedildi.", "Eklendi", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
