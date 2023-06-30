CREATE TABLE [dbo].[CustomItems] (
    [Id]            INT  NOT NULL,
    [Name]          TEXT NULL,
    [Price]         TEXT NOT NULL,
    [Selected]      INT  NOT NULL,
    [BeginQuantity] INT  NOT NULL,
    [Markup]        TEXT NOT NULL,
    [PurchasePrice] TEXT NOT NULL,
    [Step]          INT  NOT NULL,
    [AccountId]     INT  NOT NULL,
    [Quantity]      INT  DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CustomItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomItems_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([Id]) ON DELETE CASCADE
);


GO

CREATE NONCLUSTERED INDEX [IX_CustomItems_AccountId]
    ON [dbo].[CustomItems]([AccountId] ASC);


GO

