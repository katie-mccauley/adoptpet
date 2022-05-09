CREATE TABLE IF NOT EXISTS accounts(
	id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
	createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
	updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
	name varchar(255) COMMENT 'User Name',
	email varchar(255) COMMENT 'User Email',
	picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS posts(
	id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
	creatorId VARCHAR(255) NOT NULL,
	description TEXT NOT NULL,
	img TEXT NOT NULL,
	type TEXT NOT NULL,
	views INT NOT NULL DEFAULT 0,
	offers INT NOT NULL DEFAULT 0
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS comments(
	id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
	creatorId VARCHAR(255) NOT NULL,
	postId INT NOT NULL,
	body TEXT NOT NULL,
	FOREIGN KEY (postId) REFERENCES posts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS likes(
	id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
	creatorId VARCHAR(255) NOT NULL,
	likecount INT NOT NULL,
	postId INT NOT NULL,
	likerId VARCHAR(255) NOT NULL,
	FOREIGN KEY (postId) REFERENCES posts(id) ON DELETE CASCADE,
	FOREIGN KEY (likerId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';