CREATE TABLE [SQL_].[UserPermission_App_1] (
    [UserPermissionKey] INT            NOT NULL,
    [DomainGroup]       VARCHAR (200)  NOT NULL,
    [ApplicationRole]   VARCHAR (50)   NOT NULL,
    [SQLRole]           VARCHAR (50)   NULL,
    [Comment]           NVARCHAR (200) NULL,
    [DictStatus]        INT            NOT NULL,
    CONSTRAINT [PK_ALCLOG_UserPermission] PRIMARY KEY CLUSTERED ([UserPermissionKey] ASC),
    CONSTRAINT [FK_UserPermission_DICT_App_1_Role] FOREIGN KEY ([ApplicationRole]) REFERENCES [SQL_].[DICT_App_1_Role] ([ApplicationRole]),
    CONSTRAINT [FK_UserPermission_DictStatus] FOREIGN KEY ([DictStatus]) REFERENCES [SQL_].[DictStatus] ([DictStatus])
);

