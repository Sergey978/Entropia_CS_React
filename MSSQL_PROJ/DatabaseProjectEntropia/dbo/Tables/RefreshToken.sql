CREATE TABLE [dbo].[RefreshToken] (
    [Id]              INT  NOT NULL,
    [AccountId]       INT  NOT NULL,
    [Token]           TEXT NULL,
    [Expires]         TEXT NOT NULL,
    [Created]         TEXT NOT NULL,
    [CreatedByIp]     TEXT NULL,
    [Revoked]         TEXT NULL,
    [RevokedByIp]     TEXT NULL,
    [ReplacedByToken] TEXT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RefreshToken_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([Id]) ON DELETE CASCADE
);


GO

CREATE NONCLUSTERED INDEX [IX_RefreshToken_AccountId]
    ON [dbo].[RefreshToken]([AccountId] ASC);


GO

