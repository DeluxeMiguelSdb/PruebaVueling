CREATE TABLE [dbo].[transactions] (
    [id]       INT         IDENTITY (1, 1) NOT NULL,
    [sku]      VARCHAR (5) NULL,
    [amount]   FLOAT (53)  NULL,
    [currency] VARCHAR (3) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

