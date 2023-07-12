using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HarpSimulasyonuWPF.Classes;

namespace HarpSimulasyonuWPF.UCController
{
    /// <summary>
    /// Interaction logic for UCVehicleInformation.xaml
    /// </summary>
    public partial class UCVehicleInformation : UserControl
    {
        string _Uri;
        int VehicleId;

        public UCVehicleInformation(int Id)
        {
            InitializeComponent();
            VehicleId = Id;
            getId(Id);

        }
        public int getId(int getId)
        {
            SqlConnection con;
            SqlCommand cmd;
            int tempId = 0;
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from Vehicle_Information where ID=@id";
            cmd.Parameters.AddWithValue("@id", getId);

            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                InformationVehicleName.Content = rdr[1].ToString();
                InformationVehicleSpeed.Text = rdr[3].ToString();
                InformationTargetLatitudeTextbox.Text = rdr[4].ToString();
                InformationTargetLongitudeTextbox.Text = rdr[5].ToString();
                InformationLatitudeTextbox.Text = rdr[6].ToString();
                InformationLongitudeTextBox.Text = rdr[7].ToString();
                InformationAmmoList.Content = rdr[9].ToString();
                _Uri = rdr[12].ToString();
                if (_Uri.Contains("tb2"))
                {
                    _Uri = "\\Images\\tb2.jpg";
                }
                else if (_Uri.Contains("akinci"))
                {
                    _Uri = "\\Images\\akinci.jpg";
                }
                else if (_Uri.Contains("aksungur"))
                {
                    _Uri = "\\Images\\aksungur.jpg";
                }
                else if (_Uri.Contains("anka"))
                {
                    _Uri = "\\Images\\anka.jpg";
                }
                else if (_Uri.Contains("karayel"))
                {
                    _Uri = "\\Images\\karayel.jpg";
                }
                else if (_Uri.Contains("mius"))
                {
                    _Uri = "\\Images\\mius.jpg";
                }
                else
                {

                }
                InformationImage.Source = new BitmapImage(new Uri(_Uri, UriKind.Relative));
            }
            con.Close();

            return tempId;
        }
        private void DeleteVehicle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            MessageBoxResult mb;
            mb = MessageBox.Show("Aracı silmek istediğinize emin misiniz?","Sil",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (mb == MessageBoxResult.Yes)
            {
                Database dbProvider = new Database();
                dbProvider.Delete(VehicleId);
                mw.RemoveArrayId(VehicleId);
                mw.Hide();
                mw.Show();
            }
        }
        private void InformationIncreaseSpeed_Click(object sender, RoutedEventArgs e)
        {
            InformationVehicleSpeed.Text = (Convert.ToInt32(InformationVehicleSpeed.Text)+1).ToString();
        }

        private void UpdateVehicleInformation_Click(object sender, RoutedEventArgs e)
        {
            Database dbProvider = new Database();
            dbProvider.Update(VehicleId, Convert.ToInt16(InformationVehicleSpeed.Text), Convert.ToDouble(InformationTargetLatitudeTextbox.Text), Convert.ToDouble(InformationTargetLongitudeTextbox.Text));
            MainWindow mw = new MainWindow();
            mw.Hide();
            mw.Show();
        }
        private void InformationReduceSpeed_Click(object sender, RoutedEventArgs e)
        {
            InformationVehicleSpeed.Text = (Convert.ToInt32(InformationVehicleSpeed.Text) - 1).ToString();
        }
    }
}
