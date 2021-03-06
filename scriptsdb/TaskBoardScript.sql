USE [master]
GO
/****** Object:  Database [TaskBoard]    Script Date: 27/04/2018 15:52:38 ******/
CREATE DATABASE [TaskBoard] ON  PRIMARY 
( NAME = N'TaskBoard', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TaskBoard.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'TaskBoard_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TaskBoard_log.ldf' , SIZE = 22528KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TaskBoard] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskBoard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskBoard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskBoard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskBoard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskBoard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskBoard] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskBoard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskBoard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskBoard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskBoard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskBoard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskBoard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskBoard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskBoard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskBoard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskBoard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskBoard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskBoard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskBoard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskBoard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskBoard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskBoard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskBoard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskBoard] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskBoard] SET  MULTI_USER 
GO
ALTER DATABASE [TaskBoard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskBoard] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaskBoard', N'ON'
GO
USE [TaskBoard]
GO
/****** Object:  User [Usr_BackupSymantec]    Script Date: 27/04/2018 15:52:38 ******/
CREATE USER [Usr_BackupSymantec] FOR LOGIN [Usr_BackupSymantec] WITH DEFAULT_SCHEMA=[Usr_BackupSymantec]
GO
/****** Object:  User [renan willian]    Script Date: 27/04/2018 15:52:38 ******/
CREATE USER [renan willian] FOR LOGIN [KALUNGA\renan willian] WITH DEFAULT_SCHEMA=[renan willian]
GO
/****** Object:  User [kabackup]    Script Date: 27/04/2018 15:52:38 ******/
CREATE USER [kabackup] FOR LOGIN [KALUNGA\kabackup] WITH DEFAULT_SCHEMA=[kabackup]
GO
ALTER ROLE [db_owner] ADD MEMBER [Usr_BackupSymantec]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Usr_BackupSymantec]
GO
ALTER ROLE [db_owner] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_datareader] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [renan willian]
GO
ALTER ROLE [db_owner] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_datareader] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [kabackup]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [kabackup]
GO
/****** Object:  Schema [kabackup]    Script Date: 27/04/2018 15:52:38 ******/
CREATE SCHEMA [kabackup]
GO
/****** Object:  Schema [renan willian]    Script Date: 27/04/2018 15:52:38 ******/
CREATE SCHEMA [renan willian]
GO
/****** Object:  Schema [Usr_BackupSymantec]    Script Date: 27/04/2018 15:52:38 ******/
CREATE SCHEMA [Usr_BackupSymantec]
GO
/****** Object:  Table [dbo].[activity]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[activity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[comment] Varchar(500) NULL,
	[old_value] Varchar(500) NULL,
	[new_value] Varchar(500) NULL,
	[timestamp] [int] NULL,
	[item_id] [int] NULL,
 CONSTRAINT [PK_activity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[board]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[board_user]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[color] Varchar(500) NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collapsed]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[collapsed](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[lane_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jwt]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jwt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] Varchar(500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lane]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lane](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[position] [int] NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[option]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[option](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tasks_order] [int] NULL,
	[show_animations] [int] NULL,
	[show_assignee] [int] NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[token]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[token](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] Varchar(500) NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 27/04/2018 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] Varchar(500) NULL,
	[is_admin] [int] NULL,
	[logins] [int] NULL,
	[last_login] [int] NULL,
	[default_board] [int] NULL,
	[salt] Varchar(500) NULL,
	[password] Varchar(500) NULL,
	[email] Varchar(500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_activity_item]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_activity_item] ON [dbo].[activity]
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_board_user_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_board_user_board] ON [dbo].[board_user]
(
	[board_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_board_user_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_board_user_user] ON [dbo].[board_user]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_board_useruser_id__board_id]    Script Date: 27/04/2018 15:52:38 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_board_useruser_id__board_id] ON [dbo].[board_user]
(
	[user_id] ASC,
	[board_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_category_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_category_board] ON [dbo].[category]
(
	[board_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_collapsed_lane]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_collapsed_lane] ON [dbo].[collapsed]
(
	[lane_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_collapsed_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_collapsed_user] ON [dbo].[collapsed]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_lane_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_lane_board] ON [dbo].[lane]
(
	[board_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_option_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_option_user] ON [dbo].[option]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [index_foreignkey_token_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_token_user] ON [dbo].[token]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[board_user]  WITH CHECK ADD FOREIGN KEY([board_id])
REFERENCES [dbo].[board] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[board_user]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[category]  WITH CHECK ADD FOREIGN KEY([board_id])
REFERENCES [dbo].[board] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[collapsed]  WITH CHECK ADD FOREIGN KEY([lane_id])
REFERENCES [dbo].[lane] ([id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[collapsed]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[lane]  WITH CHECK ADD FOREIGN KEY([board_id])
REFERENCES [dbo].[board] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[option]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[token]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
USE [master]
GO
ALTER DATABASE [TaskBoard] SET  READ_WRITE 
GO
