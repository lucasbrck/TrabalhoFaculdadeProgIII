IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [ClienteModelId] bigint NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Endereco] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Cpf] nvarchar(max) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([ClienteModelId])
);
GO

CREATE TABLE [Produtos] (
    [ProdutoModelId] bigint NOT NULL IDENTITY,
    [Codigo] int NOT NULL,
    [Nome] nvarchar(max) NULL,
    [PrecoUnit] decimal(18,2) NOT NULL,
    [Quantidade] int NOT NULL,
    [PrecoTotal] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([ProdutoModelId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201130223802_ControleVendas', N'5.0.0');
GO

COMMIT;
GO

