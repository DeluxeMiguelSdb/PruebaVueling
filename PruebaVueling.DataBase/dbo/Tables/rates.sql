CREATE TABLE [dbo].[rates] (
    [id]   INT         IDENTITY (1, 1) NOT NULL,
    [from] VARCHAR (3) NULL,
    [to]   VARCHAR (3) NULL,
    [rate] FLOAT (53)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

