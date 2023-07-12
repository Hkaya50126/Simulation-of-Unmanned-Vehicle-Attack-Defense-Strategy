using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarpSimulasyonuWPF.Classes
{
    class DatagridList
    {
        int _Id;
        int _Vehicle_Speed;  
        string _Friend_Or_Enemy;
        string _Vehicle_Name;
        string _Vehicle_Type;

        public int Id { get { return _Id; } set { _Id = value; } }
        public string Vehicle_Name { get { return _Vehicle_Name; } set { _Vehicle_Name = value; } }
        public string Vehicle_Type { get { return _Vehicle_Type; } set { _Vehicle_Type = value; } }
        public int Vehicle_Speed { get { return _Vehicle_Speed; } set { _Vehicle_Speed = value; } }
        public string Friend_Or_Enemy { get { return _Friend_Or_Enemy; } set { _Friend_Or_Enemy = value; } }
    }
}
