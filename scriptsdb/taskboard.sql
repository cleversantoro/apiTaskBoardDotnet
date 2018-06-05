CREATE TABLE activity ( 
id INT IDENTITY(1,1)  PRIMARY KEY,
comment TEXT,
old_value TEXT,
new_value TEXT,
timestamp INT,
item_id INT   
)

CREATE TABLE board ( 
id INT IDENTITY(1,1) PRIMARY KEY, 
name TEXT, 
active INT
)

CREATE TABLE [user] ( 
id INT IDENTITY(1,1) PRIMARY KEY, 
username TEXT, 
is_admin INT, 
logins INT, 
last_login INT, 
default_board INT, 
salt TEXT, 
[password] TEXT, 
email TEXT
)

CREATE TABLE jwt ( 
id INT IDENTITY(1,1) PRIMARY KEY, 
token TEXT
)						 

CREATE TABLE board_user ( 
id INT IDENTITY(1,1) PRIMARY KEY,
user_id INT,
board_id INT, 

FOREIGN KEY(board_id) REFERENCES board(id) ON DELETE CASCADE ON UPDATE CASCADE, 
FOREIGN KEY(user_id) REFERENCES [user](id) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE category ( 
id INT IDENTITY(1,1) PRIMARY KEY,
name TEXT,
color TEXT,
board_id INT, 
FOREIGN KEY(board_id) REFERENCES board(id) ON DELETE CASCADE ON UPDATE CASCADE 
)

CREATE TABLE lane ( 
id INT IDENTITY(1,1) PRIMARY KEY,
name TEXT,
position INT,
board_id INT  , 

FOREIGN KEY(board_id) REFERENCES board(id) ON DELETE CASCADE ON UPDATE CASCADE 
)						 

CREATE TABLE collapsed ( 
id INT IDENTITY(1,1) PRIMARY KEY,
user_id INT,
lane_id INT, 

FOREIGN KEY(user_id) REFERENCES [user](id) ON DELETE SET NULL ON UPDATE SET NULL, 
FOREIGN KEY(lane_id) REFERENCES lane(id) ON DELETE SET NULL ON UPDATE SET NULL 
)
						 
CREATE TABLE [option] ( 
id INTEGER IDENTITY(1,1) PRIMARY KEY,
tasks_order INTEGER,
show_animations INTEGER,
show_assignee INTEGER,
user_id INTEGER,
 
FOREIGN KEY(user_id) REFERENCES [user](id) ON DELETE CASCADE ON UPDATE CASCADE 
)						 

CREATE TABLE token ( 
id INTEGER IDENTITY(1,1) PRIMARY KEY,
token TEXT,
user_id INTEGER, 

FOREIGN KEY(user_id) REFERENCES [user](id) ON DELETE SET NULL ON UPDATE SET NULL 
)



sqlite

CREATE TABLE `activity` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`comment` TEXT,`old_value` TEXT,`new_value` TEXT,`timestamp` INTEGER,`item_id` INTEGER   );

CREATE TABLE `board` ( id INTEGER PRIMARY KEY AUTOINCREMENT , `name` TEXT, `active` INTEGER);

CREATE TABLE `board_user` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`user_id` INTEGER,`board_id` INTEGER  , FOREIGN KEY(`board_id`)
						 REFERENCES `board`(`id`)
						 ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY(`user_id`)
						 REFERENCES `user`(`id`)
						 ON DELETE CASCADE ON UPDATE CASCADE );

CREATE TABLE `category` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`name` TEXT,`color` TEXT,`board_id` INTEGER  , FOREIGN KEY(`board_id`)
						 REFERENCES `board`(`id`)
						 ON DELETE CASCADE ON UPDATE CASCADE );

CREATE TABLE `collapsed` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`user_id` INTEGER,`lane_id` INTEGER  , FOREIGN KEY(`user_id`)
						 REFERENCES `user`(`id`)
						 ON DELETE SET NULL ON UPDATE SET NULL, FOREIGN KEY(`lane_id`)
						 REFERENCES `lane`(`id`)
						 ON DELETE SET NULL ON UPDATE SET NULL );

CREATE TABLE `jwt` ( id INTEGER PRIMARY KEY AUTOINCREMENT , `token` TEXT);

CREATE TABLE `lane` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`name` TEXT,`position` INTEGER,`board_id` INTEGER  , FOREIGN KEY(`board_id`)
						 REFERENCES `board`(`id`)
						 ON DELETE CASCADE ON UPDATE CASCADE );

CREATE TABLE `option` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`tasks_order` INTEGER,`show_animations` INTEGER,`show_assignee` INTEGER,`user_id` INTEGER  , FOREIGN KEY(`user_id`)
						 REFERENCES `user`(`id`)
						 ON DELETE CASCADE ON UPDATE CASCADE );

CREATE TABLE `token` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT  ,`token` TEXT,`user_id` INTEGER  , FOREIGN KEY(`user_id`)
						 REFERENCES `user`(`id`)
						 ON DELETE SET NULL ON UPDATE SET NULL );

CREATE TABLE `user` ( id INTEGER PRIMARY KEY AUTOINCREMENT , `username` TEXT, `is_admin` INTEGER, `logins` INTEGER, `last_login` INTEGER, `default_board` INTEGER, `salt` TEXT, `password` TEXT, `email` TEXT);

CREATE INDEX index_foreignkey_activity_item ON `activity` (item_id);

CREATE INDEX index_foreignkey_board_user_user ON `board_user` (user_id);

CREATE INDEX index_foreignkey_board_user_board ON `board_user` (board_id);

CREATE UNIQUE INDEX UQ_board_useruser_id__board_id ON `board_user` (`user_id`,`board_id`);

CREATE INDEX index_foreignkey_category_board ON `category` (board_id);

CREATE INDEX index_foreignkey_collapsed_lane ON `collapsed` (lane_id);

CREATE INDEX index_foreignkey_collapsed_user ON `collapsed` (user_id);

CREATE INDEX index_foreignkey_lane_board ON `lane` (board_id);

CREATE INDEX index_foreignkey_option_user ON `option` (user_id);

CREATE INDEX index_foreignkey_token_user ON `token` (user_id);


