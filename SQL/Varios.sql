CREATE TABLE rates (
	id			int IDENTITY(1,1) PRIMARY KEY,
	[from]		varchar(3),
	[to]		varchar(3),
	rate		float
);
CREATE TABLE transactions (
	id			int IDENTITY(1,1) PRIMARY KEY,
	sku			varchar(5),
	amount		float,
	currency	varchar(3)
);

INSERT INTO transactions values ('S2006',33.33,'EU')


SELECT * from dbo.rates

DROP TABLE dbo.rates

DROP TABLE dbo.transactions