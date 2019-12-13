using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RiotSharp;
using RiotSharp.Misc;
using MART391TestApp3.App_Code;
using System.Web.UI.DataVisualization.Charting;

namespace MART391TestApp3
{
    public partial class Default : System.Web.UI.Page
    {
        string devKey = new DevelopmentInfo().GetDevKey();
        RiotApi api;
        //ChampionIO champIO;
        MatchIO matchIO;
        MatchManager matchManager;
        //MatchParticipantIO matchParticipantIO;
        MatchParticipantManager participantManager;
        ParticipantStatIO participantStatIO;
        ParticipantStatManager statManager;
        SummonerIO summonerIO;
        ChampionManager champManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            api = RiotApi.GetDevelopmentInstance(devKey);
            //champIO = new ChampionIO();
            matchIO = new MatchIO();
            matchManager = new MatchManager();
            //matchParticipantIO = new MatchParticipantIO();
            participantManager = new MatchParticipantManager();
            participantStatIO = new ParticipantStatIO();
            statManager = new ParticipantStatManager();
            summonerIO = new SummonerIO();
            champManager = new ChampionManager();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Summoner searchedSummoner;
            Summoner queriedSummoner;
            LAMatch match;
            List<LAMatch> retrievedMatches = new List<LAMatch>();
            string search = txtSearch.Text;
            string summonerID = "";
            string accountID = "";
            string message = "";
            try
            {
                if(Session["SummonerName"] != null)
                {
                    Session["SummonerName"] = null;
                }
                if (search != "") // Just making sure the text box isn't blank, I will also add a validation later
                {
                    // TODO:
                    // This should also be moved into a manager class
                    var summoner = api.Summoner.GetSummonerByNameAsync(Region.Na, search).Result;
                    summonerID = summoner.Id;
                    accountID = summoner.AccountId;
                    searchedSummoner = new Summoner(summonerID, summoner.Name, summoner.AccountId, summoner.ProfileIconId);

                    lblNavbarBrand.Text = summoner.Name;
                    // ######################## //
                    // Summoner Exists in DB
                    // Check if they have been Searched before
                    // Return info/sesions info 
                    // ######################## //
                    if (summonerIO.SummonerExists(summonerID))
                    {
                        // Adding some summoner info to the session
                        Session["SummonerName"] = summoner.Name;
                        // Would like to pull ALOT of data and store it in the session
                        // So i can display it in graph form and others
                        queriedSummoner = summonerIO.GetSummonerByID(summonerID);
                        retrievedMatches = matchManager.GetTenMatches(summonerID);
                        //SqlDataSource2.Update();
                        GridView1.DataSource = retrievedMatches;
                        GridView1.DataBind();
                    }
                    // ######################## //
                    // Summoner does NOT exist
                    // insert Summoner AND Match history 
                    // ######################## //
                    else
                    {
                        summonerIO.InsertSummoner(searchedSummoner).ToString();
                        queriedSummoner = summonerIO.GetSummonerByID(summonerID);
                        var matches = api.Match.GetMatchListAsync(Region.Na, accountID).Result.Matches;
                        int matchlistlen = matches.Count;

                        for (int x = 0; x < 20; x++) // 10 most recent matches
                        {
                            if (!matchIO.MatchExists(matches[x].GameId)) // Match doesn't exist
                            {
                                var riotmatch = api.Match.GetMatchAsync(Region.Na, matches[x].GameId).Result;
                                match = matchManager.GetMatch(riotmatch);

                                // TODO: This SHOULD insert summoners into DB as well if they are missing
                                var participants = participantManager.GetMatchParticipants(riotmatch); // Also inserts stats
                            }
                        }

                        Session["SummonerName"] = summoner.Name;

                        queriedSummoner = summonerIO.GetSummonerByID(summonerID);
                        retrievedMatches = matchManager.GetTenMatches(summonerID);

                        GridView1.DataSource = retrievedMatches;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    message = "Please search a summoner!";
                }

                lblMessage.Text = message;
            }

            catch (Exception ex)
            {
                // TODO: Proper Exception catching
                //Response.Write(ex.ToString());
                lblMessage.Text = ex.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            List<LAMatch> retrievedMatches = new List<LAMatch>();
            Summoner queriedSummoner;
            Summoner summoner;
            LAMatch match;
            //string search = txtSearch.Text; // 
            string summonerID = "";
            string accountID = "";
            string message = "";

            // Crappy way to check if a summoner has been searched yet.
            if (!lblNavbarBrand.Text.Equals("League-Alytics")) { 
            string summonerName = lblNavbarBrand.Text;

                // TODO:
                try
                {

                    chrtChampKDA.Visible = false;
                    // Until we store the session changing things around a bit
                    summoner = summonerIO.GetSummonerByName(summonerName);
                    summonerID = summoner.SummonerID;
                    accountID = summoner.AccountID;
                    var matches = api.Match.GetMatchListAsync(Region.Na, accountID).Result.Matches;
                    int matchlistlen = matches.Count;
                    for (int x = 0; x < 20; x++) // 20 most recent matches
                    {
                        if (!matchIO.MatchExists(matches[x].GameId)) // Match doesn't exist
                        {
                            var riotmatch = api.Match.GetMatchAsync(Region.Na, matches[x].GameId).Result;
                            match = matchManager.GetMatch(riotmatch);

                            // TODO: This SHOULD insert summoners into DB as well if they are missing
                            var participants = participantManager.GetMatchParticipants(riotmatch); // Also inserts stats
                        }
                    }

                    // ######################## //
                    // This needs to be in the match Manager class
                    // ######################## //
                    queriedSummoner = summonerIO.GetSummonerByID(summonerID);
                    retrievedMatches = matchManager.GetTenMatches(summonerID);

                    GridView1.DataSource = retrievedMatches;
                    GridView1.DataBind();
                }

                catch (Exception ex)
                {
                    // TODO: Proper Exception catching
                    // Response.Write(ex.ToString());
                    lblMessage.Text = ex.ToString();
                }
                lblMessage.Text = message;
            }
            else
            {
                // Do nothing so far
            }
        }

        protected void btnMatchHistory_Click(object sender, EventArgs e)
        {
            chrtChampKDA.Visible = false;
            if (Session["SummonerName"] != null)
            {
                
                //lblMessage.Text = Session["SummonerName"].ToString();
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
            }
        }

        protected void btnChampions_Click(object sender, EventArgs e)
        {
            
            string message = "";
            chrtChampKDA.Visible = false;
            List<ChampionStats> champStats = new List<ChampionStats>();
            // Making sure the session variable is not null
            if (Session["SummonerName"] != null)
            {
                try
                {
                    champStats = champManager.GetSummonerChampionWinPercentages(Session["SummonerName"].ToString());

                    foreach (ChampionStats champStat in champStats)
                    {
                        string KDA;

                        // TODO: 
                        // Remove this/ change it
                        // This is useless now 
                        if (champStat.GetKDA() != -1.00) //Not a perfect KDA
                        {
                            KDA = String.Format("{0:0.00}", champStat.GetKDA());
                        }
                        else
                        {
                            KDA = "Perfect";
                        }
                        string killAvg = String.Format("{0:0.##}", (double)champStat.Kills / champStat.GetTotalGames());
                        string deathAvg = String.Format("{0:0.##}", (double)champStat.Deaths / champStat.GetTotalGames());
                        string assistAvg = String.Format("{0:0.##}", (double)champStat.Assists / champStat.GetTotalGames());
                        message += "Champion: " + champStat.ChampionName + "<br />&#8195;Total Games: " + champStat.GetTotalGames() + "<br />&#8195;Win/Loss: "
                            + champStat.TotalWins + "/" + champStat.TotalLosses + "<br />&#8195;KDA: " + KDA + " " + killAvg + "/" + deathAvg + "/" + assistAvg + "<br />";
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Proper Exception catching
                    // Response.Write(ex.ToString());
                    lblMessage.Text = ex.ToString();
                }
            }

            lblMessage.Text = message;
            GridView1.DataSource = champStats;
            GridView1.DataBind();
        }

        protected void btnStats_Click(object sender, EventArgs e)
        {
            // TODO:
            // Stats I'd like to display:
            // A graph of the Champs tab
            //    So KDA and Kills/Deaths/Assists
            // Most played Champions
            // Highest Gold Earned
            // Most Kills
            // Highest Damage Done
            if(Session["SummonerName"] != null) {


                // Clearing the Gridview for some other things
                GridView1.DataSource = null;
                GridView1.DataBind();
                try
                {
                    string message = "";
                    string summonerName = Session["SummonerName"].ToString();
                    List<ChampionStats> champStats = champManager.GetSummonerChampionWinPercentages(summonerName);
                    List<Tuple<String, int>> goldStats = statManager.GetGoldEarnedByChampionByMatch(summonerName);
                    var mostPlayed = champManager.GetMostPlayedChampion(summonerName);
                    lblMessage.Text = "Most Played Champion: " + mostPlayed.Item1 + " " + mostPlayed.Item2 + " games.";

                    // ######################## //
                    // KDA By Champion
                    // ######################## //
                    chrtChampKDA.AlignDataPointsByAxisLabel();
                    chrtChampKDA.DataSource = champStats;
                    chrtChampKDA.DataBind();
                    Series newSeries = new Series("Series 1");
                    chrtChampKDA.Series.Add(newSeries);
                    newSeries.XValueMember = "ChampionName";
                    newSeries.YValueMembers = "KDA";
                    newSeries.IsXValueIndexed = true;
                    chrtChampKDA.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                    chrtChampKDA.Visible = true;

                    // ######################## //
                    // Gold Earned Averages By Champion
                    // ######################## //
                    //chrtChampGoldEarned.AlignDataPointsByAxisLabel();
                    //chrtChampGoldEarned.DataSource = goldStats;


                    lblMessage.Text = message;
                }
                catch (Exception ex)
                {
                    // TODO: Proper Exception catching
                    // Response.Write(ex.ToString());
                    lblMessage.Text = ex.ToString();
                }
            }
        }
    }
}