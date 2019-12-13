using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
// Summary:
// Might delete this later
namespace MART391TestApp3.App_Code
{
    public class ChampionStats
    {

        public String ChampionName { get; set; }
        public int TotalWins { get; set; } = 0;
        public int TotalLosses { get; set; } = 0;
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public double KDA { get; set; }
        public ChampionStats() { }
        
        public ChampionStats(string championName, int totalWins, int totalLosses, int kills, int deaths, int assists)
        {
            ChampionName = championName;
            TotalWins = totalWins;
            TotalLosses = totalLosses;
            Kills = kills;
            Deaths = deaths;
            Assists = assists;
            KDA = GetKDA();
        }

        public bool IsChampion(string champName)
        {
            if (ChampionName.Equals(champName)) return true;
            else return false;
        } 

        public int GetTotalGames()
        {
            return TotalWins + TotalLosses;
        }

        public double GetKDA()
        {
            if(Deaths != 0)
            {
                KDA = (1.00 * (Kills + Assists)) / Deaths;
            } else
            {
                KDA = (1.00 * (Kills + Assists));
            }
            
            return KDA;
        }
    }
}