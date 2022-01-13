CREATE TABLE transactions (
	id			int identity(1,1) NOT NULL,
	sku			varchar(5),
	aomunt		decimal,
	currency	varchar(2)
);

CREATE TABLE rates (
	id			int identity(1,1) NOT NULL,
	[from]		varchar(3),
	[to]		varchar(3),
	rate		decimal
);


INSERT INTO transactions values ('S2006',33.33,'EU')


SELECT * from dbo.transactions

DROP TABLE transactions