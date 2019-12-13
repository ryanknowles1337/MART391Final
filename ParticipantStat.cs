using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class ParticipantStat
    {
        public int StatID { get; set; }
        public string Winner { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int GoldSpent { get; set; }
        public int GoldEarned { get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public int TotalDamageDealt { get; set; }
        public int PhysicalDamageTaken { get; set; }
        public int PhysicalDamageDealtToChampions { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int MagicDamageTaken { get; set; }
        public int MagicDamageDealtToChampions { get; set; }
        public int MagicDamageDealt { get; set; }
        public int TrueDamageTaken { get; set; }
        public int TrueDamageDealtToChampions { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TotalHeal { get; set; }
        public int TotalTimeCrowdControlDealt { get; set; }
        public int WardsPlaced { get; set; }
        public int WardsKilled { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int VisionScore { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int TowerKills { get; set; }
        public int InhibitorKills { get; set; }
        public bool FirstTowerKill { get; set; }
        public bool FirstTowerAssist { get; set; }
        public bool FirstInhibitorKill { get; set; }
        public bool FirstInhibitorAssist { get; set; }
        public bool FirstBloodKill { get; set; }
        public bool FirstBloodAssist { get; set; }
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }
        public int UnrealKills { get; set; }
        public int KillingSprees { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int NeutralMinionsKilledEnemyJungle { get; set; }
        public int NeutralMinionsKilledJungle { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int ParticipantID { get; set; }
        public long Deaths { get; set; }
        public long ChampionLevel { get; set; }

        public ParticipantStat(int statID, string winner,int kills,int assists,int goldSpent, int goldEarned, int totalDamageTaken,
            int totalDamageDealt, int physicalDamageTaken, int physicalDamageDealtToChampions, int physicalDamageDealt, int magicDamageTaken,
            int magicDamageDealtToChampions, int magicDamageDealt, int trueDamageTaken, int trueDamageDealtToChampions, int trueDamageDealt,
            int totalUnitsHealed, int totalHeal, int totalTimeCrowdControlDealt, int wardsPlaced, int wardsKilled, int visionWardsBoughtInGame,
            int visionScore, int sightWardsBoughtInGame, int towerKills, int inhibitorKills, bool firstTowerKill, bool firstTowerAssist, bool firstInhibitorKill,
            bool firstInhibitorAssist, bool firstBloodKill, bool firstBloodAssist, int doubleKills, int tripleKills, int quadraKills, int pentaKills,
            int unrealKills, int killingSprees, int largestKillingSpree, int largestCriticalStrike, int neutralMinionsKilledEnemyJungle,
            int neutralMinionsKilledJungle, int totalMinionsKilled, int participantID, long deaths, long championLevel)
        {
            StatID = statID;
            Winner = winner;
            Kills = kills;
            Assists = assists;
            GoldSpent = goldSpent;
            GoldEarned = goldEarned;
            TotalDamageTaken = totalDamageTaken;
            TotalDamageDealt = totalDamageDealt;
            PhysicalDamageTaken = physicalDamageTaken;
            PhysicalDamageDealtToChampions = physicalDamageDealtToChampions;
            PhysicalDamageDealt = physicalDamageDealt;
            MagicDamageTaken = magicDamageTaken;
            MagicDamageDealtToChampions = magicDamageDealtToChampions;
            MagicDamageDealt = magicDamageDealt;
            TrueDamageTaken = trueDamageTaken;
            TrueDamageDealtToChampions = trueDamageDealtToChampions;
            TrueDamageDealt = trueDamageDealt;
            TotalUnitsHealed = totalUnitsHealed;
            TotalHeal = totalHeal;
            TotalTimeCrowdControlDealt = totalTimeCrowdControlDealt;
            WardsPlaced = wardsPlaced;
            WardsKilled = wardsKilled;
            VisionWardsBoughtInGame = visionWardsBoughtInGame;
            VisionScore = visionScore;
            SightWardsBoughtInGame = sightWardsBoughtInGame;
            TowerKills = towerKills;
            InhibitorKills = inhibitorKills;
            FirstTowerKill = firstTowerKill;
            FirstTowerAssist = firstTowerAssist;
            FirstInhibitorKill = firstInhibitorKill;
            FirstInhibitorAssist = firstInhibitorAssist;
            FirstBloodKill = firstBloodKill;
            FirstBloodAssist = firstBloodAssist;
            DoubleKills = doubleKills;
            TripleKills = tripleKills;
            QuadraKills = quadraKills;
            PentaKills = pentaKills;
            UnrealKills = unrealKills;
            KillingSprees = killingSprees;
            LargestKillingSpree = largestKillingSpree;
            LargestCriticalStrike = largestCriticalStrike;
            NeutralMinionsKilledEnemyJungle = neutralMinionsKilledEnemyJungle;
            NeutralMinionsKilledJungle = neutralMinionsKilledJungle;
            TotalMinionsKilled = totalMinionsKilled;
            ParticipantID = participantID;
            Deaths = deaths;
            ChampionLevel = ChampionLevel;
        }

        public ParticipantStat() { }
    }
}