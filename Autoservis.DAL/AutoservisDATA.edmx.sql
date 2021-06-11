
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2019 20:24:03
-- Generated from EDMX file: C:\Users\matija\source\repos\Autoservis\Autoservis.DAL\AutoservisDATA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [autoservis];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ZaposlenikAdresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZaposlenikSet] DROP CONSTRAINT [FK_ZaposlenikAdresa];
GO
IF OBJECT_ID(N'[dbo].[FK_ObradaVozilaVozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObradaVozilaSet] DROP CONSTRAINT [FK_ObradaVozilaVozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_MjestoAdresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdresaSet] DROP CONSTRAINT [FK_MjestoAdresa];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloKlijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VoziloSet] DROP CONSTRAINT [FK_VoziloKlijent];
GO
IF OBJECT_ID(N'[dbo].[FK_TerminPregledaVozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TerminPregledaSet] DROP CONSTRAINT [FK_TerminPregledaVozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_TerminPregledaKlijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TerminPregledaSet] DROP CONSTRAINT [FK_TerminPregledaKlijent];
GO
IF OBJECT_ID(N'[dbo].[FK_DobavljacAdresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DobavljacSet] DROP CONSTRAINT [FK_DobavljacAdresa];
GO
IF OBJECT_ID(N'[dbo].[FK_DobavljacKatalog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KatalogSet] DROP CONSTRAINT [FK_DobavljacKatalog];
GO
IF OBJECT_ID(N'[dbo].[FK_KatalogRezervniDio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KatalogSet] DROP CONSTRAINT [FK_KatalogRezervniDio];
GO
IF OBJECT_ID(N'[dbo].[FK_StavkaNarudzbaRezervniDio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StavkaNarudzbaSet] DROP CONSTRAINT [FK_StavkaNarudzbaRezervniDio];
GO
IF OBJECT_ID(N'[dbo].[FK_StavkaNarudzbaNarudzba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StavkaNarudzbaSet] DROP CONSTRAINT [FK_StavkaNarudzbaNarudzba];
GO
IF OBJECT_ID(N'[dbo].[FK_ZahtjevZaNarudzbomStavkaZahtjevZaNarudzbom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet] DROP CONSTRAINT [FK_ZahtjevZaNarudzbomStavkaZahtjevZaNarudzbom];
GO
IF OBJECT_ID(N'[dbo].[FK_ZahtjevZaNarudzbomStavkaRezervniDio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet] DROP CONSTRAINT [FK_ZahtjevZaNarudzbomStavkaRezervniDio];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamijenaDijelaRezervniDio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UslugaSet_ZamijenaDijela] DROP CONSTRAINT [FK_ZamijenaDijelaRezervniDio];
GO
IF OBJECT_ID(N'[dbo].[FK_RacunStavkaRacun]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RacunStavkaSet] DROP CONSTRAINT [FK_RacunStavkaRacun];
GO
IF OBJECT_ID(N'[dbo].[FK_RacunStavkaUsluga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RacunStavkaSet] DROP CONSTRAINT [FK_RacunStavkaUsluga];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentAdresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlijentSet] DROP CONSTRAINT [FK_KlijentAdresa];
GO
IF OBJECT_ID(N'[dbo].[FK_RacunZaposlenik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RacunSet] DROP CONSTRAINT [FK_RacunZaposlenik];
GO
IF OBJECT_ID(N'[dbo].[FK_ZahtjevZaNarudzbomZaposlenik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZahtjevZaNarudzbomSet] DROP CONSTRAINT [FK_ZahtjevZaNarudzbomZaposlenik];
GO
IF OBJECT_ID(N'[dbo].[FK_NarudzbaZaposlenik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NarudzbaSet] DROP CONSTRAINT [FK_NarudzbaZaposlenik];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaposlenikObradaZaposlenik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZaposlenikObradaSet] DROP CONSTRAINT [FK_ZaposlenikObradaZaposlenik];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaposlenikObradaObradaVozila]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZaposlenikObradaSet] DROP CONSTRAINT [FK_ZaposlenikObradaObradaVozila];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamijenaDijela_inherits_Usluga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UslugaSet_ZamijenaDijela] DROP CONSTRAINT [FK_ZamijenaDijela_inherits_Usluga];
GO
IF OBJECT_ID(N'[dbo].[FK_Posao_inherits_Usluga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UslugaSet_Posao] DROP CONSTRAINT [FK_Posao_inherits_Usluga];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KlijentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlijentSet];
GO
IF OBJECT_ID(N'[dbo].[MjestoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MjestoSet];
GO
IF OBJECT_ID(N'[dbo].[AdresaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdresaSet];
GO
IF OBJECT_ID(N'[dbo].[VoziloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VoziloSet];
GO
IF OBJECT_ID(N'[dbo].[TerminPregledaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TerminPregledaSet];
GO
IF OBJECT_ID(N'[dbo].[ZaposlenikSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZaposlenikSet];
GO
IF OBJECT_ID(N'[dbo].[ObradaVozilaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObradaVozilaSet];
GO
IF OBJECT_ID(N'[dbo].[RacunSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RacunSet];
GO
IF OBJECT_ID(N'[dbo].[UslugaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UslugaSet];
GO
IF OBJECT_ID(N'[dbo].[RezervniDioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RezervniDioSet];
GO
IF OBJECT_ID(N'[dbo].[DobavljacSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DobavljacSet];
GO
IF OBJECT_ID(N'[dbo].[KatalogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KatalogSet];
GO
IF OBJECT_ID(N'[dbo].[NarudzbaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NarudzbaSet];
GO
IF OBJECT_ID(N'[dbo].[StavkaNarudzbaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StavkaNarudzbaSet];
GO
IF OBJECT_ID(N'[dbo].[ZahtjevZaNarudzbomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZahtjevZaNarudzbomSet];
GO
IF OBJECT_ID(N'[dbo].[ZahtjevZaNarudzbomStavkaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet];
GO
IF OBJECT_ID(N'[dbo].[RacunStavkaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RacunStavkaSet];
GO
IF OBJECT_ID(N'[dbo].[ZaposlenikObradaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZaposlenikObradaSet];
GO
IF OBJECT_ID(N'[dbo].[UslugaSet_ZamijenaDijela]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UslugaSet_ZamijenaDijela];
GO
IF OBJECT_ID(N'[dbo].[UslugaSet_Posao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UslugaSet_Posao];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KlijentSet'
CREATE TABLE [dbo].[KlijentSet] (
    [IdKlijent] int IDENTITY(1,1) NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Lozinka] nvarchar(max)  NOT NULL,
    [AdresaIdAdresa] int  NOT NULL
);
GO

-- Creating table 'MjestoSet'
CREATE TABLE [dbo].[MjestoSet] (
    [IdMjesto] int IDENTITY(1,1) NOT NULL,
    [PostanskiBroj] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdresaSet'
CREATE TABLE [dbo].[AdresaSet] (
    [Naziv] nvarchar(max)  NOT NULL,
    [KucniBroj] nvarchar(max)  NOT NULL,
    [MjestoIdMjesto] int  NOT NULL,
    [IdAdresa] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'VoziloSet'
CREATE TABLE [dbo].[VoziloSet] (
    [IdVozilo] int IDENTITY(1,1) NOT NULL,
    [Marka] nvarchar(max)  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL,
    [GodinaProizvodnje] smallint  NOT NULL,
    [Klijent_IdKlijent] int  NOT NULL
);
GO

-- Creating table 'TerminPregledaSet'
CREATE TABLE [dbo].[TerminPregledaSet] (
    [DatumIVrijeme] datetime  NOT NULL,
    [VoziloIdVozilo] int  NOT NULL,
    [KlijentIdKlijent] int  NOT NULL,
    [Status] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ZaposlenikSet'
CREATE TABLE [dbo].[ZaposlenikSet] (
    [IdZaposlenik] int IDENTITY(1,1) NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [DatumZaposlenja] datetime  NOT NULL,
    [IdAdresa_IdAdresa] int  NOT NULL
);
GO

-- Creating table 'ObradaVozilaSet'
CREATE TABLE [dbo].[ObradaVozilaSet] (
    [IdObrada] int IDENTITY(1,1) NOT NULL,
    [DatumIVrijemeZaprimanja] datetime  NOT NULL,
    [DatumIVrijemePreuzimanja] datetime  NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [VoziloIdVozilo] int  NOT NULL
);
GO

-- Creating table 'RacunSet'
CREATE TABLE [dbo].[RacunSet] (
    [IdRacun] int IDENTITY(1,1) NOT NULL,
    [DatumIzdavanja] datetime  NULL,
    [Iznos] decimal(18,0)  NOT NULL,
    [KlijentIdKlijent] int  NOT NULL,
    [ZaposlenikIdZaposlenik] int  NOT NULL
);
GO

-- Creating table 'UslugaSet'
CREATE TABLE [dbo].[UslugaSet] (
    [IdUsluga] int IDENTITY(1,1) NOT NULL,
    [Cijena] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'RezervniDioSet'
CREATE TABLE [dbo].[RezervniDioSet] (
    [IdRezervniDio] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Cijena] decimal(18,0)  NOT NULL,
    [DostupnaKolicina] int  NOT NULL
);
GO

-- Creating table 'DobavljacSet'
CREATE TABLE [dbo].[DobavljacSet] (
    [IdDobavljac] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [AdresaIdAdresa] int  NOT NULL
);
GO

-- Creating table 'KatalogSet'
CREATE TABLE [dbo].[KatalogSet] (
    [Cijena] decimal(18,0)  NOT NULL,
    [DobavljacIdDobavljac] int  NOT NULL,
    [RezervniDioIdRezervniDio] int  NOT NULL
);
GO

-- Creating table 'NarudzbaSet'
CREATE TABLE [dbo].[NarudzbaSet] (
    [IdNarudzba] int IDENTITY(1,1) NOT NULL,
    [VoditeljIdVoditelj] int  NOT NULL,
    [DatumNarudzbe] datetime  NOT NULL,
    [ZaposlenikIdZaposlenik] int  NOT NULL
);
GO

-- Creating table 'StavkaNarudzbaSet'
CREATE TABLE [dbo].[StavkaNarudzbaSet] (
    [Kolicina] int  NOT NULL,
    [RezervniDioIdRezervniDio] int  NOT NULL,
    [IdNarudzba] int  NOT NULL
);
GO

-- Creating table 'ZahtjevZaNarudzbomSet'
CREATE TABLE [dbo].[ZahtjevZaNarudzbomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MehanicarIdMehanicar] int  NOT NULL,
    [Datum] datetime  NOT NULL,
    [ZaposlenikIdZaposlenik] int  NOT NULL
);
GO

-- Creating table 'ZahtjevZaNarudzbomStavkaSet'
CREATE TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet] (
    [ZahtjevZaNarudzbomId] int  NOT NULL,
    [ZahtjevanaKolicina] int  NOT NULL,
    [NarucenaKolicina] int  NOT NULL,
    [RezervniDioIdRezervniDio] int  NOT NULL
);
GO

-- Creating table 'RacunStavkaSet'
CREATE TABLE [dbo].[RacunStavkaSet] (
    [RacunIdRacun] int  NOT NULL,
    [UslugaIdUsluga] int  NOT NULL,
    [Kolicina] int  NOT NULL,
    [Cijena] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ZaposlenikObradaSet'
CREATE TABLE [dbo].[ZaposlenikObradaSet] (
    [ZaposlenikIdZaposlenik] int  NOT NULL,
    [ObradaVozilaIdObrada] int  NOT NULL,
    [BrojPopravaka] int  NOT NULL
);
GO

-- Creating table 'UslugaSet_ZamijenaDijela'
CREATE TABLE [dbo].[UslugaSet_ZamijenaDijela] (
    [RezervniDioIdRezervniDio1] int  NOT NULL,
    [IdUsluga] int  NOT NULL
);
GO

-- Creating table 'UslugaSet_Posao'
CREATE TABLE [dbo].[UslugaSet_Posao] (
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [IdUsluga] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdKlijent] in table 'KlijentSet'
ALTER TABLE [dbo].[KlijentSet]
ADD CONSTRAINT [PK_KlijentSet]
    PRIMARY KEY CLUSTERED ([IdKlijent] ASC);
GO

-- Creating primary key on [IdMjesto] in table 'MjestoSet'
ALTER TABLE [dbo].[MjestoSet]
ADD CONSTRAINT [PK_MjestoSet]
    PRIMARY KEY CLUSTERED ([IdMjesto] ASC);
GO

-- Creating primary key on [IdAdresa] in table 'AdresaSet'
ALTER TABLE [dbo].[AdresaSet]
ADD CONSTRAINT [PK_AdresaSet]
    PRIMARY KEY CLUSTERED ([IdAdresa] ASC);
GO

-- Creating primary key on [IdVozilo] in table 'VoziloSet'
ALTER TABLE [dbo].[VoziloSet]
ADD CONSTRAINT [PK_VoziloSet]
    PRIMARY KEY CLUSTERED ([IdVozilo] ASC);
GO

-- Creating primary key on [Id] in table 'TerminPregledaSet'
ALTER TABLE [dbo].[TerminPregledaSet]
ADD CONSTRAINT [PK_TerminPregledaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdZaposlenik] in table 'ZaposlenikSet'
ALTER TABLE [dbo].[ZaposlenikSet]
ADD CONSTRAINT [PK_ZaposlenikSet]
    PRIMARY KEY CLUSTERED ([IdZaposlenik] ASC);
GO

-- Creating primary key on [IdObrada] in table 'ObradaVozilaSet'
ALTER TABLE [dbo].[ObradaVozilaSet]
ADD CONSTRAINT [PK_ObradaVozilaSet]
    PRIMARY KEY CLUSTERED ([IdObrada] ASC);
GO

-- Creating primary key on [IdRacun] in table 'RacunSet'
ALTER TABLE [dbo].[RacunSet]
ADD CONSTRAINT [PK_RacunSet]
    PRIMARY KEY CLUSTERED ([IdRacun] ASC);
GO

-- Creating primary key on [IdUsluga] in table 'UslugaSet'
ALTER TABLE [dbo].[UslugaSet]
ADD CONSTRAINT [PK_UslugaSet]
    PRIMARY KEY CLUSTERED ([IdUsluga] ASC);
GO

-- Creating primary key on [IdRezervniDio] in table 'RezervniDioSet'
ALTER TABLE [dbo].[RezervniDioSet]
ADD CONSTRAINT [PK_RezervniDioSet]
    PRIMARY KEY CLUSTERED ([IdRezervniDio] ASC);
GO

-- Creating primary key on [IdDobavljac] in table 'DobavljacSet'
ALTER TABLE [dbo].[DobavljacSet]
ADD CONSTRAINT [PK_DobavljacSet]
    PRIMARY KEY CLUSTERED ([IdDobavljac] ASC);
GO

-- Creating primary key on [DobavljacIdDobavljac], [RezervniDioIdRezervniDio] in table 'KatalogSet'
ALTER TABLE [dbo].[KatalogSet]
ADD CONSTRAINT [PK_KatalogSet]
    PRIMARY KEY CLUSTERED ([DobavljacIdDobavljac], [RezervniDioIdRezervniDio] ASC);
GO

-- Creating primary key on [IdNarudzba] in table 'NarudzbaSet'
ALTER TABLE [dbo].[NarudzbaSet]
ADD CONSTRAINT [PK_NarudzbaSet]
    PRIMARY KEY CLUSTERED ([IdNarudzba] ASC);
GO

-- Creating primary key on [IdNarudzba], [RezervniDioIdRezervniDio] in table 'StavkaNarudzbaSet'
ALTER TABLE [dbo].[StavkaNarudzbaSet]
ADD CONSTRAINT [PK_StavkaNarudzbaSet]
    PRIMARY KEY CLUSTERED ([IdNarudzba], [RezervniDioIdRezervniDio] ASC);
GO

-- Creating primary key on [Id] in table 'ZahtjevZaNarudzbomSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomSet]
ADD CONSTRAINT [PK_ZahtjevZaNarudzbomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ZahtjevZaNarudzbomId], [RezervniDioIdRezervniDio] in table 'ZahtjevZaNarudzbomStavkaSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet]
ADD CONSTRAINT [PK_ZahtjevZaNarudzbomStavkaSet]
    PRIMARY KEY CLUSTERED ([ZahtjevZaNarudzbomId], [RezervniDioIdRezervniDio] ASC);
GO

-- Creating primary key on [RacunIdRacun], [UslugaIdUsluga] in table 'RacunStavkaSet'
ALTER TABLE [dbo].[RacunStavkaSet]
ADD CONSTRAINT [PK_RacunStavkaSet]
    PRIMARY KEY CLUSTERED ([RacunIdRacun], [UslugaIdUsluga] ASC);
GO

-- Creating primary key on [ZaposlenikIdZaposlenik], [ObradaVozilaIdObrada] in table 'ZaposlenikObradaSet'
ALTER TABLE [dbo].[ZaposlenikObradaSet]
ADD CONSTRAINT [PK_ZaposlenikObradaSet]
    PRIMARY KEY CLUSTERED ([ZaposlenikIdZaposlenik], [ObradaVozilaIdObrada] ASC);
GO

-- Creating primary key on [IdUsluga] in table 'UslugaSet_ZamijenaDijela'
ALTER TABLE [dbo].[UslugaSet_ZamijenaDijela]
ADD CONSTRAINT [PK_UslugaSet_ZamijenaDijela]
    PRIMARY KEY CLUSTERED ([IdUsluga] ASC);
GO

-- Creating primary key on [IdUsluga] in table 'UslugaSet_Posao'
ALTER TABLE [dbo].[UslugaSet_Posao]
ADD CONSTRAINT [PK_UslugaSet_Posao]
    PRIMARY KEY CLUSTERED ([IdUsluga] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAdresa_IdAdresa] in table 'ZaposlenikSet'
ALTER TABLE [dbo].[ZaposlenikSet]
ADD CONSTRAINT [FK_ZaposlenikAdresa]
    FOREIGN KEY ([IdAdresa_IdAdresa])
    REFERENCES [dbo].[AdresaSet]
        ([IdAdresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZaposlenikAdresa'
CREATE INDEX [IX_FK_ZaposlenikAdresa]
ON [dbo].[ZaposlenikSet]
    ([IdAdresa_IdAdresa]);
GO

-- Creating foreign key on [VoziloIdVozilo] in table 'ObradaVozilaSet'
ALTER TABLE [dbo].[ObradaVozilaSet]
ADD CONSTRAINT [FK_ObradaVozilaVozilo]
    FOREIGN KEY ([VoziloIdVozilo])
    REFERENCES [dbo].[VoziloSet]
        ([IdVozilo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObradaVozilaVozilo'
CREATE INDEX [IX_FK_ObradaVozilaVozilo]
ON [dbo].[ObradaVozilaSet]
    ([VoziloIdVozilo]);
GO

-- Creating foreign key on [MjestoIdMjesto] in table 'AdresaSet'
ALTER TABLE [dbo].[AdresaSet]
ADD CONSTRAINT [FK_MjestoAdresa]
    FOREIGN KEY ([MjestoIdMjesto])
    REFERENCES [dbo].[MjestoSet]
        ([IdMjesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MjestoAdresa'
CREATE INDEX [IX_FK_MjestoAdresa]
ON [dbo].[AdresaSet]
    ([MjestoIdMjesto]);
GO

-- Creating foreign key on [Klijent_IdKlijent] in table 'VoziloSet'
ALTER TABLE [dbo].[VoziloSet]
ADD CONSTRAINT [FK_VoziloKlijent]
    FOREIGN KEY ([Klijent_IdKlijent])
    REFERENCES [dbo].[KlijentSet]
        ([IdKlijent])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoziloKlijent'
CREATE INDEX [IX_FK_VoziloKlijent]
ON [dbo].[VoziloSet]
    ([Klijent_IdKlijent]);
GO

-- Creating foreign key on [VoziloIdVozilo] in table 'TerminPregledaSet'
ALTER TABLE [dbo].[TerminPregledaSet]
ADD CONSTRAINT [FK_TerminPregledaVozilo]
    FOREIGN KEY ([VoziloIdVozilo])
    REFERENCES [dbo].[VoziloSet]
        ([IdVozilo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TerminPregledaVozilo'
CREATE INDEX [IX_FK_TerminPregledaVozilo]
ON [dbo].[TerminPregledaSet]
    ([VoziloIdVozilo]);
GO

-- Creating foreign key on [KlijentIdKlijent] in table 'TerminPregledaSet'
ALTER TABLE [dbo].[TerminPregledaSet]
ADD CONSTRAINT [FK_TerminPregledaKlijent]
    FOREIGN KEY ([KlijentIdKlijent])
    REFERENCES [dbo].[KlijentSet]
        ([IdKlijent])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TerminPregledaKlijent'
CREATE INDEX [IX_FK_TerminPregledaKlijent]
ON [dbo].[TerminPregledaSet]
    ([KlijentIdKlijent]);
GO

-- Creating foreign key on [AdresaIdAdresa] in table 'DobavljacSet'
ALTER TABLE [dbo].[DobavljacSet]
ADD CONSTRAINT [FK_DobavljacAdresa]
    FOREIGN KEY ([AdresaIdAdresa])
    REFERENCES [dbo].[AdresaSet]
        ([IdAdresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DobavljacAdresa'
CREATE INDEX [IX_FK_DobavljacAdresa]
ON [dbo].[DobavljacSet]
    ([AdresaIdAdresa]);
GO

-- Creating foreign key on [DobavljacIdDobavljac] in table 'KatalogSet'
ALTER TABLE [dbo].[KatalogSet]
ADD CONSTRAINT [FK_DobavljacKatalog]
    FOREIGN KEY ([DobavljacIdDobavljac])
    REFERENCES [dbo].[DobavljacSet]
        ([IdDobavljac])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RezervniDioIdRezervniDio] in table 'KatalogSet'
ALTER TABLE [dbo].[KatalogSet]
ADD CONSTRAINT [FK_KatalogRezervniDio]
    FOREIGN KEY ([RezervniDioIdRezervniDio])
    REFERENCES [dbo].[RezervniDioSet]
        ([IdRezervniDio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KatalogRezervniDio'
CREATE INDEX [IX_FK_KatalogRezervniDio]
ON [dbo].[KatalogSet]
    ([RezervniDioIdRezervniDio]);
GO

-- Creating foreign key on [RezervniDioIdRezervniDio] in table 'StavkaNarudzbaSet'
ALTER TABLE [dbo].[StavkaNarudzbaSet]
ADD CONSTRAINT [FK_StavkaNarudzbaRezervniDio]
    FOREIGN KEY ([RezervniDioIdRezervniDio])
    REFERENCES [dbo].[RezervniDioSet]
        ([IdRezervniDio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StavkaNarudzbaRezervniDio'
CREATE INDEX [IX_FK_StavkaNarudzbaRezervniDio]
ON [dbo].[StavkaNarudzbaSet]
    ([RezervniDioIdRezervniDio]);
GO

-- Creating foreign key on [IdNarudzba] in table 'StavkaNarudzbaSet'
ALTER TABLE [dbo].[StavkaNarudzbaSet]
ADD CONSTRAINT [FK_StavkaNarudzbaNarudzba]
    FOREIGN KEY ([IdNarudzba])
    REFERENCES [dbo].[NarudzbaSet]
        ([IdNarudzba])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ZahtjevZaNarudzbomId] in table 'ZahtjevZaNarudzbomStavkaSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet]
ADD CONSTRAINT [FK_ZahtjevZaNarudzbomStavkaZahtjevZaNarudzbom]
    FOREIGN KEY ([ZahtjevZaNarudzbomId])
    REFERENCES [dbo].[ZahtjevZaNarudzbomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RezervniDioIdRezervniDio] in table 'ZahtjevZaNarudzbomStavkaSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomStavkaSet]
ADD CONSTRAINT [FK_ZahtjevZaNarudzbomStavkaRezervniDio]
    FOREIGN KEY ([RezervniDioIdRezervniDio])
    REFERENCES [dbo].[RezervniDioSet]
        ([IdRezervniDio])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZahtjevZaNarudzbomStavkaRezervniDio'
CREATE INDEX [IX_FK_ZahtjevZaNarudzbomStavkaRezervniDio]
ON [dbo].[ZahtjevZaNarudzbomStavkaSet]
    ([RezervniDioIdRezervniDio]);
GO

-- Creating foreign key on [RezervniDioIdRezervniDio1] in table 'UslugaSet_ZamijenaDijela'
ALTER TABLE [dbo].[UslugaSet_ZamijenaDijela]
ADD CONSTRAINT [FK_ZamijenaDijelaRezervniDio]
    FOREIGN KEY ([RezervniDioIdRezervniDio1])
    REFERENCES [dbo].[RezervniDioSet]
        ([IdRezervniDio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZamijenaDijelaRezervniDio'
CREATE INDEX [IX_FK_ZamijenaDijelaRezervniDio]
ON [dbo].[UslugaSet_ZamijenaDijela]
    ([RezervniDioIdRezervniDio1]);
GO

-- Creating foreign key on [RacunIdRacun] in table 'RacunStavkaSet'
ALTER TABLE [dbo].[RacunStavkaSet]
ADD CONSTRAINT [FK_RacunStavkaRacun]
    FOREIGN KEY ([RacunIdRacun])
    REFERENCES [dbo].[RacunSet]
        ([IdRacun])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UslugaIdUsluga] in table 'RacunStavkaSet'
ALTER TABLE [dbo].[RacunStavkaSet]
ADD CONSTRAINT [FK_RacunStavkaUsluga]
    FOREIGN KEY ([UslugaIdUsluga])
    REFERENCES [dbo].[UslugaSet]
        ([IdUsluga])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunStavkaUsluga'
CREATE INDEX [IX_FK_RacunStavkaUsluga]
ON [dbo].[RacunStavkaSet]
    ([UslugaIdUsluga]);
GO

-- Creating foreign key on [AdresaIdAdresa] in table 'KlijentSet'
ALTER TABLE [dbo].[KlijentSet]
ADD CONSTRAINT [FK_KlijentAdresa]
    FOREIGN KEY ([AdresaIdAdresa])
    REFERENCES [dbo].[AdresaSet]
        ([IdAdresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentAdresa'
CREATE INDEX [IX_FK_KlijentAdresa]
ON [dbo].[KlijentSet]
    ([AdresaIdAdresa]);
GO

-- Creating foreign key on [ZaposlenikIdZaposlenik] in table 'RacunSet'
ALTER TABLE [dbo].[RacunSet]
ADD CONSTRAINT [FK_RacunZaposlenik]
    FOREIGN KEY ([ZaposlenikIdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunZaposlenik'
CREATE INDEX [IX_FK_RacunZaposlenik]
ON [dbo].[RacunSet]
    ([ZaposlenikIdZaposlenik]);
GO

-- Creating foreign key on [ZaposlenikIdZaposlenik] in table 'ZahtjevZaNarudzbomSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomSet]
ADD CONSTRAINT [FK_ZahtjevZaNarudzbomZaposlenik]
    FOREIGN KEY ([ZaposlenikIdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZahtjevZaNarudzbomZaposlenik'
CREATE INDEX [IX_FK_ZahtjevZaNarudzbomZaposlenik]
ON [dbo].[ZahtjevZaNarudzbomSet]
    ([ZaposlenikIdZaposlenik]);
GO

-- Creating foreign key on [ZaposlenikIdZaposlenik] in table 'NarudzbaSet'
ALTER TABLE [dbo].[NarudzbaSet]
ADD CONSTRAINT [FK_NarudzbaZaposlenik]
    FOREIGN KEY ([ZaposlenikIdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NarudzbaZaposlenik'
CREATE INDEX [IX_FK_NarudzbaZaposlenik]
ON [dbo].[NarudzbaSet]
    ([ZaposlenikIdZaposlenik]);
GO

-- Creating foreign key on [ZaposlenikIdZaposlenik] in table 'ZaposlenikObradaSet'
ALTER TABLE [dbo].[ZaposlenikObradaSet]
ADD CONSTRAINT [FK_ZaposlenikObradaZaposlenik]
    FOREIGN KEY ([ZaposlenikIdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObradaVozilaIdObrada] in table 'ZaposlenikObradaSet'
ALTER TABLE [dbo].[ZaposlenikObradaSet]
ADD CONSTRAINT [FK_ZaposlenikObradaObradaVozila]
    FOREIGN KEY ([ObradaVozilaIdObrada])
    REFERENCES [dbo].[ObradaVozilaSet]
        ([IdObrada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZaposlenikObradaObradaVozila'
CREATE INDEX [IX_FK_ZaposlenikObradaObradaVozila]
ON [dbo].[ZaposlenikObradaSet]
    ([ObradaVozilaIdObrada]);
GO

-- Creating foreign key on [IdUsluga] in table 'UslugaSet_ZamijenaDijela'
ALTER TABLE [dbo].[UslugaSet_ZamijenaDijela]
ADD CONSTRAINT [FK_ZamijenaDijela_inherits_Usluga]
    FOREIGN KEY ([IdUsluga])
    REFERENCES [dbo].[UslugaSet]
        ([IdUsluga])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdUsluga] in table 'UslugaSet_Posao'
ALTER TABLE [dbo].[UslugaSet_Posao]
ADD CONSTRAINT [FK_Posao_inherits_Usluga]
    FOREIGN KEY ([IdUsluga])
    REFERENCES [dbo].[UslugaSet]
        ([IdUsluga])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------