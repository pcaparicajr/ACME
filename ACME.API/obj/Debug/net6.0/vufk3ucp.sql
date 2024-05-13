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

CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [NomeCliente] varchar(60) NOT NULL,
    [EmailCliente] varchar(60) NOT NULL,
    [DataCriacao] datetimeoffset NULL,
    [Pago] bit NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [NomeProduto] varchar(20) NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ItensPedidos] (
    [Id] int NOT NULL IDENTITY,
    [IdPedido] int NOT NULL,
    [IdProduto] int NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_ItensPedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItensPedidos_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItensPedidos_Produtos_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'EmailCliente', N'NomeCliente', N'Pago') AND [object_id] = OBJECT_ID(N'[Pedidos]'))
    SET IDENTITY_INSERT [Pedidos] ON;
INSERT INTO [Pedidos] ([Id], [DataCriacao], [EmailCliente], [NomeCliente], [Pago])
VALUES (1, '2024-05-13T00:00:00.0000000-03:00', 'Maria@gmail.com', 'Maria', CAST(1 AS bit)),
(2, '2024-05-13T00:00:00.0000000-03:00', 'Josegmail.com', 'Jose', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'EmailCliente', N'NomeCliente', N'Pago') AND [object_id] = OBJECT_ID(N'[Pedidos]'))
    SET IDENTITY_INSERT [Pedidos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NomeProduto', N'Valor') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] ON;
INSERT INTO [Produtos] ([Id], [NomeProduto], [Valor])
VALUES (1, 'Martelo', 10.0),
(2, 'Serrote', 20.0),
(3, 'Prego', 3.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NomeProduto', N'Valor') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdPedido', N'IdProduto', N'Quantidade') AND [object_id] = OBJECT_ID(N'[ItensPedidos]'))
    SET IDENTITY_INSERT [ItensPedidos] ON;
INSERT INTO [ItensPedidos] ([Id], [IdPedido], [IdProduto], [Quantidade])
VALUES (1, 1, 1, 5),
(2, 1, 2, 7),
(3, 2, 2, 2),
(4, 2, 3, 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IdPedido', N'IdProduto', N'Quantidade') AND [object_id] = OBJECT_ID(N'[ItensPedidos]'))
    SET IDENTITY_INSERT [ItensPedidos] OFF;
GO

CREATE INDEX [IX_ItensPedidos_IdPedido] ON [ItensPedidos] ([IdPedido]);
GO

CREATE INDEX [IX_ItensPedidos_IdProduto] ON [ItensPedidos] ([IdProduto]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240513040359_ACME', N'6.0.29');
GO

COMMIT;
GO

