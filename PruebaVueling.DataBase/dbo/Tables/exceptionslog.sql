CREATE TABLE [dbo].[exceptionslog] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [description]   VARCHAR (MAX) NULL,
    [creation_date] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

