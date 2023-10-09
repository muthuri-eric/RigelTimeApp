CREATE TABLE [dbo].[Template] (
    [TemplateId] INT            NOT NULL IDENTITY,
    [EmployeeId] INT            NOT NULL,
    [FID]        INT            NOT NULL,
    [Size]       INT            NULL,
    [Valid]      INT            NULL,
    [Template]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED ([EmployeeId], [FID] ASC)
);

