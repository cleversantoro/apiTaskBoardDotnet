CREATE TABLE [dbo].[activity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[comment] Varchar(500) NULL,
	[old_value] Varchar(500) NULL,
	[new_value] Varchar(500) NULL,
	[timestamp] [int] NULL,
	[item_id] [int] NULL,
 CONSTRAINT [PK_activity] PRIMARY KEY CLUSTERED ([id] ASC)
)
GO

/****** Object:  Table [dbo].[board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[board](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[active] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)
GO

/****** Object:  Table [dbo].[board_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[board_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)

/****** Object:  Table [dbo].[category]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[color] Varchar(500) NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)

/****** Object:  Table [dbo].[collapsed]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[collapsed](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[lane_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)

/****** Object:  Table [dbo].[jwt]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[jwt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] Varchar(500) NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)

/****** Object:  Table [dbo].[lane]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[lane](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] Varchar(500) NULL,
	[position] [int] NULL,
	[board_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
)

/****** Object:  Table [dbo].[option]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[option](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tasks_order] [int] NULL,
	[show_animations] [int] NULL,
	[show_assignee] [int] NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
) 

/****** Object:  Table [dbo].[token]    Script Date: 27/04/2018 15:52:38 ******/
CREATE TABLE [dbo].[token](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] Varchar(500) NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED (	[id] ASC)
) 

/****** Object:  Table [dbo].[user]    Script Date: 27/04/2018 15:52:38 ******/
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
PRIMARY KEY CLUSTERED (	[id] ASC)
)


/****** Object:  Index [index_foreignkey_activity_item]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_activity_item] ON [dbo].[activity](	[item_id] ASC)
GO

/****** Object:  Index [index_foreignkey_board_user_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_board_user_board] ON [dbo].[board_user](	[board_id] ASC)
GO

/****** Object:  Index [index_foreignkey_board_user_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_board_user_user] ON [dbo].[board_user](	[user_id] ASC)
GO

/****** Object:  Index [UQ_board_useruser_id__board_id]    Script Date: 27/04/2018 15:52:38 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_board_useruser_id__board_id] ON [dbo].[board_user](	[user_id] ASC,	[board_id] ASC)
GO

/****** Object:  Index [index_foreignkey_category_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_category_board] ON [dbo].[category](	[board_id] ASC)
GO

/****** Object:  Index [index_foreignkey_collapsed_lane]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_collapsed_lane] ON [dbo].[collapsed](	[lane_id] ASC)
GO

/****** Object:  Index [index_foreignkey_collapsed_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_collapsed_user] ON [dbo].[collapsed](	[user_id] ASC)
GO

/****** Object:  Index [index_foreignkey_lane_board]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_lane_board] ON [dbo].[lane](	[board_id] ASC)
GO

/****** Object:  Index [index_foreignkey_option_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_option_user] ON [dbo].[option](	[user_id] ASC)
GO

/****** Object:  Index [index_foreignkey_token_user]    Script Date: 27/04/2018 15:52:38 ******/
CREATE NONCLUSTERED INDEX [index_foreignkey_token_user] ON [dbo].[token](	[user_id] ASC)
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
