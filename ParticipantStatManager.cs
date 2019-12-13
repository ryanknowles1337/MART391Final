using MART391TestApp3.App_Code;
using RiotSharp.Endpoints.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3
{
    public class ParticipantStatManager
    {
        private readonly ParticipantStatIO statIO = new ParticipantStatIO();
        public ParticipantStatManager() { }

        public ParticipantStat GetParticipantStat(Match match, MatchParticipant participant, int participantNum, int id)
        {
            
            ParticipantStat stats = new ParticipantStat();
            // StatID needs to be pulled
            stats.Winner = match.Participants[participantNum].Stats.Winner.ToString(); //Oops
            stats.Kills = (int)match.Participants[participantNum].Stats.Kills; // This is a long?
            stats.Assists = (int)match.Participants[participantNum].Stats.Assists; // Why are all of these longs...
            stats.GoldSpent = (int)match.Participants[participantNum].Stats.GoldSpent;
            stats.GoldEarned = (int)match.Participants[participantNum].Stats.GoldEarned;
            stats.TotalDamageTaken = (int)match.Participants[participantNum].Stats.TotalDamageTaken;
            stats.TotalDamageDealtToChampions = (int)match.Participants[participantNum].Stats.TotalDamageDealtToChampions;
            stats.TotalDamageDealt = (int)match.Participants[participantNum].Stats.TotalDamageDealt;
            stats.PhysicalDamageTaken = (int)match.Participants[participantNum].Stats.PhysicalDamageTaken;
            stats.PhysicalDamageDealtToChampions = (int)match.Participants[participantNum].Stats.PhysicalDamageDealtToChampions;
            stats.PhysicalDamageDealt = (int)match.Participants[participantNum].Stats.PhysicalDamageDealt;
            stats.MagicDamageTaken = (int)match.Participants[participantNum].Stats.MagicDamageTaken;
            stats.MagicDamageDealtToChampions = (int)match.Participants[participantNum].Stats.MagicDamageDealtToChampions;
            stats.MagicDamageDealt = (int)match.Participants[participantNum].Stats.MagicDamageDealt;
            stats.TrueDamageTaken = (int)match.Participants[participantNum].Stats.TrueDamageTaken;
            stats.TrueDamageDealtToChampions = (int)match.Participants[participantNum].Stats.TrueDamageDealtToChampions;
            stats.TrueDamageDealt = (int)match.Participants[participantNum].Stats.TrueDamageDealt;
            stats.TotalUnitsHealed = (int)match.Participants[participantNum].Stats.TotalUnitsHealed;
            stats.TotalHeal = (int)match.Participants[participantNum].Stats.TotalHeal;
            stats.TotalTimeCrowdControlDealt = (int)match.Participants[participantNum].Stats.TotalTimeCrowdControlDealt;
            stats.WardsPlaced = (int)match.Participants[participantNum].Stats.WardsPlaced;
            stats.WardsKilled = (int)match.Participants[participantNum].Stats.WardsKilled;
            stats.VisionWardsBoughtInGame = (int)match.Participants[participantNum].Stats.VisionWardsBoughtInGame;
            stats.VisionScore = (int)match.Participants[participantNum].Stats.VisionScore;
            stats.SightWardsBoughtInGame = (int)match.Participants[participantNum].Stats.SightWardsBoughtInGame;
            stats.TowerKills = (int)match.Participants[participantNum].Stats.TowerKills;
            stats.InhibitorKills = (int)match.Participants[participantNum].Stats.InhibitorKills;
            stats.FirstTowerKill = match.Participants[participantNum].Stats.FirstTowerKill;
            stats.FirstTowerAssist = match.Participants[participantNum].Stats.FirstTowerAssist;
            stats.FirstInhibitorKill = match.Participants[participantNum].Stats.FirstInhibitorKill;
            stats.FirstInhibitorAssist = match.Participants[participantNum].Stats.FirstInhibitorAssist;
            stats.FirstBloodKill = match.Participants[participantNum].Stats.FirstBloodKill;
            stats.FirstBloodAssist = match.Participants[participantNum].Stats.FirstBloodAssist;
            stats.DoubleKills = (int)match.Participants[participantNum].Stats.DoubleKills;
            stats.TripleKills = (int)match.Participants[participantNum].Stats.TripleKills;
            stats.QuadraKills = (int)match.Participants[participantNum].Stats.QuadraKills;
            stats.PentaKills = (int)match.Participants[participantNum].Stats.PentaKills;
            stats.UnrealKills = (int)match.Participants[participantNum].Stats.UnrealKills;
            stats.KillingSprees = (int)match.Participants[participantNum].Stats.KillingSprees;
            stats.LargestKillingSpree = (int)match.Participants[participantNum].Stats.LargestKillingSpree;
            stats.LargestCriticalStrike = (int)match.Participants[participantNum].Stats.LargestCriticalStrike;
            stats.NeutralMinionsKilledEnemyJungle = (int)match.Participants[participantNum].Stats.NeutralMinionsKilledEnemyJungle;
            stats.NeutralMinionsKilledJungle = (int)match.Participants[participantNum].Stats.NeutralMinionsKilledJungle;
            stats.TotalMinionsKilled = (int)match.Participants[participantNum].Stats.TotalMinionsKilled;
            stats.ParticipantID = id;
            stats.Deaths = match.Participants[participantNum].Stats.Deaths;
            stats.ChampionLevel = match.Participants[participantNum].Stats.ChampLevel;

            // TODO:
            // The stat io
            stats.StatID = statIO.InsertParticipantStat(stats); 
            return stats;
        }


        public List<Tuple<string, int>> GetGoldEarnedByChampionByMatch(string summonerName)
        {
            return statIO.GetGoldEarnedByMatch(summonerName);
        }
    }
}