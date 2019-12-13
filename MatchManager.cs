using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RiotSharp;
using RiotSharp.Misc;
using RiotSharp.Endpoints.MatchEndpoint;
using MART391TestApp3.App_Code;

namespace MART391TestApp3
{
    // TODO:
    // For this class we need to move a lot of functions from the Admin.aspx.cs
    public class MatchManager
    {
        private readonly MatchIO matchIO = new MatchIO();
        public LAMatch GetMatch(Match riotmatch)
        {
            LAMatch match = new LAMatch(); // Renamed Match to LAMatch, not a perfect name but works
            match.MatchID = riotmatch.GameId;
            match.RegionID = (int)Region.Na;
            match.DatePlayed = riotmatch.GameCreation;
            match.DurationSeconds = riotmatch.GameDuration.TotalSeconds;
            match.SeasonID = riotmatch.SeasonId;
            match.GameVersion = riotmatch.GameVersion;
            match.GameMode = riotmatch.GameMode;
            match.GameType = riotmatch.GameType;
            match.MapID = riotmatch.MapId;
            matchIO.InsertMatch(match);
            return match;
        }

        public List<LAMatch> GetTenMatches(string summonerID) // Or as many matches as there are in the DB
        {
            // I believe i'll just retrieve all matches and only display the top 10?
            List<LAMatch> queriedmatches = matchIO.GetMatchesBySummonerID(summonerID);

            return queriedmatches;
        }

        // Summary:
        // Might rewrite this to NOT use the riot api and pull from the DB
        //
        public bool MatchWin(long matchID, RiotApi api, string summonerID)
        {
            //Might move this to class level?
            var match = api.Match.GetMatchAsync(Region.Na, matchID).Result;
            int playerParticipantID = 0;
            int teamID;
            //First find the appropriate summonerID and then find which team they are on
            for(int x = 0; x < 10; x++)
            {
                if(match.ParticipantIdentities[x].Player.SummonerId == summonerID)
                {
                    playerParticipantID = x;
                }
            }
            teamID = match.Participants[playerParticipantID].TeamId;
            //I believe team 100 is red side and 200 is blue side?
            //Find which team the summoner in question is on
            for(int x = 0; x < 3; x++)
            {
                //Checking for correct team
                if(match.Teams[x].TeamId == teamID)
                {
                    if(match.Teams[x].Win.Equals("Win"))
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        
    }
}