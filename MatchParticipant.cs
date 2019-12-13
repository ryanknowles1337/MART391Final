using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MART391TestApp3.App_Code
{
    public class MatchParticipant
    {
        public int ParticipantID { get; set; }
        public long MatchID { get; set; }
        public string SummonerID { get; set; }
        public int ChampionID { get; set; }
        public int TeamID { get; set; }
        public int Spell1ID { get; set; }
        public int Spell2ID { get; set; }

        public MatchParticipant(int participantID, long matchID, string summonerID, int championID, int teamID, int spell1ID, int spell2ID)
        {
            ParticipantID = participantID;
            MatchID = matchID;
            SummonerID = summonerID;
            ChampionID = championID;
            TeamID = teamID;
            Spell1ID = spell1ID;
            Spell2ID = spell2ID;
        }

        public MatchParticipant() { }
    }
}