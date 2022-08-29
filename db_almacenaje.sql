/*
Script de implementación para db_blank

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "db_blank"
:setvar DefaultFilePrefix "db_blank"
:setvar DefaultDataPath "C:\Users\Usuario\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Usuario\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creando Tabla [dbo].[__EFMigrationsHistory]...';


GO
CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Articulo_custodia]...';


GO
CREATE TABLE [dbo].[Articulo_custodia] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Codigo_cliente]       INT            NOT NULL,
    [Codigo_transportista] INT            NOT NULL,
    [TrackingID]           NVARCHAR (18)  NOT NULL,
    [Descripcion]          NVARCHAR (100) NOT NULL,
    [Peso]                 REAL           NOT NULL,
    [Precio_articulo]      REAL           NOT NULL,
    [Fecha_ingreso]        DATETIME2 (7)  NOT NULL,
    [Estado]               NVARCHAR (MAX) NOT NULL,
    [Fecha_retiro]         DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Articulo_custodia] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Articulo_retirado]...';


GO
CREATE TABLE [dbo].[Articulo_retirado] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Codigo_cliente]       INT            NOT NULL,
    [Codigo_transportista] INT            NOT NULL,
    [TrackingID]           NVARCHAR (18)  NOT NULL,
    [Descripcion]          NVARCHAR (100) NOT NULL,
    [Estado]               NVARCHAR (MAX) NOT NULL,
    [Fecha_retiro]         DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Articulo_retirado] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Cliente]...';


GO
CREATE TABLE [dbo].[Cliente] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [Codigo_cliente]        INT           NOT NULL,
    [Nombre_completo]       NVARCHAR (30) NOT NULL,
    [Numero_identificacion] NVARCHAR (9)  NOT NULL,
    [Fecha_nacimiento]      DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Tabla [dbo].[Transportista]...';


GO
CREATE TABLE [dbo].[Transportista] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Codigo_transportista] INT           NOT NULL,
    [Nombre_empresa]       NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Transportista] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando Secuencia [dbo].[Codigo_cliente]...';


GO
CREATE SEQUENCE [dbo].[Codigo_cliente]
    AS INT
    START WITH 1000
    INCREMENT BY 1;


GO
SELECT  NEXT VALUE FOR [dbo].[Codigo_cliente];

ALTER SEQUENCE [dbo].[Codigo_cliente]
    INCREMENT BY 2;

SELECT  NEXT VALUE FOR [dbo].[Codigo_cliente];

ALTER SEQUENCE [dbo].[Codigo_cliente]
    INCREMENT BY 1;


GO
PRINT N'Creando Secuencia [dbo].[Codigo_transportista]...';


GO
CREATE SEQUENCE [dbo].[Codigo_transportista]
    AS INT
    START WITH 100
    INCREMENT BY 1;


GO
SELECT  NEXT VALUE FOR [dbo].[Codigo_transportista];

ALTER SEQUENCE [dbo].[Codigo_transportista]
    INCREMENT BY 2;

SELECT  NEXT VALUE FOR [dbo].[Codigo_transportista];

ALTER SEQUENCE [dbo].[Codigo_transportista]
    INCREMENT BY 1;


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Cliente]...';


GO
ALTER TABLE [dbo].[Cliente]
    ADD DEFAULT (NEXT VALUE FOR [Codigo_cliente]) FOR [Codigo_cliente];


GO
PRINT N'Creando Restricción DEFAULT restricción sin nombre en [dbo].[Transportista]...';


GO
ALTER TABLE [dbo].[Transportista]
    ADD DEFAULT (NEXT VALUE FOR [Codigo_transportista]) FOR [Codigo_transportista];


GO
PRINT N'Actualización completada.';


GO
