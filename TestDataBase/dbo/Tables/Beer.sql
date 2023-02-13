CREATE TABLE [dbo].[Beer] (
    [BeerId]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                     VARCHAR (200) NOT NULL,
    [PercentageAlcholByVolume] FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_Beer] PRIMARY KEY CLUSTERED ([BeerId] ASC)
);

