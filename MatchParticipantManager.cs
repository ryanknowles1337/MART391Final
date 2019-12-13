using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MART391TestApp3.App_Code;
using RiotSharp.Endpoints.MatchEndpoint;

namespace MART391TestApp3
{
    public class MatchParticipantManager
    {
        private readonly ParticipantStatManager statManager = new ParticipantStatManager();
        private readonly MatchParticipantIO matchParticipantIO = new MatchParticipantIO();
        private readonly SummonerIO summonerIO = new SummonerIO(); // I believe this should be in the summonerManager class TODO :(
        public MatchParticipantManager() { }
        public List<MatchParticipant> GetMatchParticipants(Match match)
        {
            //MatchParticipantManager mpManager = new MatchParticipantManager();
            List<MatchParticipant> participants = new List<MatchParticipant>();
            int numParticipants = match.Participants.Count;
            //foreach (Participant participant in match.Participants)
            for(int x = 0; x < 10; x++)
            {
                MatchParticipant newParticipant = new MatchParticipant();
                newParticipant.ParticipantID = match.Participants[x].ParticipantId;
                newParticipant.MatchID = match.GameId;
                newParticipant.SummonerID = match.ParticipantIdentities[x].Player.SummonerId; //Getting summoner ID from participantindent
                newParticipant.ChampionID = match.Participants[x].ChampionId;
                newParticipant.TeamID = match.Participants[x].TeamId;
                newParticipant.Spell1ID = match.Participants[x].Spell1Id;
                newParticipant.Spell2ID = match.Participants[x].Spell2Id;

                // If summoner not in DB, insert
                if(!summonerIO.SummonerExists(newParticipant.SummonerID))
                {
                    Summoner summoner = new Summoner()
                    {
                        SummonerID = match.ParticipantIdentities[x].Player.SummonerId,
                        SummonerName = match.ParticipantIdentities[x].Player.SummonerName,
                        AccountID = match.ParticipantIdentities[x].Player.AccountId,
                        ProfileIconID = match.ParticipantIdentities[x].Player.ProfileIcon
                    };
                    summonerIO.InsertSummoner(summoner);
                }
                // Insert the participant into the DB
                matchParticipantIO.InsertMatchParticipant(newParticipant);
                int participantID = matchParticipantIO.GetParticipantIDBySummonerID(newParticipant.SummonerID, newParticipant.MatchID);

                // Insert the stats in the DB and retrieve them
                ParticipantStat stats= statManager.GetParticipantStat(match, newParticipant, x, participantID);

            }
            return participants;
        }

        public List<Tuple<string, string, int, string>> GetParticipantsWinLoss(long matchID)
        {

            List<Tuple<string, string, int, string>> participants = matchParticipantIO.GetMatchParticipantsByMatchID(matchID);
            return participants;
        }
    }
}