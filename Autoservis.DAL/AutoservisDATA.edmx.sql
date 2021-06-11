
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/20/2019 00:57:52
-- Generated from EDMX file: C:\Users\matija\source\repos\Autoservis\Autoservis.DAL\AutoservisDATA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [KlijentIdKlijent] int  NOT NULL
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
    [MehanicarIdMehanicar] int  NOT NULL,
    [ObradaVozila_IdObrada] int  NOT NULL
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
    [DatumNarudzbe] datetime  NOT NULL
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
    [Datum] datetime  NOT NULL
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

-- Creating table 'ZaposlenikSet_Mehanicar'
CREATE TABLE [dbo].[ZaposlenikSet_Mehanicar] (
    [Opis] nvarchar(max)  NOT NULL,
    [IdZaposlenik] int  NOT NULL
);
GO

-- Creating table 'ZaposlenikSet_Voditelj'
CREATE TABLE [dbo].[ZaposlenikSet_Voditelj] (
    [Opis] nvarchar(max)  NOT NULL,
    [IdZaposlenik] int  NOT NULL
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

-- Creating table 'ObradaVozilaMehanicar'
CREATE TABLE [dbo].[ObradaVozilaMehanicar] (
    [ObradaVozilaMehanicar_Mehanicar_IdObrada] int  NOT NULL,
    [Mehanicari_IdZaposlenik] int  NOT NULL
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

-- Creating primary key on [VoziloIdVozilo], [KlijentIdKlijent] in table 'TerminPregledaSet'
ALTER TABLE [dbo].[TerminPregledaSet]
ADD CONSTRAINT [PK_TerminPregledaSet]
    PRIMARY KEY CLUSTERED ([VoziloIdVozilo], [KlijentIdKlijent] ASC);
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

-- Creating primary key on [IdZaposlenik] in table 'ZaposlenikSet_Mehanicar'
ALTER TABLE [dbo].[ZaposlenikSet_Mehanicar]
ADD CONSTRAINT [PK_ZaposlenikSet_Mehanicar]
    PRIMARY KEY CLUSTERED ([IdZaposlenik] ASC);
GO

-- Creating primary key on [IdZaposlenik] in table 'ZaposlenikSet_Voditelj'
ALTER TABLE [dbo].[ZaposlenikSet_Voditelj]
ADD CONSTRAINT [PK_ZaposlenikSet_Voditelj]
    PRIMARY KEY CLUSTERED ([IdZaposlenik] ASC);
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

-- Creating primary key on [ObradaVozilaMehanicar_Mehanicar_IdObrada], [Mehanicari_IdZaposlenik] in table 'ObradaVozilaMehanicar'
ALTER TABLE [dbo].[ObradaVozilaMehanicar]
ADD CONSTRAINT [PK_ObradaVozilaMehanicar]
    PRIMARY KEY CLUSTERED ([ObradaVozilaMehanicar_Mehanicar_IdObrada], [Mehanicari_IdZaposlenik] ASC);
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

-- Creating foreign key on [ObradaVozilaMehanicar_Mehanicar_IdObrada] in table 'ObradaVozilaMehanicar'
ALTER TABLE [dbo].[ObradaVozilaMehanicar]
ADD CONSTRAINT [FK_ObradaVozilaMehanicar_ObradaVozila]
    FOREIGN KEY ([ObradaVozilaMehanicar_Mehanicar_IdObrada])
    REFERENCES [dbo].[ObradaVozilaSet]
        ([IdObrada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Mehanicari_IdZaposlenik] in table 'ObradaVozilaMehanicar'
ALTER TABLE [dbo].[ObradaVozilaMehanicar]
ADD CONSTRAINT [FK_ObradaVozilaMehanicar_Mehanicar]
    FOREIGN KEY ([Mehanicari_IdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet_Mehanicar]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObradaVozilaMehanicar_Mehanicar'
CREATE INDEX [IX_FK_ObradaVozilaMehanicar_Mehanicar]
ON [dbo].[ObradaVozilaMehanicar]
    ([Mehanicari_IdZaposlenik]);
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
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating foreign key on [MehanicarIdMehanicar] in table 'RacunSet'
ALTER TABLE [dbo].[RacunSet]
ADD CONSTRAINT [FK_RacunMehanicar]
    FOREIGN KEY ([MehanicarIdMehanicar])
    REFERENCES [dbo].[ZaposlenikSet_Mehanicar]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunMehanicar'
CREATE INDEX [IX_FK_RacunMehanicar]
ON [dbo].[RacunSet]
    ([MehanicarIdMehanicar]);
GO

-- Creating foreign key on [ObradaVozila_IdObrada] in table 'RacunSet'
ALTER TABLE [dbo].[RacunSet]
ADD CONSTRAINT [FK_RacunObradaVozila]
    FOREIGN KEY ([ObradaVozila_IdObrada])
    REFERENCES [dbo].[ObradaVozilaSet]
        ([IdObrada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunObradaVozila'
CREATE INDEX [IX_FK_RacunObradaVozila]
ON [dbo].[RacunSet]
    ([ObradaVozila_IdObrada]);
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

-- Creating foreign key on [VoditeljIdVoditelj] in table 'NarudzbaSet'
ALTER TABLE [dbo].[NarudzbaSet]
ADD CONSTRAINT [FK_NarudzbaVoditelj]
    FOREIGN KEY ([VoditeljIdVoditelj])
    REFERENCES [dbo].[ZaposlenikSet_Voditelj]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NarudzbaVoditelj'
CREATE INDEX [IX_FK_NarudzbaVoditelj]
ON [dbo].[NarudzbaSet]
    ([VoditeljIdVoditelj]);
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

-- Creating foreign key on [MehanicarIdMehanicar] in table 'ZahtjevZaNarudzbomSet'
ALTER TABLE [dbo].[ZahtjevZaNarudzbomSet]
ADD CONSTRAINT [FK_ZahtjevZaNarudzbomMehanicar]
    FOREIGN KEY ([MehanicarIdMehanicar])
    REFERENCES [dbo].[ZaposlenikSet_Mehanicar]
        ([IdZaposlenik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZahtjevZaNarudzbomMehanicar'
CREATE INDEX [IX_FK_ZahtjevZaNarudzbomMehanicar]
ON [dbo].[ZahtjevZaNarudzbomSet]
    ([MehanicarIdMehanicar]);
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
    ON DELETE NO ACTION ON UPDATE NO ACTION;
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

-- Creating foreign key on [IdZaposlenik] in table 'ZaposlenikSet_Mehanicar'
ALTER TABLE [dbo].[ZaposlenikSet_Mehanicar]
ADD CONSTRAINT [FK_Mehanicar_inherits_Zaposlenik]
    FOREIGN KEY ([IdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdZaposlenik] in table 'ZaposlenikSet_Voditelj'
ALTER TABLE [dbo].[ZaposlenikSet_Voditelj]
ADD CONSTRAINT [FK_Voditelj_inherits_Zaposlenik]
    FOREIGN KEY ([IdZaposlenik])
    REFERENCES [dbo].[ZaposlenikSet]
        ([IdZaposlenik])
    ON DELETE CASCADE ON UPDATE NO ACTION;
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