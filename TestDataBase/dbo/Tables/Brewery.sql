CREATE TABLE [dbo].[Brewery] (
    [BreweryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (500) NULL,
    CONSTRAINT [PK_Brewery] PRIMARY KEY CLUSTERED ([BreweryId] ASC)
);

