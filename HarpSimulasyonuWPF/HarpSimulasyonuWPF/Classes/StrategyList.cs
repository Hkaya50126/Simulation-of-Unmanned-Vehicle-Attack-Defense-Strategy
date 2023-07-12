using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarpSimulasyonuWPF.Classes
{
     class StrategyList
    {
        int _Id;
        string _Strategy_With_Ids;

        public int Id { get { return _Id; } set { _Id = value; } }
        public string Strategy_With_Ids { get { return _Strategy_With_Ids; } set { _Strategy_With_Ids = value; } }

    }
}
