using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class SummonerIO
    {
        private readonly DBIO dBManager = new DBIO();
        //private readonly MatchManager matchManager = new MatchManager();

        public int InsertSummoner(Summoner summoner)
        {
            string query = "spInsertSummoner";

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("SummonerID", summoner.SummonerID);
            parameters[1] = new SqlParameter("SummonerName", summoner.SummonerName);
            parameters[2] = new SqlParameter("AccountID", summoner.AccountID);
            parameters[3] = new SqlParameter("ProfileIconID", summoner.ProfileIconID);
            int rows = dBManager.ExecuteNonQuery(query, parameters);
            return rows;
        }

        public Summoner GetSummonerByID(string summonerID)
        {
            string query = "spGetSummoner";
            Summoner summoner = new Summoner();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerID", summonerID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            summoner.SummonerID = dataset.Tables[0].Rows[0]["SummonerID"].ToString();
            summoner.SummonerName = dataset.Tables[0].Rows[0]["SummonerName"].ToString();
            summoner.AccountID = dataset.Tables[0].Rows[0]["AccountID"].ToString();
            summoner.ProfileIconID = (int)dataset.Tables[0].Rows[0]["ProfileIconID"];

            return summoner;
        }

        public Summoner GetSummonerByName(string summonerName)
        {
            string query = "spGetSummonerByName";
            Summoner summoner = new Summoner();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerName", summonerName);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            summoner.SummonerID = dataset.Tables[0].Rows[0]["SummonerID"].ToString();
            summoner.SummonerName = dataset.Tables[0].Rows[0]["SummonerName"].ToString();
            summoner.AccountID = dataset.Tables[0].Rows[0]["AccountID"].ToString();
            summoner.ProfileIconID = (int)dataset.Tables[0].Rows[0]["ProfileIconID"];

            return summoner;
        }

        public bool SummonerExists(string summonerID)
        {
            string query = "spGetSummoner";
            //string result = "None";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("SummonerID", summonerID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            
            // This would mean that there is no matching summoner in the DB
            if(dataset.Tables[0].Rows.Count == 0)
            {
                return false;
            } else // There is a matching summoner in the DB 
            {
                return true;
            }
        }
    }
}