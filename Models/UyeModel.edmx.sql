
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2022 01:07:37
-- Generated from EDMX file: C:\Users\90553\Desktop\esra\int_prog\FinalProject\Models\UyeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [finalproject];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Alt_Kategoriler_Kategoriler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alt_Kategoriler] DROP CONSTRAINT [FK_Alt_Kategoriler_Kategoriler];
GO
IF OBJECT_ID(N'[dbo].[FK_Kategoriler_Cihazlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kategoriler] DROP CONSTRAINT [FK_Kategoriler_Cihazlar];
GO
IF OBJECT_ID(N'[dbo].[FK_Urunler_Urunler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Urunler] DROP CONSTRAINT [FK_Urunler_Urunler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Uye_giris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uye_giris];
GO
IF OBJECT_ID(N'[dbo].[Alt_Kategoriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alt_Kategoriler];
GO
IF OBJECT_ID(N'[dbo].[Cihazlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cihazlar];
GO
IF OBJECT_ID(N'[dbo].[Kategoriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategoriler];
GO
IF OBJECT_ID(N'[dbo].[Urunler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Urunler];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Uye_giris'
CREATE TABLE [dbo].[Uye_giris] (
    [id] int  NOT NULL,
    [ad] nchar(50)  NULL,
    [soyad] nvarchar(50)  NULL,
    [mail] nvarchar(50)  NULL,
    [sifre] nvarchar(50)  NULL
);
GO

-- Creating table 'Alt_Kategoriler'
CREATE TABLE [dbo].[Alt_Kategoriler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [altKategori_ad] nvarchar(50)  NULL,
    [kategori_id] int  NULL
);
GO

-- Creating table 'Cihazlar'
CREATE TABLE [dbo].[Cihazlar] (
    [id] int IDENTITY(1,1) NOT NULL,
    [cihaz_ad] nvarchar(50)  NULL
);
GO

-- Creating table 'Kategoriler'
CREATE TABLE [dbo].[Kategoriler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [kategori_ad] nvarchar(50)  NULL,
    [cihaz_id] int  NULL
);
GO

-- Creating table 'Urunler'
CREATE TABLE [dbo].[Urunler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [urun_ad] nvarchar(50)  NULL,
    [altKategori_id] int  NULL,
    [urun_img] nvarchar(50)  NULL,
    [indirme_linki] nchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Uye_giris'
ALTER TABLE [dbo].[Uye_giris]
ADD CONSTRAINT [PK_Uye_giris]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Alt_Kategoriler'
ALTER TABLE [dbo].[Alt_Kategoriler]
ADD CONSTRAINT [PK_Alt_Kategoriler]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cihazlar'
ALTER TABLE [dbo].[Cihazlar]
ADD CONSTRAINT [PK_Cihazlar]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Kategoriler'
ALTER TABLE [dbo].[Kategoriler]
ADD CONSTRAINT [PK_Kategoriler]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Urunler'
ALTER TABLE [dbo].[Urunler]
ADD CONSTRAINT [PK_Urunler]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [kategori_id] in table 'Alt_Kategoriler'
ALTER TABLE [dbo].[Alt_Kategoriler]
ADD CONSTRAINT [FK_Alt_Kategoriler_Kategoriler]
    FOREIGN KEY ([kategori_id])
    REFERENCES [dbo].[Kategoriler]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Alt_Kategoriler_Kategoriler'
CREATE INDEX [IX_FK_Alt_Kategoriler_Kategoriler]
ON [dbo].[Alt_Kategoriler]
    ([kategori_id]);
GO

-- Creating foreign key on [cihaz_id] in table 'Kategoriler'
ALTER TABLE [dbo].[Kategoriler]
ADD CONSTRAINT [FK_Kategoriler_Cihazlar]
    FOREIGN KEY ([cihaz_id])
    REFERENCES [dbo].[Cihazlar]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kategoriler_Cihazlar'
CREATE INDEX [IX_FK_Kategoriler_Cihazlar]
ON [dbo].[Kategoriler]
    ([cihaz_id]);
GO

-- Creating foreign key on [altKategori_id] in table 'Urunler'
ALTER TABLE [dbo].[Urunler]
ADD CONSTRAINT [FK_Urunler_Urunler]
    FOREIGN KEY ([altKategori_id])
    REFERENCES [dbo].[Alt_Kategoriler]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Urunler_Urunler'
CREATE INDEX [IX_FK_Urunler_Urunler]
ON [dbo].[Urunler]
    ([altKategori_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------