using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarpSimulasyonuWPF.Classes
{
    class VehicleAdd
    {
        int     _Vehicle_Speed;
        double  _Target_Latitude;
        double  _Target_Longitude;
        double  _Instant_Latitude;
        double  _Instant_Longitude;
        string  _Vehicle_Direction;
        string  _Ammo_List;
        string  _Friend_Or_Enemy;
        string  _Vehicle_Name;
        string  _Vehicle_Type;
        string  _Active_Or_Passive;
        string  _Uri_Link;

        
        public string Vehicle_Name { get { return _Vehicle_Name; } set { _Vehicle_Name = value; } }
        public string Vehicle_Type { get { return _Vehicle_Type; } set { _Vehicle_Type = value; } }
        public int Vehicle_Speed { get { return _Vehicle_Speed; } set { _Vehicle_Speed = value; } }
        public double Target_Latitude { get { return _Target_Latitude; } set { _Target_Latitude = value; } }
        public double Target_Longitude { get { return _Target_Longitude; } set { _Target_Longitude = value; } }
        public double Instant_Latitude { get { return _Instant_Latitude; } set { _Instant_Latitude = value; } }
        public double Instant_Longitude { get { return _Instant_Longitude; } set { _Instant_Longitude = value; } }
        public string Vehicle_Direction { get { return _Vehicle_Direction; } set { _Vehicle_Direction = value; } }
        public string Ammo_List { get { return _Ammo_List; } set { _Ammo_List = value; } }
        public string Friend_Or_Enemy { get { return _Friend_Or_Enemy; } set { _Friend_Or_Enemy = value; } }
        public string Active_Or_Passive { get { return _Active_Or_Passive; } set { _Active_Or_Passive = value; } }
        public string Uri_Link { get { return _Uri_Link; } set { _Uri_Link = value; } }
    }
}
