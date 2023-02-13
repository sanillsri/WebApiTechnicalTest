CREATE TABLE [dbo].[Mapping_Brewery_Beers] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [BreweryId] INT NOT NULL,
    [BeerId]    INT NOT NULL,
    CONSTRAINT [PK_Mapping_Brewery_Beers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mapping_Brewery_Beers_Beer] FOREIGN KEY ([BeerId]) REFERENCES [dbo].[Beer] ([BeerId]),
    CONSTRAINT [FK_Mapping_Brewery_Beers_Brewery] FOREIGN KEY ([BreweryId]) REFERENCES [dbo].[Brewery] ([BreweryId])
);

