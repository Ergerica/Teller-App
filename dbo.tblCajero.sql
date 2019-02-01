CREATE TABLE [dbo].[tblCajero] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]   VARCHAR (50) NULL,
    [Apellido] VARCHAR (50) NULL,
    [Usuario]  VARCHAR (50) NULL,
    [Password] VARCHAR (50) NULL,
    [Tipo]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

