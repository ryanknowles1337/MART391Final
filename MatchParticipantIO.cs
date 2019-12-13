using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class MatchParticipantIO
    {
        private readonly DBIO dBManager = new DBIO();
        public int InsertMatchParticipant(MatchParticipant newParticipant)
        {
            string query = "spInsertMatchParticipant";
            //RiotSharp.Endpoints.MatchEndpoint.Match mymatch; //just testing
            //mymatch.ParticipantIdentities[0].Player. //just testing
            SqlParameter[] parameters = new SqlParameter[6];
            //parameters[0] = new SqlParameter("ParticipantID", newParticipant.ParticipantID);
            parameters[0] = new SqlParameter("MatchID", newParticipant.MatchID);
            parameters[1] = new SqlParameter("SummonerID", newParticipant.SummonerID);
            parameters[2] = new SqlParameter("ChampionID", newParticipant.ChampionID);
            parameters[3] = new SqlParameter("TeamID", newParticipant.TeamID);
            parameters[4] = new SqlParameter("Spell1ID", newParticipant.Spell1ID);
            parameters[5] = new SqlParameter("Spell2ID", newParticipant.Spell2ID);
            int rows = dBManager.ExecuteNonQuery(query,parameters);
            return rows;
        }

        public MatchParticipant GetMatchParticipantByID(int participantID)
        {
            string query = "spGetMatchParticipant";
            MatchParticipant participant = new MatchParticipant();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter();
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            participant.ParticipantID = (int)dataset.Tables[0].Rows[0]["ParticipantID"];
            participant.MatchID = (int)dataset.Tables[0].Rows[0]["MatchID"];
            participant.SummonerID = dataset.Tables[0].Rows[0]["SummonerID"].ToString();
            participant.ChampionID = (int)dataset.Tables[0].Rows[0]["ChampionID"];
            //participant.StatID = (int)dataset.Tables[0].Rows[0]["StatID"];
            participant.TeamID = (int)dataset.Tables[0].Rows[0]["TeamID"];
            participant.Spell1ID = (int)dataset.Tables[0].Rows[0]["Spell1ID"];
            participant.Spell2ID = (int)dataset.Tables[0].Rows[0]["Spell2ID"];
            return participant;
        }

        public int GetParticipantIDBySummonerID(string summonerID, long matchID)
        {
            string query = "spGetParticipantIDBySummonerID";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("SummonerID", summonerID);
            parameters[1] = new SqlParameter("MatchID", matchID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);
            return Int32.Parse(dataset.Tables[0].Rows[0]["ParticipantID"].ToString());
        }

        // Summary:
        // Getting Summoner Name, Champion Name, TeamID and Win/Loss by matchID
        // Should return 10 participants for whatever match we are looking for.
        public List<Tuple<string,string,int,string>> GetMatchParticipantsByMatchID(long matchID)
        {
            string query = "spGetMatchParticipantsByMatchID";
            List<Tuple<string, string, int, string>> particpants = new List<Tuple<string, string, int, string>>();

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("MatchID", matchID);
            DataSet dataset = dBManager.CreateDataSet(query,parameters);
            int datasetlen = dataset.Tables[0].Rows.Count;
            for(int x = 0; x < datasetlen; x++)
            {
                string summoner = dataset.Tables[0].Rows[x]["SummonerName"].ToString();
                string champion = dataset.Tables[0].Rows[x]["ChampionName"].ToString();
                int team = (int)dataset.Tables[0].Rows[x]["TeamID"];
                string win = dataset.Tables[0].Rows[x]["Winner"].ToString();
                Tuple<string, string, int, string> newParticipant = Tuple.Create(summoner, champion, team, win);
                particpants.Add(newParticipant);
            }

            return particpants;
        }

        public bool MatchParticipantExists(int participantID)
        {
            string query = "spGetMatchParticipant";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("ParticipantID", participantID);
            DataSet dataset = dBManager.CreateDataSet(query, parameters);

            if (dataset.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else // There is a matching matchparticipant in the DB 
            {
                return true;
            }
        }
    }
}