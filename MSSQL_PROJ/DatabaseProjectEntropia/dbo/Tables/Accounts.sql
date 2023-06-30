CREATE TABLE [dbo].[Accounts] (
    [Id]                INT  NOT NULL,
    [Email]             TEXT NULL,
    [PasswordHash]      TEXT NULL,
    [AcceptTerms]       INT  NOT NULL,
    [Role]              INT  NOT NULL,
    [VerificationToken] TEXT NULL,
    [Verified]          TEXT NULL,
    [ResetToken]        TEXT NULL,
    [ResetTokenExpires] TEXT NULL,
    [PasswordReset]     TEXT NULL,
    [Created]           TEXT NOT NULL,
    [Updated]           TEXT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

