using MART391TestApp3.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3
{
    public class ChampionManager
    {
        private readonly ChampionIO champIO = new ChampionIO();
        public ChampionManager() { }

        public List<ChampionStats> GetSummonerChampionWinPercentages(string summonerName)
        {
            List<ChampionStats> champStats = new List<ChampionStats>();
            List<Tuple<string, string, int, int, int>> champPerfBySummoner = champIO.GetChampionWinLossBySummonerName(summonerName);
            foreach(Tuple<string, string, int, int, int> champPerf in champPerfBySummoner)
            {
                bool champFound = false;
                // Iterate over the current stats to make sure the champion is not already added
                for(int x = 0; x < champStats.Count; x++)
                {
                    if(champStats[x].IsChampion(champPerf.Item1)) // Champ matches
                    {
                        // Checking win loss
                        if(champPerf.Item2.Equals("True")) // True = Win
                        {
                            champStats[x].TotalWins += 1;
                        } else // False = Loss
                        {
                            champStats[x].TotalLosses += 1;
                        }
                        champStats[x].Kills += champPerf.Item3;
                        champStats[x].Deaths += champPerf.Item4;
                        champStats[x].Assists += champPerf.Item5;
                        champFound = true;
                    }
                }
                // If they aren't found in the list, add them
                // Annoyingly I might add
                if(!champFound)
                {
                    int win = 0;
                    int loss = 0;
                    if(champPerf.Item3.Equals("True"))
                    {
                        win += 1;
                    } else
                    {
                        loss += 1;
                    }
                    champStats.Add(new ChampionStats(champPerf.Item1, win, loss, champPerf.Item3, champPerf.Item4, champPerf.Item5));
                }
            }

            return champStats;
        }

        public Tuple<string, int> GetMostPlayedChampion(string summonerName)
        {
            return champIO.GetMostPlayedChampion(summonerName);
        }
    }
}