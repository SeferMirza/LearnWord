CREATE TABLE [dbo].[Kelimeler] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [KelimeIng]    NVARCHAR (50) NOT NULL,
    [KelimeTurkce] NVARCHAR (50) NOT NULL,
    [Durum]        CHAR(10)           NOT NULL,
    [Tarih]        INT           NOT NULL,
    [BaslangicTarih] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

