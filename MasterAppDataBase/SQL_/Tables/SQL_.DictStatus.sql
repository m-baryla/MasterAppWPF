CREATE TABLE [SQL_].[DictStatus] (
    [DictStatus]          INT            IDENTITY (1, 1) NOT NULL,
    [BusinessDescription] NVARCHAR (200) NULL,
    [Comment]             NVARCHAR (200) NULL,
    CONSTRAINT [PK_DictStatus] PRIMARY KEY CLUSTERED ([DictStatus] ASC),
    CONSTRAINT [FK_DictStatus_DictStatus] FOREIGN KEY ([DictStatus]) REFERENCES [SQL_].[DictStatus] ([DictStatus])
);

