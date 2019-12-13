using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class LAMatch
    {
        public long MatchID { get; set; }
        public int RegionID { get; set; }
        public DateTime DatePlayed { get; set; }
        public double DurationSeconds { get; set; }
        public int SeasonID { get; set; }
        public string GameVersion { get; set; }
        public string GameMode { get; set; }
        public string GameType { get; set; }
        public int MapID { get; set; }

        public LAMatch(long matchID, int regionID, DateTime datePlayed, double durationSeconds, int seasonID,
            string gameVersion, string gameMode, string gameType, int mapID)
        {
            MatchID = matchID;
            RegionID = regionID;
            DatePlayed = datePlayed;
            DurationSeconds = durationSeconds;
            SeasonID = seasonID;
            GameVersion = gameVersion;
            GameMode = gameVersion;
            GameType = gameType;
            MapID = mapID;
        }

        public LAMatch() { }

        public override string ToString()
        {
            TimeSpan time = TimeSpan.FromSeconds(DurationSeconds); //Not perfect, but hey
            return "MatchID: " + MatchID + " Date: "+ DatePlayed + " Duration: " + time + "<br />";
        }
    }
}