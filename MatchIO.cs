using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class MatchIO
    {
        private readonly DBIO dBManager = new DBIO();
        public int InsertMatch(LAMatch match)
        {
            string query = "spInsertMatch";

            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = new SqlParameter("MatchID", match.MatchID);
            parameters[1] = new SqlParameter("RegionID", match.RegionID);
            parameters[2] = new SqlParameter("DatePlayed", match.DatePlayed);
            parameters[3] = new SqlParameter("DurationSeconds", match.DurationSeconds);
            parameters[4] = new SqlParameter("SeasonID", match.SeasonID);
            parameters[5] = new SqlParameter("GameVersion", match.GameVersion);
            parameters[6] = new SqlParameter("GameMode", match.GameMode);
            parameters[7] = new SqlParameter("GameType", match.GameType);
            parameters[8] = new SqlParameter("MapID", match.MapID);
            int rows = dBManager.ExecuteNonQuery(query, parameters);
            return rows;
        }

        public LAMatch GetMatchByID(int matchID)
        {
            string query = "spGetMatch";
            LAMatch match = new LAMatch();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("MatchID", matchID);
            DataSet dataset = dBManager.CreateDataSet(query,parameters);
            match.MatchID = (long)dataset.Tables[0].Rows[0]["MatchID"];
            match.RegionID = (int)dataset.Tables[0].Rows[0]["RegionID"];
            match.DatePlayed = (DateTime)dataset.Tables[0].Rows[0]["DatePlayed"];
            match.DurationSeconds = (double)dataset.Tables[0].Rows[0]["DurationSeconds"];
            match.SeasonID = (int)dataset.Tables[0].Rows[0]["SeasonID"];
            match.GameVersion = dataset.Tables[0].Rows[0]["GameVersion"].ToString();
            match.GameMode = dataset.Tables[0].Rows[0]["GameMode"].ToString();
            match.GameType = dataset.Tables[0].Rows[0]["GameType"].ToString();
            match.MapID = (int)dataset.Tables[0].Rows[0]["MapID"];
            return match;
        }

        public List<LAMatch> GetMatchesBySummonerID(string summonerID)
        {
            string query = "spGetMatchesBySummonerID";
            List<LAMatch> matches = new List<LAMatch>();
            LAMatch match;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerID", summonerID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            // TODO: 
            // Decide on an appropriate number of matches to retrieve
            int datasetlen = dataset.Tables[0].Rows.Count; 
            int len = 20;
            if(datasetlen <= len) { len = datasetlen; }
            for(int x = 0; x < len; x++)
            {
                match = new LAMatch()
                {
                    MatchID = (long)dataset.Tables[0].Rows[x]["MatchID"],
                    RegionID = (int)dataset.Tables[0].Rows[x]["RegionID"],
                    DatePlayed = (DateTime)dataset.Tables[0].Rows[x]["DatePlayed"],
                    DurationSeconds = (double)dataset.Tables[0].Rows[x]["DurationSeconds"],
                    SeasonID = (int)dataset.Tables[0].Rows[x]["SeasonID"],
                    GameVersion = dataset.Tables[0].Rows[x]["GameVersion"].ToString(),
                    GameMode = dataset.Tables[0].Rows[x]["GameMode"].ToString(),
                    GameType = dataset.Tables[0].Rows[x]["GameType"].ToString(),
                    MapID = (int)dataset.Tables[0].Rows[x]["MapID"],
                };
                matches.Add(match);
            }

            return matches;
        }

        public bool MatchExists(long matchID)
        {
            string query = "spGetMatch";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("MatchID", matchID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);

            if (dataset.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else // There is a matching summoner in the DB 
            {
                return true;
            }
        }
    }
}