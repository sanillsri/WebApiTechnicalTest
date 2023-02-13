CREATE TABLE [dbo].[Bar] (
    [BarId]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (500) NULL,
    [Address] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Bar] PRIMARY KEY CLUSTERED ([BarId] ASC)
);

