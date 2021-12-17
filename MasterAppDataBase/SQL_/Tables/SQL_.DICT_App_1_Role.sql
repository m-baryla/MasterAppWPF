CREATE TABLE [SQL_].[DICT_App_1_Role] (
    [ApplicationRole]     VARCHAR (50)   NOT NULL,
    [BusinessDescription] NVARCHAR (200) NULL,
    [Comment]             NVARCHAR (200) NULL,
    [DictStatus]          INT            NOT NULL,
    [SortOrder]           INT            NOT NULL,
    CONSTRAINT [PK_ALCLOG_ApplicationRole] PRIMARY KEY CLUSTERED ([ApplicationRole] ASC),
    CONSTRAINT [FK_DICT_App_1_Role_DictStatus] FOREIGN KEY ([DictStatus]) REFERENCES [SQL_].[DictStatus] ([DictStatus])
);

