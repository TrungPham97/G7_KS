
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/02/2018 15:14:28
-- Generated from EDMX file: D:\QLKhachSan\QLKhachSan\Models\NOBLESSE.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NOBLESSE.Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Customer_CustomerType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_Customer_CustomerType];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomReservationDetail_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetail_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_RoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_Room_RoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_RoomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Room_RoomType];
GO
IF OBJECT_ID(N'[dbo].[FK_BillRoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_BillRoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomReservationDetailRoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservationDetails] DROP CONSTRAINT [FK_RoomReservationDetailRoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_BillCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_BillCustomer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bills];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[CustomerTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerTypes];
GO
IF OBJECT_ID(N'[dbo].[RoomReservationDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReservationDetails];
GO
IF OBJECT_ID(N'[dbo].[RoomReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReservations];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RoomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [CMND] nvarchar(max)  NULL,
    [Add] nvarchar(max)  NULL,
    [CustomerTypeId] int  NOT NULL
);
GO

-- Creating table 'CustomerTypes'
CREATE TABLE [dbo].[CustomerTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RoomReservationDetails'
CREATE TABLE [dbo].[RoomReservationDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [RoomReservationId] int  NOT NULL
);
GO

-- Creating table 'RoomReservations'
CREATE TABLE [dbo].[RoomReservations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateEnded] datetime  NULL,
    [RoomId] int  NOT NULL,
    [BillId] int  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [IsExist] bit  NULL,
    [RoomType_Id] int  NOT NULL
);
GO

-- Creating table 'RoomTypes'
CREATE TABLE [dbo].[RoomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerTypes'
ALTER TABLE [dbo].[CustomerTypes]
ADD CONSTRAINT [PK_CustomerTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomReservationDetails'
ALTER TABLE [dbo].[RoomReservationDetails]
ADD CONSTRAINT [PK_RoomReservationDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [PK_RoomReservations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomTypes'
ALTER TABLE [dbo].[RoomTypes]
ADD CONSTRAINT [PK_RoomTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerTypeId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_Customer_CustomerType]
    FOREIGN KEY ([CustomerTypeId])
    REFERENCES [dbo].[CustomerTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer_CustomerType'
CREATE INDEX [IX_FK_Customer_CustomerType]
ON [dbo].[Customers]
    ([CustomerTypeId]);
GO

-- Creating foreign key on [CustomerId] in table 'RoomReservationDetails'
ALTER TABLE [dbo].[RoomReservationDetails]
ADD CONSTRAINT [FK_RoomReservationDetail_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomReservationDetail_Customer'
CREATE INDEX [IX_FK_RoomReservationDetail_Customer]
ON [dbo].[RoomReservationDetails]
    ([CustomerId]);
GO

-- Creating foreign key on [RoomId] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_Room_RoomReservation]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_RoomReservation'
CREATE INDEX [IX_FK_Room_RoomReservation]
ON [dbo].[RoomReservations]
    ([RoomId]);
GO

-- Creating foreign key on [RoomType_Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Room_RoomType]
    FOREIGN KEY ([RoomType_Id])
    REFERENCES [dbo].[RoomTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_RoomType'
CREATE INDEX [IX_FK_Room_RoomType]
ON [dbo].[Rooms]
    ([RoomType_Id]);
GO

-- Creating foreign key on [BillId] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_BillRoomReservation]
    FOREIGN KEY ([BillId])
    REFERENCES [dbo].[Bills]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillRoomReservation'
CREATE INDEX [IX_FK_BillRoomReservation]
ON [dbo].[RoomReservations]
    ([BillId]);
GO

-- Creating foreign key on [RoomReservationId] in table 'RoomReservationDetails'
ALTER TABLE [dbo].[RoomReservationDetails]
ADD CONSTRAINT [FK_RoomReservationDetailRoomReservation]
    FOREIGN KEY ([RoomReservationId])
    REFERENCES [dbo].[RoomReservations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomReservationDetailRoomReservation'
CREATE INDEX [IX_FK_RoomReservationDetailRoomReservation]
ON [dbo].[RoomReservationDetails]
    ([RoomReservationId]);
GO

-- Creating foreign key on [CustomerId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_BillCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillCustomer'
CREATE INDEX [IX_FK_BillCustomer]
ON [dbo].[Bills]
    ([CustomerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------