using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using HarpSimulasyonuWPF.UCController;
using GMap.NET.MapProviders;

namespace HarpSimulasyonuWPF.Classes
{
    class Database
    {
        SqlConnection con;
        SqlCommand cmd;
        public Database()
        {
            Connection();
        }
        public void Connection()
        {
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public List<DatagridList> List()
        {
            try
            {
                List<DatagridList> DataGridListVehicle = new List<DatagridList>();

                cmd.Parameters.Clear();
                cmd.CommandText = "Select ID,Vehicle_Name,Vehicle_Type,Vehicle_Speed,Friend_Or_Enemy from Vehicle_Information where Active_Or_Passive=@active_or_passive";
                cmd.Parameters.AddWithValue("@active_or_passive", "Active");
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DatagridList dgl = new DatagridList();

                    dgl.Id= Convert.ToInt32(rdr[0].ToString());
                    dgl.Vehicle_Name = rdr[1].ToString();
                    dgl.Vehicle_Type = rdr[2].ToString();
                    dgl.Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    dgl.Friend_Or_Enemy = rdr[4].ToString();
                    DataGridListVehicle.Add(dgl);

                }
                return DataGridListVehicle;
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
        public List<DatagridList> SpaceList()
        {
            try
            {
                List<DatagridList> DataGridListVehicle = new List<DatagridList>();

                cmd.Parameters.Clear();
                cmd.CommandText = "Select ID,Vehicle_Name,Vehicle_Type,Vehicle_Speed,Friend_Or_Enemy from Vehicle_Information where Active_Or_Passive=@active_or_passive";
                cmd.Parameters.AddWithValue("@active_or_passive", "0");
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DatagridList dgl = new DatagridList();

                    dgl.Id = Convert.ToInt32(rdr[0].ToString());
                    dgl.Vehicle_Name = rdr[1].ToString();
                    dgl.Vehicle_Type = rdr[2].ToString();
                    dgl.Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    dgl.Friend_Or_Enemy = rdr[4].ToString();
                    DataGridListVehicle.Add(dgl);

                }
                return DataGridListVehicle;
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
        public List<DatagridList> ListMarker(bool getAir,bool getLand,bool getNaval)
        {
            try
            {
                List<DatagridList> DataGridListVehicle = new List<DatagridList>();

                cmd.Parameters.Clear();
                cmd.CommandText = "Select ID,Vehicle_Name,Vehicle_Type,Vehicle_Speed,Friend_Or_Enemy from Vehicle_Information where Active_Or_Passive=@active_or_passive and Vehicle_Type=@vehicle_type";

                if (getAir == true)
                {
                    cmd.Parameters.AddWithValue("@vehicle_type", "Hava");

                }
                else if (getLand == true)
                {
                    cmd.Parameters.AddWithValue("@vehicle_type", "Kara");
                }
                else if (getNaval == true)
                {
                    cmd.Parameters.AddWithValue("@vehicle_type", "Deniz");
                }

                cmd.Parameters.AddWithValue("@active_or_passive", "Active");

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DatagridList dgl = new DatagridList();

                    dgl.Id = Convert.ToInt32(rdr[0].ToString());
                    dgl.Vehicle_Name = rdr[1].ToString();
                    dgl.Vehicle_Type = rdr[2].ToString();
                    dgl.Vehicle_Speed = Convert.ToInt32(rdr[3].ToString());
                    dgl.Friend_Or_Enemy = rdr[4].ToString();
                    DataGridListVehicle.Add(dgl);

                }
                return DataGridListVehicle;
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
        public List<StrategyList> StrategyList()
        {
            con = new SqlConnection("Data Source=DESKTOP-OAC4TCU\\SQLEXPRESS;Initial Catalog=war_simulation;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                List<StrategyList> strategyList = new List<StrategyList>();

                cmd.CommandText = "Select * from Strategies";

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StrategyList sl = new StrategyList();

                    sl.Id = Convert.ToInt16(rdr[0]);
                    sl.Strategy_With_Ids = rdr[1].ToString();
                    strategyList.Add(sl);

                }
                return strategyList;

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
        public void Add(VehicleAdd va)
        {
            try
            {
                cmd.CommandText = "Insert Into Vehicle_Information(Vehicle_Name,Vehicle_Type,Vehicle_Speed,Target_Latitude,Target_Longitude,Instant_Latitude,Instant_Longitude,Vehicle_Direction" +
                    ",Ammo_List,Friend_Or_Enemy,Active_Or_Passive,Uri_Link) Values (@vehicle_name,@vehicle_type,@vehicle_speed,@target_latitude,@target_longitude,@instant_latitude,@instant_longitude" +
                    ",@vehicle_direction,@ammo_list,@friend_or_enemy,@active_or_passive,@Uri_Link)";
                cmd.Parameters.AddWithValue("@vehicle_name", va.Vehicle_Name);
                cmd.Parameters.AddWithValue("@vehicle_type", va.Vehicle_Type);
                cmd.Parameters.AddWithValue("@vehicle_speed", va.Vehicle_Speed);
                cmd.Parameters.AddWithValue("@target_latitude", va.Target_Latitude);
                cmd.Parameters.AddWithValue("@target_longitude", va.Target_Longitude);
                cmd.Parameters.AddWithValue("@instant_latitude", va.Instant_Latitude);
                cmd.Parameters.AddWithValue("@instant_longitude", va.Instant_Longitude);
                cmd.Parameters.AddWithValue("@vehicle_direction", va.Vehicle_Direction);
                cmd.Parameters.AddWithValue("@ammo_list", va.Ammo_List);
                cmd.Parameters.AddWithValue("@friend_or_enemy", va.Friend_Or_Enemy);
                cmd.Parameters.AddWithValue("@active_or_passive", va.Active_Or_Passive);
                cmd.Parameters.AddWithValue("@Uri_Link", va.Uri_Link);
                cmd.CommandType = CommandType.Text;
                con.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Ekleme işleminiz başarıyla tamamlandı","Eklendi",MessageBoxButton.OK,MessageBoxImage.Information);
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
        
        public int getId(string getVehicle_Name,double getTarget_Latitude,double getInstant_Latitude)
        {
            int tempId = 0;

            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select ID,Vehicle_Name from Vehicle_Information where Vehicle_Name=@vehicle_name and (Target_Latitude=@target_latitude and Instant_Latitude=@instant_latitude)";
            cmd.Parameters.AddWithValue("@vehicle_name", getVehicle_Name);
            cmd.Parameters.AddWithValue("@target_latitude", getTarget_Latitude);
            cmd.Parameters.AddWithValue("@instant_latitude", getInstant_Latitude);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tempId = Convert.ToInt32(rdr[0]);
                //a = rdr[1].ToString();
            }
            con.Close();

            return tempId;
        }

        public void Delete(int getId)
        {
            try
            {
                cmd.CommandText = "Delete from Vehicle_Information where ID=@id";
                cmd.Parameters.AddWithValue("@id", getId);
                cmd.CommandType = CommandType.Text;
                con.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Silme işleminiz başarıyla tamamlandı", "Silindi", MessageBoxButton.OK, MessageBoxImage.Information);
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
        public void Update(int getId,int getSpeed,double getTargetLatitude, double getTargetLongitude)
        {
            try
            {
                cmd.CommandText = "Update Vehicle_Information set Vehicle_Speed=@vehicle_speed,Target_Latitude=@target_latitude,Target_Longitude=@target_longitude where ID=@id";
                cmd.Parameters.AddWithValue("@id", getId);
                cmd.Parameters.AddWithValue("@vehicle_speed", getSpeed);
                cmd.Parameters.AddWithValue("@target_latitude", getTargetLatitude);
                cmd.Parameters.AddWithValue("@target_longitude", getTargetLongitude);

                cmd.CommandType = CommandType.Text;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Güncelleme işleminiz başarıyla tamamlandı", "Güncellendi", MessageBoxButton.OK, MessageBoxImage.Information);
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
        public void ActivePassiveUpdate()
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandText = "Update Vehicle_Information set Active_Or_Passive=@active_or_passive";

                cmd.Parameters.AddWithValue("@active_or_passive", "Passive");
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
    }
}
