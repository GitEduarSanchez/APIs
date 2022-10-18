CREATE DATABASE tiendaProducto;
USE tiendaProducto;

CREATE TABLE [dbo].[categoria]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [categoria] VARCHAR(50) NOT NULL
);

INSERT INTO [dbo].[categoria] ( [categoria]) VALUES ('software');
INSERT INTO [dbo].[categoria] ( [categoria]) VALUES ( 'hardware');

CREATE TABLE [dbo].[producto] (
    [Id]          INT         IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR(50)  NOT NULL,
    [descripcion] VARCHAR(100) NULL,
    [categoriaid] INT         NOT NULL,
    [img]         VARCHAR(200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_producto_categoria] FOREIGN KEY ([categoriaid]) REFERENCES [dbo].[categoria] ([Id])
);

SET IDENTITY_INSERT [dbo].[producto] ON
INSERT INTO [dbo].[producto] ([Id], [nombre], [descripcion], [categoriaid], [img]) VALUES (1, N'api key', N'api key google', 1, N'img.jpg')
INSERT INTO [dbo].[producto] ([Id], [nombre], [descripcion], [categoriaid], [img]) VALUES (2, N'portatil', N'mac', 2, N'img.jpg')
SET IDENTITY_INSERT [dbo].[producto] OFF
