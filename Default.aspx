<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MART391TestApp3.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="LeagueAlytics.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSearch" defaultfocus="txtSearch">
        <!-- Navbar -->
       <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">

            <!--<a class="navbar-brand" href="#"></a>-->
            <asp:Label ID="lblNavbarBrand" runat="server" Text="League-Alytics" CssClass="navbar-brand"></asp:Label>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            
            <div class="navbar-collapse collapse justify-content-stretch" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-dark" OnClick="btnUpdate_Click" TabIndex="1"/>
                    </li>
                    <li class="nav-item active">
                        <asp:Button ID="btnMatchHistory" runat="server" Text="Match History"  CssClass="btn btn-dark" OnClick="btnMatchHistory_Click" TabIndex="2" />
                    </li>
                    <li class="nav-item active">
                        <asp:Button ID="btnChampions" runat="server" Text="Champions" CssClass="btn btn-dark" OnClick="btnChampions_Click" TabIndex="3" />
                    </li>
                    <li class="nav-item active">
                        <asp:Button ID="btnStats" runat="server" Text="Statistics" CssClass="btn btn-dark" OnClick="btnStats_Click" />
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="Admin.aspx">Admin Stuff</a>
                    </li>
                </ul>
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <%-- --%>
                        <%--<div class="form-inline">--%>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder=". . ."></asp:TextBox>
                            
                        <%--</div> --%>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="btnSearch" runat="server" Text="Search Summoner" OnClick="btnSearch_Click" CssClass="btn btn-secondary" />
                    </li>
                </ul>
                
            </div>
        </nav>
        
        <%-- Content --%>
        <div class="jumbotron jumbotron-fluid border-dark">
            <div>
                <%-- <asp:Label ID="lblChartHeader" runat="server" Text="Match History"></asp:Label>--%>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CssClass="mydatagrid">
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="spGetChampionWinLossBySummonerName" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="SummonerName" SessionField="SummonerName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="spGetMatchHistory" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="SummonerName" SessionField="SummonerName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Chart ID="chrtChampKDA" runat="server" BackColor="Silver" BorderlineColor="Gray" Visible="False" Width="1200px">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <%-- 
                <asp:Chart ID="chrtChampGoldEarned" runat="server" BackColor="Silver" BorderlineColor="Gray" Visible="False" Width="1200px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                --%>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="Welcome to League Analytics. Please search for a summoner name!"></asp:Label>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-2.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
