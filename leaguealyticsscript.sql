USE [master]
GO
/****** Object:  Database [LeagueAnalyticsDB1]    Script Date: 12/11/2019 11:04:51 AM ******/
CREATE DATABASE [LeagueAnalyticsDB1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeagueAnalyticsDB1', FILENAME = N'F:\program files\Sql Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LeagueAnalyticsDB1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LeagueAnalyticsDB1_log', FILENAME = N'F:\program files\Sql Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LeagueAnalyticsDB1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeagueAnalyticsDB1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET RECOVERY FULL 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET  MULTI_USER 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LeagueAnalyticsDB1', N'ON'
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET QUERY_STORE = OFF
GO
USE [LeagueAnalyticsDB1]
GO
/****** Object:  Table [dbo].[Champions]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Champions](
	[ChampionID] [int] NOT NULL,
	[ChampionName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Champions] PRIMARY KEY CLUSTERED 
(
	[ChampionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[MatchID] [bigint] NOT NULL,
	[RegionID] [int] NOT NULL,
	[DatePlayed] [datetime] NOT NULL,
	[DurationSeconds] [float] NOT NULL,
	[SeasonID] [int] NULL,
	[GameVersion] [varchar](50) NULL,
	[GameMode] [varchar](20) NULL,
	[GameType] [varchar](20) NULL,
	[MapID] [int] NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[MatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatchParticipants]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchParticipants](
	[ParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[MatchID] [bigint] NOT NULL,
	[SummonerID] [varchar](100) NOT NULL,
	[ChampionID] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
	[Spell1ID] [int] NULL,
	[Spell2ID] [int] NULL,
 CONSTRAINT [PK_MatchParticipants] PRIMARY KEY CLUSTERED 
(
	[ParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParticipantStats]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParticipantStats](
	[StatID] [int] IDENTITY(1,1) NOT NULL,
	[Winner] [varchar](5) NOT NULL,
	[Kills] [int] NOT NULL,
	[Assists] [int] NOT NULL,
	[GoldSpent] [int] NOT NULL,
	[GoldEarned] [int] NOT NULL,
	[TotalDamageTaken] [int] NOT NULL,
	[TotalDamageDealtToChampions] [int] NOT NULL,
	[TotalDamageDealt] [int] NOT NULL,
	[PhysicalDamageTaken] [int] NOT NULL,
	[PhysicalDamageDealtToChampions] [int] NOT NULL,
	[PhysicalDamageDealt] [int] NOT NULL,
	[MagicDamageTaken] [int] NOT NULL,
	[MagicDamageDealtToChampions] [int] NOT NULL,
	[MagicDamageDealt] [int] NOT NULL,
	[TrueDamageTaken] [int] NOT NULL,
	[TrueDamageDealtToChampions] [int] NOT NULL,
	[TrueDamageDealt] [int] NOT NULL,
	[TotalUnitsHealed] [int] NOT NULL,
	[TotalHeal] [int] NOT NULL,
	[TotalTimeCrowdControlDealt] [int] NOT NULL,
	[WardsPlaced] [int] NOT NULL,
	[WardsKilled] [int] NOT NULL,
	[VisionWardsBoughtInGame] [int] NOT NULL,
	[VisionScore] [int] NOT NULL,
	[SightWardsBoughtInGame] [int] NOT NULL,
	[TowerKills] [int] NOT NULL,
	[InhibitorKills] [int] NOT NULL,
	[FirstTowerKill] [bit] NOT NULL,
	[FirstTowerAssist] [bit] NOT NULL,
	[FirstInhibitorKill] [bit] NOT NULL,
	[FirstInhibitorAssist] [bit] NOT NULL,
	[FirstBloodKill] [bit] NOT NULL,
	[FirstBloodAssist] [bit] NOT NULL,
	[DoubleKills] [int] NOT NULL,
	[TripleKills] [int] NOT NULL,
	[QuadraKills] [int] NOT NULL,
	[PentaKills] [int] NOT NULL,
	[UnrealKills] [int] NOT NULL,
	[KillingSprees] [int] NOT NULL,
	[LargestKillingSpree] [int] NOT NULL,
	[LargestCriticalStrike] [int] NOT NULL,
	[NeutralMinionsKilledEnemyJungle] [int] NOT NULL,
	[NeutralMinionsKilledJungle] [int] NOT NULL,
	[TotalMinionsKilled] [int] NOT NULL,
	[ParticipantID] [int] NOT NULL,
	[Deaths] [bigint] NOT NULL,
	[ChampionLevel] [bigint] NOT NULL,
 CONSTRAINT [PK_ParticipantStats] PRIMARY KEY CLUSTERED 
(
	[StatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionID] [int] NOT NULL,
	[Region] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Runes]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Runes](
	[RuneID] [int] NOT NULL,
	[RuneVar1] [varchar](100) NULL,
	[RuneVar2] [varchar](100) NULL,
	[RuneVar3] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Summoners]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Summoners](
	[SummonerID] [varchar](100) NOT NULL,
	[SummonerName] [varchar](100) NOT NULL,
	[AccountID] [varchar](100) NULL,
	[ProfileIconID] [int] NULL,
 CONSTRAINT [PK_Summoners] PRIMARY KEY CLUSTERED 
(
	[SummonerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetChampionWinLossBySummonerID]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Get Matches, Champions played, and win/loss by SummonerID
-- =============================================
CREATE PROCEDURE [dbo].[spGetChampionWinLossBySummonerID]
	@SummonerID varchar(100)
AS
BEGIN
	SELECT SummonerName, Champions.ChampionName, ParticipantStats.Winner, Kills, Deaths, Assists
	FROM ParticipantStats
	INNER JOIN MatchParticipants ON ParticipantStats.ParticipantID = MatchParticipants.ParticipantID
	INNER JOIN Champions ON MatchParticipants.ChampionID = Champions.ChampionID
	INNER JOIN Summoners ON MatchParticipants.SummonerID = Summoners.SummonerID
	WHERE Summoners.SummonerID = @SummonerID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetChampionWinLossBySummonerName]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Gets Champion Win Loss by Summoner Name
-- =============================================
CREATE PROCEDURE [dbo].[spGetChampionWinLossBySummonerName]
	@SummonerName varchar(100)
AS
BEGIN
	SELECT Champions.ChampionName, ParticipantStats.Winner, Kills, Deaths, Assists
	FROM ParticipantStats
	INNER JOIN MatchParticipants ON ParticipantStats.ParticipantID = MatchParticipants.ParticipantID
	INNER JOIN Champions ON MatchParticipants.ChampionID = Champions.ChampionID
	INNER JOIN Summoners ON MatchParticipants.SummonerID = Summoners.SummonerID
	WHERE Summoners.SummonerName = @SummonerName
	ORDER BY ChampionName
END

GO
/****** Object:  StoredProcedure [dbo].[spGetGoldEarnedByMatch]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/11/2019
-- Description:	Get Gold earned by summoner by Match
-- =============================================
CREATE PROCEDURE [dbo].[spGetGoldEarnedByMatch]
	@SummonerName varchar(100)
AS
BEGIN
	
	SELECT ChampionName, GoldEarned
	FROM ParticipantStats p
	INNER JOIN MatchParticipants m 
		ON m.ParticipantID = p.ParticipantID
	INNER JOIN Summoners s
		ON s.SummonerID = m.SummonerID
	INNER JOIN Champions c
		ON m.ChampionID = c.ChampionID
	WHERE SummonerName = @SummonerName
	ORDER BY ChampionName
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMatch]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/8/2019
-- Description:	Gets a Match
-- =============================================
CREATE PROCEDURE [dbo].[spGetMatch]
	@MatchID bigint
AS
BEGIN
	SELECT MatchID, RegionID, DatePlayed, DurationSeconds, SeasonID, GameVersion, GameMode, GameType, MapID
	FROM Matches
	WHERE MatchID = @MatchID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMatchesBySummonerID]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Get match list by Summoner ID
-- =============================================
CREATE PROCEDURE [dbo].[spGetMatchesBySummonerID] 
	@SummonerID varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Matches.MatchID, RegionID, DatePlayed, DurationSeconds, SeasonID, GameVersion, GameMode, GameType, MapID
	FROM MatchParticipants
	INNER JOIN Matches
	ON MatchParticipants.MatchID = Matches.MatchID
	WHERE MatchParticipants.SummonerID = @SummonerID;

END
GO
/****** Object:  StoredProcedure [dbo].[spGetMatchHistory]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Get match history by summonername
-- =============================================
CREATE PROCEDURE [dbo].[spGetMatchHistory] 
	@SummonerName varchar(100)
AS
BEGIN
	SELECT Matches.DatePlayed, Champions.ChampionName, ParticipantStats.Winner AS "Win/Loss"
	FROM Matches
	INNER JOIN MatchParticipants ON Matches.MatchID = MatchParticipants.MatchID
	INNER JOIN Summoners ON MatchParticipants.SummonerID = Summoners.SummonerID
	INNER JOIN ParticipantStats ON ParticipantStats.ParticipantID = MatchParticipants.ParticipantID
	INNER JOIN Champions ON Champions.ChampionID = MatchParticipants.ChampionID
	WHERE SummonerName = @SummonerName
	ORDER BY DatePlayed DESC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMatchParticipant]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/9/2019
-- Description:	Gets a Match Participant (One of Ten Summoners in a Match)
-- =============================================
CREATE PROCEDURE [dbo].[spGetMatchParticipant] 
	@ParticipantID int 
AS
BEGIN
	SELECT ParticipantID, MatchID, SummonerID, ChampionID, TeamID, Spell1ID, Spell2ID
	FROM MatchParticipants
	WHERE ParticipantID = @ParticipantID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMatchParticipantsByMatchID]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Get Match participants by MatchID
-- =============================================
CREATE PROCEDURE [dbo].[spGetMatchParticipantsByMatchID]
	@MatchID bigint
AS
BEGIN
	SELECT SummonerName, ChampionName, TeamID, Winner
	FROM MatchParticipants
	INNER JOIN Matches ON MatchParticipants.MatchID = Matches.MatchID
	INNER JOIN Champions ON MatchParticipants.ChampionID = Champions.ChampionID
	INNER JOIN Summoners ON MatchParticipants.SummonerID = Summoners.SummonerID
	INNER JOIN ParticipantStats ON MatchParticipants.ParticipantID = ParticipantStats.ParticipantID
	WHERE Matches.MatchID = @MatchID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMinionKillsBySummonerID]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/9/2019
-- Description:	Get Minion Kill values by Summoner ID
-- =============================================
CREATE PROCEDURE [dbo].[spGetMinionKillsBySummonerID] 
	@SummonerID varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TotalMinionsKilled
	FROM ParticipantStats
	INNER JOIN MatchParticipants
	ON ParticipantStats.ParticipantID = MatchParticipants.ParticipantID
	WHERE SummonerID = @SummonerID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMostPlayedChampionBySummonerName]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Gets most played champion by Summoner Name
-- =============================================
CREATE PROCEDURE [dbo].[spGetMostPlayedChampionBySummonerName]
	@SummonerName varchar(100)
AS
BEGIN
	SELECT ChampionName, COUNT(ChampionName) TimesPlayed
	FROM Champions c
	INNER JOIN MatchParticipants m 
		ON m.ChampionID = c.ChampionID
	INNER JOIN ParticipantStats p 
		ON p.ParticipantID = m.ParticipantID
	INNER JOIN Summoners s 
		ON s.SummonerID = m.SummonerID
	WHERE SummonerName = @SummonerName
	GROUP BY ChampionName
	ORDER BY COUNT(*) Desc
END
GO
/****** Object:  StoredProcedure [dbo].[spGetParticipantIDBySummonerID]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/9/2019
-- Description:	Get Participant ID by Summoner ID?
-- =============================================
CREATE PROCEDURE [dbo].[spGetParticipantIDBySummonerID]
	@SummonerID varchar(100),
	@MatchID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT ParticipantID
	FROM MatchParticipants
	WHERE SummonerID = @SummonerID
	AND MatchID = @MatchID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetParticipantStat]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/9/2019
-- Description:	Get Participant Stats for a specific match
-- =============================================
CREATE PROCEDURE [dbo].[spGetParticipantStat] 
	@StatID int
AS
BEGIN
	SELECT Winner, Kills, Assists, GoldSpent, GoldEarned, TotalDamageTaken, TotalDamageDealtToChampions, TotalDamageDealt, PhysicalDamageTaken, PhysicalDamageDealtToChampions, PhysicalDamageDealt,
		MagicDamageTaken, MagicDamageDealtToChampions, MagicDamageDealt, TrueDamageTaken, TrueDamageDealtToChampions, TrueDamageDealt, TotalUnitsHealed, TotalHeal, TotalTimeCrowdControlDealt,
		WardsPlaced, WardsKilled, VisionWardsBoughtInGame, VisionScore, SightWardsBoughtInGame, TowerKills, InhibitorKills, FirstTowerKill, FirstTowerAssist, FirstInhibitorKill, FirstInhibitorAssist,
		FirstBloodKill, FirstBloodAssist, DoubleKills, TripleKills, QuadraKills, PentaKills, UnrealKills, KillingSprees, LargestKillingSpree, LargestCriticalStrike, NeutralMinionsKilledEnemyJungle,
		NeutralMinionsKilledJungle, TotalMinionsKilled, ParticipantID, Deaths, ChampionLevel
	FROM ParticipantStats
	WHERE StatID = @StatID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSummoner]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/7/2019
-- Description:	Gets Summoner by SummonerID
-- =============================================
CREATE PROCEDURE [dbo].[spGetSummoner]
	@SummonerID varchar(100)
AS
BEGIN
	SELECT SummonerID, SummonerName, AccountID, ProfileIconID
	FROM Summoners
	WHERE SummonerID = @SummonerID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSummonerByName]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/10/2019
-- Description:	Get summoner by summoner name
-- =============================================
CREATE PROCEDURE [dbo].[spGetSummonerByName]
	@SummonerName varchar(100)
AS
BEGIN
	SELECT SummonerID, SummonerName, AccountID, ProfileIconID
	FROM Summoners
	WHERE SummonerName = @SummonerName
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertChampion]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/4/2019
-- Description:	Creates a champion
-- =============================================
CREATE PROCEDURE [dbo].[spInsertChampion] 
	-- Add the parameters for the stored procedure here
	@ChampionID int, 
	@ChampionName varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Champions
		(ChampionID, ChampionName)
	VALUES
		(@ChampionID, @ChampionName)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertMatch]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/5/2019
-- Description:	Insert Match
-- =============================================
CREATE PROCEDURE [dbo].[spInsertMatch]
	-- Add the parameters for the stored procedure here
	@MatchID bigint,
	@RegionID int,
	@DatePlayed datetime,
	@DurationSeconds float,
	@SeasonID int,
	@GameVersion varchar(50),
	@GameMode varchar(20),
	@GameType varchar(20),
	@MapID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Matches
		(MatchID, RegionID, DatePlayed, DurationSeconds, SeasonID, GameVersion, GameMode, GameType, MapID)
	VALUES
		(@MatchID, @RegionID, @DatePlayed, @DurationSeconds, @SeasonID, @GameVersion, @GameMode, @GameType, @MapID)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertMatchParticipant]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/4/2019
-- Description:	Creates a Match Participant
-- =============================================
CREATE PROCEDURE [dbo].[spInsertMatchParticipant] 
	-- Add the parameters for the stored procedure here
	@MatchID bigint,
	@SummonerID varchar(100),
	@ChampionID int,
	@TeamID int, 
	@Spell1ID int,
	@Spell2ID int
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO MatchParticipants
		(MatchID, SummonerID, ChampionID, TeamID, Spell1ID, Spell2ID)
	VALUES
		(@MatchID, @SummonerID, @ChampionID, @TeamID, @Spell1ID, @Spell2ID)

END
GO
/****** Object:  StoredProcedure [dbo].[spInsertParticipantStat]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/9/2019
-- Description:	Get Participant Stats for a specific match
-- =============================================
CREATE PROCEDURE [dbo].[spInsertParticipantStat] 
	@StatID int,
	@Winner varchar(5),
	@Kills int,
	@Assists int,
	@GoldSpent int,
	@GoldEarned int,
	@TotalDamageTaken int,
	@TotalDamageDealtToChampions int,
	@TotalDamageDealt int,
	@PhysicalDamageTaken int,
	@PhysicalDamageDealtToChampions int,
	@PhysicalDamageDealt int,
	@MagicDamageTaken int,
	@MagicDamageDealtToChampions int,
	@MagicDamageDealt int,
	@TrueDamageTaken int,
	@TrueDamageDealtToChampions int,
	@TrueDamageDealt int,
	@TotalUnitsHealed int,
	@TotalHeal int,
	@TotalTimeCrowdControlDealt int,
	@WardsPlaced int,
	@WardsKilled int,
	@VisionWardsBoughtInGame int,
	@VisionScore int,
	@SightWardsBoughtInGame int,
	@TowerKills int,
	@InhibitorKills int,
	@FirstTowerKill bit,
	@FirstTowerAssist bit,
	@FirstInhibitorKill bit,
	@FirstInhibitorAssist bit,
	@FirstBloodKill bit,
	@FirstBloodAssist bit,
	@DoubleKills int,
	@TripleKills int,
	@QuadraKills int,
	@PentaKills int,
	@UnrealKills int,
	@KillingSprees int,
	@LargestKillingSpree int,
	@LargestCriticalStrike int,
	@NeutralMinionsKilledEnemyJungle int,
	@NeutralMinionsKilledJungle int,
	@TotalMinionsKilled int,
	@ParticipantID int,
	@Deaths bigint,
	@ChampionLevel bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO ParticipantStats
		(Winner, Kills, Assists, GoldSpent, GoldEarned, TotalDamageTaken, TotalDamageDealtToChampions, TotalDamageDealt, PhysicalDamageTaken, PhysicalDamageDealtToChampions, PhysicalDamageDealt,
		MagicDamageTaken, MagicDamageDealtToChampions, MagicDamageDealt, TrueDamageTaken, TrueDamageDealtToChampions, TrueDamageDealt, TotalUnitsHealed, TotalHeal, TotalTimeCrowdControlDealt,
		WardsPlaced, WardsKilled, VisionWardsBoughtInGame, VisionScore, SightWardsBoughtInGame, TowerKills, InhibitorKills, FirstTowerKill, FirstTowerAssist, FirstInhibitorKill, FirstInhibitorAssist,
		FirstBloodKill, FirstBloodAssist, DoubleKills, TripleKills, QuadraKills, PentaKills, UnrealKills, KillingSprees, LargestKillingSpree, LargestCriticalStrike, NeutralMinionsKilledEnemyJungle,
		NeutralMinionsKilledJungle, TotalMinionsKilled, ParticipantID, Deaths, ChampionLevel)
	VALUES
		(@Winner, @Kills, @Assists, @GoldSpent, @GoldEarned, @TotalDamageTaken, @TotalDamageDealtToChampions, @TotalDamageDealt, @PhysicalDamageTaken, @PhysicalDamageDealtToChampions, @PhysicalDamageDealt,
		@MagicDamageTaken, @MagicDamageDealtToChampions, @MagicDamageDealt, @TrueDamageTaken, @TrueDamageDealtToChampions, @TrueDamageDealt, @TotalUnitsHealed, @TotalHeal, @TotalTimeCrowdControlDealt,
		@WardsPlaced, @WardsKilled, @VisionWardsBoughtInGame, @VisionScore, @SightWardsBoughtInGame, @TowerKills, @InhibitorKills, @FirstTowerKill, @FirstTowerAssist, @FirstInhibitorKill, @FirstInhibitorAssist,
		@FirstBloodKill, @FirstBloodAssist, @DoubleKills, @TripleKills, @QuadraKills, @PentaKills, @UnrealKills, @KillingSprees, @LargestKillingSpree, @LargestCriticalStrike, @NeutralMinionsKilledEnemyJungle,
		@NeutralMinionsKilledJungle, @TotalMinionsKilled, @ParticipantID, @Deaths, @ChampionLevel)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertSummoner]    Script Date: 12/11/2019 11:04:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ryan Knowles
-- Create date: 12/7/2019
-- Description:	Creates a Summoner
-- =============================================
CREATE PROCEDURE [dbo].[spInsertSummoner]
	
	@SummonerID varchar(100),
	@SummonerName varchar(100),
	@AccountID varchar(100),
	@ProfileIconID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Summoners
		(SummonerID, SummonerName, AccountID, ProfileIconID)
	VALUES
		(@SummonerID, @SummonerName, @AccountID, @ProfileIconID)
END
GO
USE [master]
GO
ALTER DATABASE [LeagueAnalyticsDB1] SET  READ_WRITE 
GO
