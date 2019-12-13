using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class Summoner
    {
        public string SummonerID { get; set; }
        public string SummonerName { get; set; }
        public string AccountID { get; set; }
        public int ProfileIconID { get; set; }

        public Summoner(string summonerID, string summonerName, string accountID, int profileIconID)
        {
            SummonerID = summonerID;
            SummonerName = summonerName;
            AccountID = accountID;
            ProfileIconID = profileIconID;
        }

        public Summoner() { }

        public override string ToString()
        {
            return "Summoner ID: " + SummonerID + " Name: " + SummonerName + " Account ID: " + AccountID + " Icon ID: " + ProfileIconID;
        }
    }
}