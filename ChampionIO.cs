using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MART391TestApp3.App_Code;

namespace MART391TestApp3
{
    public class ChampionIO
    {
        DBIO dbManager = new DBIO();

        //This should ONLY be called when a new champion is released
        public int InsertChampion(Champion newChamp)
        {
            // This was auto generated?
            if (newChamp is null)
            {
                throw new ArgumentNullException(nameof(newChamp));
            }

            string query = "spInsertChampion";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("ChampionID", newChamp.ChampionID);
            parameters[1] = new SqlParameter("ChampionName", newChamp.ChampionName);
            int rows = dbManager.ExecuteNonQuery(query, parameters);
            return rows;
        }
        public List<Tuple<string, string, string, int, int, int>> GetChampionWinLossBySummonerID(int summonerID)
        {
            string query = "spGetChampionWinLossBySummonerID";
            Tuple<string, string, string, int, int, int> champWL;
            List<Tuple<string, string, string, int, int, int>> champs = new List<Tuple<string, string, string, int, int, int>>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerID",summonerID);
            DataSet dataset = dbManager.CreateDataSet(query, parameters);
            int datasetlen = dataset.Tables[0].Rows.Count;

            for (int x = 0; x < datasetlen; x++) {
                string summonerName = dataset.Tables[0].Rows[x]["SummonerName"].ToString();
                string champName = dataset.Tables[0].Rows[x]["ChampionName"].ToString();
                string winner = dataset.Tables[0].Rows[x]["Winner"].ToString();
                int kills = Int32.Parse(dataset.Tables[0].Rows[x]["Kills"].ToString());
                int deaths = Int32.Parse(dataset.Tables[0].Rows[x]["Deaths"].ToString());
                int assists = Int32.Parse(dataset.Tables[0].Rows[x]["Assists"].ToString());
                champWL = Tuple.Create(summonerName, champName, winner, kills, deaths, assists);
                champs.Add(champWL);
            }
            return champs;
        }

        public List<Tuple<string, string, int, int, int>> GetChampionWinLossBySummonerName(string name)
        {
            string query = "spGetChampionWinLossBySummonerName";
            Tuple<string, string, int, int, int> champTuple;
            List<Tuple<string, string, int, int, int>> champs = new List<Tuple<string, string, int, int, int>>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerName", name);
            DataSet dataset = dbManager.CreateDataSet(query, parameters);
            int datasetlen = dataset.Tables[0].Rows.Count;

            for (int x = 0; x < datasetlen; x++)
            {
                //string summonerName = dataset.Tables[0].Rows[x]["SummonerName"].ToString();
                string champName = dataset.Tables[0].Rows[x]["ChampionName"].ToString();
                string winner = dataset.Tables[0].Rows[x]["Winner"].ToString();
                int kills = Int32.Parse(dataset.Tables[0].Rows[x]["Kills"].ToString());
                int deaths = Int32.Parse(dataset.Tables[0].Rows[x]["Deaths"].ToString());
                int assists = Int32.Parse(dataset.Tables[0].Rows[x]["Assists"].ToString());
                champTuple = Tuple.Create(champName, winner, kills, deaths, assists);
                champs.Add(champTuple);
            }
            return champs;
        }

        public Tuple<string, int> GetMostPlayedChampion(string summonerName)
        {
            string query = "spGetMostPlayedChampionBySummonerName";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerName", summonerName);
            DataSet dataset = dbManager.CreateDataSet(query, parameters);

            //Pulling the first row as it is ordered from most to least played
            string champion = dataset.Tables[0].Rows[0]["ChampionName"].ToString();
            int timesPlayed = (int)dataset.Tables[0].Rows[0]["TimesPlayed"];
            Tuple<string, int> tuple = Tuple.Create(champion, timesPlayed);

            return tuple;
        }

    }
}