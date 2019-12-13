using RiotSharp;
using RiotSharp.Misc;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Endpoints.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MART391TestApp3.App_Code; //Why do i have to do this :(
using System.Data;
//using RiotSharp.Endpoints.MatchEndpoint;

namespace MART391TestApp3
{
    public partial class Admin : System.Web.UI.Page
    {
        string devKey = new DevelopmentInfo().GetDevKey();
        RiotApi api;
        ChampionIO champIO;
        MatchIO matchIO;
        MatchManager matchManager;
        MatchParticipantIO matchParticipantIO;
        MatchParticipantManager participantManager;
        ParticipantStatIO participantStatIO;
        SummonerIO summonerIO;
        protected void Page_Load(object sender, EventArgs e)
        {
            api = RiotApi.GetDevelopmentInstance(devKey);
            champIO = new ChampionIO();
            matchIO = new MatchIO();
            matchManager = new MatchManager();
            matchParticipantIO = new MatchParticipantIO();
            participantManager = new MatchParticipantManager();
            participantStatIO = new ParticipantStatIO();
            summonerIO = new SummonerIO();
        }

        protected void btnAddChampions_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                string message = "";

                // Plan to insert the searched summoner into the db
                string version = api.StaticData.Versions.GetAllAsync().Result[0];
                var champions = api.StaticData.Champions.GetAllAsync(version, Language.en_US, true).Result.Champions.Values;

                // For my sake i'm just doing some behind the scenes work of putting the champions into a list. 
                // probably not worth it as they are already in a more complex one.
                List<Champion> champList = new List<Champion>();
                Champion newChamp;
                foreach(ChampionStatic champ in champions)
                {
                    newChamp = new Champion(champ.Id, champ.Name);
                    message += "| " + champ.Id + " | " + champ.Name + " | " + "<br />"; // This is just test outputs
                    //message += champIO.InsertChampion(newChamp); // I believe this breaks the query atm xD
                    //message += "<br/>"; 
                }
                if (lblMessage.Text != "") {
                    string summonerID = api.Summoner.GetSummonerByNameAsync(Region.Na, search).Result.Id;
                }

                lblMessage.Text = message;
            }

            catch (Exception ex)
            {
                // TODO: Proper Exception catching?
                Response.Write(ex.ToString());
            }
        }

        // Summary:
        // Honestly I'm not 100% on inserting all of these huge objects properly, here we go!
        protected void btnTestInsertMatch_Click(object sender, EventArgs e)
        {

            try
            {
                string message = "";
                var riotMatch = api.Match.GetMatchAsync(Region.Na, 3223236153).Result;

                LAMatch newMatch = new LAMatch(riotMatch.GameId, (int)Region.Na, riotMatch.GameCreation, riotMatch.GameDuration.TotalSeconds,
                    riotMatch.SeasonId,riotMatch.GameVersion, riotMatch.GameMode,riotMatch.GameType, riotMatch.MapId);
                message = matchIO.InsertMatch(newMatch).ToString();
                lblMessage.Text = message;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }


        // Summary: 
        // If the summoner exists pull summoner data
        // If the summoner doesn't exist insert into db 
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Summoner searchedSummoner;
            Summoner queriedSummoner;
            LAMatch match;
            try
            {
                string search = txtSearch.Text;
                string summonerID = "";
                string accountID = "";
                string message = "";

                // Just making sure the text box isn't blank, I will also add a validation later
                if (search != "") 
                {
                    var summoner = api.Summoner.GetSummonerByNameAsync(Region.Na, search).Result;
                    summonerID = summoner.Id;
                    accountID = summoner.AccountId;
                    searchedSummoner = new Summoner(summonerID, summoner.Name, summoner.AccountId, summoner.ProfileIconId);
                    
                    // If exists, return info
                    if(summonerIO.SummonerExists(summonerID))
                    {
                        // TODO: 
                        // Check each match if exists in the DB
                        // Check for participants and their stats
                        queriedSummoner = summonerIO.GetSummonerByID(summonerID);
                        var matches = api.Match.GetMatchListAsync(Region.Na, accountID).Result.Matches;
                        // To do this i believe i have to search each match via riot's api :( big oof
                        int matchlistlen = matches.Count;

                        //for (int x = 0; x < 1; x++) // 1 most recent matches?
                        for (int x = 0; x < 10; x++) // 10 most recent matches
                        {

                            // If the match already exists in the DB
                            // Don't Search for it via the Riot API and 
                            // Don't try inserting it in the DB
                            if (!matchIO.MatchExists(matches[x].GameId))
                            {
                                // I assume I am going to get rate limited by this
                                var riotmatch = api.Match.GetMatchAsync(Region.Na, matches[x].GameId).Result;
                                match = new LAMatch(); // I see why i'm having warnings now :( I should rename this
                                match.MatchID = riotmatch.GameId;
                                match.RegionID = (int)Region.Na;
                                match.DatePlayed = riotmatch.GameCreation; // This might be in accurate
                                match.DurationSeconds = riotmatch.GameDuration.TotalSeconds;
                                match.SeasonID = riotmatch.SeasonId;
                                match.GameVersion = riotmatch.GameVersion;
                                match.GameMode = riotmatch.GameMode;
                                match.GameType = riotmatch.GameType;
                                match.MapID = riotmatch.MapId;
                                matchIO.InsertMatch(match);

                                // Need to make sure to pass in the RiotSharp match
                                // This will also insert the stats
                                var participants = participantManager.GetMatchParticipants(riotmatch); 
                                message += match.MatchID + "<br />";
                                for(int y = 0; y < participants.Count; y++)
                                {
                                    message += participants[y].SummonerID + "<br />";
                                }
                            }
                        }

                    } else // If not exists, insert summoner and then output generic return code
                    {
                        // TODO: Since they do not exists their matches also 'should' not exist in the DB
                        // So we need to insert them
                        message += summonerIO.InsertSummoner(searchedSummoner).ToString();
                    }
                } else
                {
                    message = "Please search a summoner!";
                }
                
                lblMessage.Text = message;
            }

            catch (Exception ex)
            {
                // TODO: Proper Exception catching
                Response.Write(ex.ToString());
            }
        }

        protected void btnUploadReplay_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            string path = Server.MapPath("~/ReplaysFolder/");
            if(fileupReplay.HasFiles)
            {
                string fileExtension = System.IO.Path.GetExtension(fileupReplay.FileName).ToLower();
                string[] allowedExtensions = { ".rofl" };
                
                for(int x = 0; x < allowedExtensions.Length; x++)
                {
                    if(fileExtension == allowedExtensions[x])
                    {
                        fileOK = true;
                    }
                }
            }

            if(fileOK)
            {
                try
                {
                    fileupReplay.PostedFile.SaveAs(path + fileupReplay.FileName);
                    lblFileMessage.Text = "File uploaded!<br />";
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    lblFileMessage.Text = "File could not be uploaded.<br />";
                }
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Size", typeof(string));

            foreach (string strFile in Directory.GetFiles(Server.MapPath("~/ReplaysFolder/")))
            {
                FileInfo file = new FileInfo(strFile);
                dt.Rows.Add(file.Name, file.Length);
                
            }

            gdvReplays.DataSource = dt;
            gdvReplays.DataBind();
        }

        protected void gdvReplays_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //lblMessage.Text = "PLZ";
            if (e.CommandName == "Download")
            {
                
                string filename = e.CommandArgument.ToString();
                string path = "~/ReplaysFolder/" + filename;

                Response.Clear();
                Response.ContentType = "text/plain";
                lblMessage.Text = filename; // Testing
                Response.AddHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument + ";");
                Response.TransmitFile(Server.MapPath(path));
                Response.Flush();
                Response.End();
            }
        }

        protected void gdvReplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: In the far future, replay parse info
        }

    }
}