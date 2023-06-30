CREATE TABLE [dbo].[UserStandartItems] (
    [Id]             INT  NOT NULL,
    [StandartItemId] INT  NOT NULL,
    [Selected]       INT  NOT NULL,
    [BeginQuantity]  INT  NOT NULL,
    [Markup]         TEXT NOT NULL,
    [PurchasePrice]  TEXT NOT NULL,
    [Step]           INT  NOT NULL,
    [AccountId]      INT  NOT NULL,
    [Quantity]       INT  DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserStandartItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserStandartItems_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserStandartItems_StandartItems_StandartItemId] FOREIGN KEY ([StandartItemId]) REFERENCES [dbo].[StandartItems] ([Id]) ON DELETE CASCADE
);


GO

CREATE NONCLUSTERED INDEX [IX_UserStandartItems_AccountId]
    ON [dbo].[UserStandartItems]([AccountId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_UserStandartItems_StandartItemId]
    ON [dbo].[UserStandartItems]([StandartItemId] ASC);


GO

