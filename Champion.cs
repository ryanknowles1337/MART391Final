using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class Champion
    {
        public int ChampionID { get; set; }
        public string ChampionName { get; set; }

        public Champion(int id, string name)
        {
            ChampionID = id;
            ChampionName = name;
        }
    }
}