using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{

    public class ParticipantStatIO
    {
        // TODO: Finish
        // Also write the huge stored procedure for this :(
        private readonly DBIO dbIO = new DBIO();
        public int InsertParticipantStat(ParticipantStat stat)
        {
            string query = "spInsertParticipantStat";

            SqlParameter[] parameters = new SqlParameter[48];
            parameters[0] = new SqlParameter("StatID", stat.StatID);
            parameters[1] = new SqlParameter("Winner", stat.Winner);
            parameters[2] = new SqlParameter("Kills", stat.Kills);
            parameters[3] = new SqlParameter("Assists", stat.Assists);
            parameters[4] = new SqlParameter("GoldSpent", stat.GoldSpent);
            parameters[5] = new SqlParameter("GoldEarned", stat.GoldEarned);
            parameters[6] = new SqlParameter("TotalDamageTaken", stat.TotalDamageTaken);
            parameters[7] = new SqlParameter("TotalDamageDealtToChampions", stat.TotalDamageDealtToChampions);
            parameters[8] = new SqlParameter("TotalDamageDealt", stat.TotalDamageDealt);
            parameters[9] = new SqlParameter("PhysicalDamageTaken", stat.PhysicalDamageTaken);
            parameters[10] = new SqlParameter("PhysicalDamageDealtToChampions", stat.PhysicalDamageDealtToChampions);
            parameters[11] = new SqlParameter("PhysicalDamageDealt", stat.PhysicalDamageDealt);
            parameters[12] = new SqlParameter("MagicDamageTaken", stat.MagicDamageTaken);
            parameters[13] = new SqlParameter("MagicDamageDealtToChampions", stat.MagicDamageDealtToChampions);
            parameters[14] = new SqlParameter("MagicDamageDealt", stat.MagicDamageDealt);
            parameters[15] = new SqlParameter("TrueDamageTaken", stat.TrueDamageTaken);
            parameters[16] = new SqlParameter("TrueDamageDealtToChampions", stat.TrueDamageDealtToChampions);
            parameters[17] = new SqlParameter("TrueDamageDealt", stat.TrueDamageDealt);
            parameters[18] = new SqlParameter("TotalUnitsHealed", stat.TotalUnitsHealed);
            parameters[19] = new SqlParameter("TotalHeal", stat.TotalHeal);
            parameters[20] = new SqlParameter("TotalTimeCrowdControlDealt", stat.TotalTimeCrowdControlDealt);
            parameters[21] = new SqlParameter("WardsPlaced", stat.WardsPlaced);
            parameters[22] = new SqlParameter("WardsKilled", stat.WardsKilled);
            parameters[23] = new SqlParameter("VisionWardsBoughtInGame", stat.VisionWardsBoughtInGame);
            parameters[24] = new SqlParameter("VisionScore", stat.VisionScore);
            parameters[25] = new SqlParameter("SightWardsBoughtInGame", stat.SightWardsBoughtInGame);
            parameters[26] = new SqlParameter("TowerKills", stat.TowerKills);
            parameters[27] = new SqlParameter("InhibitorKills", stat.InhibitorKills);
            parameters[28] = new SqlParameter("FirstTowerKill", stat.FirstTowerKill);
            parameters[29] = new SqlParameter("FirstTowerAssist", stat.FirstTowerAssist);
            parameters[30] = new SqlParameter("FirstInhibitorKill", stat.FirstInhibitorKill);
            parameters[31] = new SqlParameter("FirstInhibitorAssist", stat.FirstInhibitorAssist);
            parameters[32] = new SqlParameter("FirstBloodKill", stat.FirstBloodKill);
            parameters[33] = new SqlParameter("FirstBloodAssist", stat.FirstBloodAssist);
            parameters[34] = new SqlParameter("DoubleKills", stat.DoubleKills);
            parameters[35] = new SqlParameter("TripleKills", stat.TripleKills);
            parameters[36] = new SqlParameter("QuadraKills", stat.QuadraKills);
            parameters[37] = new SqlParameter("PentaKills", stat.PentaKills);
            parameters[38] = new SqlParameter("UnrealKills", stat.UnrealKills);
            parameters[39] = new SqlParameter("KillingSprees", stat.KillingSprees);
            parameters[40] = new SqlParameter("LargestKillingSpree", stat.LargestKillingSpree);
            parameters[41] = new SqlParameter("LargestCriticalStrike", stat.LargestCriticalStrike);
            parameters[42] = new SqlParameter("NeutralMinionsKilledEnemyJungle", stat.NeutralMinionsKilledEnemyJungle);
            parameters[43] = new SqlParameter("NeutralMinionsKilledJungle", stat.NeutralMinionsKilledJungle);
            parameters[44] = new SqlParameter("TotalMinionsKilled", stat.TotalMinionsKilled);
            parameters[45] = new SqlParameter("ParticipantID", stat.ParticipantID);
            parameters[46] = new SqlParameter("Deaths", stat.Deaths);
            parameters[47] = new SqlParameter("ChampionLevel", stat.ChampionLevel);
            int rows = dbIO.ExecuteNonQuery(query, parameters);
            return rows;
        }

        public ParticipantStat GetParticipantStatsByID()
        {
            ParticipantStat stats = new ParticipantStat();

            return stats;
        }

        public List<Tuple<string, int>> GetGoldEarnedByMatch(string summonerName)
        {
            string query = "spGetGoldEarnedByMatch";
            List<Tuple<string, int>> goldValues = new List<Tuple<string, int>>();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerName", summonerName);
            DataSet dataset = dbIO.CreateDataSet(query, parameters);
            int datasetlen = dataset.Tables[0].Rows.Count;
            for (int x = 0; x < datasetlen; x++)
            {
                string champ = dataset.Tables[0].Rows[x]["ChampionName"].ToString();
                int gold = (int)dataset.Tables[0].Rows[x]["GoldEarned"];
                Tuple<string, int> goldValue = Tuple.Create(champ, gold);

                goldValues.Add(goldValue);
            }

            return goldValues;
        }
    }
}