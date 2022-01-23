CREATE TABLE transactions (
	id			int IDENTITY(1,1) PRIMARY KEY,
	sku			varchar(5),
	amount		float,
	currency	varchar(3)
);

CREATE TABLE rates (
	id			int IDENTITY(1,1) PRIMARY KEY,
	[from]		varchar(3),
	[to]		varchar(3),
	rate		decimal
);

CREATE TABLE exceptionslog (
	id				int IDENTITY(1,1) PRIMARY KEY,
	description		varchar(MAX),
	creation_date	DATETIME
);

DROP TABLE dbo.transactions