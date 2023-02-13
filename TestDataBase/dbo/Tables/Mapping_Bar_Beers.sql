CREATE TABLE [dbo].[Mapping_Bar_Beers] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [BarId]  INT NOT NULL,
    [BeerId] INT NOT NULL,
    CONSTRAINT [PK_Mapping_Bar_Beers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mapping_Bar_Beers_Bar] FOREIGN KEY ([BarId]) REFERENCES [dbo].[Bar] ([BarId]),
    CONSTRAINT [FK_Mapping_Bar_Beers_Beer] FOREIGN KEY ([BeerId]) REFERENCES [dbo].[Beer] ([BeerId])
);

